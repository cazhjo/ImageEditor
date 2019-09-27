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

            for (int x = 0; x < originalImage.Height; x++)
            {
                for (int y = 0; y < originalImage.Width; y++)
                {
                    originalImage.SetPixel(x, y, Color.FromArgb(150, 200, 250));
                }
            }


            Bitmap negativeImage = image.CreateNegativeImage();
            for (int x = 0; x < negativeImage.Height; x++)
            {
                for (int y = 0; y < negativeImage.Width; y++)
                {
                    Color negativePixelColor = negativeImage.GetPixel(x, y);
                    Assert.AreEqual(105, negativePixelColor.R);
                    Assert.AreEqual(55, negativePixelColor.G);
                    Assert.AreEqual(5, negativePixelColor.B);
                }
            }
        }

        [Test]
        public void TestThatImage_IsGreyscale()
        {
            Bitmap originalImage = new Bitmap(3, 3);
            ImageEdit imageEdit = new ImageEdit(originalImage);

            for (int x = 0; x < originalImage.Height; x++)
            {
                for (int y = 0; y < originalImage.Width; y++)
                {
                    originalImage.SetPixel(x, y, Color.FromArgb(150, 200, 250));

                }
            }

            Bitmap greyscaleImage = imageEdit.CreateGrayscaleImage();

            for (int x = 0; x < greyscaleImage.Height; x++)
            {
                for (int y = 0; y < greyscaleImage.Width; y++)
                {
                    Color greyscalePixel = greyscaleImage.GetPixel(x, y);

                    Assert.AreEqual(200, greyscalePixel.R);
                    Assert.AreEqual(200, greyscalePixel.G);
                    Assert.AreEqual(200, greyscalePixel.B);
                }
            }
        }

        [Test]
        public void TestThatImage_IsBlurred()
        {
            Bitmap originalImage = new Bitmap(9, 9);
            ImageEdit imageEdit = new ImageEdit(originalImage);

            for (int x = 0; x < originalImage.Height; x++)
            {
                for (int y = 0; y < originalImage.Width; y++)
                {
                    originalImage.SetPixel(x, y, Color.FromArgb(250, 250, 250));
                }
            }

            originalImage.SetPixel(4, 4, Color.FromArgb(100, 100, 100));

            Bitmap blurredImage = imageEdit.CreateBlurredImage();

            for (int x = 2; x < blurredImage.Height - 2; x++)
            {
                for (int y = 2; y < blurredImage.Width - 2; y++)
                {
                    Color blurredPixel = blurredImage.GetPixel(x, y);
                    Assert.AreEqual(244, blurredPixel.R);
                    Assert.AreEqual(244, blurredPixel.G);s
                    Assert.AreEqual(244, blurredPixel.B);
                }
            }


        }

        [Test]
        public void TestThatFileName_HasSuffix()
        {
            string originalFilePath = @"C:\Picture\apple.jpg";
            FilePathSplitter filePath = new FilePathSplitter(originalFilePath);
            string newFilePath = filePath.GetFileNameWithSuffix("test");

            Assert.AreEqual("apple_test.jpg", newFilePath);
        }
    }
}