namespace ImageEditorForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.originalImageBox = new System.Windows.Forms.PictureBox();
            this.editedImageBox = new System.Windows.Forms.PictureBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.negativeButton = new System.Windows.Forms.Button();
            this.greyscaleButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.blurButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editedImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // originalImageBox
            // 
            this.originalImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalImageBox.Location = new System.Drawing.Point(8, 27);
            this.originalImageBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.originalImageBox.Name = "originalImageBox";
            this.originalImageBox.Size = new System.Drawing.Size(201, 196);
            this.originalImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.originalImageBox.TabIndex = 0;
            this.originalImageBox.TabStop = false;
            // 
            // editedImageBox
            // 
            this.editedImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editedImageBox.Location = new System.Drawing.Point(325, 27);
            this.editedImageBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.editedImageBox.Name = "editedImageBox";
            this.editedImageBox.Size = new System.Drawing.Size(201, 196);
            this.editedImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.editedImageBox.TabIndex = 1;
            this.editedImageBox.TabStop = false;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(72, 226);
            this.browseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(63, 21);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(397, 226);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(63, 21);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // negativeButton
            // 
            this.negativeButton.Location = new System.Drawing.Point(232, 64);
            this.negativeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.negativeButton.Name = "negativeButton";
            this.negativeButton.Size = new System.Drawing.Size(75, 33);
            this.negativeButton.TabIndex = 4;
            this.negativeButton.Text = "Negative";
            this.negativeButton.UseVisualStyleBackColor = true;
            this.negativeButton.Click += new System.EventHandler(this.NegativeButton_Click);
            // 
            // greyscaleButton
            // 
            this.greyscaleButton.Location = new System.Drawing.Point(232, 112);
            this.greyscaleButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.greyscaleButton.Name = "greyscaleButton";
            this.greyscaleButton.Size = new System.Drawing.Size(75, 33);
            this.greyscaleButton.TabIndex = 5;
            this.greyscaleButton.Text = "Greyscale";
            this.greyscaleButton.UseVisualStyleBackColor = true;
            this.greyscaleButton.Click += new System.EventHandler(this.GreyscaleButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Original Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Edited Image";
            // 
            // blurButton
            // 
            this.blurButton.Location = new System.Drawing.Point(232, 160);
            this.blurButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.blurButton.Name = "blurButton";
            this.blurButton.Size = new System.Drawing.Size(75, 33);
            this.blurButton.TabIndex = 8;
            this.blurButton.Text = "Blur";
            this.blurButton.UseVisualStyleBackColor = true;
            this.blurButton.Click += new System.EventHandler(this.BlurButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.blurButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.greyscaleButton);
            this.Controls.Add(this.negativeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.editedImageBox);
            this.Controls.Add(this.originalImageBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ImageEditor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editedImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox originalImageBox;
        private System.Windows.Forms.PictureBox editedImageBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button negativeButton;
        private System.Windows.Forms.Button greyscaleButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button blurButton;
    }
}

