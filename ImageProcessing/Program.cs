using System;
using System.Drawing;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;

namespace ImageProcessing
{
    internal static class Program
    {
        private static void ChangeBitmap(Image image, Color color, string filePath)
        {
            using var imageFactory = new ImageFactory();
            imageFactory.Load(image).Format(new JpegFormat {Quality = 90}).BackgroundColor(color).Save(filePath);
        }

        public static void Main()
        {
            var stringArray = new[,]
            {
                {"d13be0da-b7c1-4a50-b720-d27c72da6bb8", "#ffffff"}
            };
            for (var index = 0; index < stringArray.GetLength(0); index++)
            {
                var color = ColorTranslator.FromHtml(stringArray[index, 1]);
                using (var image =
                    Image.FromFile("/Users/javier/Projects/ImageProcessing/ImageProcessing/biometal.png"))
                {
                    ChangeBitmap(image, color,
                        string.Concat("/Users/javier/Desktop/Productos/", stringArray[index, 0], ".jpg"));
                }
                // using (var image =
                //     Image.FromFile("/Users/javier/Projects/ImageProcessing/ImageProcessing/mockup-3.png"))
                // {
                //     ChangeBitmap(image, color,
                //         string.Concat("/Users/javier/Desktop/Productos/", stringArray[index, 0], "-3.jpg"));
                // }
                //using (var image = Image.FromFile("/Users/javier/Projects/ImageProcessing/ImageProcessing/mockup-4.png"))
                //{

                //    ChangeBitmap(image, color, string.Concat("/Users/javier/Desktop/Productos/", stringArray[i, 0], "-4.jpg"));
                //}
                Console.WriteLine(index);
            }
        }
    }
}