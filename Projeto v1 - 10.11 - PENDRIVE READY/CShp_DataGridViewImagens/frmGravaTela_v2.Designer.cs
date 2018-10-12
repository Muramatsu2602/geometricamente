namespace CShp_DataGridViewImagens
{
    partial class frmGravaTela_v2
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
            this.picMostraTela = new System.Windows.Forms.PictureBox();
            this.btnCapturaTela = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnTerminaGravacao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picMostraTela)).BeginInit();
            this.SuspendLayout();
            // 
            // picMostraTela
            // 
            this.picMostraTela.Location = new System.Drawing.Point(12, 12);
            this.picMostraTela.Name = "picMostraTela";
            this.picMostraTela.Size = new System.Drawing.Size(644, 426);
            this.picMostraTela.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMostraTela.TabIndex = 0;
            this.picMostraTela.TabStop = false;
            // 
            // btnCapturaTela
            // 
            this.btnCapturaTela.Location = new System.Drawing.Point(693, 180);
            this.btnCapturaTela.Name = "btnCapturaTela";
            this.btnCapturaTela.Size = new System.Drawing.Size(75, 23);
            this.btnCapturaTela.TabIndex = 1;
            this.btnCapturaTela.Text = "&FOTO";
            this.btnCapturaTela.UseVisualStyleBackColor = true;
            this.btnCapturaTela.Click += new System.EventHandler(this.btnCapturaTela_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(693, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "&VIDEO";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTerminaGravacao
            // 
            this.btnTerminaGravacao.Location = new System.Drawing.Point(693, 238);
            this.btnTerminaGravacao.Name = "btnTerminaGravacao";
            this.btnTerminaGravacao.Size = new System.Drawing.Size(75, 23);
            this.btnTerminaGravacao.TabIndex = 3;
            this.btnTerminaGravacao.Text = "&STOP";
            this.btnTerminaGravacao.UseVisualStyleBackColor = true;
            this.btnTerminaGravacao.Click += new System.EventHandler(this.btnTerminaGravacao_Click);
            // 
            // frmGravaTela_v2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTerminaGravacao);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCapturaTela);
            this.Controls.Add(this.picMostraTela);
            this.Name = "frmGravaTela_v2";
            this.Text = "frmGravaTela_v2";
            ((System.ComponentModel.ISupportInitialize)(this.picMostraTela)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picMostraTela;
        private System.Windows.Forms.Button btnCapturaTela;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnTerminaGravacao;
    }
}