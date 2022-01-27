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
            KindOfProcessingImagesDictionary.Add("cross_correlation", "Сross-correlation");

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
                if (inputOriginalBitmap.Width > 500)
                {
                    inputOriginalBitmap = inputOriginalBitmap.Clone(new Rectangle(0, 0, 500, inputOriginalBitmap.Height), inputOriginalBitmap.PixelFormat);
                }
                if (inputOriginalBitmap.Height > 655)
                {
                    inputOriginalBitmap = inputOriginalBitmap.Clone(new Rectangle(0, 0, inputOriginalBitmap.Width, 655), inputOriginalBitmap.PixelFormat);
                }
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
                var dialog = new SaveFileDialog();

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
                else if (KindOfProcessingImagesDictionary.TryGetValue("cross_correlation", out str) && operation == str)
                {
                    i = 3;
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
                    case 3:
                        this.startCrossCorrelation();
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
                    finalBrightness = Convert.ToInt32((Math.Cos(u[0] * h + v[0] * w) + Math.Cos(u[0] * h + v[1] * w) + Math.Cos(u[1] * h + v[0] * w) + Math.Cos(u[1] * h + v[1] * w)) * conversionAddition + conversionAddition * 2);
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

        private void startConvolutionImageWithMatrix()
        {
            Bitmap inputBitmap = (Bitmap)InputImagePictureBox.Image;
            Bitmap outputBitmap = new Bitmap(inputBitmap.Width, inputBitmap.Height);
            int height = InputImagePictureBox.Image.Height;
            int width = InputImagePictureBox.Image.Width;

            int convolutionMatrixSize = 5; //only an odd number
            double[][] convolutionMatrix = new double[convolutionMatrixSize][];
            convolutionMatrix[0] = new double[convolutionMatrixSize];
            convolutionMatrix[1] = new double[convolutionMatrixSize];
            convolutionMatrix[2] = new double[convolutionMatrixSize];
            convolutionMatrix[3] = new double[convolutionMatrixSize];
            convolutionMatrix[4] = new double[convolutionMatrixSize];

            ////Starting matrix without matrix fliping

            //convolutionMatrix[0][0] = 1; convolutionMatrix[0][1] = 1; convolutionMatrix[0][2] = 1; convolutionMatrix[0][3] = 1; convolutionMatrix[0][4] = 1;
            //convolutionMatrix[1][0] = 1; convolutionMatrix[1][1] = 1; convolutionMatrix[1][2] = 1; convolutionMatrix[1][3] = 1; convolutionMatrix[1][4] = 1;
            //convolutionMatrix[2][0] = 1; convolutionMatrix[2][1] = 1; convolutionMatrix[2][2] = 1; convolutionMatrix[2][3] = 1; convolutionMatrix[2][4] = 1;
            //convolutionMatrix[3][0] = 1; convolutionMatrix[3][1] = 1; convolutionMatrix[3][2] = 1; convolutionMatrix[3][3] = 1; convolutionMatrix[3][4] = 1;
            //convolutionMatrix[4][0] = 1; convolutionMatrix[4][1] = 1; convolutionMatrix[4][2] = 1; convolutionMatrix[4][3] = 1; convolutionMatrix[4][4] = 1;

            //convolutionMatrix[0][0] = 0; convolutionMatrix[0][1] = 0; convolutionMatrix[0][2] = 0; convolutionMatrix[0][3] = 0; convolutionMatrix[0][4] = 1;
            //convolutionMatrix[1][0] = 0; convolutionMatrix[1][1] = 0; convolutionMatrix[1][2] = 0; convolutionMatrix[1][3] = 0; convolutionMatrix[1][4] = 2;
            //convolutionMatrix[2][0] = 0; convolutionMatrix[2][1] = 0; convolutionMatrix[2][2] = 0; convolutionMatrix[2][3] = 0; convolutionMatrix[2][4] = 3;
            //convolutionMatrix[3][0] = 0; convolutionMatrix[3][1] = 0; convolutionMatrix[3][2] = 0; convolutionMatrix[3][3] = 0; convolutionMatrix[3][4] = 2;
            //convolutionMatrix[4][0] = 1; convolutionMatrix[4][1] = 2; convolutionMatrix[4][2] = 3; convolutionMatrix[4][3] = 2; convolutionMatrix[4][4] = 1;

            convolutionMatrix[0][0] = -1; convolutionMatrix[0][1] = 0; convolutionMatrix[0][2] = 1;
            convolutionMatrix[1][0] = -2; convolutionMatrix[1][1] = 0; convolutionMatrix[1][2] = 2;
            convolutionMatrix[2][0] = -1; convolutionMatrix[2][1] = 0; convolutionMatrix[2][2] = 1;

            //convolutionMatrix[0][0] = -1; convolutionMatrix[0][1] = -1; convolutionMatrix[0][2] = -1;
            //convolutionMatrix[1][0] = -1; convolutionMatrix[1][1] = 9; convolutionMatrix[1][2] = -1;
            //convolutionMatrix[2][0] = -1; convolutionMatrix[2][1] = -1; convolutionMatrix[2][2] = -1;

            int convolutionOffset = 1 + convolutionMatrixSize / 2; //center of convolution matrix: convolutionMatrix[convolutionOffset][convolutionOffset]
            int convolutionMatrixHalf = convolutionOffset - 1;

            //Matrix flip and normalization
            double matrixSum = convolutionMatrix[convolutionMatrixHalf][convolutionMatrixHalf];
            for (int i = 0; i < convolutionOffset; i++)
            {
                for (int j = 0; j < convolutionMatrixSize; j++)
                {
                    if (j == convolutionMatrixHalf && i == convolutionMatrixHalf) break;
                    double temp = convolutionMatrix[i][j];
                    convolutionMatrix[i][j] = convolutionMatrix[convolutionMatrixSize - 1 - i][convolutionMatrixSize - 1 - j];
                    matrixSum += temp + convolutionMatrix[i][j];
                    convolutionMatrix[convolutionMatrixSize - 1 - i][convolutionMatrixSize - 1 - j] = temp;
                }
            }
            if (matrixSum != 0)
            {
                for (int i = 0; i < convolutionMatrixSize; i++)
                {
                    for (int j = 0; j < convolutionMatrixSize; j++)
                    {
                        convolutionMatrix[i][j] = convolutionMatrix[i][j] / matrixSum;
                    }
                }
            }
            for (int h = convolutionOffset; h < height - convolutionOffset; h++)
            {
                for (int w = convolutionOffset; w < width - convolutionOffset; w++)
                {
                    int newR = 0, newG = 0, newB = 0;
                    for (int i = -convolutionMatrixHalf; i <= convolutionMatrixHalf; i++)
                    {
                        for (int j = -convolutionMatrixHalf; j <= convolutionMatrixHalf; j++)
                        {
                            newR += (int)(convolutionMatrix[convolutionMatrixHalf + i][convolutionMatrixHalf + j] * inputBitmap.GetPixel(w + j, h + i).R);
                            newG += (int)(convolutionMatrix[convolutionMatrixHalf + i][convolutionMatrixHalf + j] * inputBitmap.GetPixel(w + j, h + i).G);
                            newB += (int)(convolutionMatrix[convolutionMatrixHalf + i][convolutionMatrixHalf + j] * inputBitmap.GetPixel(w + j, h + i).B);
                        }
                    }

                    newR = newR < 0 ? 0 : (newR > 255 ? 255 : newR);
                    newG = newG < 0 ? 0 : (newG > 255 ? 255 : newG);
                    newB = newB < 0 ? 0 : (newB > 255 ? 255 : newB);
                    Color newColor = Color.FromArgb(newR, newG, newB);
                    outputBitmap.SetPixel(w, h, newColor);
                }
            }
            OutputImagePictureBox.Image = outputBitmap;
        }

        private void makeInputPictureGrayAndInverted()
        {
            Bitmap inputBitmap = (Bitmap)InputImagePictureBox.Image;
            int height = InputImagePictureBox.Image.Height;
            int width = InputImagePictureBox.Image.Width;
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    Color origColor = inputBitmap.GetPixel(w, h);
                    int averageBrightness = 255 - (origColor.R + origColor.G + origColor.B) / 3;
                    inputBitmap.SetPixel(w, h, Color.FromArgb(averageBrightness, averageBrightness, averageBrightness));
                }
            }
            InputImagePictureBox.Image = inputBitmap;

            try
            {
                var dialog = new SaveFileDialog();

                dialog.Title = "Save Image";
                //dialog.Filter = "bmp files (*.bmp)|*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    InputImagePictureBox.Image.Save(dialog.FileName);

                }
                dialog.Dispose();

            }
            catch (Exception exp)
            {
                MessageBox.Show("Error with save result image. Error message: " + exp.Message);
            }
        }

        private void startCrossCorrelation()
        {
            Bitmap inputBitmap = (Bitmap)InputImagePictureBox.Image;
            Bitmap outputBitmap = new Bitmap(inputBitmap.Width, inputBitmap.Height);
            int height = InputImagePictureBox.Image.Height;
            int width = InputImagePictureBox.Image.Width;
            var dialog = new OpenFileDialog();

            dialog.Title = "Open fragment for cross-correlation";
            //dialog.Filter = "bmp files (*.bmp)|*.bmp";
            Bitmap correlationFragmentBitmap = new Bitmap(51, 51);
            bool uploaded = false;
            while (!uploaded)
            {
                if (dialog.ShowDialog() == DialogResult.OK && dialog.CheckPathExists && dialog.CheckFileExists)
                {
                    correlationFragmentBitmap = new Bitmap(dialog.FileName);
                    if (correlationFragmentBitmap.Width % 2 == 0)
                    {
                        correlationFragmentBitmap = correlationFragmentBitmap.Clone(new Rectangle(0, 0, correlationFragmentBitmap.Width - 1, correlationFragmentBitmap.Height), correlationFragmentBitmap.PixelFormat);
                    }
                    if (correlationFragmentBitmap.Height % 2 == 0)
                    {
                        correlationFragmentBitmap = correlationFragmentBitmap.Clone(new Rectangle(0, 0, correlationFragmentBitmap.Width, correlationFragmentBitmap.Height - 1), correlationFragmentBitmap.PixelFormat);
                    }
                    uploaded = true;
                    dialog.Dispose();
                }
                else
                {
                    MessageBox.Show("Error with upload chosen file");
                }
            }

            int widthFragment = correlationFragmentBitmap.Width;
            int heightFragment = correlationFragmentBitmap.Height;
            int fragmentHeightOffset = 1 + heightFragment / 2;
            int fragmentWidthOffset = 1 + widthFragment / 2;
            int fragmentHeightHalf = fragmentHeightOffset - 1;
            int fragmentWidthHalf = fragmentWidthOffset - 1;

            for (int h = 0; h < heightFragment; h++)
            {
                for (int w = 0; w < widthFragment; w++)
                {
                    Color origColor = correlationFragmentBitmap.GetPixel(w, h);
                    int averageBrightness = (origColor.R + origColor.G + origColor.B) / 3;
                    averageBrightness = averageBrightness < 127 ? 10 : 0;
                    correlationFragmentBitmap.SetPixel(w, h, Color.FromArgb(averageBrightness, averageBrightness, averageBrightness));
                }
            }

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    Color origColor = inputBitmap.GetPixel(w, h);
                    int averageBrightness = (origColor.R + origColor.G + origColor.B) / 3;
                    averageBrightness = averageBrightness / 2;
                    inputBitmap.SetPixel(w, h, Color.FromArgb(averageBrightness, averageBrightness, averageBrightness));
                }
            }
            InputImagePictureBox.Image = inputBitmap;

            for (int h = fragmentHeightOffset; h < height - fragmentHeightOffset; h++)
            {
                for (int w = fragmentWidthOffset; w < width - fragmentWidthOffset; w++)
                {
                    int newR = 0;
                    for (int i = -fragmentHeightHalf; i <= fragmentHeightHalf; i++)
                    {
                        for (int j = -fragmentWidthHalf; j <= fragmentWidthHalf; j++)
                        {
                            int temp = correlationFragmentBitmap.GetPixel(fragmentWidthHalf + j, fragmentHeightHalf + i).R;
                            newR += (int)(temp * inputBitmap.GetPixel(w + j, h + i).R);
                        }
                    }
                    newR = newR / (heightFragment * widthFragment);

                    newR = newR < 0 ? 0 : (newR > 255 ? 255 : newR);
                    Color newColor = Color.FromArgb(newR, newR, newR);
                    outputBitmap.SetPixel(w, h, newColor);
                }
            }
            OutputImagePictureBox.Image = outputBitmap;
        }
    }
}
