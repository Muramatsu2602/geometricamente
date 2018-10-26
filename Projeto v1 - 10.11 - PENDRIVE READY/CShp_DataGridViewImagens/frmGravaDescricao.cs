using System.Drawing;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Input;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace Geometricamente_V1
{
    public partial class frmGravaDescricao : Form
    {
        DateTime tempoInicial;
        TimeSpan diferencaTempo;
        String[] dados = new string[100];
        bool ligado = true;


        Pen crossPen;
        Pen rectanglePen;
        Brush rectangleBrush;
        bool mouseDown = false;
        Point startPoint = Point.Empty;
        Point endPoint = Point.Empty;

        //gravação de audio
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command, StringBuilder retstring, int ReturnLength, IntPtr callback);

        private void frmFala_Load(object sender, EventArgs e)
        {
       
        }

        public frmGravaDescricao(Image imgForm, String[] dados)
        {
            InitializeComponent();
            mciSendString("open new Type waveaudio alias recsound", null, 0, IntPtr.Zero);
            picImagem.Image = imgForm;
            this.dados = dados;
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            crossPen = new Pen(Color.Red, 2);
            rectangleBrush = new SolidBrush(Color.FromArgb(50, Color.Blue));
            rectanglePen = new Pen(Color.Blue, 1);



        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            diferencaTempo = (DateTime.Now).Subtract(tempoInicial);
            lblTempo.Text = diferencaTempo.ToString("c");
        }

     
        public void Gravar()
        {
            mciSendString("record recsound", null, 0, IntPtr.Zero);
            //cronometro
            tempoInicial = DateTime.Now;
            timer1.Start();
        }
        public void ParaGravar()
        {
            try
            {
                timer1.Stop();

                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Pronto! deseja salvar?", "GEOMETRIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {
                    DateTime agora = DateTime.Now;
                    mciSendString("Save recsound D:\\Geometricamente\\audio\\" + agora.ToString("yyyy-MM-dd_HH-mm-ss") + "_img-" + dados[2] + "_" + dados[0] + "_" + dados[1] + "anos" + ".wav", null, 0, IntPtr.Zero);
                    mciSendString("close recsound", null, 0, IntPtr.Zero);

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
            endPoint = picImagem.Location;
            this.Invalidate();
            base.OnMouseMove(e);
            lblCoordenadas.Text = string.Format("X = {0}, Y = {1}", e.X, e.Y);
        }
        private void picImagem_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            base.OnMouseUp(e);
        }
        private void picImagem_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = picImagem.Location;
            mouseDown = true;
            base.OnMouseDown(e);
        }

        void DrawCross(Graphics g, Point point)
        {
            g.DrawLine(crossPen, new Point(0, point.Y), new Point(picImagem.Width, point.Y));
            g.DrawLine(crossPen, new Point(point.X, 0), new Point(point.X, picImagem.Height));
        }

        private void picImagem_Paint(object sender, PaintEventArgs e)
        {
            /*
            if (this.ClientRectangle.Contains(endPoint))
                DrawCross(e.Graphics, endPoint); */
        }

        private void PicGravador_Click(object sender, EventArgs e)
        {
            if (picGravador.BackColor == Color.Transparent)
            {
                Gravar();
                picGravador.BackColor = Color.Red;

            }
            else if (picGravador.BackColor == Color.Red)
            {
                ParaGravar();
                picGravador.BackColor = Color.Transparent;
            }
        }


        /*
        private void picImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblCoordenadas.Text = string.Format("X = {0}, Y = {1}", e.X, e.Y);         
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            startPoint = picImagem.Location;
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
            endPoint = picImagem.Location;
            this.Invalidate();
            base.OnMouseMove(e);
        }
        
        

        private void picImagem_Paint(object sender, PaintEventArgs e)
        {
            if (this.ClientRectangle.Contains(endPoint))
                DrawCross(e.Graphics, endPoint);
        }
        */




    }

}



