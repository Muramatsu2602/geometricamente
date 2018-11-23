using CapturaTela;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometricamente_V1
{
    public partial class frmModoDesenho : Form
    {
        String[] dados = new String[100];
        public frmModoDesenho(String[] dados)
        {
            this.dados = dados;
            InitializeComponent();
        }
        private void btnGeometricamente_MouseHover(object sender, EventArgs e)
        {
            btnGeometricamente.BackColor = Color.LightGray;
        }

        private void btnGeometricamente_MouseLeave(object sender, EventArgs e)
        {
            btnGeometricamente.BackColor = Color.Transparent;
        }

        private void btnMSPaint_MouseHover(object sender, EventArgs e)
        {
            btnMSPaint.BackColor = Color.LightGray;
        }

        private void btnMSPaint_MouseLeave(object sender, EventArgs e)
        {
            btnMSPaint.BackColor = Color.Transparent;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMSPaint_Click(object sender, EventArgs e)
        {
            Process.Start("mspaint");
            frmGravaPaint grava = new frmGravaPaint(dados);
            grava.Show();
            this.Close();
        }

        private void btnGeometricamente_Click(object sender, EventArgs e)
        {
             frmCapturaDesenho captura = new frmCapturaDesenho(dados);
             captura.ShowDialog();
            this.Close();
        }
    }

}
