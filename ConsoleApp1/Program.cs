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

            EditImage image = new EditImage(fileName);
            image.CreateNegativeImage();
            image.CreateGrayscaleImage();
            image.SaveImages(fileName);

            
           

        


        }
    }
}
