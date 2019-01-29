using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using BD.DAO;
using BD.Model;

namespace Geometricamente_V1
{
    public partial class FrmGravaDescricao : Form
    {
        #region Atributos
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

        #endregion

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
            // MessageBox.Show(dados[10]);
            MessageBox.Show(Environment.CurrentDirectory);



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
            //MessageBox.Show("hey");
        }
        public void ParaGravar()
        {
            try
            {
                timer1.Stop();
                DateTime agora = DateTime.Now;
                string dh_arquivo = agora.ToString("yyyy-MM-dd_HH-mm-ss");
                string dh_save = agora.ToString("yyyy-MM-dd HH:mm:ss");
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Pronto! deseja salvar?", "GEOMETRIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {
                    mciSendString("save recsound " + TestaPendrive() + "\\audio\\" + dados[10] + "_" + dh_arquivo + "_" + dados[0] + "_" + dados[1] + "anos" + ".mp3", null, 0,
                        IntPtr.Zero);
                    mciSendString("close recsound", null, 0, IntPtr.Zero);

                    //Gravar no BD 
                    Audio_DAO aDAO = new Audio_DAO();
                    Audio audio = new Audio
                    {
                        Nome_arquivo = dados[10] + "_" + dh_arquivo + "_" + dados[0] + "_" + dados[1] + "anos" + ".mp3",
                        Nome_imagem = dados[10],
                        Idade = Convert.ToInt32(dados[1]),
                        Narrador = dados[0],
                        Data = dh_save
                    };
                    aDAO.inserir(audio);

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
                Close();
            }
        }


        private void PicGravador_Click(object sender, EventArgs e)
        {
            if (picGravador.BackColor == Color.White)
            {
                lblGravando.ForeColor = Color.GreenYellow;
                picGravador.BackColor = Color.GreenYellow;
                Gravar();
            }
            else if (picGravador.BackColor == Color.GreenYellow)
            {
                lblGravando.ForeColor = Color.White;
                picGravador.BackColor = Color.White;
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


    }

}



