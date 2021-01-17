namespace CarlosSeptica
{
    partial class InterfaceForm
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonStart = new System.Windows.Forms.Button();
            this.difficulty = new System.Windows.Forms.GroupBox();
            this.radioButtonImmortal = new System.Windows.Forms.RadioButton();
            this.radioButtonHard = new System.Windows.Forms.RadioButton();
            this.radioButtonMedium = new System.Windows.Forms.RadioButton();
            this.radioButtonEz = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.difficulty.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.AccessibleName = "pictureBox";
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(956, 654);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(104, 410);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start Game!";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // difficulty
            // 
            this.difficulty.Controls.Add(this.radioButtonImmortal);
            this.difficulty.Controls.Add(this.radioButtonHard);
            this.difficulty.Controls.Add(this.radioButtonMedium);
            this.difficulty.Controls.Add(this.radioButtonEz);
            this.difficulty.Location = new System.Drawing.Point(31, 31);
            this.difficulty.Name = "difficulty";
            this.difficulty.Size = new System.Drawing.Size(136, 113);
            this.difficulty.TabIndex = 0;
            this.difficulty.TabStop = false;
            this.difficulty.Text = "Difficulty";
            // 
            // radioButtonImmortal
            // 
            this.radioButtonImmortal.AutoSize = true;
            this.radioButtonImmortal.Location = new System.Drawing.Point(7, 89);
            this.radioButtonImmortal.Name = "radioButtonImmortal";
            this.radioButtonImmortal.Size = new System.Drawing.Size(64, 17);
            this.radioButtonImmortal.TabIndex = 3;
            this.radioButtonImmortal.TabStop = true;
            this.radioButtonImmortal.Text = "Immortal";
            this.radioButtonImmortal.UseVisualStyleBackColor = true;
            // 
            // radioButtonHard
            // 
            this.radioButtonHard.AutoSize = true;
            this.radioButtonHard.Location = new System.Drawing.Point(7, 66);
            this.radioButtonHard.Name = "radioButtonHard";
            this.radioButtonHard.Size = new System.Drawing.Size(48, 17);
            this.radioButtonHard.TabIndex = 2;
            this.radioButtonHard.TabStop = true;
            this.radioButtonHard.Text = "Hard";
            this.radioButtonHard.UseVisualStyleBackColor = true;
            // 
            // radioButtonMedium
            // 
            this.radioButtonMedium.AutoSize = true;
            this.radioButtonMedium.Location = new System.Drawing.Point(7, 43);
            this.radioButtonMedium.Name = "radioButtonMedium";
            this.radioButtonMedium.Size = new System.Drawing.Size(62, 17);
            this.radioButtonMedium.TabIndex = 1;
            this.radioButtonMedium.TabStop = true;
            this.radioButtonMedium.Text = "Medium";
            this.radioButtonMedium.UseVisualStyleBackColor = true;
            // 
            // radioButtonEz
            // 
            this.radioButtonEz.AutoSize = true;
            this.radioButtonEz.Checked = true;
            this.radioButtonEz.Location = new System.Drawing.Point(7, 20);
            this.radioButtonEz.Name = "radioButtonEz";
            this.radioButtonEz.Size = new System.Drawing.Size(37, 17);
            this.radioButtonEz.TabIndex = 0;
            this.radioButtonEz.TabStop = true;
            this.radioButtonEz.Text = "Ez";
            this.radioButtonEz.UseVisualStyleBackColor = true;
            // 
            // InterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 678);
            this.Controls.Add(this.difficulty);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InterfaceForm";
            this.Text = "CarlosSeptica";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.difficulty.ResumeLayout(false);
            this.difficulty.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.GroupBox difficulty;
        private System.Windows.Forms.RadioButton radioButtonImmortal;
        private System.Windows.Forms.RadioButton radioButtonHard;
        private System.Windows.Forms.RadioButton radioButtonMedium;
        private System.Windows.Forms.RadioButton radioButtonEz;
    }
}

