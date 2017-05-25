namespace WumpusProject
{
    partial class CaveDesign
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
            System.Windows.Forms.Button LeftBttn;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaveDesign));
            this.RightBttn = new System.Windows.Forms.Button();
            this.StraightBttn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StatsDisplay = new System.Windows.Forms.Button();
            this.wumpusBox = new System.Windows.Forms.PictureBox();
            this.pitBox = new System.Windows.Forms.PictureBox();
            this.batBox = new System.Windows.Forms.PictureBox();
            this.hazardLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buySecretsBtn = new System.Windows.Forms.Button();
            this.buyArrowBtn = new System.Windows.Forms.Button();
            LeftBttn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wumpusBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftBttn
            // 
            LeftBttn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            LeftBttn.Location = new System.Drawing.Point(72, 105);
            LeftBttn.Name = "LeftBttn";
            LeftBttn.Size = new System.Drawing.Size(44, 68);
            LeftBttn.TabIndex = 1;
            LeftBttn.Text = "<<";
            LeftBttn.UseVisualStyleBackColor = false;
            LeftBttn.Click += new System.EventHandler(this.LeftBttn_Click);
            // 
            // RightBttn
            // 
            this.RightBttn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RightBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RightBttn.Location = new System.Drawing.Point(569, 405);
            this.RightBttn.Name = "RightBttn";
            this.RightBttn.Size = new System.Drawing.Size(43, 68);
            this.RightBttn.TabIndex = 0;
            this.RightBttn.Text = ">>";
            this.RightBttn.UseVisualStyleBackColor = false;
            this.RightBttn.Click += new System.EventHandler(this.RightBttn_Click);
            // 
            // StraightBttn
            // 
            this.StraightBttn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StraightBttn.Location = new System.Drawing.Point(306, 552);
            this.StraightBttn.Name = "StraightBttn";
            this.StraightBttn.Size = new System.Drawing.Size(85, 36);
            this.StraightBttn.TabIndex = 2;
            this.StraightBttn.Text = "^^";
            this.StraightBttn.UseVisualStyleBackColor = false;
            this.StraightBttn.Click += new System.EventHandler(this.StraightBttn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WumpusProject.Properties.Resources._13_stickman_walking_gif_;
            this.pictureBox1.Location = new System.Drawing.Point(247, 138);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 224);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // StatsDisplay
            // 
            this.StatsDisplay.Location = new System.Drawing.Point(569, 12);
            this.StatsDisplay.Name = "StatsDisplay";
            this.StatsDisplay.Size = new System.Drawing.Size(103, 45);
            this.StatsDisplay.TabIndex = 4;
            this.StatsDisplay.Text = "Stats";
            this.StatsDisplay.UseVisualStyleBackColor = true;
            this.StatsDisplay.Click += new System.EventHandler(this.StatsDisplay_Click);
            // 
            // wumpusBox
            // 
            this.wumpusBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.wumpusBox.Image = global::WumpusProject.Properties.Resources.blobby;
            this.wumpusBox.Location = new System.Drawing.Point(236, 39);
            this.wumpusBox.Name = "wumpusBox";
            this.wumpusBox.Size = new System.Drawing.Size(218, 180);
            this.wumpusBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.wumpusBox.TabIndex = 5;
            this.wumpusBox.TabStop = false;
            // 
            // pitBox
            // 
            this.pitBox.Image = global::WumpusProject.Properties.Resources.pit;
            this.pitBox.Location = new System.Drawing.Point(82, 238);
            this.pitBox.Name = "pitBox";
            this.pitBox.Size = new System.Drawing.Size(138, 112);
            this.pitBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pitBox.TabIndex = 6;
            this.pitBox.TabStop = false;
            // 
            // batBox
            // 
            this.batBox.Image = global::WumpusProject.Properties.Resources.vampire_bat_300x236;
            this.batBox.Location = new System.Drawing.Point(264, 405);
            this.batBox.Name = "batBox";
            this.batBox.Size = new System.Drawing.Size(151, 114);
            this.batBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.batBox.TabIndex = 7;
            this.batBox.TabStop = false;
            // 
            // hazardLbl
            // 
            this.hazardLbl.AutoSize = true;
            this.hazardLbl.Location = new System.Drawing.Point(12, 486);
            this.hazardLbl.Name = "hazardLbl";
            this.hazardLbl.Size = new System.Drawing.Size(0, 20);
            this.hazardLbl.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 9;
            // 
            // buySecretsBtn
            // 
            this.buySecretsBtn.Location = new System.Drawing.Point(16, 13);
            this.buySecretsBtn.Name = "buySecretsBtn";
            this.buySecretsBtn.Size = new System.Drawing.Size(103, 32);
            this.buySecretsBtn.TabIndex = 10;
            this.buySecretsBtn.Text = "Buy Secrets";
            this.buySecretsBtn.UseVisualStyleBackColor = true;
            this.buySecretsBtn.Click += new System.EventHandler(this.buySecretsBtn_Click);
            // 
            // buyArrowBtn
            // 
            this.buyArrowBtn.Location = new System.Drawing.Point(16, 51);
            this.buyArrowBtn.Name = "buyArrowBtn";
            this.buyArrowBtn.Size = new System.Drawing.Size(100, 31);
            this.buyArrowBtn.TabIndex = 11;
            this.buyArrowBtn.Text = "Buy Arrows";
            this.buyArrowBtn.UseVisualStyleBackColor = true;
            this.buyArrowBtn.Click += new System.EventHandler(this.buyArrowBtn_Click);
            // 
            // CaveDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 590);
            this.Controls.Add(this.buyArrowBtn);
            this.Controls.Add(this.buySecretsBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hazardLbl);
            this.Controls.Add(this.batBox);
            this.Controls.Add(this.pitBox);
            this.Controls.Add(this.wumpusBox);
            this.Controls.Add(this.StatsDisplay);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.StraightBttn);
            this.Controls.Add(LeftBttn);
            this.Controls.Add(this.RightBttn);
            this.DoubleBuffered = true;
            this.Name = "CaveDesign";
            this.Text = "CaveDesign";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wumpusBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RightBttn;
        private System.Windows.Forms.Button StraightBttn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button StatsDisplay;
        private System.Windows.Forms.PictureBox wumpusBox;
        private System.Windows.Forms.PictureBox pitBox;
        private System.Windows.Forms.PictureBox batBox;
        private System.Windows.Forms.Label hazardLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buySecretsBtn;
        private System.Windows.Forms.Button buyArrowBtn;
    }
}