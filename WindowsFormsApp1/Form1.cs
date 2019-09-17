using ImageEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private SaveFileDialog SaveFileDialog = new SaveFileDialog();
        private EditImage image;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "jpeg (*.jpg)|*.jpg|png (*.png)|*.png) ";
            

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap tempImg = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = tempImg;
                new EditImage(openFileDialog.FileName);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            EditImage image = new EditImage(openFileDialog.FileName);
            pictureBox2.Image = image.CreateNegativeImage();
            pictureBox2.Tag = "negative";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            EditImage image = new EditImage(openFileDialog.FileName);
            pictureBox2.Image = image.CreateGrayscaleImage();
            pictureBox2.Tag = "greyscale";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox2.Tag == image.NegativeImage.Tag)
                {
                    SaveFileDialog.InitialDirectory = image.NewFilePath(image.NegativeImage);
                }
            }
            catch (NullReferenceException) { }

            try
            {
                if (pictureBox2.Tag == image.GreyscaleImage.Tag)
                {
                    SaveFileDialog.InitialDirectory = image.NewFilePath(image.GreyscaleImage);
                    SaveFileDialog.FileName
                }
            }
            catch (NullReferenceException) { }

            
            SaveFileDialog.ShowDialog();
            
        }
    }
}
