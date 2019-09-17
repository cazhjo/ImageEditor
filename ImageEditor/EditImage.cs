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

        public Bitmap NegativeImage { get { return negativeImage; } }
        public Bitmap GreyscaleImage { get { return greyscaleImage; } }
        private string fileName;
        public FilePathSplitter FilePath {get; set;}

        public EditImage(string fileName)
        {
            this.fileName = fileName;
            try
            {
                Image = new Bitmap(fileName);
                

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid Format");
                Environment.Exit(0);
            }
            FilePath = new FilePathSplitter(fileName);
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

        public void SaveImage(Bitmap img)
        {
            try
            {
                if (img.Tag == negativeImage.Tag)
                {
                    FilePath.AddSufixToFileName("negative");
                    negativeImage.Save(FilePath.FullFilePathWithSufix);
                }
            }
            catch (NullReferenceException) { }

            try
            {
                if (img.Tag == greyscaleImage.Tag)
                {
                    FilePath.AddSufixToFileName("greyscale");
                    greyscaleImage.Save(FilePath.FullFilePathWithSufix);
                }

            }
            catch (NullReferenceException) { }
        }
    }
}


