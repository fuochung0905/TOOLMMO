using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using TOOLMMO.MODELS.ENITIES;
using TOOLMMO.SERVICE;
using TOOLMMO.VIEWMODELS;
using TOOLMMO.VIEWS;

namespace TOOLMMO
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Server=.;Database=TOOLMMO;Trusted_Connection=True;TrustServerCertificate=True"));
            services.AddTransient<ConfigSystemViewModel>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();
            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
