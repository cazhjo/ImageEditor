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


namespace ImageEditorForm
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        private ImageEdit image;
        private FilePathSplitter filePath;

        public Form1()
        {
            InitializeComponent();

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = "C:" + Path.DirectorySeparatorChar;
            openFileDialog.Filter = "jpeg (*.jpg)|*.jpg|png (*.png)|*.png) ";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                editedImageBox.Image = null;

                ImageEdit image = new ImageEdit(openFileDialog.FileName);
                originalImageBox.Image = image.Image;
                
                negativeButton.Enabled = true;
                greyscaleButton.Enabled = true;
                blurButton.Enabled = true;
            }
        }

        private void NegativeButton_Click(object sender, EventArgs e)
        {
            image = new ImageEdit(openFileDialog.FileName); ;
            editedImageBox.Image = image.CreateNegativeImage();

            saveButton.Enabled = true;
        }

        private void GreyscaleButton_Click(object sender, EventArgs e)
        {
            image = new ImageEdit(openFileDialog.FileName);
            editedImageBox.Image = image.CreateGrayscaleImage();

            saveButton.Enabled = true;
        }

        private void BlurButton_Click(object sender, EventArgs e)
        {
            image = new ImageEdit(openFileDialog.FileName);
            editedImageBox.Image = image.CreateBlurredImage();

            saveButton.Enabled = true;
        }                                            

        private void SaveButton_Click(object sender, EventArgs e)
        {
            filePath = new FilePathSplitter(openFileDialog.FileName);

            saveFileDialog.Filter = "jpeg (*.jpg)|*.jpg|png (*.png)|*.png) ";
            saveFileDialog.InitialDirectory = filePath.GetFileDirectory();
            saveFileDialog.FileName = filePath.GetFileNameWithSuffix((string)editedImageBox.Image.Tag);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                image.SaveImage((Bitmap)editedImageBox.Image, saveFileDialog.FileName);
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //when editedImageBox is null
            saveButton.Enabled = false;

            //when originalImageBox is null
            negativeButton.Enabled = false;
            greyscaleButton.Enabled = false;
            blurButton.Enabled = false;
        }

       
    }
}



