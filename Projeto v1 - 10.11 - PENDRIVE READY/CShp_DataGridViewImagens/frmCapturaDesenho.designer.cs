namespace CapturaTela
{
    partial class frmCapturaDesenho
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            //if (_writer.IsOpen)
            //{
            //    _streamVideo.SignalToStop();
            //    _writer.Close();
            //    _writer.Dispose();
            //}
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapturaDesenho));
            this.cb_VideoCodec = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_BitRate = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picDesenha = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.picApaga = new System.Windows.Forms.PictureBox();
            this.picRetangulo = new System.Windows.Forms.PictureBox();
            this.picTriangulo = new System.Windows.Forms.PictureBox();
            this.picCirculo = new System.Windows.Forms.PictureBox();
            this.picQuadrado = new System.Windows.Forms.PictureBox();
            this.txt_ShapeSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_PenColor = new System.Windows.Forms.Button();
            this.pnl_Draw = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.lb_stopWatch = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_screenSelector = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_FPS = new System.Windows.Forms.NumericUpDown();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDesenha)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picApaga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRetangulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTriangulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCirculo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQuadrado)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnl_Draw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FPS)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_VideoCodec
            // 
            this.cb_VideoCodec.FormattingEnabled = true;
            this.cb_VideoCodec.Location = new System.Drawing.Point(100, 549);
            this.cb_VideoCodec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_VideoCodec.Name = "cb_VideoCodec";
            this.cb_VideoCodec.Size = new System.Drawing.Size(135, 24);
            this.cb_VideoCodec.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 551);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "VideoCodec:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 551);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "BitRate:";
            // 
            // cb_BitRate
            // 
            this.cb_BitRate.FormattingEnabled = true;
            this.cb_BitRate.Location = new System.Drawing.Point(307, 548);
            this.cb_BitRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_BitRate.Name = "cb_BitRate";
            this.cb_BitRate.Size = new System.Drawing.Size(100, 24);
            this.cb_BitRate.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.picDesenha);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(4, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 641);
            this.panel1.TabIndex = 17;
            // 
            // picDesenha
            // 
            this.picDesenha.BackColor = System.Drawing.Color.Transparent;
            this.picDesenha.Image = ((System.Drawing.Image)(resources.GetObject("picDesenha.Image")));
            this.picDesenha.Location = new System.Drawing.Point(58, 498);
            this.picDesenha.Name = "picDesenha";
            this.picDesenha.Size = new System.Drawing.Size(120, 120);
            this.picDesenha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDesenha.TabIndex = 19;
            this.picDesenha.TabStop = false;
            this.picDesenha.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.picApaga);
            this.panel7.Controls.Add(this.picRetangulo);
            this.panel7.Controls.Add(this.picTriangulo);
            this.panel7.Controls.Add(this.picCirculo);
            this.panel7.Controls.Add(this.picQuadrado);
            this.panel7.Controls.Add(this.txt_ShapeSize);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(13, 143);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(223, 321);
            this.panel7.TabIndex = 3;
            // 
            // picApaga
            // 
            this.picApaga.BackColor = System.Drawing.Color.White;
            this.picApaga.Image = ((System.Drawing.Image)(resources.GetObject("picApaga.Image")));
            this.picApaga.Location = new System.Drawing.Point(151, 40);
            this.picApaga.Name = "picApaga";
            this.picApaga.Size = new System.Drawing.Size(66, 57);
            this.picApaga.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picApaga.TabIndex = 20;
            this.picApaga.TabStop = false;
            this.picApaga.Click += new System.EventHandler(this.picApaga_Click);
            this.picApaga.DoubleClick += new System.EventHandler(this.picApaga_Click);
            // 
            // picRetangulo
            // 
            this.picRetangulo.BackColor = System.Drawing.Color.White;
            this.picRetangulo.Image = ((System.Drawing.Image)(resources.GetObject("picRetangulo.Image")));
            this.picRetangulo.Location = new System.Drawing.Point(113, 235);
            this.picRetangulo.Name = "picRetangulo";
            this.picRetangulo.Size = new System.Drawing.Size(93, 46);
            this.picRetangulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRetangulo.TabIndex = 21;
            this.picRetangulo.TabStop = false;
            this.picRetangulo.Click += new System.EventHandler(this.btn_Rectangle_Click);
            // 
            // picTriangulo
            // 
            this.picTriangulo.BackColor = System.Drawing.Color.White;
            this.picTriangulo.Image = ((System.Drawing.Image)(resources.GetObject("picTriangulo.Image")));
            this.picTriangulo.Location = new System.Drawing.Point(12, 216);
            this.picTriangulo.Name = "picTriangulo";
            this.picTriangulo.Size = new System.Drawing.Size(80, 78);
            this.picTriangulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTriangulo.TabIndex = 20;
            this.picTriangulo.TabStop = false;
            this.picTriangulo.Click += new System.EventHandler(this.btn_Triangle_Click);
            // 
            // picCirculo
            // 
            this.picCirculo.BackColor = System.Drawing.Color.White;
            this.picCirculo.Image = ((System.Drawing.Image)(resources.GetObject("picCirculo.Image")));
            this.picCirculo.Location = new System.Drawing.Point(126, 115);
            this.picCirculo.Name = "picCirculo";
            this.picCirculo.Size = new System.Drawing.Size(80, 80);
            this.picCirculo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCirculo.TabIndex = 19;
            this.picCirculo.TabStop = false;
            this.picCirculo.Click += new System.EventHandler(this.btn_Circle_Click);
            // 
            // picQuadrado
            // 
            this.picQuadrado.BackColor = System.Drawing.Color.White;
            this.picQuadrado.Image = ((System.Drawing.Image)(resources.GetObject("picQuadrado.Image")));
            this.picQuadrado.Location = new System.Drawing.Point(12, 115);
            this.picQuadrado.Name = "picQuadrado";
            this.picQuadrado.Size = new System.Drawing.Size(80, 80);
            this.picQuadrado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQuadrado.TabIndex = 18;
            this.picQuadrado.TabStop = false;
            this.picQuadrado.Click += new System.EventHandler(this.btn_Square_Click);
            // 
            // txt_ShapeSize
            // 
            this.txt_ShapeSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ShapeSize.Location = new System.Drawing.Point(5, 66);
            this.txt_ShapeSize.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ShapeSize.Name = "txt_ShapeSize";
            this.txt_ShapeSize.Size = new System.Drawing.Size(139, 30);
            this.txt_ShapeSize.TabIndex = 9;
            this.txt_ShapeSize.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 42);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "TAMANHO";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DimGray;
            this.panel8.Controls.Add(this.label8);
            this.panel8.Location = new System.Drawing.Point(5, 3);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(223, 33);
            this.panel8.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(66, 6);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "FORMAS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btn_PenColor);
            this.panel2.Location = new System.Drawing.Point(13, 13);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(223, 126);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DimGray;
            this.panel6.Controls.Add(this.label10);
            this.panel6.Location = new System.Drawing.Point(0, -1);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(222, 33);
            this.panel6.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(90, 9);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "COR";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Location = new System.Drawing.Point(-1, 155);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(173, 123);
            this.panel3.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(4, 80);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 34);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox1.Location = new System.Drawing.Point(5, 47);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 34);
            this.button2.TabIndex = 0;
            this.button2.Text = "Pen Tool";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_PenColor
            // 
            this.btn_PenColor.BackColor = System.Drawing.Color.Black;
            this.btn_PenColor.Location = new System.Drawing.Point(-21, 16);
            this.btn_PenColor.Margin = new System.Windows.Forms.Padding(4);
            this.btn_PenColor.Name = "btn_PenColor";
            this.btn_PenColor.Size = new System.Drawing.Size(256, 137);
            this.btn_PenColor.TabIndex = 2;
            this.btn_PenColor.UseVisualStyleBackColor = false;
            this.btn_PenColor.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnl_Draw
            // 
            this.pnl_Draw.AutoSize = true;
            this.pnl_Draw.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnl_Draw.Controls.Add(this.button4);
            this.pnl_Draw.Controls.Add(this.panel1);
            this.pnl_Draw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Draw.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.pnl_Draw.Location = new System.Drawing.Point(0, 0);
            this.pnl_Draw.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_Draw.Name = "pnl_Draw";
            this.pnl_Draw.Size = new System.Drawing.Size(1440, 673);
            this.pnl_Draw.TabIndex = 19;
            this.pnl_Draw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_Draw_MouseDown);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(1388, 11);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 40);
            this.button4.TabIndex = 18;
            this.button4.Text = "&X";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lb_stopWatch
            // 
            this.lb_stopWatch.AutoSize = true;
            this.lb_stopWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_stopWatch.Location = new System.Drawing.Point(93, 609);
            this.lb_stopWatch.Name = "lb_stopWatch";
            this.lb_stopWatch.Size = new System.Drawing.Size(263, 32);
            this.lb_stopWatch.TabIndex = 13;
            this.lb_stopWatch.Text = "00:00:00.0000000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 583);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Screens:";
            // 
            // cb_screenSelector
            // 
            this.cb_screenSelector.FormattingEnabled = true;
            this.cb_screenSelector.Location = new System.Drawing.Point(100, 580);
            this.cb_screenSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_screenSelector.Name = "cb_screenSelector";
            this.cb_screenSelector.Size = new System.Drawing.Size(135, 24);
            this.cb_screenSelector.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 581);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "FPS:";
            // 
            // nud_FPS
            // 
            this.nud_FPS.Location = new System.Drawing.Point(305, 575);
            this.nud_FPS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.nud_FPS.Size = new System.Drawing.Size(100, 22);
            this.nud_FPS.TabIndex = 9;
            this.nud_FPS.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pnl_Draw);
            this.panel4.Controls.Add(this.nud_FPS);
            this.panel4.Controls.Add(this.cb_screenSelector);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.lb_stopWatch);
            this.panel4.Controls.Add(this.cb_BitRate);
            this.panel4.Controls.Add(this.cb_VideoCodec);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1440, 673);
            this.panel4.TabIndex = 20;
            // 
            // frmCapturaDesenho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1440, 673);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmCapturaDesenho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Geometricamente v1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDesenha)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picApaga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRetangulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTriangulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCirculo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQuadrado)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnl_Draw.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_FPS)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_VideoCodec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_BitRate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_Draw;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txt_ShapeSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_PenColor;
        private System.Windows.Forms.Label lb_stopWatch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_screenSelector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_FPS;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox picTriangulo;
        private System.Windows.Forms.PictureBox picCirculo;
        private System.Windows.Forms.PictureBox picQuadrado;
        private System.Windows.Forms.PictureBox picRetangulo;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox picApaga;
        private System.Windows.Forms.PictureBox picDesenha;
    }
}

