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
            Random rand = new Random();
            Bitmap originalImage = new Bitmap(3, 3);
            ImageEdit image = new ImageEdit(originalImage);

            for(int x = 0; x < originalImage.Height; x++)
            {
                for(int y = 0; y < originalImage.Width; y++)
                {
                    originalImage.SetPixel(x, y, Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)));
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
                }
            }
        }
    }
}