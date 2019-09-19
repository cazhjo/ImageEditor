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
        private ImageEdit image;

        public Form1()
        {
            InitializeComponent();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "jpeg (*.jpg)|*.jpg|png (*.png)|*.png) ";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImageEdit image = new ImageEdit(openFileDialog.FileName);
                pictureBox1.Image = image.Image;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            image = new ImageEdit(openFileDialog.FileName); ;
            pictureBox2.Image = image.CreateNegativeImage();
            pictureBox2.Tag = image.NegativeImage.Tag.ToString();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            image = new ImageEdit(openFileDialog.FileName);
            pictureBox2.Image = image.CreateGrayscaleImage();
            pictureBox2.Tag = image.GreyscaleImage.Tag;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog.Filter = "jpeg (*.jpg)|*.jpg|png (*.png)|*.png) ";
            try
            {
                if (pictureBox2.Tag == image.NegativeImage.Tag)
                {
                    SaveFileDialog.InitialDirectory = image.GetFullFilePathWithSufix(image.NegativeImage);
                    SaveFileDialog.FileName = image.GetFileNameWithSufix(image.NegativeImage);
                }
            }
            catch (NullReferenceException) { }

            try
            {
                if (pictureBox2.Tag == image.GreyscaleImage.Tag)
                {
                    SaveFileDialog.InitialDirectory = image.GetFullFilePathWithSufix(image.GreyscaleImage);
                    SaveFileDialog.FileName = image.GetFileNameWithSufix(image.GreyscaleImage);
                    if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        image.SaveImage(image.GreyscaleImage);
                    }
                }
            }
            catch (NullReferenceException) { }

            try
            {
                if (pictureBox2.Tag == image.BlurredImage.Tag)
                {
                    SaveFileDialog.InitialDirectory = image.GetFullFilePathWithSufix(image.BlurredImage);
                    SaveFileDialog.FileName = image.GetFileNameWithSufix(image.BlurredImage);
                    if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        
                    }
                }
            }
            catch (NullReferenceException) { }

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            image = new ImageEdit(openFileDialog.FileName);
            pictureBox2.Image = image.CreateBlurredImage();
            pictureBox2.Tag = image.BlurredImage.Tag;
        }
    }
}



