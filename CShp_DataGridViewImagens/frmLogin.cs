using System;
using System.Drawing;
using System.Windows.Forms;

namespace Geometricamente_V1
{
    public partial class frmLogin : Form
    {

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        String[] dados = new String[100];
        public frmLogin()
        {

            InitializeComponent();
            frmSplashScreen splash = new frmSplashScreen();
            splash.ShowDialog();
            SetForegroundWindow(this.Handle);
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
                }
                else if (botao.Equals('d'))
                {
                    frmModoDesenho modo = new frmModoDesenho(dados);
                    modo.ShowDialog();
                }


            }
        }

        private void btnGravar_MouseHover(object sender, EventArgs e)
        {
            btnGravar.BackColor = Color.LightGray;
        }

        private void btnGravar_MouseLeave(object sender, EventArgs e)
        {
            btnGravar.BackColor = Color.White;
        }

        private void btnDesenhar_MouseHover(object sender, EventArgs e)
        {
            btnDesenhar.BackColor = Color.LightGray;
        }

        private void btnDesenhar_MouseLeave(object sender, EventArgs e)
        {
            btnDesenhar.BackColor = Color.White;

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
