using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using SVGLib;

namespace Draw
{
	/// <summary>
	/// Summary description for PropertiesImage.
	/// </summary>
	public class PropertiesImage : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbAlpha2;
		private System.Windows.Forms.TrackBar tbStrokeOpacity;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textFileName;
		private System.Windows.Forms.Button btnSelectFile;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textX;
		private System.Windows.Forms.TextBox textY;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textHeight;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textWidth;
		private System.Windows.Forms.Label label8;

		public bool IsChangedFileName = false;
		public string FileName = "";
		public int Opaque = 0;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TrackBar trackBar1;
		public RectangleF Rect = new RectangleF(0,0,0,0);

		public PropertiesImage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lbAlpha2 = new System.Windows.Forms.Label();
			this.tbStrokeOpacity = new System.Windows.Forms.TrackBar();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textFileName = new System.Windows.Forms.TextBox();
			this.btnSelectFile = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textX = new System.Windows.Forms.TextBox();
			this.textY = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textHeight = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textWidth = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			((System.ComponentModel.ISupportInitialize)(this.tbStrokeOpacity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(288, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 16);
			this.label5.TabIndex = 88;
			this.label5.Text = "макс";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(96, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 16);
			this.label3.TabIndex = 86;
			this.label3.Text = "мин";
			this.label3.Visible = false;
			// 
			// lbAlpha2
			// 
			this.lbAlpha2.Location = new System.Drawing.Point(24, 16);
			this.lbAlpha2.Name = "lbAlpha2";
			this.lbAlpha2.Size = new System.Drawing.Size(88, 23);
			this.lbAlpha2.TabIndex = 85;
			this.lbAlpha2.Text = "Opacity";
			// 
			// tbStrokeOpacity
			// 
			this.tbStrokeOpacity.Location = new System.Drawing.Point(144, 16);
			this.tbStrokeOpacity.Maximum = 255;
			this.tbStrokeOpacity.Name = "tbStrokeOpacity";
			this.tbStrokeOpacity.Size = new System.Drawing.Size(136, 45);
			this.tbStrokeOpacity.TabIndex = 84;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(248, 208);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 28);
			this.btnCancel.TabIndex = 73;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(88, 208);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 28);
			this.btnOK.TabIndex = 72;
			this.btnOK.Text = "Ok";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 144);
			this.label1.Name = "label1";
			this.label1.TabIndex = 89;
			this.label1.Text = "File name";
			// 
			// textFileName
			// 
			this.textFileName.Location = new System.Drawing.Point(8, 176);
			this.textFileName.Name = "textFileName";
			this.textFileName.Size = new System.Drawing.Size(408, 20);
			this.textFileName.TabIndex = 90;
			this.textFileName.Text = "";
			// 
			// btnSelectFile
			// 
			this.btnSelectFile.Location = new System.Drawing.Point(424, 176);
			this.btnSelectFile.Name = "btnSelectFile";
			this.btnSelectFile.Size = new System.Drawing.Size(24, 23);
			this.btnSelectFile.TabIndex = 91;
			this.btnSelectFile.Text = "...";
			this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(200, 23);
			this.label2.TabIndex = 92;
			this.label2.Text = "Coordinates of left upper corner";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(24, 23);
			this.label4.TabIndex = 93;
			this.label4.Text = "X";
			// 
			// textX
			// 
			this.textX.Location = new System.Drawing.Point(56, 88);
			this.textX.Name = "textX";
			this.textX.Size = new System.Drawing.Size(72, 20);
			this.textX.TabIndex = 94;
			this.textX.Text = "";
			// 
			// textY
			// 
			this.textY.Location = new System.Drawing.Point(216, 88);
			this.textY.Name = "textY";
			this.textY.Size = new System.Drawing.Size(80, 20);
			this.textY.TabIndex = 96;
			this.textY.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(176, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(24, 23);
			this.label6.TabIndex = 95;
			this.label6.Text = "Y";
			// 
			// textHeight
			// 
			this.textHeight.Location = new System.Drawing.Point(256, 111);
			this.textHeight.Name = "textHeight";
			this.textHeight.Size = new System.Drawing.Size(88, 20);
			this.textHeight.TabIndex = 100;
			this.textHeight.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(184, 111);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 23);
			this.label7.TabIndex = 99;
			this.label7.Text = "Height";
			// 
			// textWidth
			// 
			this.textWidth.Location = new System.Drawing.Point(80, 112);
			this.textWidth.Name = "textWidth";
			this.textWidth.Size = new System.Drawing.Size(80, 20);
			this.textWidth.TabIndex = 98;
			this.textWidth.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 111);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 23);
			this.label8.TabIndex = 97;
			this.label8.Text = "Width";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(288, 40);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(32, 16);
			this.label9.TabIndex = 88;
			this.label9.Text = "макс";
			this.label9.Visible = false;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(24, 16);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 23);
			this.label10.TabIndex = 85;
			this.label10.Text = "Прозрачность";
			this.label10.Visible = false;
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(144, 16);
			this.trackBar1.Maximum = 255;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(136, 45);
			this.trackBar1.TabIndex = 84;
			this.trackBar1.Visible = false;
			// 
			// PropertiesImage
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(464, 244);
			this.Controls.Add(this.textHeight);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textWidth);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textY);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textX);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnSelectFile);
			this.Controls.Add(this.textFileName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbAlpha2);
			this.Controls.Add(this.tbStrokeOpacity);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.trackBar1);
			this.Name = "PropertiesImage";
			this.Text = "Properties of image";
			this.Load += new System.EventHandler(this.PropertiesImage_Load);
			((System.ComponentModel.ISupportInitialize)(this.tbStrokeOpacity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSelectFile_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.InitialDirectory = Application.StartupPath;
			openFileDialog1.Filter = Draw.GRAPHICS_EXTS;
			openFileDialog1.FilterIndex = 0 ;
			openFileDialog1.RestoreDirectory = true ;
			if(openFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			try 
			{
				Image CurrentImage = Image.FromFile(openFileDialog1.FileName);
				this.textFileName.Text = openFileDialog1.FileName;
				this.IsChangedFileName = true;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error read file\n"+ex);
				return;
			}
		}

		private void PropertiesImage_Load(object sender, System.EventArgs e)
		{
			this.textFileName.Text = this.FileName;
			this.tbStrokeOpacity.Value = this.Opaque;
			this.textX.Text = Rect.X.ToString();
			this.textY.Text = Rect.Y.ToString();
			this.textWidth.Text = Rect.Width.ToString();
			this.textHeight.Text = Rect.Height.ToString();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (this.textFileName.Text.Length == 0)
			{
				MessageBox.Show("Must input file name\n");
				this.DialogResult = DialogResult.None;
				return;
			}
			try
			{
				RectangleF rect = new RectangleF(float.Parse(textX.Text),float.Parse(textY.Text),
					float.Parse(textWidth.Text),float.Parse(textHeight.Text));
			} 
			catch (Exception ex)
			{
				ErrH.Log("PropertiesImage", "Click", ex.ToString(), ErrH._LogPriority.Info);
				MessageBox.Show("Invalid coordinats\n"+ex);
				this.DialogResult = DialogResult.None;
				return;
			}
		}
	}
}
