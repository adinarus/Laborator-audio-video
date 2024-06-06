namespace WindowsFormsApp1
{
    partial class Form2
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
            this.buttonSelectAudio = new System.Windows.Forms.Button();
            this.buttonAudioStop = new System.Windows.Forms.Button();
            this.buttonPitch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSelectAudio
            // 
            this.buttonSelectAudio.Location = new System.Drawing.Point(113, 61);
            this.buttonSelectAudio.Name = "buttonSelectAudio";
            this.buttonSelectAudio.Size = new System.Drawing.Size(134, 51);
            this.buttonSelectAudio.TabIndex = 0;
            this.buttonSelectAudio.Text = "Play audio";
            this.buttonSelectAudio.UseVisualStyleBackColor = true;
            this.buttonSelectAudio.Click += new System.EventHandler(this.buttonSelectAudio_Click);
            // 
            // buttonAudioStop
            // 
            this.buttonAudioStop.Location = new System.Drawing.Point(113, 157);
            this.buttonAudioStop.Name = "buttonAudioStop";
            this.buttonAudioStop.Size = new System.Drawing.Size(134, 50);
            this.buttonAudioStop.TabIndex = 1;
            this.buttonAudioStop.Text = "Stop";
            this.buttonAudioStop.UseVisualStyleBackColor = true;
            this.buttonAudioStop.Click += new System.EventHandler(this.buttonAudioStop_Click);
            // 
            // buttonPitch
            // 
            this.buttonPitch.Location = new System.Drawing.Point(113, 245);
            this.buttonPitch.Name = "buttonPitch";
            this.buttonPitch.Size = new System.Drawing.Size(131, 46);
            this.buttonPitch.TabIndex = 2;
            this.buttonPitch.Text = "Pitch audio";
            this.buttonPitch.UseVisualStyleBackColor = true;
            this.buttonPitch.Click += new System.EventHandler(this.buttonPitch_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 620);
            this.Controls.Add(this.buttonPitch);
            this.Controls.Add(this.buttonAudioStop);
            this.Controls.Add(this.buttonSelectAudio);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSelectAudio;
        private System.Windows.Forms.Button buttonAudioStop;
        private System.Windows.Forms.Button buttonPitch;
    }
}