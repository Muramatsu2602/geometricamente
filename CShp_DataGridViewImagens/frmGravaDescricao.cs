using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Geometricamente_V1
{
    public partial class FrmGravaDescricao : Form
    {
        DateTime tempoInicial;
        TimeSpan diferencaTempo;
        String[] dados = new string[100];
        Pen crossPen;
        Pen rectanglePen;
        Brush rectangleBrush;
        bool mouseDown;
        Point startPoint = Point.Empty;
        Point endPoint = Point.Empty;
        bool cross;

        public bool Ligado { get; set; } = true;
        public Pen CrossPen { get => crossPen; set => crossPen = value; }
        public DateTime TempoInicial { get => tempoInicial; set => tempoInicial = value; }
        public TimeSpan DiferencaTempo { get => diferencaTempo; set => diferencaTempo = value; }
        public string[] Dados { get => dados; set => dados = value; }
        public Pen CrossPen1 { get => crossPen; set => crossPen = value; }
        public Pen RectanglePen { get => rectanglePen; set => rectanglePen = value; }
        public Brush RectangleBrush { get => rectangleBrush; set => rectangleBrush = value; }
        public bool MouseDown1 { get => mouseDown; set => mouseDown = value; }
        public Point StartPoint { get => startPoint; set => startPoint = value; }
        public Point EndPoint { get => endPoint; set => endPoint = value; }
        public bool Cross { get => cross; set => cross = value; }

        //gravação de audio
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command, StringBuilder retstring, int ReturnLength, IntPtr callback);

        private void frmFala_Load(object sender, EventArgs e)
        {

        }

        public FrmGravaDescricao(Image imgForm, String[] dados)
        {
            InitializeComponent();
            mciSendString("open new Type waveaudio alias recsound", null, 0, IntPtr.Zero);
            picImagem.Image = imgForm;
            this.dados = dados;
            DoubleBuffered = true;
            ResizeRedraw = true;
            CrossPen = new Pen(Color.Red, 2);
            rectangleBrush = new SolidBrush(Color.FromArgb(50, Color.Blue));
            rectanglePen = new Pen(Color.Blue, 1);
            tmrCross.Start();

        }
        private void timer1_Tick(object sender, EventArgs e)
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
                    mciSendString("save recsound " + TestaPendrive() + "\\audio\\" + agora.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + dados[0] + "_" + dados[1] + "anos" + ".mp3", null, 0,
                        IntPtr.Zero);
                    mciSendString("close recsound", null, 0, IntPtr.Zero);
                }
                else if (dr == DialogResult.No)
                {
                    lblTempo.Text = "00:00:00";
                    picGravador.Focus();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("DEU ERRO" + a);
            }
        }

        public String TestaPendrive()
        {

            return Environment.CurrentDirectory;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
        
            dr = MessageBox.Show("Deseja mesmo sair?", "GEOMETRICAMENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            
         
        }


        private void PicGravador_Click(object sender, EventArgs e)
        {
            if (picGravador.BackColor == Color.Transparent)
            {
                lblGravando.ForeColor = Color.GreenYellow;
                picGravador.BackColor = Color.GreenYellow;
                Gravar();
            }
            else if (picGravador.BackColor == Color.GreenYellow)
            {
                lblGravando.ForeColor = Color.Silver;
                picGravador.BackColor = Color.Transparent;
                ParaGravar();
            }
        }


        private void picImagem_MouseMove(object sender, MouseEventArgs e)
        {

            if (!cross)
            {
                line_X.Show();
                line_Y.Show();
                label_X.Text = e.Location.X.ToString();
                label_Y.Text = e.Location.Y.ToString();
                line_Y.Location = new Point((e.Location.X + 0), 50);
                line_X.Location = new Point(0, (e.Location.Y + 50));
            }
            else if (cross)
            {
                line_X.Hide();
                line_Y.Hide();
            }
        }
        private void btnCrosshair_Click(object sender, EventArgs e)
        {

            if (btnCrosshair.BackColor == Color.White)
            {
                cross = true;
                label_X.Visible = false;
                label_Y.Visible = false;
                label3.Visible = false;
                label2.Visible = false;
                btnCrosshair.BackColor = Color.Silver;

            }
            else if (btnCrosshair.BackColor == Color.Silver)
            {
                cross = false;
                 label_X.Visible = true;
                label_Y.Visible = true;
                label3.Visible = true;
                label2.Visible = true;
                btnCrosshair.BackColor = Color.White;
            }

        }

        private void tmrCross_Tick(object sender, EventArgs e)
        {

        }
    }

}



