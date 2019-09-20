using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

            try
            {
                Image = new Bitmap(fileName);
                Bitmap tempImage = (Bitmap)Image.Clone();
                if (Image.Height > 150 && Image.Width > 150)
                {

                    Image = new Bitmap(tempImage, 150, 150);
                }
                tempImage.Dispose();
                
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid Format");
                Environment.Exit(0);
            }
        }

        public Bitmap CreateNegativeImage()
        {
            Bitmap negativeImage = new Bitmap(Image.Width, Image.Height);
            negativeImage.Tag = new string("negative".ToCharArray());

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
            greyscaleImage.Tag = new string("greyscale".ToCharArray());

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

        public Bitmap CreateBlurredImage()
        {
            Bitmap blurredImage = new Bitmap(Image.Width, Image.Height);
            blurredImage.Tag = new string("blurred".ToCharArray());

            for (int x = 0; x < Image.Height; x++)
            {
                for (int y = 0; y < Image.Width; y++)
                {
                    Color pixelColor;
                    int redSum = 0;
                    int greenSum = 0;
                    int blueSum = 0;

                    if (x > 1 && x < Image.Height - 2 && y > 1 && y < Image.Width - 2)
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
            img.Save(filePath.GetFileDirectory() + "\\" + filePath.GetFileNameWithSufix(img.Tag.ToString()));
        }

        public void SaveImage(Bitmap img, string fileName)
        {
            img.Save(fileName);
        }
    }
}


