using System;
using System.Drawing;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;

namespace ImageProcessing
{
    internal static class Program
    {
        private static void SaveImageWithBackgroundColor(Image sourceImage, Color backgroundColor, string outputFilePath)
        {
            using var imageFactory = new ImageFactory();
            imageFactory.Load(sourceImage).Format(new JpegFormat {Quality = 90}).BackgroundColor(backgroundColor).Save(outputFilePath);
        }

        public static void Main()
        {
            var productConfigurations = new[,]
            {
                {"d13be0da-b7c1-4a50-b720-d27c72da6bb8", "#ffffff"}
            };
            for (var productIndex = 0; productIndex < productConfigurations.GetLength(0); productIndex++)
            {
                var backgroundColor = ColorTranslator.FromHtml(productConfigurations[productIndex, 1]);
                using (var sourceImage =
                    Image.FromFile("/Users/javier/Projects/ImageProcessing/ImageProcessing/biometal.png"))
                {
                    SaveImageWithBackgroundColor(sourceImage, backgroundColor,
                        string.Concat("/Users/javier/Desktop/Productos/", productConfigurations[productIndex, 0], ".jpg"));
                }
                // using (var sourceImage =
                //     Image.FromFile("/Users/javier/Projects/ImageProcessing/ImageProcessing/mockup-3.png"))
                // {
                //     SaveImageWithBackgroundColor(sourceImage, backgroundColor,
                //         string.Concat("/Users/javier/Desktop/Productos/", productConfigurations[productIndex, 0], "-3.jpg"));
                // }
                //using (var sourceImage = Image.FromFile("/Users/javier/Projects/ImageProcessing/ImageProcessing/mockup-4.png"))
                //{

                //    SaveImageWithBackgroundColor(sourceImage, backgroundColor, string.Concat("/Users/javier/Desktop/Productos/", productConfigurations[productIndex, 0], "-4.jpg"));
                //}
                Console.WriteLine(productIndex);
            }
        }
    }
}