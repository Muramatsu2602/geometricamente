namespace Geometricamente_V1
{
    partial class frmModoDesenho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModoDesenho));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMSPaint = new System.Windows.Forms.PictureBox();
            this.btnGeometricamente = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnMSPaint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGeometricamente)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(559, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 44);
            this.button1.TabIndex = 22;
            this.button1.Text = "&X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(-25, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(653, 97);
            this.label1.TabIndex = 21;
            this.label1.Text = " TELA DE DESENHO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMSPaint
            // 
            this.btnMSPaint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMSPaint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMSPaint.Image = ((System.Drawing.Image)(resources.GetObject("btnMSPaint.Image")));
            this.btnMSPaint.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnMSPaint.InitialImage")));
            this.btnMSPaint.Location = new System.Drawing.Point(109, 167);
            this.btnMSPaint.Name = "btnMSPaint";
            this.btnMSPaint.Padding = new System.Windows.Forms.Padding(11);
            this.btnMSPaint.Size = new System.Drawing.Size(150, 150);
            this.btnMSPaint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMSPaint.TabIndex = 23;
            this.btnMSPaint.TabStop = false;
            this.btnMSPaint.Click += new System.EventHandler(this.btnMSPaint_Click);
            this.btnMSPaint.MouseLeave += new System.EventHandler(this.btnMSPaint_MouseLeave);
            this.btnMSPaint.MouseHover += new System.EventHandler(this.btnMSPaint_MouseHover);
            // 
            // btnGeometricamente
            // 
            this.btnGeometricamente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnGeometricamente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeometricamente.Image = ((System.Drawing.Image)(resources.GetObject("btnGeometricamente.Image")));
            this.btnGeometricamente.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnGeometricamente.InitialImage")));
            this.btnGeometricamente.Location = new System.Drawing.Point(366, 167);
            this.btnGeometricamente.Name = "btnGeometricamente";
            this.btnGeometricamente.Padding = new System.Windows.Forms.Padding(11);
            this.btnGeometricamente.Size = new System.Drawing.Size(150, 150);
            this.btnGeometricamente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnGeometricamente.TabIndex = 24;
            this.btnGeometricamente.TabStop = false;
            this.btnGeometricamente.Click += new System.EventHandler(this.btnGeometricamente_Click);
            this.btnGeometricamente.MouseLeave += new System.EventHandler(this.btnGeometricamente_MouseLeave);
            this.btnGeometricamente.MouseHover += new System.EventHandler(this.btnGeometricamente_MouseHover);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(109, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Paint";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(340, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Geometricamente";
            // 
            // frmModoDesenho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(619, 498);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGeometricamente);
            this.Controls.Add(this.btnMSPaint);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmModoDesenho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmModoDesenho";
            ((System.ComponentModel.ISupportInitialize)(this.btnMSPaint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGeometricamente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnMSPaint;
        private System.Windows.Forms.PictureBox btnGeometricamente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}