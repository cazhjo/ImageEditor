using System;
using System.Drawing;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = string.Empty;
            args[0] = fileName;
            try
            {
                Bitmap image1 = new Bitmap(fileName);
                Console.WriteLine(image1.Height);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Error");
            }
        }
    }
}
