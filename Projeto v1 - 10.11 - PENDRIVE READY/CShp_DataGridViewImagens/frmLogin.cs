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
            t.Abort();
            InitializeComponent();
            
            this.ShowDialog();
        }
        private void StartForm()
        {
           
            Application.Run(new frmSplashScreen());
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Deseja mesmo sair?", "GEOMETRICAMENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
               Application.Exit();
            }
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            ValidaCampo('g');
        }

        private void btnDesenhar_Click(object sender, EventArgs e)

        {
           ValidaCampo('d');
        }

        public void ValidaCampo(char botao)
        {
            if (String.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("PREENCHA O SEU NOME!");
                txtNome.Focus();
            }
            else if (numIdade.Value == 0)

            {
                MessageBox.Show("IDADE NAO PODE SER IGUAL A ZERO!");
                numIdade.Focus();
            }
            else
            {
                dados[0] = txtNome.Text;
                dados[1] = numIdade.Value.ToString();
                if (botao.Equals('g'))
                {
                    frmEscolhePasta enviaDados = new frmEscolhePasta(dados);
                    enviaDados.Show();  
                }else if (botao.Equals('d'))
                {
                    frmCapturaDesenho captura = new frmCapturaDesenho(dados);
                    captura.Show();
                }
            
            } 
        }

        private void btnGravar_MouseHover(object sender, EventArgs e)
        {
            btnGravar.BackColor = Color.LightGray;
        }

        private void btnGravar_MouseLeave(object sender, EventArgs e)
        {
            btnGravar.BackColor = Color.Transparent;
        }

        private void btnDesenhar_MouseHover(object sender, EventArgs e)
        {
            btnDesenhar.BackColor = Color.LightGray;
        }

        private void btnDesenhar_MouseLeave(object sender, EventArgs e)
        {
            btnDesenhar.BackColor = Color.Transparent;

        }
    }
}
