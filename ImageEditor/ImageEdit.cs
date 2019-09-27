using System;
using System.Drawing;
using System.IO;

namespace ImageEditor
{
    public class ImageEdit
    {
        public Bitmap Image { get; private set; }
        private FilePathSplitter filePath;

        public ImageEdit(Bitmap originalImage)
        {
            Image = originalImage;
        }

        public ImageEdit(string fileName)
        {
            filePath = new FilePathSplitter(fileName);
            Image = new Bitmap(fileName);
        }

        public Bitmap CreateNegativeImage()
        {
            Bitmap negativeImage = new Bitmap(Image.Width, Image.Height);
            negativeImage.Tag = "negative";

            for (int x = 0; x < Image.Height; x++)
            {
                for (int y = 0; y < Image.Width; y++)
                {
                    Color pixelColor = Image.GetPixel(x, y);
                    negativeImage.SetPixel(x, y, Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B));
                }

            }

            return negativeImage;
        }

        public Bitmap CreateGrayscaleImage()
        {
            Bitmap greyscaleImage = new Bitmap(Image.Width, Image.Height);
            greyscaleImage.Tag = "greyscale";

            for (int x = 0; x < Image.Height; x++)
            {
                for (int y = 0; y < Image.Width; y++)
                {

                    Color pixelColor = Image.GetPixel(x, y);
                    int rgbAverage = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    greyscaleImage.SetPixel(x, y, Color.FromArgb(rgbAverage, rgbAverage, rgbAverage));
                }
            }

            return greyscaleImage;
        }

        /// <summary>
        /// Blurs the image but leaves 4 pixels in width and height unblurred
        /// </summary>
        /// <returns>A blurred image from the original image</returns>
        public Bitmap CreateBlurredImage()
        {
            Bitmap blurredImage = new Bitmap(Image.Width, Image.Height);
            blurredImage.Tag = "blurred";

            for (int x = 2; x < Image.Height - 2; x++)
            {
                for (int y = 2; y < Image.Width - 2; y++)
                {
                    Color pixelColor;
                    int redSum = 0;
                    int greenSum = 0;
                    int blueSum = 0;

                    {
                        for (int d = -2; d < 3; d++)
                        {
                            for (int e = -2; e < 3; e++)
                            {
                                pixelColor = Image.GetPixel(x + d, y + e);
                                redSum += pixelColor.R;
                                greenSum += pixelColor.G;
                                blueSum += pixelColor.B;
                            }
                        }

                        blurredImage.SetPixel(x, y, Color.FromArgb(redSum / 25, greenSum / 25, blueSum / 25));
                    }

                }
            }
            return blurredImage;
        }

        public void SaveImage(Bitmap img)
        {
            img.Save(filePath.GetFullFilePathWithSuffix((string)img.Tag));
        }

        public void SaveImage(Bitmap img, string fileName)
        {
            img.Save(fileName);
        }
    }


}


