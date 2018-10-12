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

namespace CShp_DataGridViewImagens
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }
        private void StartForm()
        {
            Application.Run(new frmSplashScreen());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String[] dados = new String[100];
            dados[0] = txtNome.Text;
            dados[1] = numIdade.Value.ToString();
            if (rbFala.Checked)
            {
                frmEscolhePasta enviaDados = new frmEscolhePasta(dados);
                enviaDados.Show();
            }
            else
            {
                frmCapturaDesenho captura = new frmCapturaDesenho(dados);
                captura.Show();
            }
            this.Hide();
            
        }

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
           if( string.IsNullOrEmpty(txtNome.Text))
            {
                txtNome.Focus();
                MessageBox.Show("CAMPO NOME NAO PODE ESTAR VAZIO!", "Nome em branco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {

            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Form1")
                    Application.OpenForms[i].Close();
        
            }
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
