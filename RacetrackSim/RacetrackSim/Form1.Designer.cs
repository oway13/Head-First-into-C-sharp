namespace RacetrackSim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dogPic1 = new System.Windows.Forms.PictureBox();
            this.dogPic0 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dogPic2 = new System.Windows.Forms.PictureBox();
            this.dogPic3 = new System.Windows.Forms.PictureBox();
            this.guyRadio1 = new System.Windows.Forms.RadioButton();
            this.guyRadio2 = new System.Windows.Forms.RadioButton();
            this.guyRadio0 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.raceButton = new System.Windows.Forms.Button();
            this.guyLabel2 = new System.Windows.Forms.Label();
            this.guyLabel1 = new System.Windows.Forms.Label();
            this.guyLabel0 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dogUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.betUpDown = new System.Windows.Forms.NumericUpDown();
            this.betButton = new System.Windows.Forms.Button();
            this.currentBettorLabel = new System.Windows.Forms.Label();
            this.minBetLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dogPic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dogPic0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dogPic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dogPic3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dogUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.betUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // dogPic1
            // 
            this.dogPic1.Image = global::RacetrackSim.Properties.Resources.dog;
            this.dogPic1.Location = new System.Drawing.Point(23, 70);
            this.dogPic1.Name = "dogPic1";
            this.dogPic1.Size = new System.Drawing.Size(75, 20);
            this.dogPic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.dogPic1.TabIndex = 2;
            this.dogPic1.TabStop = false;
            // 
            // dogPic0
            // 
            this.dogPic0.Image = global::RacetrackSim.Properties.Resources.dog;
            this.dogPic0.Location = new System.Drawing.Point(23, 22);
            this.dogPic0.Name = "dogPic0";
            this.dogPic0.Size = new System.Drawing.Size(75, 20);
            this.dogPic0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.dogPic0.TabIndex = 1;
            this.dogPic0.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RacetrackSim.Properties.Resources.racetrack;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(601, 202);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dogPic2
            // 
            this.dogPic2.Image = global::RacetrackSim.Properties.Resources.dog;
            this.dogPic2.Location = new System.Drawing.Point(23, 124);
            this.dogPic2.Name = "dogPic2";
            this.dogPic2.Size = new System.Drawing.Size(75, 20);
            this.dogPic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.dogPic2.TabIndex = 3;
            this.dogPic2.TabStop = false;
            // 
            // dogPic3
            // 
            this.dogPic3.Image = global::RacetrackSim.Properties.Resources.dog;
            this.dogPic3.Location = new System.Drawing.Point(23, 179);
            this.dogPic3.Name = "dogPic3";
            this.dogPic3.Size = new System.Drawing.Size(75, 20);
            this.dogPic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.dogPic3.TabIndex = 4;
            this.dogPic3.TabStop = false;
            // 
            // guyRadio1
            // 
            this.guyRadio1.AutoSize = true;
            this.guyRadio1.Location = new System.Drawing.Point(3, 53);
            this.guyRadio1.Name = "guyRadio1";
            this.guyRadio1.Size = new System.Drawing.Size(85, 17);
            this.guyRadio1.TabIndex = 6;
            this.guyRadio1.TabStop = true;
            this.guyRadio1.Text = "radioButton1";
            this.guyRadio1.UseVisualStyleBackColor = true;
            this.guyRadio1.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // guyRadio2
            // 
            this.guyRadio2.AutoSize = true;
            this.guyRadio2.Location = new System.Drawing.Point(3, 76);
            this.guyRadio2.Name = "guyRadio2";
            this.guyRadio2.Size = new System.Drawing.Size(85, 17);
            this.guyRadio2.TabIndex = 7;
            this.guyRadio2.TabStop = true;
            this.guyRadio2.Text = "radioButton1";
            this.guyRadio2.UseVisualStyleBackColor = true;
            this.guyRadio2.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // guyRadio0
            // 
            this.guyRadio0.AutoSize = true;
            this.guyRadio0.Location = new System.Drawing.Point(3, 30);
            this.guyRadio0.Name = "guyRadio0";
            this.guyRadio0.Size = new System.Drawing.Size(85, 17);
            this.guyRadio0.TabIndex = 5;
            this.guyRadio0.TabStop = true;
            this.guyRadio0.Text = "radioButton1";
            this.guyRadio0.UseVisualStyleBackColor = true;
            this.guyRadio0.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.raceButton);
            this.panel1.Controls.Add(this.guyLabel2);
            this.panel1.Controls.Add(this.guyLabel1);
            this.panel1.Controls.Add(this.guyLabel0);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dogUpDown);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.betUpDown);
            this.panel1.Controls.Add(this.betButton);
            this.panel1.Controls.Add(this.currentBettorLabel);
            this.panel1.Controls.Add(this.minBetLabel);
            this.panel1.Controls.Add(this.guyRadio0);
            this.panel1.Controls.Add(this.guyRadio2);
            this.panel1.Controls.Add(this.guyRadio1);
            this.panel1.Location = new System.Drawing.Point(12, 220);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 145);
            this.panel1.TabIndex = 8;
            // 
            // raceButton
            // 
            this.raceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raceButton.Location = new System.Drawing.Point(447, 104);
            this.raceButton.Name = "raceButton";
            this.raceButton.Size = new System.Drawing.Size(75, 33);
            this.raceButton.TabIndex = 18;
            this.raceButton.Text = "Race!";
            this.raceButton.UseVisualStyleBackColor = true;
            this.raceButton.Click += new System.EventHandler(this.raceButton_Click);
            // 
            // guyLabel2
            // 
            this.guyLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guyLabel2.Location = new System.Drawing.Point(290, 76);
            this.guyLabel2.Name = "guyLabel2";
            this.guyLabel2.Size = new System.Drawing.Size(308, 17);
            this.guyLabel2.TabIndex = 17;
            this.guyLabel2.Text = "label3";
            // 
            // guyLabel1
            // 
            this.guyLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guyLabel1.Location = new System.Drawing.Point(290, 53);
            this.guyLabel1.Name = "guyLabel1";
            this.guyLabel1.Size = new System.Drawing.Size(308, 17);
            this.guyLabel1.TabIndex = 16;
            this.guyLabel1.Text = "label3";
            // 
            // guyLabel0
            // 
            this.guyLabel0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guyLabel0.Location = new System.Drawing.Point(290, 30);
            this.guyLabel0.Name = "guyLabel0";
            this.guyLabel0.Size = new System.Drawing.Size(308, 17);
            this.guyLabel0.TabIndex = 15;
            this.guyLabel0.Text = "Joe bets ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(286, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Bets";
            // 
            // dogUpDown
            // 
            this.dogUpDown.Location = new System.Drawing.Point(290, 110);
            this.dogUpDown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.dogUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dogUpDown.Name = "dogUpDown";
            this.dogUpDown.Size = new System.Drawing.Size(67, 20);
            this.dogUpDown.TabIndex = 13;
            this.dogUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "bucks on dog number ";
            // 
            // betUpDown
            // 
            this.betUpDown.Location = new System.Drawing.Point(107, 110);
            this.betUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.betUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.betUpDown.Name = "betUpDown";
            this.betUpDown.Size = new System.Drawing.Size(57, 20);
            this.betUpDown.TabIndex = 11;
            this.betUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // betButton
            // 
            this.betButton.Location = new System.Drawing.Point(34, 110);
            this.betButton.Name = "betButton";
            this.betButton.Size = new System.Drawing.Size(67, 23);
            this.betButton.TabIndex = 10;
            this.betButton.Text = "Bets";
            this.betButton.UseVisualStyleBackColor = true;
            this.betButton.Click += new System.EventHandler(this.betButton_Click);
            // 
            // currentBettorLabel
            // 
            this.currentBettorLabel.AutoSize = true;
            this.currentBettorLabel.Location = new System.Drawing.Point(3, 115);
            this.currentBettorLabel.Name = "currentBettorLabel";
            this.currentBettorLabel.Size = new System.Drawing.Size(35, 13);
            this.currentBettorLabel.TabIndex = 9;
            this.currentBettorLabel.Text = "label1";
            // 
            // minBetLabel
            // 
            this.minBetLabel.AutoSize = true;
            this.minBetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minBetLabel.Location = new System.Drawing.Point(0, 7);
            this.minBetLabel.Name = "minBetLabel";
            this.minBetLabel.Size = new System.Drawing.Size(112, 20);
            this.minBetLabel.TabIndex = 8;
            this.minBetLabel.Text = "Minimum Bet";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 375);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dogPic3);
            this.Controls.Add(this.dogPic2);
            this.Controls.Add(this.dogPic1);
            this.Controls.Add(this.dogPic0);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "A Day at the Races";
            ((System.ComponentModel.ISupportInitialize)(this.dogPic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dogPic0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dogPic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dogPic3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dogUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.betUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox dogPic0;
        private System.Windows.Forms.PictureBox dogPic1;
        private System.Windows.Forms.PictureBox dogPic2;
        private System.Windows.Forms.PictureBox dogPic3;
        private System.Windows.Forms.RadioButton guyRadio1;
        private System.Windows.Forms.RadioButton guyRadio2;
        private System.Windows.Forms.RadioButton guyRadio0;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label guyLabel2;
        private System.Windows.Forms.Label guyLabel1;
        private System.Windows.Forms.Label guyLabel0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown dogUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown betUpDown;
        private System.Windows.Forms.Button betButton;
        private System.Windows.Forms.Label currentBettorLabel;
        private System.Windows.Forms.Label minBetLabel;
        private System.Windows.Forms.Button raceButton;
    }
}

