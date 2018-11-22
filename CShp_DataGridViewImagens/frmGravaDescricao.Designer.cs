namespace Geometricamente_V1
{
    partial class FrmGravaDescricao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGravaDescricao));
            this.lblTempo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSair = new System.Windows.Forms.Button();
            this.picGravador = new System.Windows.Forms.PictureBox();
            this.btnCrosshair = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_X = new System.Windows.Forms.Label();
            this.label_Y = new System.Windows.Forms.Label();
            this.picImagem = new System.Windows.Forms.PictureBox();
            this.line_Y = new System.Windows.Forms.Label();
            this.line_X = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmrCross = new System.Windows.Forms.Timer(this.components);
            this.lblGravando = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGravador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCrosshair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTempo
            // 
            this.lblTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempo.Location = new System.Drawing.Point(265, 614);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(155, 40);
            this.lblTempo.TabIndex = 8;
            this.lblTempo.Text = "00:00:00";
            this.lblTempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Red;
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(541, 2);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(35, 36);
            this.btnSair.TabIndex = 12;
            this.btnSair.Text = "&X";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.button1_Click);
            // 
            // picGravador
            // 
            this.picGravador.BackColor = System.Drawing.Color.Transparent;
            this.picGravador.Image = ((System.Drawing.Image)(resources.GetObject("picGravador.Image")));
            this.picGravador.Location = new System.Drawing.Point(159, 554);
            this.picGravador.Name = "picGravador";
            this.picGravador.Size = new System.Drawing.Size(100, 100);
            this.picGravador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGravador.TabIndex = 14;
            this.picGravador.TabStop = false;
            this.picGravador.Click += new System.EventHandler(this.PicGravador_Click);
            // 
            // btnCrosshair
            // 
            this.btnCrosshair.BackColor = System.Drawing.Color.White;
            this.btnCrosshair.Image = ((System.Drawing.Image)(resources.GetObject("btnCrosshair.Image")));
            this.btnCrosshair.Location = new System.Drawing.Point(32, 597);
            this.btnCrosshair.Margin = new System.Windows.Forms.Padding(2);
            this.btnCrosshair.Name = "btnCrosshair";
            this.btnCrosshair.Size = new System.Drawing.Size(42, 46);
            this.btnCrosshair.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCrosshair.TabIndex = 19;
            this.btnCrosshair.TabStop = false;
            this.btnCrosshair.Click += new System.EventHandler(this.btnCrosshair_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(2, 570);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Coordenadas";
            // 
            // label_X
            // 
            this.label_X.BackColor = System.Drawing.Color.White;
            this.label_X.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_X.Location = new System.Drawing.Point(126, 13);
            this.label_X.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(48, 29);
            this.label_X.TabIndex = 21;
            // 
            // label_Y
            // 
            this.label_Y.BackColor = System.Drawing.Color.White;
            this.label_Y.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Y.Location = new System.Drawing.Point(44, 13);
            this.label_Y.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Y.Name = "label_Y";
            this.label_Y.Size = new System.Drawing.Size(48, 29);
            this.label_Y.TabIndex = 22;
            // 
            // picImagem
            // 
            this.picImagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImagem.BackColor = System.Drawing.Color.White;
            this.picImagem.Location = new System.Drawing.Point(0, 46);
            this.picImagem.Name = "picImagem";
            this.picImagem.Size = new System.Drawing.Size(600, 488);
            this.picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImagem.TabIndex = 0;
            this.picImagem.TabStop = false;
            this.picImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picImagem_MouseMove);
            // 
            // line_Y
            // 
            this.line_Y.BackColor = System.Drawing.Color.Red;
            this.line_Y.Location = new System.Drawing.Point(0, 46);
            this.line_Y.Name = "line_Y";
            this.line_Y.Size = new System.Drawing.Size(2, 488);
            this.line_Y.TabIndex = 24;
            // 
            // line_X
            // 
            this.line_X.BackColor = System.Drawing.Color.Red;
            this.line_X.Location = new System.Drawing.Point(0, 46);
            this.line_X.Name = "line_X";
            this.line_X.Size = new System.Drawing.Size(600, 2);
            this.line_X.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "X:";
            // 
            // tmrCross
            // 
            this.tmrCross.Tick += new System.EventHandler(this.tmrCross_Tick);
            // 
            // lblGravando
            // 
            this.lblGravando.AutoSize = true;
            this.lblGravando.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGravando.ForeColor = System.Drawing.Color.Silver;
            this.lblGravando.Location = new System.Drawing.Point(287, 597);
            this.lblGravando.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGravando.Name = "lblGravando";
            this.lblGravando.Size = new System.Drawing.Size(110, 20);
            this.lblGravando.TabIndex = 27;
            this.lblGravando.Text = "GRAVANDO";
            // 
            // frmGravaDescricao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(600, 671);
            this.Controls.Add(this.lblGravando);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.line_Y);
            this.Controls.Add(this.line_X);
            this.Controls.Add(this.label_Y);
            this.Controls.Add(this.label_X);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCrosshair);
            this.Controls.Add(this.picGravador);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.picImagem);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGravaDescricao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imagem Selecionada";
            ((System.ComponentModel.ISupportInitialize)(this.picGravador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCrosshair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox picGravador;
        private System.Windows.Forms.PictureBox btnCrosshair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_X;
        private System.Windows.Forms.Label label_Y;
        private System.Windows.Forms.PictureBox picImagem;
        private System.Windows.Forms.Label line_Y;
        private System.Windows.Forms.Label line_X;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer tmrCross;
        private System.Windows.Forms.Label lblGravando;
    }
}