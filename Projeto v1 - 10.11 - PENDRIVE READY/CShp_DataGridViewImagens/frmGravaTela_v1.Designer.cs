namespace CShp_DataGridViewImagens
{
    partial class frmGravaTela_v1
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
            this.btnComecaGravacao = new System.Windows.Forms.Button();
            this.btnPararGravar = new System.Windows.Forms.Button();
            this.tmrGrava = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnComecaGravacao
            // 
            this.btnComecaGravacao.Location = new System.Drawing.Point(39, 262);
            this.btnComecaGravacao.Name = "btnComecaGravacao";
            this.btnComecaGravacao.Size = new System.Drawing.Size(75, 23);
            this.btnComecaGravacao.TabIndex = 0;
            this.btnComecaGravacao.Text = "&GRAVAR";
            this.btnComecaGravacao.UseVisualStyleBackColor = true;
            this.btnComecaGravacao.Click += new System.EventHandler(this.btnComecaGravacao_Click);
            // 
            // btnPararGravar
            // 
            this.btnPararGravar.Location = new System.Drawing.Point(219, 262);
            this.btnPararGravar.Name = "btnPararGravar";
            this.btnPararGravar.Size = new System.Drawing.Size(75, 23);
            this.btnPararGravar.TabIndex = 1;
            this.btnPararGravar.Text = "&PARAR";
            this.btnPararGravar.UseVisualStyleBackColor = true;
            this.btnPararGravar.Click += new System.EventHandler(this.btnPararGravar_Click);
            // 
            // tmrGrava
            // 
            this.tmrGrava.Interval = 500;
            this.tmrGrava.Tick += new System.EventHandler(this.tmrGrava_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(306, 244);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmGravaTela_v1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 297);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPararGravar);
            this.Controls.Add(this.btnComecaGravacao);
            this.Name = "frmGravaTela_v1";
            this.Text = "frmGravaTela";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnComecaGravacao;
        private System.Windows.Forms.Button btnPararGravar;
        private System.Windows.Forms.Timer tmrGrava;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}