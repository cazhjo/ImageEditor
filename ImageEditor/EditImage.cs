using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ImageEditor
{
    public class EditImage
    {
        public Bitmap Image { get; private set; }
        private Bitmap negativeImage;
        private Bitmap greyscaleImage;

        public EditImage(string fileName)
        {

            try
            {
                Image = new Bitmap(fileName);
                
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid Format");
                Environment.Exit(0);
            }
        }

        public void CreateNegativeImage()
        {
            negativeImage = (Bitmap)Image.Clone();

            for (int x = 0; x < Image.Height; x++)
            {
                for (int y = 0; y < Image.Width; y++)
                {
                    
                    Color pixelColor = negativeImage.GetPixel(x, y);
                    negativeImage.SetPixel(x, y, Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B));
                }
                
            }
            
        }

        public void CreateGrayscaleImage()
        {
            greyscaleImage = (Bitmap)Image.Clone();

            for (int x = 0; x < Image.Height; x++)
            {
                for (int y = 0; y < Image.Width; y++)
                {
                    
                    Color pixelColor = greyscaleImage.GetPixel(x, y);
                    int rgbAverage = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    greyscaleImage.SetPixel(x, y, Color.FromArgb(rgbAverage, rgbAverage, rgbAverage));
                }
            }
            
        }

        public void SaveImages(string fileName)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string fileExtension = Path.GetExtension(fileName);
            string fileDirectoryName = Path.GetDirectoryName(fileName);

            if (negativeImage != null)
            {
                negativeImage.Save(fileDirectoryName + "\\" + fileNameWithoutExtension + "_negative" + fileExtension);
            }
            if (greyscaleImage != null)
            {
                greyscaleImage.Save(fileDirectoryName + "\\" + fileNameWithoutExtension + "_greyscale" + fileExtension);
            }
            
        }
    }
}


