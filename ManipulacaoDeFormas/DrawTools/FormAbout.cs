using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DocToolkit;

namespace DrawTools
{
	/// <summary>
	/// About dialog
	/// </summary>
	public class FormAbout : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Button OK;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel linkLabel2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormAbout()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			//this.linkLabel1.Links.Add(24, 9, "www.shokhin1.narod.ru");
			// Create a new link using the Add method of the LinkCollection class.
			linkLabel1.Links.Add(0,linkLabel1.Text.Length,"www.shokhin1.narod.ru");
			linkLabel2.Links.Add(0,linkLabel2.Text.Length,"mailto:ashokhin59@mail.ru");
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormAbout));
			this.lblText = new System.Windows.Forms.Label();
			this.OK = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// lblText
			// 
			this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblText.Location = new System.Drawing.Point(36, 24);
			this.lblText.Name = "lblText";
			this.lblText.Size = new System.Drawing.Size(207, 36);
			this.lblText.TabIndex = 0;
			this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// OK
			// 
			this.OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.OK.Location = new System.Drawing.Point(118, 232);
			this.OK.Name = "OK";
			this.OK.Size = new System.Drawing.Size(86, 25);
			this.OK.TabIndex = 1;
			this.OK.Text = "Close";
			this.OK.Click += new System.EventHandler(this.OK_Click);
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(44, 76);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.TabIndex = 2;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Alexandr Shokhin";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// linkLabel2
			// 
			this.linkLabel2.Location = new System.Drawing.Point(44, 104);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(148, 23);
			this.linkLabel2.TabIndex = 3;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "email : ashokhin59@mail.ru";
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// FormAbout
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(358, 264);
			this.Controls.Add(this.linkLabel2);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.OK);
			this.Controls.Add(this.lblText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAbout";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About program";
			this.Load += new System.EventHandler(this.FormAbout_Load);
			this.ResumeLayout(false);

		}
		#endregion

        private void OK_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void FormAbout_Load(object sender, System.EventArgs e)
        {
            this.Text = "About " + DocManager.ApplicationName/*Application.ProductName*/;

            lblText.Text = "Program: " + DocManager.ApplicationName + "\n" +
                "version: " + Application.ProductVersion;
        
        }

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			// Determine which link was clicked within the LinkLabel.
//			linkLabel1.Links[linkLabel1.Links.IndexOf(e.Link)].Visited = true;
			// Display the appropriate link based on the value of the LinkData property of the Link object.
			try
			{
				System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
			} 
			catch
			{
				MessageBox.Show("Not install application for call this link");
			}
		}
	}
}
