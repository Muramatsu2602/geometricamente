using System.Drawing;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Input;
using System.Drawing.Drawing2D;

namespace Geometricamente_V1
{
    public partial class frmGravaDescricao : Form
    {
        DateTime tempoInicial;
        TimeSpan diferencaTempo;
        String[] dados = new string[100];

        Pen crossPen;
        Pen rectanglePen;
        Brush rectangleBrush;

        //gravação de audio
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command, StringBuilder retstring, int ReturnLength, IntPtr callback);

        private void frmFala_Load(object sender, EventArgs e)
        {
            pictureBox2.Enabled = false;
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

            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            crossPen = new Pen(Color.Red, 2);
            rectangleBrush = new SolidBrush(Color.FromArgb(50, Color.Blue));
            rectanglePen = new Pen(Color.Blue, 1);

        }
        bool mouseDown = false;
        Point startPoint = Point.Empty;
        Point endPoint = Point.Empty;

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            diferencaTempo = (DateTime.Now).Subtract(tempoInicial);
            lblTempo.Text = diferencaTempo.ToString("c");
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            mciSendString("record recsound", null, 0, IntPtr.Zero);
            pictureBox2.Enabled = false;
            pictureBox1.Enabled = true;
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
                    pictureBox2.Enabled = false;
                    pictureBox1.Enabled = false;
                }
                else
                {
                    pictureBox1.Enabled = true;
                    pictureBox2.Enabled = false;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("DEU ERRO" + a);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblCoordenadas.Text = string.Format("X = {0}, Y = {1}", e.X, e.Y);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            startPoint = e.Location;
            mouseDown = true;
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            mouseDown = false;
            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            endPoint = e.Location;
            this.Invalidate();
            base.OnMouseMove(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            if (this.ClientRectangle.Contains(endPoint))
                DrawCross(e.Graphics, endPoint);
        }

        void DrawCross(Graphics g, Point point)
        {
            g.DrawLine(crossPen, new Point(0, point.Y), new Point(Width, point.Y));
            g.DrawLine(crossPen, new Point(point.X, 0), new Point(point.X, Height));
        }
    
       
    }
}



