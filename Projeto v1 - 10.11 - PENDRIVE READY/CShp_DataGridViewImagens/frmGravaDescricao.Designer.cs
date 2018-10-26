namespace Geometricamente_V1
{
    partial class frmGravaDescricao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGravaDescricao));
            this.picImagem = new System.Windows.Forms.PictureBox();
            this.lblTempo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.picGravador = new System.Windows.Forms.PictureBox();
            this.lblCoordenadas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGravador)).BeginInit();
            this.SuspendLayout();
            // 
            // picImagem
            // 
            this.picImagem.BackColor = System.Drawing.Color.White;
            this.picImagem.Location = new System.Drawing.Point(0, 49);
            this.picImagem.Margin = new System.Windows.Forms.Padding(4);
            this.picImagem.Name = "picImagem";
            this.picImagem.Size = new System.Drawing.Size(768, 635);
            this.picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImagem.TabIndex = 0;
            this.picImagem.TabStop = false;
            this.picImagem.Paint += new System.Windows.Forms.PaintEventHandler(this.picImagem_Paint);
            this.picImagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picImagem_MouseDown);
            this.picImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picImagem_MouseMove);
            this.picImagem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picImagem_MouseUp);
            // 
            // lblTempo
            // 
            this.lblTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempo.Location = new System.Drawing.Point(0, 2);
            this.lblTempo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(768, 49);
            this.lblTempo.TabIndex = 8;
            this.lblTempo.Text = "00:00:00";
            this.lblTempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(721, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 44);
            this.button1.TabIndex = 12;
            this.button1.Text = "&X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // picGravador
            // 
            this.picGravador.BackColor = System.Drawing.Color.Transparent;
            this.picGravador.Image = ((System.Drawing.Image)(resources.GetObject("picGravador.Image")));
            this.picGravador.Location = new System.Drawing.Point(323, 692);
            this.picGravador.Margin = new System.Windows.Forms.Padding(4);
            this.picGravador.Name = "picGravador";
            this.picGravador.Size = new System.Drawing.Size(133, 123);
            this.picGravador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGravador.TabIndex = 14;
            this.picGravador.TabStop = false;
            this.picGravador.Click += new System.EventHandler(this.PicGravador_Click);
            // 
            // lblCoordenadas
            // 
            this.lblCoordenadas.AutoSize = true;
            this.lblCoordenadas.BackColor = System.Drawing.Color.White;
            this.lblCoordenadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoordenadas.Location = new System.Drawing.Point(26, 12);
            this.lblCoordenadas.Name = "lblCoordenadas";
            this.lblCoordenadas.Size = new System.Drawing.Size(123, 20);
            this.lblCoordenadas.TabIndex = 16;
            this.lblCoordenadas.Text = "                   ";
            // 
            // frmGravaDescricao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(769, 826);
            this.Controls.Add(this.lblCoordenadas);
            this.Controls.Add(this.picGravador);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.picImagem);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGravaDescricao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imagem Selecionada";
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGravador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImagem;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picGravador;
        private System.Windows.Forms.Label lblCoordenadas;
    }
}