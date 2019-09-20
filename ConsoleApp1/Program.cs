using ImageEditor;
using System;
using System.Drawing;
using System.IO;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = string.Empty;

            try
            {
                fileName = args[1];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Enter a file path for an image: ");
                fileName = Console.ReadLine();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Enter a file path for an image: ");
                fileName = Console.ReadLine();
            }

            ImageEdit image = new ImageEdit(fileName);
            Bitmap blurredImage = image.CreateBlurredImage();
            Bitmap greyscaleImage = image.CreateGrayscaleImage();
            Bitmap negativeImage = image.CreateNegativeImage();

            image.SaveImage(blurredImage);
            image.SaveImage(greyscaleImage);
            image.SaveImage(negativeImage);

        }
    }
}
