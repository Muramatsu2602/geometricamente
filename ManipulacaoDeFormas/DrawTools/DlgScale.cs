using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DrawTools
{
	/// <summary>
	/// Класс диалога ввода масштаба изображения плана.
	/// </summary>
	public class DlgScale : System.Windows.Forms.Form
	{
		/// <summary>
		/// масштаб
		/// </summary>
		public float Sc = 100;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.Button bOk;
		private System.Windows.Forms.ComboBox comboBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// конструктор
		/// </summary>
		public DlgScale()
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
		/// Освобождение каких либо задействованных ресурсов.
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
			this.label1 = new System.Windows.Forms.Label();
			this.bCancel = new System.Windows.Forms.Button();
			this.bOk = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Set new scale in %";
			// 
			// bCancel
			// 
			this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancel.Location = new System.Drawing.Point(200, 48);
			this.bCancel.Name = "bCancel";
			this.bCancel.TabIndex = 6;
			this.bCancel.Text = "Cancel";
			// 
			// bOk
			// 
			this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bOk.Location = new System.Drawing.Point(40, 48);
			this.bOk.Name = "bOk";
			this.bOk.TabIndex = 5;
			this.bOk.Text = "Ok";
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Items.AddRange(new object[] {
														   "100",
														   "200",
														   "400",
														   "600",
														   "800"});
			this.comboBox1.Location = new System.Drawing.Point(232, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 7;
			// 
			// DlgScale
			// 
			this.AcceptButton = this.bOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.bCancel;
			this.ClientSize = new System.Drawing.Size(368, 77);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "DlgScale";
			this.ShowInTaskbar = false;
			this.Text = "Set scale";
			this.Load += new System.EventHandler(this.DlgScale_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void DlgScale_Load(object sender, System.EventArgs e)
		{
			float v = Sc*100;
			this.comboBox1.Items.Insert(0,v.ToString());
			comboBox1.SelectedIndex = 0;
		}

		private void bOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				string s = this.comboBox1.Text;
				int p = s.IndexOf("%",0);
				if (p > 0)
				{
					s = s.Substring(0,p);
				}
				this.Sc = float.Parse(s);
				Sc /= 100;
			}
			catch
			{
				MessageBox.Show("Invalid scale.");
				this.DialogResult = DialogResult.None;
				return;
			}
			if (Sc == 0.0)
			{
				MessageBox.Show("Scale not be equal 0.");
				this.DialogResult = DialogResult.None;
				return;
			}
		}
	}
}
