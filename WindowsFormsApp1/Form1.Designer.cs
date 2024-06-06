namespace WindowsFormsApp1
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
            this.button_image_upload = new System.Windows.Forms.Button();
            this.pictureBoxFull = new System.Windows.Forms.PictureBox();
            this.button_histogram = new System.Windows.Forms.Button();
            this.numericUpDownAlpha = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBeta = new System.Windows.Forms.NumericUpDown();
            this.button_contrast_brightness = new System.Windows.Forms.Button();
            this.button_gamma = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.numericUpDownGamma = new System.Windows.Forms.NumericUpDown();
            this.buttonFiltering = new System.Windows.Forms.Button();
            this.checkBoxRed = new System.Windows.Forms.CheckBox();
            this.checkBoxGreen = new System.Windows.Forms.CheckBox();
            this.checkBoxBlue = new System.Windows.Forms.CheckBox();
            this.pictureBoxROI = new System.Windows.Forms.PictureBox();
            this.buttonScale = new System.Windows.Forms.Button();
            this.buttonRotate = new System.Windows.Forms.Button();
            this.numericUpDownResize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRotate = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.buttonResizeWidthHeight = new System.Windows.Forms.Button();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonVideoUpload = new System.Windows.Forms.Button();
            this.buttonPlayVideo = new System.Windows.Forms.Button();
            this.buttonBgSubstract = new System.Windows.Forms.Button();
            this.buttonBlending = new System.Windows.Forms.Button();
            this.buttonConvertGrayscale = new System.Windows.Forms.Button();
            this.buttonSaveVideo = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonTransition = new System.Windows.Forms.Button();
            this.comboBoxTransition = new System.Windows.Forms.ComboBox();
            this.buttonAudio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxROI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // button_image_upload
            // 
            this.button_image_upload.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_image_upload.Location = new System.Drawing.Point(24, 70);
            this.button_image_upload.Name = "button_image_upload";
            this.button_image_upload.Size = new System.Drawing.Size(147, 44);
            this.button_image_upload.TabIndex = 0;
            this.button_image_upload.Text = "Upload image";
            this.button_image_upload.UseVisualStyleBackColor = false;
            this.button_image_upload.Click += new System.EventHandler(this.button_image_upload_Click);
            // 
            // pictureBoxFull
            // 
            this.pictureBoxFull.Location = new System.Drawing.Point(339, 138);
            this.pictureBoxFull.Name = "pictureBoxFull";
            this.pictureBoxFull.Size = new System.Drawing.Size(1120, 776);
            this.pictureBoxFull.TabIndex = 1;
            this.pictureBoxFull.TabStop = false;
            this.pictureBoxFull.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBoxFull.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBoxFull.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBoxFull.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button_histogram
            // 
            this.button_histogram.Location = new System.Drawing.Point(32, 211);
            this.button_histogram.Name = "button_histogram";
            this.button_histogram.Size = new System.Drawing.Size(122, 36);
            this.button_histogram.TabIndex = 2;
            this.button_histogram.Text = "Create histogram";
            this.button_histogram.UseVisualStyleBackColor = true;
            this.button_histogram.Click += new System.EventHandler(this.button_histogram_Click);
            // 
            // numericUpDownAlpha
            // 
            this.numericUpDownAlpha.DecimalPlaces = 2;
            this.numericUpDownAlpha.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownAlpha.Location = new System.Drawing.Point(186, 279);
            this.numericUpDownAlpha.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownAlpha.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAlpha.Name = "numericUpDownAlpha";
            this.numericUpDownAlpha.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownAlpha.TabIndex = 3;
            this.numericUpDownAlpha.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownBeta
            // 
            this.numericUpDownBeta.Location = new System.Drawing.Point(185, 307);
            this.numericUpDownBeta.Name = "numericUpDownBeta";
            this.numericUpDownBeta.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownBeta.TabIndex = 4;
            // 
            // button_contrast_brightness
            // 
            this.button_contrast_brightness.Location = new System.Drawing.Point(32, 279);
            this.button_contrast_brightness.Name = "button_contrast_brightness";
            this.button_contrast_brightness.Size = new System.Drawing.Size(147, 51);
            this.button_contrast_brightness.TabIndex = 5;
            this.button_contrast_brightness.Text = "Contrast/Brightness";
            this.button_contrast_brightness.UseVisualStyleBackColor = true;
            this.button_contrast_brightness.Click += new System.EventHandler(this.button_contrast_brightness_Click);
            // 
            // button_gamma
            // 
            this.button_gamma.Location = new System.Drawing.Point(32, 369);
            this.button_gamma.Name = "button_gamma";
            this.button_gamma.Size = new System.Drawing.Size(147, 35);
            this.button_gamma.TabIndex = 6;
            this.button_gamma.Text = "button_Gamma";
            this.button_gamma.UseVisualStyleBackColor = true;
            this.button_gamma.Click += new System.EventHandler(this.button_gamma_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(185, 70);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(121, 44);
            this.buttonReset.TabIndex = 8;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // numericUpDownGamma
            // 
            this.numericUpDownGamma.DecimalPlaces = 2;
            this.numericUpDownGamma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownGamma.Location = new System.Drawing.Point(186, 376);
            this.numericUpDownGamma.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownGamma.Name = "numericUpDownGamma";
            this.numericUpDownGamma.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownGamma.TabIndex = 9;
            this.numericUpDownGamma.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonFiltering
            // 
            this.buttonFiltering.Location = new System.Drawing.Point(32, 432);
            this.buttonFiltering.Name = "buttonFiltering";
            this.buttonFiltering.Size = new System.Drawing.Size(71, 36);
            this.buttonFiltering.TabIndex = 10;
            this.buttonFiltering.Text = "Filter";
            this.buttonFiltering.UseVisualStyleBackColor = true;
            this.buttonFiltering.Click += new System.EventHandler(this.buttonFiltering_Click);
            // 
            // checkBoxRed
            // 
            this.checkBoxRed.AutoSize = true;
            this.checkBoxRed.Location = new System.Drawing.Point(123, 441);
            this.checkBoxRed.Name = "checkBoxRed";
            this.checkBoxRed.Size = new System.Drawing.Size(55, 20);
            this.checkBoxRed.TabIndex = 14;
            this.checkBoxRed.Text = "Red";
            this.checkBoxRed.UseVisualStyleBackColor = true;
            // 
            // checkBoxGreen
            // 
            this.checkBoxGreen.AutoSize = true;
            this.checkBoxGreen.Location = new System.Drawing.Point(186, 441);
            this.checkBoxGreen.Name = "checkBoxGreen";
            this.checkBoxGreen.Size = new System.Drawing.Size(66, 20);
            this.checkBoxGreen.TabIndex = 15;
            this.checkBoxGreen.Text = "Green";
            this.checkBoxGreen.UseVisualStyleBackColor = true;
            // 
            // checkBoxBlue
            // 
            this.checkBoxBlue.AutoSize = true;
            this.checkBoxBlue.Location = new System.Drawing.Point(258, 441);
            this.checkBoxBlue.Name = "checkBoxBlue";
            this.checkBoxBlue.Size = new System.Drawing.Size(56, 20);
            this.checkBoxBlue.TabIndex = 16;
            this.checkBoxBlue.Text = "Blue";
            this.checkBoxBlue.UseVisualStyleBackColor = true;
            // 
            // pictureBoxROI
            // 
            this.pictureBoxROI.Location = new System.Drawing.Point(1477, 447);
            this.pictureBoxROI.Name = "pictureBoxROI";
            this.pictureBoxROI.Size = new System.Drawing.Size(435, 426);
            this.pictureBoxROI.TabIndex = 17;
            this.pictureBoxROI.TabStop = false;
            // 
            // buttonScale
            // 
            this.buttonScale.Location = new System.Drawing.Point(32, 512);
            this.buttonScale.Name = "buttonScale";
            this.buttonScale.Size = new System.Drawing.Size(122, 34);
            this.buttonScale.TabIndex = 18;
            this.buttonScale.Text = "Scale image";
            this.buttonScale.UseVisualStyleBackColor = true;
            this.buttonScale.Click += new System.EventHandler(this.buttonScale_Click);
            // 
            // buttonRotate
            // 
            this.buttonRotate.Location = new System.Drawing.Point(32, 639);
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.Size = new System.Drawing.Size(122, 31);
            this.buttonRotate.TabIndex = 19;
            this.buttonRotate.Text = "Rotate image";
            this.buttonRotate.UseVisualStyleBackColor = true;
            this.buttonRotate.Click += new System.EventHandler(this.buttonRotate_Click);
            // 
            // numericUpDownResize
            // 
            this.numericUpDownResize.DecimalPlaces = 2;
            this.numericUpDownResize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownResize.Location = new System.Drawing.Point(172, 519);
            this.numericUpDownResize.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownResize.Name = "numericUpDownResize";
            this.numericUpDownResize.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownResize.TabIndex = 20;
            this.numericUpDownResize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownRotate
            // 
            this.numericUpDownRotate.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRotate.Location = new System.Drawing.Point(172, 644);
            this.numericUpDownRotate.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownRotate.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownRotate.Name = "numericUpDownRotate";
            this.numericUpDownRotate.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownRotate.TabIndex = 21;
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(226, 564);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(80, 22);
            this.numericUpDownWidth.TabIndex = 23;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // buttonResizeWidthHeight
            // 
            this.buttonResizeWidthHeight.Location = new System.Drawing.Point(32, 574);
            this.buttonResizeWidthHeight.Name = "buttonResizeWidthHeight";
            this.buttonResizeWidthHeight.Size = new System.Drawing.Size(122, 34);
            this.buttonResizeWidthHeight.TabIndex = 22;
            this.buttonResizeWidthHeight.Text = "Resize image";
            this.buttonResizeWidthHeight.UseVisualStyleBackColor = true;
            this.buttonResizeWidthHeight.Click += new System.EventHandler(this.buttonResizeWidthHeight_Click);
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(226, 592);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(80, 22);
            this.numericUpDownHeight.TabIndex = 24;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 566);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 592);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "height";
            // 
            // buttonVideoUpload
            // 
            this.buttonVideoUpload.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonVideoUpload.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonVideoUpload.Location = new System.Drawing.Point(1555, 52);
            this.buttonVideoUpload.Name = "buttonVideoUpload";
            this.buttonVideoUpload.Size = new System.Drawing.Size(120, 44);
            this.buttonVideoUpload.TabIndex = 27;
            this.buttonVideoUpload.Text = "Upload video";
            this.buttonVideoUpload.UseVisualStyleBackColor = false;
            this.buttonVideoUpload.Click += new System.EventHandler(this.buttonVideoUpload_Click);
            // 
            // buttonPlayVideo
            // 
            this.buttonPlayVideo.Location = new System.Drawing.Point(1705, 50);
            this.buttonPlayVideo.Name = "buttonPlayVideo";
            this.buttonPlayVideo.Size = new System.Drawing.Size(117, 44);
            this.buttonPlayVideo.TabIndex = 28;
            this.buttonPlayVideo.Text = "Play video";
            this.buttonPlayVideo.UseVisualStyleBackColor = true;
            this.buttonPlayVideo.Click += new System.EventHandler(this.buttonPlayVideo_Click);
            // 
            // buttonBgSubstract
            // 
            this.buttonBgSubstract.Location = new System.Drawing.Point(1717, 264);
            this.buttonBgSubstract.Name = "buttonBgSubstract";
            this.buttonBgSubstract.Size = new System.Drawing.Size(110, 44);
            this.buttonBgSubstract.TabIndex = 31;
            this.buttonBgSubstract.Text = "Substract background";
            this.buttonBgSubstract.UseVisualStyleBackColor = true;
            this.buttonBgSubstract.Click += new System.EventHandler(this.buttonBgSubstract_Click);
            // 
            // buttonBlending
            // 
            this.buttonBlending.Location = new System.Drawing.Point(47, 676);
            this.buttonBlending.Name = "buttonBlending";
            this.buttonBlending.Size = new System.Drawing.Size(107, 50);
            this.buttonBlending.TabIndex = 32;
            this.buttonBlending.Text = "Image blending";
            this.buttonBlending.UseVisualStyleBackColor = true;
            this.buttonBlending.Click += new System.EventHandler(this.buttonBlending_Click);
            // 
            // buttonConvertGrayscale
            // 
            this.buttonConvertGrayscale.Location = new System.Drawing.Point(185, 211);
            this.buttonConvertGrayscale.Name = "buttonConvertGrayscale";
            this.buttonConvertGrayscale.Size = new System.Drawing.Size(106, 36);
            this.buttonConvertGrayscale.TabIndex = 33;
            this.buttonConvertGrayscale.Text = "Grayscale";
            this.buttonConvertGrayscale.UseVisualStyleBackColor = true;
            this.buttonConvertGrayscale.Click += new System.EventHandler(this.buttonConvertGrayscale_Click);
            // 
            // buttonSaveVideo
            // 
            this.buttonSaveVideo.Location = new System.Drawing.Point(1717, 181);
            this.buttonSaveVideo.Name = "buttonSaveVideo";
            this.buttonSaveVideo.Size = new System.Drawing.Size(105, 45);
            this.buttonSaveVideo.TabIndex = 34;
            this.buttonSaveVideo.Text = "Save to new Video";
            this.buttonSaveVideo.UseVisualStyleBackColor = true;
            this.buttonSaveVideo.Click += new System.EventHandler(this.buttonSaveVideo_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(704, 50);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(167, 29);
            this.labelMessage.TabIndex = 35;
            this.labelMessage.Text = "Message here";
            this.labelMessage.Visible = false;
            // 
            // buttonTransition
            // 
            this.buttonTransition.Location = new System.Drawing.Point(1717, 376);
            this.buttonTransition.Name = "buttonTransition";
            this.buttonTransition.Size = new System.Drawing.Size(120, 40);
            this.buttonTransition.TabIndex = 36;
            this.buttonTransition.Text = "Transition";
            this.buttonTransition.UseVisualStyleBackColor = true;
            this.buttonTransition.Click += new System.EventHandler(this.buttonTransition_Click);
            // 
            // comboBoxTransition
            // 
            this.comboBoxTransition.FormattingEnabled = true;
            this.comboBoxTransition.Items.AddRange(new object[] {
            "Abrupt",
            "Cross-fade",
            "Fade to black"});
            this.comboBoxTransition.Location = new System.Drawing.Point(1566, 385);
            this.comboBoxTransition.Name = "comboBoxTransition";
            this.comboBoxTransition.Size = new System.Drawing.Size(121, 24);
            this.comboBoxTransition.TabIndex = 37;
            // 
            // buttonAudio
            // 
            this.buttonAudio.Location = new System.Drawing.Point(785, 920);
            this.buttonAudio.Name = "buttonAudio";
            this.buttonAudio.Size = new System.Drawing.Size(153, 58);
            this.buttonAudio.TabIndex = 38;
            this.buttonAudio.Text = "Audio Editor";
            this.buttonAudio.UseVisualStyleBackColor = true;
            this.buttonAudio.Click += new System.EventHandler(this.buttonAudio_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.buttonAudio);
            this.Controls.Add(this.comboBoxTransition);
            this.Controls.Add(this.buttonTransition);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonSaveVideo);
            this.Controls.Add(this.buttonConvertGrayscale);
            this.Controls.Add(this.buttonBlending);
            this.Controls.Add(this.buttonBgSubstract);
            this.Controls.Add(this.buttonPlayVideo);
            this.Controls.Add(this.buttonVideoUpload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownHeight);
            this.Controls.Add(this.numericUpDownWidth);
            this.Controls.Add(this.buttonResizeWidthHeight);
            this.Controls.Add(this.numericUpDownRotate);
            this.Controls.Add(this.numericUpDownResize);
            this.Controls.Add(this.buttonRotate);
            this.Controls.Add(this.buttonScale);
            this.Controls.Add(this.pictureBoxROI);
            this.Controls.Add(this.checkBoxBlue);
            this.Controls.Add(this.checkBoxGreen);
            this.Controls.Add(this.checkBoxRed);
            this.Controls.Add(this.buttonFiltering);
            this.Controls.Add(this.numericUpDownGamma);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.button_gamma);
            this.Controls.Add(this.button_contrast_brightness);
            this.Controls.Add(this.numericUpDownBeta);
            this.Controls.Add(this.numericUpDownAlpha);
            this.Controls.Add(this.button_histogram);
            this.Controls.Add(this.pictureBoxFull);
            this.Controls.Add(this.button_image_upload);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxROI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_image_upload;
        private System.Windows.Forms.PictureBox pictureBoxFull;
        private System.Windows.Forms.Button button_histogram;
        private System.Windows.Forms.NumericUpDown numericUpDownAlpha;
        private System.Windows.Forms.NumericUpDown numericUpDownBeta;
        private System.Windows.Forms.Button button_contrast_brightness;
        private System.Windows.Forms.Button button_gamma;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.NumericUpDown numericUpDownGamma;
        private System.Windows.Forms.Button buttonFiltering;
        private System.Windows.Forms.CheckBox checkBoxRed;
        private System.Windows.Forms.CheckBox checkBoxGreen;
        private System.Windows.Forms.CheckBox checkBoxBlue;
        private System.Windows.Forms.PictureBox pictureBoxROI;
        private System.Windows.Forms.Button buttonScale;
        private System.Windows.Forms.Button buttonRotate;
        private System.Windows.Forms.NumericUpDown numericUpDownResize;
        private System.Windows.Forms.NumericUpDown numericUpDownRotate;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Button buttonResizeWidthHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonVideoUpload;
        private System.Windows.Forms.Button buttonPlayVideo;
        private System.Windows.Forms.Button buttonBgSubstract;
        private System.Windows.Forms.Button buttonBlending;
        private System.Windows.Forms.Button buttonConvertGrayscale;
        private System.Windows.Forms.Button buttonSaveVideo;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonTransition;
        private System.Windows.Forms.ComboBox comboBoxTransition;
        private System.Windows.Forms.Button buttonAudio;
    }
}

