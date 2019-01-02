using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;

namespace Draw
{
    /// <summary>
    /// Properties dialog for graphic object.
    /// Shows properties for one or more graphic objects.
    /// 
    /// Special value "Undefined" is used when number of objects
    /// have different property values.
    /// 
    /// Input/output: GraphicsProperties class.
    /// 
    /// </summary>
    public class PropertiesDialog : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.Label lblPenWidth;
        private System.Windows.Forms.ComboBox cmbPenWidth;
        private System.Windows.Forms.CheckBox chFill;
        private System.Windows.Forms.Button btnSelectFillColor;
        private System.Windows.Forms.Label lblFillColor;
        private System.Windows.Forms.Label lblFill;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbAlpha2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar tbStrokeOpacity;
        private System.Windows.Forms.TrackBar tbFillOpacity;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public PropertiesDialog()
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.lblPenWidth = new System.Windows.Forms.Label();
            this.cmbPenWidth = new System.Windows.Forms.ComboBox();
            this.chFill = new System.Windows.Forms.CheckBox();
            this.btnSelectFillColor = new System.Windows.Forms.Button();
            this.lblFillColor = new System.Windows.Forms.Label();
            this.lblFill = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbAlpha2 = new System.Windows.Forms.Label();
            this.tbStrokeOpacity = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbFillOpacity = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbStrokeOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFillOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(37, 242);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 28);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Ok";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(224, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cor";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tamanho do traço";
            // 
            // lblColor
            // 
            this.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblColor.Location = new System.Drawing.Point(113, 16);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(74, 21);
            this.lblColor.TabIndex = 4;
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectColor.Location = new System.Drawing.Point(224, 16);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(27, 28);
            this.btnSelectColor.TabIndex = 5;
            this.btnSelectColor.Text = "...";
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectColor_Click);
            // 
            // lblPenWidth
            // 
            this.lblPenWidth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPenWidth.Location = new System.Drawing.Point(113, 56);
            this.lblPenWidth.Name = "lblPenWidth";
            this.lblPenWidth.Size = new System.Drawing.Size(74, 21);
            this.lblPenWidth.TabIndex = 6;
            this.lblPenWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPenWidth
            // 
            this.cmbPenWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPenWidth.Location = new System.Drawing.Point(207, 56);
            this.cmbPenWidth.Name = "cmbPenWidth";
            this.cmbPenWidth.Size = new System.Drawing.Size(86, 21);
            this.cmbPenWidth.TabIndex = 7;
            this.cmbPenWidth.SelectedIndexChanged += new System.EventHandler(this.cmbPenWidth_SelectedIndexChanged);
            // 
            // chFill
            // 
            this.chFill.Checked = true;
            this.chFill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chFill.Location = new System.Drawing.Point(19, 165);
            this.chFill.Name = "chFill";
            this.chFill.Size = new System.Drawing.Size(168, 24);
            this.chFill.TabIndex = 8;
            this.chFill.Text = "Preencher";
            this.chFill.CheckedChanged += new System.EventHandler(this.chFill_CheckedChanged);
            // 
            // btnSelectFillColor
            // 
            this.btnSelectFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectFillColor.Location = new System.Drawing.Point(616, 56);
            this.btnSelectFillColor.Name = "btnSelectFillColor";
            this.btnSelectFillColor.Size = new System.Drawing.Size(27, 28);
            this.btnSelectFillColor.TabIndex = 11;
            this.btnSelectFillColor.Text = "...";
            this.btnSelectFillColor.Visible = false;
            this.btnSelectFillColor.Click += new System.EventHandler(this.btnSelectFillColor_Click);
            // 
            // lblFillColor
            // 
            this.lblFillColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFillColor.Location = new System.Drawing.Point(496, 56);
            this.lblFillColor.Name = "lblFillColor";
            this.lblFillColor.Size = new System.Drawing.Size(74, 21);
            this.lblFillColor.TabIndex = 10;
            this.lblFillColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFillColor.Visible = false;
            // 
            // lblFill
            // 
            this.lblFill.Location = new System.Drawing.Point(392, 56);
            this.lblFill.Name = "lblFill";
            this.lblFill.Size = new System.Drawing.Size(80, 21);
            this.lblFill.TabIndex = 9;
            this.lblFill.Text = "Cor";
            this.lblFill.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(97, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 65;
            this.label3.Text = "min";
            this.label3.Visible = false;
            // 
            // lbAlpha2
            // 
            this.lbAlpha2.Location = new System.Drawing.Point(8, 96);
            this.lbAlpha2.Name = "lbAlpha2";
            this.lbAlpha2.Size = new System.Drawing.Size(88, 23);
            this.lbAlpha2.TabIndex = 64;
            this.lbAlpha2.Text = "Opacidade";
            this.lbAlpha2.Visible = false;
            // 
            // tbStrokeOpacity
            // 
            this.tbStrokeOpacity.Location = new System.Drawing.Point(119, 114);
            this.tbStrokeOpacity.Maximum = 255;
            this.tbStrokeOpacity.Name = "tbStrokeOpacity";
            this.tbStrokeOpacity.Size = new System.Drawing.Size(136, 45);
            this.tbStrokeOpacity.TabIndex = 63;
            this.tbStrokeOpacity.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(250, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 67;
            this.label5.Text = "max";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(648, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 71;
            this.label4.Text = "max";
            this.label4.Visible = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(450, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 70;
            this.label7.Text = "min";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(377, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 23);
            this.label8.TabIndex = 69;
            this.label8.Text = "Opacidade";
            this.label8.Visible = false;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // tbFillOpacity
            // 
            this.tbFillOpacity.Location = new System.Drawing.Point(505, 96);
            this.tbFillOpacity.Maximum = 255;
            this.tbFillOpacity.Name = "tbFillOpacity";
            this.tbFillOpacity.Size = new System.Drawing.Size(136, 45);
            this.tbFillOpacity.TabIndex = 68;
            this.tbFillOpacity.Visible = false;
            // 
            // PropertiesDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(342, 298);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbFillOpacity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbAlpha2);
            this.Controls.Add(this.tbStrokeOpacity);
            this.Controls.Add(this.btnSelectFillColor);
            this.Controls.Add(this.lblFillColor);
            this.Controls.Add(this.lblFill);
            this.Controls.Add(this.chFill);
            this.Controls.Add(this.cmbPenWidth);
            this.Controls.Add(this.lblPenWidth);
            this.Controls.Add(this.btnSelectColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertiesDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Properties of drawing object";
            this.Load += new System.EventHandler(this.PropertiesDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbStrokeOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFillOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private GraphicsProperties properties;
        private const string undefined = "??";
        private const int maxWidth = 15;

        public GraphicsProperties Properties
        {
            get
            {
                return properties;
            }
            set
            {
                properties = value;
            }
        }

        private void PropertiesDialog_Load(object sender, System.EventArgs e)
        {
            InitControls();
            SetColor();
            SetPenWidth();
        }

        private void InitControls()
        {
            for (int i = 0; i <= maxWidth; i++)
            {
                cmbPenWidth.Items.Add(i.ToString(CultureInfo.InvariantCulture));
            }
        }

        private void SetColor()
        {
            if (!properties.ColorDefined)
                lblColor.Text = undefined;
            else
                lblColor.BackColor = properties.Color;
            if (!properties.FillDefined)
                this.lblFillColor.Text = undefined;
            if (properties.IsFill)
            {
                this.chFill.Checked = true;
                lblFillColor.BackColor = properties.FillColor;
            }
            else
                this.chFill.Checked = false;
        }

        private void SetPenWidth()
        {
            float penWidth = properties.PenWidth;

            if (penWidth < 0)
                penWidth = 0;

            if (penWidth > maxWidth)
                penWidth = maxWidth;

            if (!properties.PenWidthDefined)
                lblPenWidth.Text = undefined;
            else
            {
                try
                {
                    lblPenWidth.Text = penWidth.ToString(CultureInfo.InvariantCulture);
                    cmbPenWidth.SelectedIndex = Convert.ToInt32(penWidth);
                }
                catch { }
            }
        }

        private void ReadValues()
        {
            if (cmbPenWidth.Text != undefined)
            {
                properties.PenWidthDefined = true;
                properties.PenWidth = cmbPenWidth.SelectedIndex;
            }

            if (lblColor.Text.Length == 0)
            {
                properties.ColorDefined = true;
                properties.Color = lblColor.BackColor;
            }

            if (this.lblFillColor.Text.Length == 0)
            {
                properties.FillDefined = true;
                //properties.FillColor = this.lblFillColor.BackColor;
                properties.FillColor = lblColor.BackColor;
                properties.IsFill = this.chFill.Checked;
            }
        }

        private void cmbPenWidth_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int width = cmbPenWidth.SelectedIndex + 1;
            lblPenWidth.Text = width.ToString(CultureInfo.InvariantCulture);
        }

        private void btnSelectColor_Click(object sender, System.EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = lblColor.BackColor;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                lblColor.BackColor = dlg.Color;
                lblColor.Text = "";
            }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            ReadValues();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void chFill_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chFill.Checked)
            {
                this.lblFill.Enabled = true;
                this.btnSelectFillColor.Enabled = true;
            }
            else
            {
                this.lblFill.Enabled = false;
                this.btnSelectFillColor.Enabled = false;
            }
        }

        private void btnSelectFillColor_Click(object sender, System.EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = lblFillColor.BackColor;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                this.lblFillColor.BackColor = dlg.Color;
                lblColor.Text = "";
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
