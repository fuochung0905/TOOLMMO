using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Reflection;
using System.Windows;
using System.IO.Compression;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V137.Network; 
using static System.Collections.Specialized.BitVector32;
using System.Security.Policy;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Diagnostics;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Tesseract;
using System.Runtime.InteropServices;
using OpenCvSharp.CPlusPlus;
using TOOLMMO.MODELS.BASE;
namespace TOOLMMO.SERVICES.BASES
{
    public class BASEService : IBASEService
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private string ReportPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Setting");
        private HttpMessageHandler handler;
        private string AccountFile => Path.Combine(ReportPath, "Account.txt");
        private string ProxyFile => Path.Combine(ReportPath, "Proxy.txt");

        public async Task MoChromeAnDanh(string url, string proxyString, string username, string password)
        {
            string[] parts = proxyString.Split(':');
            if (parts.Length != 4)
            {
                MessageBox.Show("Proxy sai định dạng (ip:port:user:pass): " + proxyString);
                return;
            }

            string ip = parts[0], port = parts[1], user = parts[2], pass = parts[3];

            try
            {
                var service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;

                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--incognito");
                options.AddArgument("--start-maximized");
                options.AddArgument("--disable-blink-features=AutomationControlled");
                options.AddArgument("--disable-notifications");
                options.AddArgument("--disable-popup-blocking");

                string extPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ext", "proxyAuth-1.1.0-chrome");
                options.AddArguments($"--load-extension={extPath}");
                options.AddArgument("--disable-features=DisableLoadExtensionCommandLineSwitch");
                try
                {
                    var driver = new ChromeDriver(service, options);

                    driver.Navigate().GoToUrl("about:blank?proxy=" + proxyString);
                    await Task.Delay(3000); // Đợi extension thiết lập proxy

                    driver.Navigate().GoToUrl(url);
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                    Thread.Sleep(3000);
                    try
                    {
                        var loginOptionBtn = wait.Until(d => d.FindElement(By.XPath(
                             "//button[contains(@class, 'TUXButton') and contains(@class, 'TUXButton--primary') and contains(@class, 'StyledLeftSidePrimaryButtonRedesign')]"
                         ))); loginOptionBtn.Click();
                        Thread.Sleep(1000);
                    }
                    catch { }

                    try
                    {
                        var emailTab = wait.Until(d => d.FindElement(By.XPath("//div[@role='link' and .//div[text()='Use phone / email / username']]")));
                        emailTab.Click();
                        Thread.Sleep(3000);
                    }
                    catch { }
                    try
                    {
                        var loginWithEmailLink = wait.Until(d => d.FindElement(By.XPath("//a[text()='Log in with email or username']")));
                        loginWithEmailLink.Click();
                        Thread.Sleep(3000);
                    }
                    catch { }
                    var usernameInput = wait.Until(d => d.FindElement(By.Name("username")));
                    usernameInput.Clear();
                    usernameInput.SendKeys(username);
                    Thread.Sleep(3000);
                    var passwordInput = wait.Until(d => d.FindElement(By.XPath("//input[@type='password' and @placeholder='Password']")));
                    passwordInput.Clear();
                    passwordInput.SendKeys(password);
                    Thread.Sleep(3000);
                    try
                    {
                        var loginButton = wait.Until(d => d.FindElement(By.XPath("//button[@data-e2e='login-button']")));
                        loginButton.Click();

                        await Task.Delay(8000); 

                        bool coCaptcha = driver.PageSource.Contains("verify") || driver.Url.Contains("captcha") || driver.Url.Contains("challenge");
                        if (coCaptcha)
                        {
                            Tiktok3DSelectObjectWebTask();
                        }
                    }
                    catch (Exception ex)
                    {
                        driver.GetScreenshot().SaveAsFile("error_login.png");
                        MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message);

                    }
                    await Task.Delay(8000); 

                }
                catch (Exception ext)
                {
                    MessageBox.Show("Lỗi mở Chrome/Login: " + ext.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở Chrome/Login: " + ex.Message);
            }
        }

        private void Tiktok3DSelectObjectWebTask()
        {
            string tesseractDataPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"tessdata");
            string url = "https://www.tiktok.com"; 

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(url);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(drv =>
            {
                var img = drv.FindElement(By.CssSelector("img.cap-rounded-lg.cap-cursor-pointer.cap-w-full.cap-h-auto"));
                return ((IJavaScriptExecutor)drv).ExecuteScript("return arguments[0].complete && arguments[0].naturalWidth > 0", img).Equals(true);
            });
            Console.WriteLine("Captcha image fully loaded");
            var captchaElement = driver.FindElement(By.CssSelector("img.cap-rounded-lg.cap-cursor-pointer.cap-w-full.cap-h-auto"));

            wait.Until(drv => ((IJavaScriptExecutor)drv).ExecuteScript("return arguments[0].complete && arguments[0].naturalWidth > 0", captchaElement).Equals(true));

            string base64Image = (string)((IJavaScriptExecutor)driver).ExecuteScript(@"
        var img = arguments[0];
        var canvas = document.createElement('canvas');
        canvas.width = img.naturalWidth;
        canvas.height = img.naturalHeight;
        var ctx = canvas.getContext('2d');
        ctx.drawImage(img, 0, 0);
        return canvas.toDataURL('image/png').substring(22);
    ", captchaElement);

            byte[] imageBytes = Convert.FromBase64String(base64Image);
            string captchaPath = "captcha_blob.png";
            File.WriteAllBytes(captchaPath, imageBytes);

            Console.WriteLine("Đã lưu ảnh CAPTCHA blob thành captcha_blob.png");
        }
    }
}
