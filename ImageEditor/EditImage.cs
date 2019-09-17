using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageEditor
{
    public class EditImage
    {
        public Bitmap Image { get; private set; }
        private Bitmap negativeImage;
        private Bitmap greyscaleImage;
        private Bitmap blurredImage;

        public Bitmap NegativeImage { get { return negativeImage; } }
        public Bitmap GreyscaleImage { get { return greyscaleImage; } }
        public Bitmap BlurredImage { get { return blurredImage; } }

        private string fileName;

        public EditImage(string fileName)
        {
            this.fileName = fileName;
            try
            {
                Bitmap tempImage = new Bitmap(fileName);
                Image = new Bitmap(tempImage, 300, 300);

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
            negativeImage = (Bitmap)Image.Clone();
            negativeImage.Tag = new string("negative".ToCharArray());

            for (int x = 0; x < Image.Height; x++)
            {
                for (int y = 0; y < Image.Width; y++)
                {

                    Color pixelColor = negativeImage.GetPixel(x, y);
                    negativeImage.SetPixel(x, y, Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B));
                }

            }
            return negativeImage;

        }

        public Bitmap CreateGrayscaleImage()
        {
            greyscaleImage = (Bitmap)Image.Clone();
            greyscaleImage.Tag = new string("greyscale".ToCharArray());

            for (int x = 0; x < Image.Height; x++)
            {
                for (int y = 0; y < Image.Width; y++)
                {

                    Color pixelColor = greyscaleImage.GetPixel(x, y);
                    int rgbAverage = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    greyscaleImage.SetPixel(x, y, Color.FromArgb(rgbAverage, rgbAverage, rgbAverage));
                }
            }
            return greyscaleImage;

        }

        public Bitmap CreateBlurredImage()
        {
            blurredImage = (Bitmap)Image.Clone();
            Bitmap tempImage = new Bitmap(3, 3);
            blurredImage.Tag = new string("blurred".ToCharArray());

            for (int x = 0; x < Image.Height; x++)
            {
                for (int y = 0; y < Image.Width; y++)
                {
                    Color pixelColor;
                    int redSum = 0;
                    int greenSum = 0;
                    int blueSum = 0;

                    if (x > 0 && x < Image.Height - 1 && y > 0 && y < Image.Width - 1)
                    {
                        pixelColor = blurredImage.GetPixel(x - 1, y - 1);
                        tempImage.SetPixel(0, 0, pixelColor);
                        pixelColor = blurredImage.GetPixel(x - 1, y);
                        tempImage.SetPixel(0, 1, pixelColor);
                        pixelColor = blurredImage.GetPixel(x - 1, y + 1);
                        tempImage.SetPixel(0, 2, pixelColor);
                        pixelColor = blurredImage.GetPixel(x, y - 1);
                        tempImage.SetPixel(1, 0, pixelColor);
                        pixelColor = blurredImage.GetPixel(x, y);
                        tempImage.SetPixel(1, 1, pixelColor);
                        pixelColor = blurredImage.GetPixel(x, y + 1);
                        tempImage.SetPixel(1, 2, pixelColor);
                        pixelColor = blurredImage.GetPixel(x + 1, y - 1);
                        tempImage.SetPixel(2, 0, pixelColor);
                        pixelColor = blurredImage.GetPixel(x + 1, y);
                        tempImage.SetPixel(2, 1, pixelColor);
                        pixelColor = blurredImage.GetPixel(x + 1, y + 1);
                        tempImage.SetPixel(2, 2, pixelColor);

                        for (int a = 0; a < tempImage.Height; a++)
                        {
                            for (int b = 0; b < tempImage.Width; b++)
                            {
                                pixelColor = tempImage.GetPixel(a, b);
                                redSum += pixelColor.R;
                                greenSum += pixelColor.G;
                                blueSum += pixelColor.B;
                            }
                        }

                        blurredImage.SetPixel(x, y, Color.FromArgb(redSum / 9, greenSum / 9, blueSum / 9));
                    }

                }
            }

            
            return blurredImage;

        }

        public string GetFileNameWithSufix(Bitmap img)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string fileExtension = Path.GetExtension(fileName);

            return $"{fileNameWithoutExtension}_{img.Tag.ToString()}{fileExtension}";
        }

        public string GetFullFilePathWithSufix(Bitmap img)
        {
            return $"{Path.GetDirectoryName(fileName)}\\{GetFileNameWithSufix(img)}";
        }

        public void SaveImage(Bitmap img)
        {
            img.Save(GetFullFilePathWithSufix(img));
        }
    }
}


