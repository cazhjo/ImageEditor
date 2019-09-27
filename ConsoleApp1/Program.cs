using ImageEditor;
using System;
using System.Drawing;
using System.IO;


namespace ImageEditorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = string.Empty;

            if(args.Length == 2)
            {
                fileName = args[1];
            }
            else if(args.Length == 1)
            {
                fileName = args[0];
            }
            else
            {
                Console.WriteLine("Enter a file path for an image: ");
                fileName = Console.ReadLine();
            }

            ImageEdit image = null;
            try
            {
                image = new ImageEdit(fileName);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid Format");
                Environment.Exit(1);
            }

            Bitmap blurredImage = image.CreateBlurredImage();
            Bitmap greyscaleImage = image.CreateGrayscaleImage();
            Bitmap negativeImage = image.CreateNegativeImage();

            image.SaveImage(blurredImage);
            image.SaveImage(greyscaleImage);
            image.SaveImage(negativeImage);

        }
    }
}
