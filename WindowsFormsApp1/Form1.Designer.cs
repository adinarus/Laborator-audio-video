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
            this.button_image_modify = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeta)).BeginInit();
            this.SuspendLayout();
            // 
            // button_image_upload
            // 
            this.button_image_upload.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_image_upload.Location = new System.Drawing.Point(120, 60);
            this.button_image_upload.Name = "button_image_upload";
            this.button_image_upload.Size = new System.Drawing.Size(131, 36);
            this.button_image_upload.TabIndex = 0;
            this.button_image_upload.Text = "Upload image";
            this.button_image_upload.UseVisualStyleBackColor = false;
            this.button_image_upload.Click += new System.EventHandler(this.button_image_upload_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(571, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(431, 292);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button_histogram
            // 
            this.button_histogram.Location = new System.Drawing.Point(108, 137);
            this.button_histogram.Name = "button_histogram";
            this.button_histogram.Size = new System.Drawing.Size(143, 36);
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
            this.numericUpDownAlpha.Location = new System.Drawing.Point(161, 223);
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
            this.numericUpDownAlpha.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDownBeta
            // 
            this.numericUpDownBeta.Location = new System.Drawing.Point(161, 306);
            this.numericUpDownBeta.Name = "numericUpDownBeta";
            this.numericUpDownBeta.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownBeta.TabIndex = 4;
            // 
            // button_image_modify
            // 
            this.button_image_modify.Location = new System.Drawing.Point(305, 250);
            this.button_image_modify.Name = "button_image_modify";
            this.button_image_modify.Size = new System.Drawing.Size(122, 51);
            this.button_image_modify.TabIndex = 5;
            this.button_image_modify.Text = "Modify image";
            this.button_image_modify.UseVisualStyleBackColor = true;
            this.button_image_modify.Click += new System.EventHandler(this.button_image_modify_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 450);
            this.Controls.Add(this.button_image_modify);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_image_upload;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_histogram;
        private System.Windows.Forms.NumericUpDown numericUpDownAlpha;
        private System.Windows.Forms.NumericUpDown numericUpDownBeta;
        private System.Windows.Forms.Button button_image_modify;
    }
}

