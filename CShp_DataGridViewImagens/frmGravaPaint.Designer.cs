namespace Geometricamente_V1
{
    partial class frmGravaPaint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGravaPaint));
            this.picDesenha = new System.Windows.Forms.PictureBox();
            this.nud_FPS = new System.Windows.Forms.NumericUpDown();
            this.cb_screenSelector = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_BitRate = new System.Windows.Forms.ComboBox();
            this.cb_VideoCodec = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDesenha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // picDesenha
            // 
            this.picDesenha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picDesenha.BackColor = System.Drawing.Color.Silver;
            this.picDesenha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDesenha.Image = ((System.Drawing.Image)(resources.GetObject("picDesenha.Image")));
            this.picDesenha.Location = new System.Drawing.Point(104, 100);
            this.picDesenha.Margin = new System.Windows.Forms.Padding(2);
            this.picDesenha.Name = "picDesenha";
            this.picDesenha.Size = new System.Drawing.Size(134, 138);
            this.picDesenha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDesenha.TabIndex = 20;
            this.picDesenha.TabStop = false;
            this.picDesenha.Click += new System.EventHandler(this.picDesenha_Click);
            // 
            // nud_FPS
            // 
            this.nud_FPS.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_FPS.Location = new System.Drawing.Point(248, 50);
            this.nud_FPS.Margin = new System.Windows.Forms.Padding(2);
            this.nud_FPS.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nud_FPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_FPS.Name = "nud_FPS";
            this.nud_FPS.Size = new System.Drawing.Size(75, 25);
            this.nud_FPS.TabIndex = 26;
            this.nud_FPS.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_FPS.Visible = false;
            // 
            // cb_screenSelector
            // 
            this.cb_screenSelector.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_screenSelector.FormattingEnabled = true;
            this.cb_screenSelector.Location = new System.Drawing.Point(92, 47);
            this.cb_screenSelector.Margin = new System.Windows.Forms.Padding(2);
            this.cb_screenSelector.Name = "cb_screenSelector";
            this.cb_screenSelector.Size = new System.Drawing.Size(102, 25);
            this.cb_screenSelector.TabIndex = 29;
            this.cb_screenSelector.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Screens:";
            this.label5.Visible = false;
            // 
            // cb_BitRate
            // 
            this.cb_BitRate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_BitRate.FormattingEnabled = true;
            this.cb_BitRate.Location = new System.Drawing.Point(248, 19);
            this.cb_BitRate.Margin = new System.Windows.Forms.Padding(2);
            this.cb_BitRate.Name = "cb_BitRate";
            this.cb_BitRate.Size = new System.Drawing.Size(76, 25);
            this.cb_BitRate.TabIndex = 24;
            this.cb_BitRate.Visible = false;
            // 
            // cb_VideoCodec
            // 
            this.cb_VideoCodec.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_VideoCodec.FormattingEnabled = true;
            this.cb_VideoCodec.Location = new System.Drawing.Point(92, 21);
            this.cb_VideoCodec.Margin = new System.Windows.Forms.Padding(2);
            this.cb_VideoCodec.Name = "cb_VideoCodec";
            this.cb_VideoCodec.Size = new System.Drawing.Size(102, 25);
            this.cb_VideoCodec.TabIndex = 21;
            this.cb_VideoCodec.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(200, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "FPS:";
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "VideoCodec:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(192, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "BitRate:";
            this.label2.Visible = false;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.Location = new System.Drawing.Point(2, 262);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(46, 49);
            this.btnSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSettings.TabIndex = 30;
            this.btnSettings.TabStop = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // frmGravaPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.nud_FPS);
            this.Controls.Add(this.cb_screenSelector);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_BitRate);
            this.Controls.Add(this.cb_VideoCodec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picDesenha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGravaPaint";
            this.Text = "GRAVAR TELA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGravaPaint_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picDesenha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDesenha;
        private System.Windows.Forms.NumericUpDown nud_FPS;
        private System.Windows.Forms.ComboBox cb_screenSelector;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_BitRate;
        private System.Windows.Forms.ComboBox cb_VideoCodec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnSettings;
    }
}