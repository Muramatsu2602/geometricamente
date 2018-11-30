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
            this.lb_stopWatch = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_screenSelector = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_FPS = new System.Windows.Forms.NumericUpDown();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.label_X = new System.Windows.Forms.Label();
            this.label_Y = new System.Windows.Forms.Label();
            this.btnCrosshair = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.picApaga = new System.Windows.Forms.PictureBox();
            this.pnl_Draw = new System.Windows.Forms.Panel();
            this.line_Y = new System.Windows.Forms.Label();
            this.line_X = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_PenColor = new System.Windows.Forms.Button();
            this.picDesenha = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txt_ShapeSize = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picRetangulo = new System.Windows.Forms.PictureBox();
            this.tkbTamanho = new System.Windows.Forms.TrackBar();
            this.picTriangulo = new System.Windows.Forms.PictureBox();
            this.picCirculo = new System.Windows.Forms.PictureBox();
            this.picQuadrado = new System.Windows.Forms.PictureBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FPS)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCrosshair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picApaga)).BeginInit();
            this.pnl_Draw.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDesenha)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRetangulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbTamanho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTriangulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCirculo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQuadrado)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_VideoCodec
            // 
            this.cb_VideoCodec.FormattingEnabled = true;
            this.cb_VideoCodec.Location = new System.Drawing.Point(75, 446);
            this.cb_VideoCodec.Margin = new System.Windows.Forms.Padding(2);
            this.cb_VideoCodec.Name = "cb_VideoCodec";
            this.cb_VideoCodec.Size = new System.Drawing.Size(102, 21);
            this.cb_VideoCodec.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 448);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "VideoCodec:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 448);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "BitRate:";
            // 
            // cb_BitRate
            // 
            this.cb_BitRate.FormattingEnabled = true;
            this.cb_BitRate.Location = new System.Drawing.Point(230, 445);
            this.cb_BitRate.Margin = new System.Windows.Forms.Padding(2);
            this.cb_BitRate.Name = "cb_BitRate";
            this.cb_BitRate.Size = new System.Drawing.Size(76, 21);
            this.cb_BitRate.TabIndex = 7;
            // 
            // lb_stopWatch
            // 
            this.lb_stopWatch.AutoSize = true;
            this.lb_stopWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_stopWatch.Location = new System.Drawing.Point(70, 495);
            this.lb_stopWatch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_stopWatch.Name = "lb_stopWatch";
            this.lb_stopWatch.Size = new System.Drawing.Size(202, 26);
            this.lb_stopWatch.TabIndex = 13;
            this.lb_stopWatch.Text = "00:00:00.0000000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 474);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Screens:";
            // 
            // cb_screenSelector
            // 
            this.cb_screenSelector.FormattingEnabled = true;
            this.cb_screenSelector.Location = new System.Drawing.Point(75, 471);
            this.cb_screenSelector.Margin = new System.Windows.Forms.Padding(2);
            this.cb_screenSelector.Name = "cb_screenSelector";
            this.cb_screenSelector.Size = new System.Drawing.Size(102, 21);
            this.cb_screenSelector.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 472);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "FPS:";
            // 
            // nud_FPS
            // 
            this.nud_FPS.Location = new System.Drawing.Point(229, 467);
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
            this.nud_FPS.Size = new System.Drawing.Size(75, 20);
            this.nud_FPS.TabIndex = 9;
            this.nud_FPS.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel);
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
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1080, 618);
            this.panel4.TabIndex = 20;
            // 
            // panel
            // 
            this.panel.AutoSize = true;
            this.panel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel.Controls.Add(this.panel5);
            this.panel.Controls.Add(this.pnl_Draw);
            this.panel.Controls.Add(this.panel1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1080, 618);
            this.panel.TabIndex = 19;
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_Draw_MouseDown);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_Draw_MouseUp);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.lblX);
            this.panel5.Controls.Add(this.lblY);
            this.panel5.Controls.Add(this.label_X);
            this.panel5.Controls.Add(this.label_Y);
            this.panel5.Controls.Add(this.btnCrosshair);
            this.panel5.Controls.Add(this.button4);
            this.panel5.Controls.Add(this.picApaga);
            this.panel5.Location = new System.Drawing.Point(236, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(844, 81);
            this.panel5.TabIndex = 24;
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.Location = new System.Drawing.Point(386, 38);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(26, 20);
            this.lblX.TabIndex = 34;
            this.lblX.Text = "X:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.Location = new System.Drawing.Point(467, 41);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(26, 20);
            this.lblY.TabIndex = 33;
            this.lblY.Text = "Y:";
            // 
            // label_X
            // 
            this.label_X.BackColor = System.Drawing.Color.White;
            this.label_X.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_X.Location = new System.Drawing.Point(414, 32);
            this.label_X.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(48, 29);
            this.label_X.TabIndex = 32;
            // 
            // label_Y
            // 
            this.label_Y.BackColor = System.Drawing.Color.White;
            this.label_Y.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Y.Location = new System.Drawing.Point(496, 32);
            this.label_Y.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Y.Name = "label_Y";
            this.label_Y.Size = new System.Drawing.Size(48, 29);
            this.label_Y.TabIndex = 31;
            // 
            // btnCrosshair
            // 
            this.btnCrosshair.BackColor = System.Drawing.Color.White;
            this.btnCrosshair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrosshair.Image = ((System.Drawing.Image)(resources.GetObject("btnCrosshair.Image")));
            this.btnCrosshair.Location = new System.Drawing.Point(105, 9);
            this.btnCrosshair.Margin = new System.Windows.Forms.Padding(2);
            this.btnCrosshair.Name = "btnCrosshair";
            this.btnCrosshair.Size = new System.Drawing.Size(66, 62);
            this.btnCrosshair.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCrosshair.TabIndex = 30;
            this.btnCrosshair.TabStop = false;
            this.btnCrosshair.Click += new System.EventHandler(this.btnCrosshair_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(783, 11);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 50);
            this.button4.TabIndex = 18;
            this.button4.Text = "&X";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // picApaga
            // 
            this.picApaga.BackColor = System.Drawing.Color.White;
            this.picApaga.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picApaga.Image = ((System.Drawing.Image)(resources.GetObject("picApaga.Image")));
            this.picApaga.Location = new System.Drawing.Point(15, 9);
            this.picApaga.Margin = new System.Windows.Forms.Padding(2);
            this.picApaga.Name = "picApaga";
            this.picApaga.Size = new System.Drawing.Size(66, 62);
            this.picApaga.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picApaga.TabIndex = 20;
            this.picApaga.TabStop = false;
            this.picApaga.Click += new System.EventHandler(this.picApaga_Click);
            this.picApaga.DoubleClick += new System.EventHandler(this.picApaga_Click);
            // 
            // pnl_Draw
            // 
            this.pnl_Draw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Draw.BackColor = System.Drawing.Color.White;
            this.pnl_Draw.Controls.Add(this.line_Y);
            this.pnl_Draw.Controls.Add(this.line_X);
            this.pnl_Draw.Location = new System.Drawing.Point(236, 80);
            this.pnl_Draw.Name = "pnl_Draw";
            this.pnl_Draw.Size = new System.Drawing.Size(844, 538);
            this.pnl_Draw.TabIndex = 25;
            this.pnl_Draw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_Draw_MouseDown);
            this.pnl_Draw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_Draw_MouseMove);
            this.pnl_Draw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_Draw_MouseUp);
            // 
            // line_Y
            // 
            this.line_Y.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.line_Y.BackColor = System.Drawing.Color.Red;
            this.line_Y.Location = new System.Drawing.Point(0, 2);
            this.line_Y.Name = "line_Y";
            this.line_Y.Size = new System.Drawing.Size(1, 538);
            this.line_Y.TabIndex = 29;
            // 
            // line_X
            // 
            this.line_X.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line_X.BackColor = System.Drawing.Color.Red;
            this.line_X.Location = new System.Drawing.Point(0, 0);
            this.line_X.Name = "line_X";
            this.line_X.Size = new System.Drawing.Size(844, 1);
            this.line_X.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.picDesenha);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 618);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btn_PenColor);
            this.panel2.Location = new System.Drawing.Point(10, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 103);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DimGray;
            this.panel6.Controls.Add(this.label10);
            this.panel6.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.panel6.Location = new System.Drawing.Point(0, -1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(212, 27);
            this.panel6.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(-1, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(212, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "COR";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Location = new System.Drawing.Point(-1, 126);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(130, 100);
            this.panel3.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(3, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 28);
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
            this.comboBox1.Location = new System.Drawing.Point(4, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(122, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 28);
            this.button2.TabIndex = 0;
            this.button2.Text = "Pen Tool";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_PenColor
            // 
            this.btn_PenColor.BackColor = System.Drawing.Color.Black;
            this.btn_PenColor.Location = new System.Drawing.Point(-16, 5);
            this.btn_PenColor.Name = "btn_PenColor";
            this.btn_PenColor.Size = new System.Drawing.Size(235, 111);
            this.btn_PenColor.TabIndex = 2;
            this.btn_PenColor.UseVisualStyleBackColor = false;
            this.btn_PenColor.Click += new System.EventHandler(this.button1_Click);
            // 
            // picDesenha
            // 
            this.picDesenha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picDesenha.BackColor = System.Drawing.Color.White;
            this.picDesenha.Image = ((System.Drawing.Image)(resources.GetObject("picDesenha.Image")));
            this.picDesenha.Location = new System.Drawing.Point(70, 474);
            this.picDesenha.Margin = new System.Windows.Forms.Padding(2);
            this.picDesenha.Name = "picDesenha";
            this.picDesenha.Size = new System.Drawing.Size(90, 98);
            this.picDesenha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDesenha.TabIndex = 19;
            this.picDesenha.TabStop = false;
            this.picDesenha.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.pictureBox2);
            this.panel7.Controls.Add(this.txt_ShapeSize);
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.picRetangulo);
            this.panel7.Controls.Add(this.tkbTamanho);
            this.panel7.Controls.Add(this.picTriangulo);
            this.panel7.Controls.Add(this.picCirculo);
            this.panel7.Controls.Add(this.picQuadrado);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(10, 120);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(213, 313);
            this.panel7.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(4, 267);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // txt_ShapeSize
            // 
            this.txt_ShapeSize.BackColor = System.Drawing.Color.White;
            this.txt_ShapeSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ShapeSize.Location = new System.Drawing.Point(2, 232);
            this.txt_ShapeSize.Name = "txt_ShapeSize";
            this.txt_ShapeSize.Size = new System.Drawing.Size(45, 26);
            this.txt_ShapeSize.TabIndex = 9;
            this.txt_ShapeSize.Text = "100";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(156, 261);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "TAMANHO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picRetangulo
            // 
            this.picRetangulo.BackColor = System.Drawing.Color.White;
            this.picRetangulo.Image = ((System.Drawing.Image)(resources.GetObject("picRetangulo.Image")));
            this.picRetangulo.Location = new System.Drawing.Point(106, 157);
            this.picRetangulo.Margin = new System.Windows.Forms.Padding(2);
            this.picRetangulo.Name = "picRetangulo";
            this.picRetangulo.Size = new System.Drawing.Size(100, 61);
            this.picRetangulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRetangulo.TabIndex = 21;
            this.picRetangulo.TabStop = false;
            this.picRetangulo.Click += new System.EventHandler(this.btn_Rectangle_Click);
            // 
            // tkbTamanho
            // 
            this.tkbTamanho.BackColor = System.Drawing.Color.White;
            this.tkbTamanho.Location = new System.Drawing.Point(38, 267);
            this.tkbTamanho.Name = "tkbTamanho";
            this.tkbTamanho.Size = new System.Drawing.Size(111, 45);
            this.tkbTamanho.TabIndex = 2;
            this.tkbTamanho.TickFrequency = 5;
            this.tkbTamanho.ValueChanged += new System.EventHandler(this.tkbTamanho_ValueChanged);
            // 
            // picTriangulo
            // 
            this.picTriangulo.BackColor = System.Drawing.Color.White;
            this.picTriangulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picTriangulo.Image = ((System.Drawing.Image)(resources.GetObject("picTriangulo.Image")));
            this.picTriangulo.Location = new System.Drawing.Point(15, 138);
            this.picTriangulo.Margin = new System.Windows.Forms.Padding(2);
            this.picTriangulo.Name = "picTriangulo";
            this.picTriangulo.Size = new System.Drawing.Size(80, 80);
            this.picTriangulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTriangulo.TabIndex = 20;
            this.picTriangulo.TabStop = false;
            this.picTriangulo.Click += new System.EventHandler(this.btn_Triangle_Click);
            // 
            // picCirculo
            // 
            this.picCirculo.BackColor = System.Drawing.Color.White;
            this.picCirculo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCirculo.Image = ((System.Drawing.Image)(resources.GetObject("picCirculo.Image")));
            this.picCirculo.Location = new System.Drawing.Point(119, 48);
            this.picCirculo.Margin = new System.Windows.Forms.Padding(2);
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
            this.picQuadrado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picQuadrado.Image = ((System.Drawing.Image)(resources.GetObject("picQuadrado.Image")));
            this.picQuadrado.Location = new System.Drawing.Point(15, 48);
            this.picQuadrado.Margin = new System.Windows.Forms.Padding(2);
            this.picQuadrado.Name = "picQuadrado";
            this.picQuadrado.Size = new System.Drawing.Size(80, 80);
            this.picQuadrado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQuadrado.TabIndex = 18;
            this.picQuadrado.TabStop = false;
            this.picQuadrado.Click += new System.EventHandler(this.btn_Square_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DimGray;
            this.panel8.Controls.Add(this.label8);
            this.panel8.Location = new System.Drawing.Point(-2, -1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(213, 30);
            this.panel8.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(2, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(212, 29);
            this.label8.TabIndex = 1;
            this.label8.Text = "FORMAS";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCapturaDesenho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1080, 618);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCapturaDesenho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Geometricamente v1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nud_FPS)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCrosshair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picApaga)).EndInit();
            this.pnl_Draw.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDesenha)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRetangulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbTamanho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTriangulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCirculo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQuadrado)).EndInit();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_VideoCodec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_BitRate;
        private System.Windows.Forms.Label lb_stopWatch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_screenSelector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_FPS;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picDesenha;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txt_ShapeSize;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picRetangulo;
        private System.Windows.Forms.TrackBar tkbTamanho;
        private System.Windows.Forms.PictureBox picTriangulo;
        private System.Windows.Forms.PictureBox picCirculo;
        private System.Windows.Forms.PictureBox picQuadrado;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_PenColor;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox picApaga;
        private System.Windows.Forms.PictureBox btnCrosshair;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label label_X;
        private System.Windows.Forms.Label label_Y;
        private System.Windows.Forms.Panel pnl_Draw;
        private System.Windows.Forms.Label line_Y;
        private System.Windows.Forms.Label line_X;
    }
}

