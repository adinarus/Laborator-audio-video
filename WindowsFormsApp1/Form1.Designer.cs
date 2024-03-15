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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGamma)).BeginInit();
            this.SuspendLayout();
            // 
            // button_image_upload
            // 
            this.button_image_upload.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_image_upload.Location = new System.Drawing.Point(32, 58);
            this.button_image_upload.Name = "button_image_upload";
            this.button_image_upload.Size = new System.Drawing.Size(147, 36);
            this.button_image_upload.TabIndex = 0;
            this.button_image_upload.Text = "Upload image";
            this.button_image_upload.UseVisualStyleBackColor = false;
            this.button_image_upload.Click += new System.EventHandler(this.button_image_upload_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(446, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(654, 388);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button_histogram
            // 
            this.button_histogram.Location = new System.Drawing.Point(32, 120);
            this.button_histogram.Name = "button_histogram";
            this.button_histogram.Size = new System.Drawing.Size(147, 36);
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
            this.numericUpDownAlpha.Location = new System.Drawing.Point(186, 194);
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
            this.numericUpDownBeta.Location = new System.Drawing.Point(185, 222);
            this.numericUpDownBeta.Name = "numericUpDownBeta";
            this.numericUpDownBeta.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownBeta.TabIndex = 4;
            // 
            // button_contrast_brightness
            // 
            this.button_contrast_brightness.Location = new System.Drawing.Point(32, 194);
            this.button_contrast_brightness.Name = "button_contrast_brightness";
            this.button_contrast_brightness.Size = new System.Drawing.Size(147, 51);
            this.button_contrast_brightness.TabIndex = 5;
            this.button_contrast_brightness.Text = "Contrast/Brightness";
            this.button_contrast_brightness.UseVisualStyleBackColor = true;
            this.button_contrast_brightness.Click += new System.EventHandler(this.button_contrast_brightness_Click);
            // 
            // button_gamma
            // 
            this.button_gamma.Location = new System.Drawing.Point(32, 284);
            this.button_gamma.Name = "button_gamma";
            this.button_gamma.Size = new System.Drawing.Size(147, 35);
            this.button_gamma.TabIndex = 6;
            this.button_gamma.Text = "button_Gamma";
            this.button_gamma.UseVisualStyleBackColor = true;
            this.button_gamma.Click += new System.EventHandler(this.button_gamma_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(200, 58);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(121, 36);
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
            this.numericUpDownGamma.Location = new System.Drawing.Point(186, 291);
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
            this.buttonFiltering.Location = new System.Drawing.Point(69, 347);
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
            this.checkBoxRed.Location = new System.Drawing.Point(69, 389);
            this.checkBoxRed.Name = "checkBoxRed";
            this.checkBoxRed.Size = new System.Drawing.Size(55, 20);
            this.checkBoxRed.TabIndex = 14;
            this.checkBoxRed.Text = "Red";
            this.checkBoxRed.UseVisualStyleBackColor = true;
            // 
            // checkBoxGreen
            // 
            this.checkBoxGreen.AutoSize = true;
            this.checkBoxGreen.Location = new System.Drawing.Point(69, 415);
            this.checkBoxGreen.Name = "checkBoxGreen";
            this.checkBoxGreen.Size = new System.Drawing.Size(66, 20);
            this.checkBoxGreen.TabIndex = 15;
            this.checkBoxGreen.Text = "Green";
            this.checkBoxGreen.UseVisualStyleBackColor = true;
            // 
            // checkBoxBlue
            // 
            this.checkBoxBlue.AutoSize = true;
            this.checkBoxBlue.Location = new System.Drawing.Point(68, 441);
            this.checkBoxBlue.Name = "checkBoxBlue";
            this.checkBoxBlue.Size = new System.Drawing.Size(56, 20);
            this.checkBoxBlue.TabIndex = 16;
            this.checkBoxBlue.Text = "Blue";
            this.checkBoxBlue.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 526);
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
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_image_upload);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGamma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_image_upload;
        private System.Windows.Forms.PictureBox pictureBox1;
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
    }
}

