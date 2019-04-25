using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometricamente_V1
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Deseja Sair?", "Sobre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

  
        private void label11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Muramatsu2602/AnaliseGeometricamente");
        }

        
    }
}
