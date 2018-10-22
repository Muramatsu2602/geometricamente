using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using CapturaTela;

namespace Geometricamente_V1
{
    public partial class frmLogin : Form
    {
        String[] dados = new String[100];
 

        public frmLogin()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            this.Focus();
            t.Abort();
        }
        private void StartForm()
        {
            Application.Run(new frmSplashScreen());
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show(" Deseja Sair ?", "GEOMETRICAMENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();

            }
            
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            dados[0] = txtNome.Text;
            dados[1] = numIdade.Value.ToString();
            frmEscolhePasta enviaDados = new frmEscolhePasta(dados);
            enviaDados.Show();
        }

        private void btnDesenhar_Click(object sender, EventArgs e)

        {
            dados[0] = txtNome.Text;
            dados[1] = numIdade.Value.ToString();
            frmCapturaDesenho captura = new frmCapturaDesenho(dados);
            captura.Show();
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                txtNome.Focus();
                MessageBox.Show("CAMPO NOME NAO PODE ESTAR VAZIO!", "Nome em branco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
