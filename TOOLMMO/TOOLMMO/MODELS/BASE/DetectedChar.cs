using OpenCvSharp;
using OpenQA.Selenium.DevTools.V137.DOM;
using System.Drawing;
namespace TOOLMMO.MODELS.BASE
{
    public class DetectedChar
    {
        public char Character { get; set; }
        public Rect BoundingBox { get; set; }
        public Point Center { get; set; }
    }
}
