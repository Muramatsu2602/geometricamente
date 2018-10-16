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
            t.Abort();
            this.Focus();
        }
        private void StartForm()
        {
            Application.Run(new frmSplashScreen());
        }
 

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
           if( string.IsNullOrEmpty(txtNome.Text))
            {
                txtNome.Focus();
                MessageBox.Show("CAMPO NOME NAO PODE ESTAR VAZIO!", "Nome em branco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnSair_Click(object sender, EventArgs e)
        {

            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Form1")
                    Application.OpenForms[i].Close();

            }
            this.Close();
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
    }
}
