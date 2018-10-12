using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CShp_DataGridViewImagens
{
    public partial class frmGravaTela_v1 : Form
    {
        public frmGravaTela_v1()
        {
            InitializeComponent();
        }
        Bitmap bmp;
        Graphics gr;

        private void btnComecaGravacao_Click(object sender, EventArgs e)
        {
            tmrGrava.Start();
        }

        private void btnPararGravar_Click(object sender, EventArgs e)
        {
            tmrGrava.Stop();
        }

        private void tmrGrava_Tick(object sender, EventArgs e)
        {
           

            try
            {
                bmp = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                gr = Graphics.FromImage(bmp);
                gr.CopyFromScreen(0, 0, 0, 0, new Size(bmp.Width, bmp.Height));
                pictureBox1.Image = bmp;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


                bmp.Save(@"C:\DADOS_SISTEMA\teste_gravar_tela\"+ "issae" +".mp4");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
