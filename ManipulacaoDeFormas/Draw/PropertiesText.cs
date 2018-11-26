using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Draw
{
	/// <summary>
	/// Summary description for PropertiesText.
	/// </summary>
	public class PropertiesText : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblFontDescription;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.FontDialog fontDialog1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox txtText;

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbCenter;
		private System.Windows.Forms.RadioButton rbRight;
		private System.Windows.Forms.RadioButton rbLeft;

		
		private Font fontText;
		private Color stroke = Color.Black;
		private bool isEdit = true;
		private string inputText = "";
		private StringFormat textAnchor = new StringFormat();

		public PropertiesText()
		{
			InitializeComponent();
			
			FontText = this.Font;
			textAnchor.Alignment = StringAlignment.Near;
		}
		public StringFormat TextAnchor
		{
			set
			{
				textAnchor = value;
			}
			get
			{
				return textAnchor;
			}
		}
		public bool IsEdit
		{
			set
			{
				isEdit = value;
			}
			get
			{
				return isEdit;
			}
		}
/*		public string TitleText
		{
			set
			{
				this.lblText.Text = value;
			}
			get
			{
				return lblText.Text;
			}
		}*/
		public string InputText
		{
			set
			{
				inputText = value;
			}
			get
			{
				return inputText;
			}
		}
		public Font FontText
		{
			set
			{
				fontText = value;
			}
			get
			{
				return fontText;
			}
		}
		public Color Stroke
		{
			set
			{
				stroke = value;
			}
			get
			{
				return stroke;
			}
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
			this.button1 = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.lblFontDescription = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtText = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbCenter = new System.Windows.Forms.RadioButton();
			this.rbRight = new System.Windows.Forms.RadioButton();
			this.rbLeft = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(392, 88);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(32, 24);
			this.button1.TabIndex = 11;
			this.button1.Text = "...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 88);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 24);
			this.label8.TabIndex = 9;
			this.label8.Text = "Font";
			// 
			// lblFontDescription
			// 
			this.lblFontDescription.Location = new System.Drawing.Point(88, 88);
			this.lblFontDescription.Name = "lblFontDescription";
			this.lblFontDescription.Size = new System.Drawing.Size(288, 24);
			this.lblFontDescription.TabIndex = 12;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 13;
			this.label1.Text = "Text";
			// 
			// txtText
			// 
			this.txtText.Location = new System.Drawing.Point(16, 32);
			this.txtText.Multiline = true;
			this.txtText.Name = "txtText";
			this.txtText.Size = new System.Drawing.Size(464, 32);
			this.txtText.TabIndex = 14;
			this.txtText.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(272, 184);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 28);
			this.btnCancel.TabIndex = 75;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(104, 184);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 28);
			this.btnOK.TabIndex = 74;
			this.btnOK.Text = "Ok";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbCenter);
			this.groupBox1.Controls.Add(this.rbRight);
			this.groupBox1.Controls.Add(this.rbLeft);
			this.groupBox1.Location = new System.Drawing.Point(48, 120);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(376, 56);
			this.groupBox1.TabIndex = 77;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Text Align";
			// 
			// rbCenter
			// 
			this.rbCenter.Location = new System.Drawing.Point(144, 24);
			this.rbCenter.Name = "rbCenter";
			this.rbCenter.TabIndex = 2;
			this.rbCenter.Text = "Center";
			// 
			// rbRight
			// 
			this.rbRight.Location = new System.Drawing.Point(296, 24);
			this.rbRight.Name = "rbRight";
			this.rbRight.Size = new System.Drawing.Size(72, 24);
			this.rbRight.TabIndex = 1;
			this.rbRight.Text = "Right";
			// 
			// rbLeft
			// 
			this.rbLeft.Location = new System.Drawing.Point(16, 24);
			this.rbLeft.Name = "rbLeft";
			this.rbLeft.Size = new System.Drawing.Size(88, 24);
			this.rbLeft.TabIndex = 0;
			this.rbLeft.Text = "Left";
			// 
			// PropertiesText
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(496, 216);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtText);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblFontDescription);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label8);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "PropertiesText";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Text properties";
			this.Load += new System.EventHandler(this.PropertiesText_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void InitColorControl(Control ctl)
		{
			ctl.Font = FontText;
			ctl.ForeColor = Stroke;
		}
		private void InitColors()
		{
			InitColorControl(lblFontDescription);
			lblFontDescription.Text = FontText.FontFamily.Name;
			InitColorControl(txtText);
		}
		private void PropertiesText_Load(object sender, System.EventArgs e)
		{
			InitColors();
			txtText.Text = this.inputText;
			if (!IsEdit)
				this.txtText.ReadOnly = true;
			SetStringFormat(this.TextAnchor,rbLeft,rbCenter,rbRight);
		}

		public static void SetStringFormat(StringFormat fmt,RadioButton b1,RadioButton b2,RadioButton b3)
		{
			if (fmt.Alignment == StringAlignment.Near)
				b1.Checked = true;
			if (fmt.Alignment == StringAlignment.Center)
				b2.Checked = true;
			if (fmt.Alignment == StringAlignment.Far)
				b3.Checked = true;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			fontDialog1.ShowColor = true;
			fontDialog1.Font = FontText;
			fontDialog1.Color = Stroke;

			if(fontDialog1.ShowDialog() != DialogResult.Cancel )
			{
				FontText = fontDialog1.Font;
				Stroke = fontDialog1.Color;
				InitColors();
			}
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (txtText.Text.Length == 0)
			{
				this.DialogResult = DialogResult.None;
				MessageBox.Show("Need input text\n");
				return;
			}
			this.InputText = this.txtText.Text;
			if (rbLeft.Checked)
				TextAnchor.Alignment = StringAlignment.Near;
			if (rbCenter.Checked)
				TextAnchor.Alignment = StringAlignment.Center;
			if (rbRight.Checked)
				TextAnchor.Alignment = StringAlignment.Far;
		}
	}
}
