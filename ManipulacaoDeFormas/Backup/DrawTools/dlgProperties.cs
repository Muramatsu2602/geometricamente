using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DrawTools
{
	/// <summary>
	/// Summary description for dlgProperties.
	/// </summary>
	public class dlgProperties : System.Windows.Forms.Form
	{

		public SizeF SizePicture = new SizeF(500,400);
		public string desc = "SVG properties";

		private System.Windows.Forms.NumericUpDown numWidth;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numHeight;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textDescription;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public dlgProperties()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.numWidth = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.numHeight = new System.Windows.Forms.NumericUpDown();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.textDescription = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
			this.SuspendLayout();
			// 
			// numWidth
			// 
			this.numWidth.Location = new System.Drawing.Point(136, 40);
			this.numWidth.Maximum = new System.Decimal(new int[] {
																	 800,
																	 0,
																	 0,
																	 0});
			this.numWidth.Name = "numWidth";
			this.numWidth.Size = new System.Drawing.Size(48, 20);
			this.numWidth.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(96, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Size in pixels";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.TabIndex = 2;
			this.label2.Text = "Width";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 72);
			this.label3.Name = "label3";
			this.label3.TabIndex = 4;
			this.label3.Text = "Height";
			// 
			// numHeight
			// 
			this.numHeight.Location = new System.Drawing.Point(136, 72);
			this.numHeight.Maximum = new System.Decimal(new int[] {
																	  600,
																	  0,
																	  0,
																	  0});
			this.numHeight.Name = "numHeight";
			this.numHeight.Size = new System.Drawing.Size(48, 20);
			this.numHeight.TabIndex = 3;
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(32, 152);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 5;
			this.btnOk.Text = "Ok";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(152, 152);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(128, 96);
			this.label4.Name = "label4";
			this.label4.TabIndex = 7;
			this.label4.Text = "Description";
			// 
			// textDescription
			// 
			this.textDescription.Location = new System.Drawing.Point(8, 120);
			this.textDescription.Name = "textDescription";
			this.textDescription.Size = new System.Drawing.Size(416, 20);
			this.textDescription.TabIndex = 8;
			this.textDescription.Text = "";
			// 
			// dlgProperties
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(434, 182);
			this.Controls.Add(this.textDescription);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.numHeight);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numWidth);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgProperties";
			this.Text = "Document properties";
			this.Load += new System.EventHandler(this.dlgProperties_Load);
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void dlgProperties_Load(object sender, System.EventArgs e)
		{
			numWidth.Value = Convert.ToInt32(SizePicture.Width);
			numHeight.Value = Convert.ToInt32(SizePicture.Height);
			textDescription.Text = this.desc;
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			this.SizePicture = new SizeF(Convert.ToSingle(this.numWidth.Value),Convert.ToSingle(this.numHeight.Value));
			this.desc = textDescription.Text;
			this.DialogResult = DialogResult.OK;
		}
	}
}
