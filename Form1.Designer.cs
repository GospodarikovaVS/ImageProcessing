
namespace ImageProcessing
{
    partial class ExecImagesForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecImagesForm));
            this.ControlButtonsPanel = new System.Windows.Forms.Panel();
            this.ProcessImageButton = new System.Windows.Forms.Button();
            this.KindOfProcessingComboBox = new System.Windows.Forms.ComboBox();
            this.SaveResultImage = new System.Windows.Forms.Button();
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.ImagesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.InputImagePictureBox = new System.Windows.Forms.PictureBox();
            this.OutputImagePictureBox = new System.Windows.Forms.PictureBox();
            this.PeriodicalPatternButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ControlButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagesSplitContainer)).BeginInit();
            this.ImagesSplitContainer.Panel1.SuspendLayout();
            this.ImagesSplitContainer.Panel2.SuspendLayout();
            this.ImagesSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputImagePictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlButtonsPanel
            // 
            this.ControlButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlButtonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlButtonsPanel.Controls.Add(this.ProcessImageButton);
            this.ControlButtonsPanel.Controls.Add(this.KindOfProcessingComboBox);
            this.ControlButtonsPanel.Controls.Add(this.SaveResultImage);
            this.ControlButtonsPanel.Controls.Add(this.LoadImageButton);
            this.ControlButtonsPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ControlButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlButtonsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ControlButtonsPanel.Name = "ControlButtonsPanel";
            this.ControlButtonsPanel.Size = new System.Drawing.Size(880, 46);
            this.ControlButtonsPanel.TabIndex = 0;
            // 
            // ProcessImageButton
            // 
            this.ProcessImageButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProcessImageButton.Location = new System.Drawing.Point(440, 8);
            this.ProcessImageButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProcessImageButton.Name = "ProcessImageButton";
            this.ProcessImageButton.Size = new System.Drawing.Size(155, 27);
            this.ProcessImageButton.TabIndex = 3;
            this.ProcessImageButton.Text = "Proccess image";
            this.ProcessImageButton.UseVisualStyleBackColor = true;
            this.ProcessImageButton.Click += new System.EventHandler(this.ProcessImageButton_Click);
            // 
            // KindOfProcessingComboBox
            // 
            this.KindOfProcessingComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.KindOfProcessingComboBox.FormattingEnabled = true;
            this.KindOfProcessingComboBox.Location = new System.Drawing.Point(282, 8);
            this.KindOfProcessingComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.KindOfProcessingComboBox.Name = "KindOfProcessingComboBox";
            this.KindOfProcessingComboBox.Size = new System.Drawing.Size(155, 29);
            this.KindOfProcessingComboBox.TabIndex = 2;
            // 
            // SaveResultImage
            // 
            this.SaveResultImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveResultImage.Location = new System.Drawing.Point(755, 8);
            this.SaveResultImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveResultImage.Name = "SaveResultImage";
            this.SaveResultImage.Size = new System.Drawing.Size(114, 27);
            this.SaveResultImage.TabIndex = 1;
            this.SaveResultImage.Text = "Save result";
            this.SaveResultImage.UseVisualStyleBackColor = true;
            this.SaveResultImage.Click += new System.EventHandler(this.SaveResultImage_Click);
            // 
            // LoadImageButton
            // 
            this.LoadImageButton.Location = new System.Drawing.Point(10, 8);
            this.LoadImageButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadImageButton.Name = "LoadImageButton";
            this.LoadImageButton.Size = new System.Drawing.Size(114, 27);
            this.LoadImageButton.TabIndex = 0;
            this.LoadImageButton.Text = "Load image";
            this.LoadImageButton.UseVisualStyleBackColor = true;
            this.LoadImageButton.Click += new System.EventHandler(this.LoadImageButton_Click);
            // 
            // ImagesSplitContainer
            // 
            this.ImagesSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImagesSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImagesSplitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.ImagesSplitContainer.Location = new System.Drawing.Point(0, 50);
            this.ImagesSplitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ImagesSplitContainer.Name = "ImagesSplitContainer";
            // 
            // ImagesSplitContainer.Panel1
            // 
            this.ImagesSplitContainer.Panel1.AutoScroll = true;
            this.ImagesSplitContainer.Panel1.Controls.Add(this.InputImagePictureBox);
            // 
            // ImagesSplitContainer.Panel2
            // 
            this.ImagesSplitContainer.Panel2.AutoScroll = true;
            this.ImagesSplitContainer.Panel2.Controls.Add(this.OutputImagePictureBox);
            this.ImagesSplitContainer.Size = new System.Drawing.Size(880, 500);
            this.ImagesSplitContainer.SplitterDistance = 436;
            this.ImagesSplitContainer.TabIndex = 1;
            // 
            // InputImagePictureBox
            // 
            this.InputImagePictureBox.Location = new System.Drawing.Point(-1, -1);
            this.InputImagePictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InputImagePictureBox.Name = "InputImagePictureBox";
            this.InputImagePictureBox.Size = new System.Drawing.Size(438, 491);
            this.InputImagePictureBox.TabIndex = 0;
            this.InputImagePictureBox.TabStop = false;
            // 
            // OutputImagePictureBox
            // 
            this.OutputImagePictureBox.Location = new System.Drawing.Point(0, -1);
            this.OutputImagePictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutputImagePictureBox.Name = "OutputImagePictureBox";
            this.OutputImagePictureBox.Size = new System.Drawing.Size(439, 491);
            this.OutputImagePictureBox.TabIndex = 0;
            this.OutputImagePictureBox.TabStop = false;
            // 
            // PeriodicalPatternButton
            // 
            this.PeriodicalPatternButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PeriodicalPatternButton.Location = new System.Drawing.Point(12, 13);
            this.PeriodicalPatternButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PeriodicalPatternButton.Name = "PeriodicalPatternButton";
            this.PeriodicalPatternButton.Size = new System.Drawing.Size(142, 32);
            this.PeriodicalPatternButton.TabIndex = 4;
            this.PeriodicalPatternButton.Text = "Periodical pattern";
            this.PeriodicalPatternButton.UseVisualStyleBackColor = true;
            this.PeriodicalPatternButton.Click += new System.EventHandler(this.PeriodicalPatternButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PeriodicalPatternButton);
            this.panel1.Location = new System.Drawing.Point(0, 555);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 57);
            this.panel1.TabIndex = 5;
            // 
            // ExecImagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(880, 611);
            this.Controls.Add(this.ControlButtonsPanel);
            this.Controls.Add(this.ImagesSplitContainer);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1262, 820);
            this.MinimumSize = new System.Drawing.Size(702, 460);
            this.Name = "ExecImagesForm";
            this.Text = "ExecImages";
            this.ControlButtonsPanel.ResumeLayout(false);
            this.ImagesSplitContainer.Panel1.ResumeLayout(false);
            this.ImagesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagesSplitContainer)).EndInit();
            this.ImagesSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputImagePictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ControlButtonsPanel;
        private System.Windows.Forms.SplitContainer ImagesSplitContainer;
        private System.Windows.Forms.Button SaveResultImage;
        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.Button ProcessImageButton;
        private System.Windows.Forms.ComboBox KindOfProcessingComboBox;
        private System.Windows.Forms.PictureBox InputImagePictureBox;
        private System.Windows.Forms.PictureBox OutputImagePictureBox;
        private System.Windows.Forms.Label InputMatrixLabel;
        private System.Windows.Forms.Button PeriodicalPatternButton;
        private System.Windows.Forms.Panel panel1;
    }
}

