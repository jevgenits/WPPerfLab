using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPPerfLab.Common.Utils
{
    public static class ImageUtils
    {
        private static Random rand = new Random();

        private static List<string> ImagePaths = new List<string>() {
            "/Assets/Images/random_image_blue.jpg",
            "/Assets/Images/random_image_green.jpg",
            "/Assets/Images/random_image_orange.jpg",
            "/Assets/Images/random_image_red.jpg",
        };

        public static string GetRandomImagePath()
        {
            return ImagePaths[rand.Next(0, ImagePaths.Count - 1)];
        }
    }
}
