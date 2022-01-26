using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class ExecImagesForm : Form
    {
        Dictionary<string, string> KindOfProcessingImagesDictionary;

        // Add some elements to the dictionary. There are no
        // duplicate keys, but some of the values are duplicates.

        public ExecImagesForm()
        {
            InitializeComponent();
            initComboBox();
            hideStepsAfterFirst();
        }

        private void initComboBox()
        {
            KindOfProcessingComboBox.DropDownHeight = 150;

            KindOfProcessingImagesDictionary = new Dictionary<string, string>();
            KindOfProcessingImagesDictionary.Add("copy", "Copy");
            KindOfProcessingImagesDictionary.Add("gray", "Gray colors");
            KindOfProcessingImagesDictionary.Add("convolution", "Convolution");

            string[] values = KindOfProcessingImagesDictionary.Values.ToArray<string>();
            KindOfProcessingComboBox.Items.AddRange(values);
        }

        private void hideStepsAfterFirst()
        {
            KindOfProcessingComboBox.Hide();
            ProcessImageButton.Hide();
            SaveResultImage.Hide();
        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            dialog.Title = "Open Image";
            //dialog.Filter = "bmp files (*.bmp)|*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK && dialog.CheckPathExists && dialog.CheckFileExists)
            {
                Bitmap inputOriginalBitmap = new Bitmap(dialog.FileName);
                /*if (inputOriginalBitmap.Width > 500)
                {
                    inputOriginalBitmap = inputOriginalBitmap.Clone(new Rectangle(0, 0, 500, inputOriginalBitmap.Height), inputOriginalBitmap.PixelFormat);
                }
                if (inputOriginalBitmap.Height > 655)
                {
                    inputOriginalBitmap = inputOriginalBitmap.Clone(new Rectangle(0, 0, inputOriginalBitmap.Width, 655), inputOriginalBitmap.PixelFormat);
                }*/
                InputImagePictureBox.Image = inputOriginalBitmap;
                OutputImagePictureBox.Image = null;
                KindOfProcessingComboBox.Show();
                ProcessImageButton.Show();
                SaveResultImage.Hide();

            }
            else
            {
                MessageBox.Show("Error with upload chosen file");
                KindOfProcessingComboBox.Hide();
                ProcessImageButton.Hide();
            }
            dialog.Dispose();
        }

        private void SaveResultImage_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new OpenFileDialog();

                dialog.Title = "Save Image";
                //dialog.Filter = "bmp files (*.bmp)|*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    OutputImagePictureBox.Image.Save(dialog.FileName);

                }
                dialog.Dispose();

            }
            catch (Exception exp)
            {
                MessageBox.Show("Error with save result image. Error messge: " + exp.Message);
            }
        }

        private void ProcessImageButton_Click(object sender, EventArgs e)
        {
            if (KindOfProcessingComboBox.SelectedItem != null)
            {
                string operation = KindOfProcessingComboBox.SelectedItem.ToString();
                int i = -1;
                string str = "";
                if (KindOfProcessingImagesDictionary.TryGetValue("copy", out str) && operation == str)
                {
                    i = 0;
                }
                else if (KindOfProcessingImagesDictionary.TryGetValue("gray", out str) && operation == str)
                {
                    i = 1;
                }
                else if (KindOfProcessingImagesDictionary.TryGetValue("convolution", out str) && operation == str)
                {
                    i = 2;
                }
                switch (i)
                {
                    case 0:
                        this.copyImage();
                        break;
                    case 1:
                        this.colorImageGray();
                        break;
                    case 2:
                        this.startConvolutionImageWithMatrix();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Firstly choose an option in a dropdown");
            }
        }

        private void copyImage()
        {
            OutputImagePictureBox.Image = InputImagePictureBox.Image;
        }

        private void colorImageGray()
        {
            Bitmap inputBitmap = (Bitmap)InputImagePictureBox.Image;
            Bitmap outputBitmap = new Bitmap(inputBitmap.Width, inputBitmap.Height);
            int height = InputImagePictureBox.Image.Height;
            int width = InputImagePictureBox.Image.Width;
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    Color origColor = inputBitmap.GetPixel(w, h);
                    int averageBrightness = (origColor.R + origColor.G + origColor.B) / 3;
                    outputBitmap.SetPixel(w, h, Color.FromArgb(averageBrightness, averageBrightness, averageBrightness));
                }
            }
            OutputImagePictureBox.Image = outputBitmap;
        }

        private void startConvolutionImageWithMatrix()
        {
            Bitmap inputBitmap = (Bitmap)InputImagePictureBox.Image;
            Bitmap outputBitmap = new Bitmap(inputBitmap.Width, inputBitmap.Height);
            double u = 0, v = 0.5;
            int height = InputImagePictureBox.Image.Height;
            int width = InputImagePictureBox.Image.Width;
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    Color origColor = inputBitmap.GetPixel(w, h);
                    int averageBrightness = (origColor.R + origColor.G + origColor.B) / 3;
                    int editBrightness = Convert.ToInt32(127 + 50 * Math.Cos(u * h + v * w));
                    // Make processed image
                    Color editColor = Color.FromArgb(editBrightness, editBrightness, editBrightness);
                    outputBitmap.SetPixel(w, h, editColor);
                }
            }
            OutputImagePictureBox.Image = outputBitmap;
        }

        private void getPeriodicalPattern()
        {
            int height = 500;
            int width = 400;
            int n = 2;
            double[] u = new double[n];
            double[] v = new double[n];
            u[0] = 0.2; v[0] = -0.4;
            u[1] = -0.2; v[1] = 0.4;

            Bitmap inputBitmap = new Bitmap(width, height);
            Bitmap outputBitmap = new Bitmap(width, height);

            int heightOfPie = height / n;
            int widthOfPie = width / n;

            int conversionAddition = 50;
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    int finalBrightness = 0;
                    finalBrightness = Convert.ToInt32((Math.Cos(u[0] * h + v[0] * w)+ Math.Cos(u[0] * h + v[1] * w)+ Math.Cos(u[1] * h + v[0] * w)+ Math.Cos(u[1] * h + v[1] * w)) * conversionAddition + conversionAddition * 2);
                    finalBrightness = finalBrightness < 0 ? 0 : (finalBrightness > 255 ? 255 : finalBrightness);
                    Color finalColor = Color.FromArgb(finalBrightness, finalBrightness, finalBrightness);
                    outputBitmap.SetPixel(w, h, finalColor);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int h = i * heightOfPie; h < heightOfPie * i + heightOfPie; h++)
                    {
                        for (int w = j * widthOfPie; w < widthOfPie * j + widthOfPie; w++)
                        {
                            int editBrightness = Convert.ToInt32(conversionAddition * 2 + conversionAddition * Math.Cos(u[i] * h + v[j] * w));
                            // Make processed image
                            Color editColor = Color.FromArgb(editBrightness, editBrightness, editBrightness);
                            inputBitmap.SetPixel(w, h, editColor);
                        }
                    }
                }
            }

            InputImagePictureBox.Image = inputBitmap;
            OutputImagePictureBox.Image = outputBitmap;
        }

        private void PeriodicalPatternButton_Click(object sender, EventArgs e)
        {
            getPeriodicalPattern();
        }
    }
}
