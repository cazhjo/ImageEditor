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
            ImageEdit imageEdit = new ImageEdit(originalImage);

            for(int x = 0; x < originalImage.Height; x++)
            {
                for(int y = 0; y < originalImage.Width; y++)
                {
                    originalImage.SetPixel(x, y, Color.AntiqueWhite);
                }
            }

            originalImage.SetPixel(4, 4, Color.AliceBlue);

            Bitmap blurredImage = imageEdit.CreateBlurredImage();

            for (int x = 0; x < blurredImage.Height; x++)
            {
                for (int y = 0; y < blurredImage.Width; y++)
                {
                    Color pixelColor;
                    int redSum = 0;
                    int greenSum = 0;
                    int blueSum = 0;

                    if (x > 1 && x < originalImage.Height - 2 && y > 1 && y < originalImage.Width - 2)
                    {
                        for (int d = -2; d < 3; d++)
                        {
                            for (int e = -2; e < 3; e++)
                            {
                                pixelColor = originalImage.GetPixel(x + d, y + e);
                                redSum += pixelColor.R;
                                greenSum += pixelColor.G;
                                blueSum += pixelColor.B;
                            }
                        }

                        Color expectedColor = Color.FromArgb(redSum / 25, greenSum / 25, blueSum / 25);
                        Assert.AreEqual(expectedColor, blurredImage.GetPixel(x, y));
                    }

                }
            }


        }

        [Test]
        public void TestThatFilePath_HasSufix()
        {
            string originalFilePath = @"C:\Picture\apple.jpg";
            FilePathSplitter filePath = new FilePathSplitter(originalFilePath);
            string newFilePath = filePath.GetFileDirectory() + filePath.DirectorySeparatorChar + filePath.GetFileNameWithSufix("test");

            Assert.AreEqual(@"C:\Picture\apple_test.jpg", newFilePath);
        }
    }
}