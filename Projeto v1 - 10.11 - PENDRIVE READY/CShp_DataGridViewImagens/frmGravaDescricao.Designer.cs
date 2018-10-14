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
            this.picImagem = new System.Windows.Forms.PictureBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.lblTempo = new System.Windows.Forms.Label();
            this.btnParaGravar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // picImagem
            // 
            this.picImagem.Location = new System.Drawing.Point(3, 40);
            this.picImagem.Name = "picImagem";
            this.picImagem.Size = new System.Drawing.Size(463, 440);
            this.picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImagem.TabIndex = 0;
            this.picImagem.TabStop = false;
            // 
            // btnGravar
            // 
            this.btnGravar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGravar.Location = new System.Drawing.Point(15, 489);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(103, 43);
            this.btnGravar.TabIndex = 6;
            this.btnGravar.Text = "GRAVAR";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // lblTempo
            // 
            this.lblTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempo.Location = new System.Drawing.Point(178, 489);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(107, 34);
            this.lblTempo.TabIndex = 8;
            this.lblTempo.Text = "00:00:00";
            this.lblTempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnParaGravar
            // 
            this.btnParaGravar.Location = new System.Drawing.Point(351, 489);
            this.btnParaGravar.Name = "btnParaGravar";
            this.btnParaGravar.Size = new System.Drawing.Size(103, 43);
            this.btnParaGravar.TabIndex = 9;
            this.btnParaGravar.Text = "ACABEI!";
            this.btnParaGravar.UseVisualStyleBackColor = true;
            this.btnParaGravar.Click += new System.EventHandler(this.btnParaGravar_Click);
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
            this.button1.Location = new System.Drawing.Point(422, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 36);
            this.button1.TabIndex = 12;
            this.button1.Text = "&X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmGravaDescricao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 540);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnParaGravar);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.picImagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGravaDescricao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imagem Selecionada";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picImagem;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Button btnParaGravar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}