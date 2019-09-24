using ImageEditor;
using NUnit.Framework;
using System;
using System.Drawing;


namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestThatImage_IsNegative()
        {
            Bitmap originalImage = new Bitmap(3, 3);
            ImageEdit image = new ImageEdit(originalImage);

            for(int x = 0; x < originalImage.Height; x++)
            {
                for(int y = 0; y < originalImage.Width; y++)
                {
                    originalImage.SetPixel(x, y, Color.FromArgb(150, 200, 250));
                }
            }

            
            Bitmap negativeImage = image.CreateNegativeImage();
            for (int x = 0; x < negativeImage.Height; x++)
            {
                for(int y = 0; y < negativeImage.Width; y++)
                {
                    Color originalPixelColor = originalImage.GetPixel(x, y);
                    Color negativePixelColor = negativeImage.GetPixel(x, y);
                    Assert.AreEqual(255 - originalPixelColor.R, negativePixelColor.R);
                    Assert.AreEqual(255 - originalPixelColor.G, negativePixelColor.G);
                    Assert.AreEqual(255 - originalPixelColor.B, negativePixelColor.B);
                }
            }
        }

        [Test]
        public void TestThatImage_IsGreyscale()
        {
            Bitmap originalImage = new Bitmap(3, 3);
            ImageEdit image = new ImageEdit(originalImage);

            for (int x = 0; x < originalImage.Height; x++)
            {
                for (int y = 0; y < originalImage.Width; y++)
                {
                    originalImage.SetPixel(x, y, Color.FromArgb(150, 200, 250));
                }
            }

            Bitmap greyscaleImage = image.CreateGrayscaleImage();

            for (int x = 0; x < greyscaleImage.Height; x++)
            {
                for (int y = 0; y < greyscaleImage.Width; y++)
                {
                    Color originalPixel = originalImage.GetPixel(x, y);
                    Color greyscalePixel = greyscaleImage.GetPixel(x, y);

                    int rgbAverage = (originalPixel.R + originalPixel.G + originalPixel.B) / 3;

                    Assert.AreEqual(rgbAverage, greyscalePixel.R);
                    Assert.AreEqual(rgbAverage, greyscalePixel.G);
                    Assert.AreEqual(rgbAverage, greyscalePixel.B);
                }
            }
        }

        [Test]
        public void TestThatImage_IsBlurred()
        {
            Bitmap originalImage = new Bitmap(9, 9);

        }
    }
}