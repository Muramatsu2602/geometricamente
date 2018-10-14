namespace Geometricamente_V1
{
    partial class frmEscolhePasta
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDiretorio = new System.Windows.Forms.TextBox();
            this.btnSelecionarPasta = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.panel1.Controls.Add(this.txtDiretorio);
            this.panel1.Controls.Add(this.btnSelecionarPasta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 511);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 42);
            this.panel1.TabIndex = 0;
            // 
            // txtDiretorio
            // 
            this.txtDiretorio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiretorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiretorio.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtDiretorio.Location = new System.Drawing.Point(138, 11);
            this.txtDiretorio.Name = "txtDiretorio";
            this.txtDiretorio.Size = new System.Drawing.Size(574, 15);
            this.txtDiretorio.TabIndex = 1;
            // 
            // btnSelecionarPasta
            // 
            this.btnSelecionarPasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarPasta.Location = new System.Drawing.Point(3, 6);
            this.btnSelecionarPasta.Name = "btnSelecionarPasta";
            this.btnSelecionarPasta.Size = new System.Drawing.Size(129, 29);
            this.btnSelecionarPasta.TabIndex = 0;
            this.btnSelecionarPasta.Text = "Selecionar Pasta";
            this.btnSelecionarPasta.UseVisualStyleBackColor = true;
            this.btnSelecionarPasta.Click += new System.EventHandler(this.btnSelecionarPasta_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(724, 511);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 36);
            this.button1.TabIndex = 11;
            this.button1.Text = "&X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.Location = new System.Drawing.Point(3, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(718, 460);
            this.panel3.TabIndex = 1;
            // 
            // frmEscolhePasta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 553);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEscolhePasta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDiretorio;
        private System.Windows.Forms.Button btnSelecionarPasta;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
    }
}

