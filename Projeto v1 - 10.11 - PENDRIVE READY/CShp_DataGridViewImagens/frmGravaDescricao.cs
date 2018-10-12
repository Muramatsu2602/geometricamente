using System.Drawing;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using System.Text;


namespace CShp_DataGridViewImagens
{
    public partial class frmGravaDescricao : Form
    {
        DateTime tempoInicial;
        TimeSpan diferencaTempo;
        String[] dados = new string[100];

        //gravação de audio
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command, StringBuilder retstring, int ReturnLength, IntPtr callback);

        private void frmFala_Load(object sender, EventArgs e)
        {
            btnParaGravar.Enabled = false;
        }

        public frmGravaDescricao(Image imgForm, String[] dados)
        {
            InitializeComponent();
            /*Image img;
            img = Image.FromFile(caminhoImagem);*/
            // gravar audio
            mciSendString("open new Type waveaudio alias recsound", null, 0, IntPtr.Zero);
            picImagem.Image = imgForm;
            this.dados = dados;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            diferencaTempo = (DateTime.Now).Subtract(tempoInicial);
            lblTempo.Text = diferencaTempo.ToString("c");
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            mciSendString("record recsound", null, 0, IntPtr.Zero);
            btnGravar.Enabled = false;
            btnParaGravar.Enabled = true;
            //cronometro
            tempoInicial = DateTime.Now;
            timer1.Start();
        }

        private void btnParaGravar_Click(object sender, EventArgs e)
        {

            try
            {
                timer1.Stop();

                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Pronto! deseja salvar?", "GEOMETRIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {
                    DateTime agora = DateTime.Now;
                    mciSendString("Save recsound C:\\DADOS_SISTEMA\\audio\\" + agora.ToString("yyyy-MM-dd_HH-mm-ss") + "_img-" + dados[2] + "_" + dados[0] + "_" + dados[1] + "anos" + ".wav", null, 0, IntPtr.Zero);
                    mciSendString("close recsound", null, 0, IntPtr.Zero);
                    btnParaGravar.Enabled = false;
                    btnGravar.Enabled = false;
              
                }
                else
                {
                    btnGravar.Enabled = true;
                    btnParaGravar.Enabled = false;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("DEU ERRO" + a);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
