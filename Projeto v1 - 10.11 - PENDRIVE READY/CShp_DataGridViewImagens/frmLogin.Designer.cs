namespace Geometricamente_V1
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numIdade = new System.Windows.Forms.NumericUpDown();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btnGravar = new System.Windows.Forms.PictureBox();
            this.btnDesenhar = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numIdade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGravar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDesenhar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSair)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(576, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "LOGIN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 215);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "IDADE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 155);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "NOME";
            // 
            // numIdade
            // 
            this.numIdade.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numIdade.ForeColor = System.Drawing.Color.DodgerBlue;
            this.numIdade.Location = new System.Drawing.Point(112, 209);
            this.numIdade.Margin = new System.Windows.Forms.Padding(4);
            this.numIdade.Name = "numIdade";
            this.numIdade.Size = new System.Drawing.Size(93, 38);
            this.numIdade.TabIndex = 7;
            this.numIdade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(111, 155);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(500, 38);
            this.txtNome.TabIndex = 6;
            // 
            // btnGravar
            // 
            this.btnGravar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnGravar.Image = ((System.Drawing.Image)(resources.GetObject("btnGravar.Image")));
            this.btnGravar.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnGravar.InitialImage")));
            this.btnGravar.Location = new System.Drawing.Point(231, 336);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Padding = new System.Windows.Forms.Padding(11);
            this.btnGravar.Size = new System.Drawing.Size(139, 132);
            this.btnGravar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnGravar.TabIndex = 17;
            this.btnGravar.TabStop = false;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnDesenhar
            // 
            this.btnDesenhar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnDesenhar.Image = ((System.Drawing.Image)(resources.GetObject("btnDesenhar.Image")));
            this.btnDesenhar.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnDesenhar.InitialImage")));
            this.btnDesenhar.Location = new System.Drawing.Point(449, 336);
            this.btnDesenhar.Name = "btnDesenhar";
            this.btnDesenhar.Padding = new System.Windows.Forms.Padding(11);
            this.btnDesenhar.Size = new System.Drawing.Size(139, 132);
            this.btnDesenhar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDesenhar.TabIndex = 18;
            this.btnDesenhar.TabStop = false;
            this.btnDesenhar.Click += new System.EventHandler(this.btnDesenhar_Click);
            // 
            // btnSair
            // 
            this.btnSair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnSair.InitialImage")));
            this.btnSair.Location = new System.Drawing.Point(12, 336);
            this.btnSair.Name = "btnSair";
            this.btnSair.Padding = new System.Windows.Forms.Padding(11);
            this.btnSair.Size = new System.Drawing.Size(139, 132);
            this.btnSair.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSair.TabIndex = 19;
            this.btnSair.TabStop = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 498);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnDesenhar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numIdade);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            ((System.ComponentModel.ISupportInitialize)(this.numIdade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGravar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDesenhar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSair)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numIdade;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.PictureBox btnGravar;
        private System.Windows.Forms.PictureBox btnDesenhar;
        private System.Windows.Forms.PictureBox btnSair;
    }
}