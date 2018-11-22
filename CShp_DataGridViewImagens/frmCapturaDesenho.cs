using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.FFMPEG;

namespace CapturaTela
{
    public partial class frmCapturaDesenho : Form
    {
        #region Atributos da Classe
        String[] dados = new string[100];

        bool cross;
        private bool _isRecording;
        private List<string> _screenNames;
        //private Rectangle _screenSize;
        private UInt32 _frameCount;
        private int fps = 0;
        private VideoFileWriter _writer;
        private int _width;
        private int _height;
        private ScreenCaptureStream _streamVideo;
        private Stopwatch _stopWatch;
        private Rectangle _screenArea;
        int screenLeft, screenTop;
        bool useArea;
        bool isMouseDown;

        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINTAPI ptScreenPos;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINTAPI
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ICONINFO
        {
            public bool fIcon;
            public Int32 xHotspot;
            public Int32 yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll")]
        public static extern IntPtr CopyIcon(IntPtr hIcon);

        [DllImport("user32.dll")]
        public static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO piconinfo);

        [DllImport("user32.dll")]
        static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        const Int32 CURSOR_SHOWING = 0x00000001;
        #endregion

        public frmCapturaDesenho()
        {
            InitializeComponent();
            g = pnl_Draw.CreateGraphics();
        }

        public frmCapturaDesenho(String[] dados)
        {
            frmCapturaDesenho frmCapturaDesenho = this;
            frmCapturaDesenho.dados = dados;
            InitializeComponent();

            _isRecording = false;
            //this._screenSize = Screen.PrimaryScreen.Bounds;

            _frameCount = 0;
            _width = SystemInformation.VirtualScreen.Width;
            _height = SystemInformation.VirtualScreen.Height;
            _stopWatch = new Stopwatch();
            _screenArea = Rectangle.Empty;

            _writer = new VideoFileWriter();

            _screenNames = new List<string>();
            _screenNames.Add(@"Select ALL");
            _screenNames.Add(@"Custom screen area");
            foreach (var screen in Screen.AllScreens)
            {
                _screenNames.Add(screen.DeviceName);
            }
            cb_screenSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_screenSelector.DataSource = _screenNames;

            // Codec ComboBox
            cb_VideoCodec.DataSource = Enum.GetValues(typeof(VideoCodec));
            cb_VideoCodec.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        #region Metodos Para Gravacao


        private void Comecar()
        {
            Start(false);
        }
        private void Salvar()
        {
            SetVisible(false);
            MessageBox.Show(@"Vídeo Salvo com sucesso!");
            pnl_Draw.BackgroundImage = null;

            pnl_Draw.BackColor = Color.White;

        }

        private void Start(bool selectArea)
        {
            try
            {

                StartRec(selectArea);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void StartRec(bool selectArea)
        {
            if (_isRecording == false)
            {
                SetScreenArea(selectArea);
                SetVisible(true);
                _frameCount = 0;
                
                string fullName = string.Format(@"{0}\{1}_{2}.mp4", TestaPendrive()+"\\video", dados[0], DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                DateTime agora = DateTime.Now;
                // Save File option

                try
                {
                    _writer.Open(
                              fullName,
                              _width,
                              _height,
                              10,
                              (VideoCodec)cb_VideoCodec.SelectedValue,
                              (int)(BitRate)5000000);
                }
                catch (Exception e)
                {
                    MessageBox.Show("PASTA NAO ENCONTRADA!!!");
                    throw e;
                }

                // Start main work
                StartRecord();
            }
        }

        private void SetScreenArea(bool selectArea)
        {
            screenLeft = screenTop = 0;
            useArea = false;

            // get entire desktop area size
            string screenName = cb_screenSelector.SelectedValue.ToString();
            if (string.Compare(screenName, @"Select ALL", StringComparison.OrdinalIgnoreCase) == 0)
            {
                foreach (Screen screen in Screen.AllScreens)
                {
                    _screenArea = screen.Bounds;
                    _width = _screenArea.Width;
                    _height = _screenArea.Height;
                }
            } // o de cima foca a tela toda!
            else if (string.Compare(screenName, @"Custom screen area", StringComparison.OrdinalIgnoreCase) == 0)
            {
                using (TopForm f = new TopForm())
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        WindowState = FormWindowState.Minimized;
                        _screenArea = f.AreaBounds;

                        decimal prop = (decimal)4 / 3;
                        decimal realProp = (decimal)f.w / f.h;
                        bool makeLonger = realProp < prop;
                        int w = Convert.ToInt32(makeLonger ? f.h * prop : f.w);
                        int h = Convert.ToInt32(makeLonger ? f.h : f.w / prop);

                        if ((w & 1) != 0)
                            w = w + 1;
                        if ((h & 1) != 0)
                            h = h + 1;

                        _width = w;
                        _height = h;
                        screenLeft = f.AreaBounds.Left;
                        screenTop = f.AreaBounds.Top;
                        useArea = true;
                    }
                }
            }
            else
            {
                _screenArea = Screen.AllScreens.Last(scr => scr.DeviceName.Equals(screenName)).Bounds;
                _width = _screenArea.Width;
                _height = _screenArea.Height;
            }
        }

        private void StartRecord() //Object stateInfo
        {
            // create screen capture video source
            _streamVideo = new ScreenCaptureStream(_screenArea);

            // set NewFrame event handler
            _streamVideo.NewFrame += Video_NewFrame;

            // start the video source
            _streamVideo.Start();

            // _stopWatch
            _stopWatch.Start();
        }

        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (_isRecording)
            {
                _frameCount++;

                Bitmap frame = eventArgs.Frame;


                Graphics graphics = Graphics.FromImage(frame);


                CURSORINFO pci;
                pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));

                if (GetCursorInfo(out pci))
                {
                    if (pci.flags == CURSOR_SHOWING)
                    {
                        int x = pci.ptScreenPos.x - screenLeft;
                        int y = pci.ptScreenPos.y - screenTop;

                        Color c = Color.Yellow;
                        float width = 2;
                        int radius = 30;
                        if ((MouseButtons & MouseButtons.Left) != 0 || (MouseButtons & MouseButtons.Right) != 0)
                        {
                            c = Color.OrangeRed;
                            width = 4;
                            radius = 35;
                        }
                        Pen p = new Pen(c, width);

                        graphics.DrawEllipse(p, x - radius / 2, y - radius / 2, radius, radius);
                        DrawIcon(graphics.GetHdc(), x, y, pci.hCursor);
                        graphics.ReleaseHdc();
                    }
                }
                if (useArea)
                {
                    var destRect = new Rectangle(Convert.ToInt32((_width - frame.Width) / 2), Convert.ToInt32((_height - frame.Height) / 2), frame.Width, frame.Height);
                    var destImage = new Bitmap(_width, _height);
                    destImage.SetResolution(frame.HorizontalResolution, frame.VerticalResolution);

                    graphics = Graphics.FromImage(destImage);
                    graphics.DrawImage(frame, destRect, 0, 0, frame.Width, frame.Height, GraphicsUnit.Pixel, null);
                    frame = destImage;
                }
                _writer.WriteVideoFrame(frame);
            }
            else
            {
                _stopWatch.Reset();
                Thread.Sleep(500);
                _streamVideo.SignalToStop();
                Thread.Sleep(500);
                _writer.Close();
            }
        }


        private void SetVisible(bool visible)
        {
            _isRecording = visible;
        }

        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isRecording = false;

        }
        #region Metodos de Desenho em pnl_Draw


        bool startPaint;
        Graphics g;        //nullable int for storing Null value
        int? initX = null;
        int? initY = null;
        bool drawSquare;
        bool drawRectangle;
        bool drawCircle;
        bool drawTriangle;
        private Brush sb;

        //Event Fired when the mouse pointer is over Panel and a mouse button is pressed
        private void pnl_Draw_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = pnl_Draw.CreateGraphics();
            SolidBrush sb = new SolidBrush(btn_PenColor.BackColor);

            startPaint = true;
            if (drawSquare)
            {
                //Use Solid Brush for filling the graphic shapes
                //setting the width and height same for creating square.
                //Getting the width and Heigt value from Textbox(txt_ShapeSize)
                g.FillRectangle(sb, e.X, e.Y, int.Parse(txt_ShapeSize.Text), int.Parse(txt_ShapeSize.Text));
                //setting startPaint and drawSquare value to false for creating one graphic on one click.
                startPaint = false;

                //drawSquare = false;
            }
            if (drawRectangle)
            {
                //setting the width twice of the height
                g.FillRectangle(sb, e.X, e.Y, 2 * int.Parse(txt_ShapeSize.Text), int.Parse(txt_ShapeSize.Text));
                startPaint = false;
                //drawRectangle = false;
            }
            if (drawCircle)
            {
                g.FillEllipse(sb, e.X, e.Y, int.Parse(txt_ShapeSize.Text), int.Parse(txt_ShapeSize.Text));
                startPaint = false;
                //drawCircle = false;
            }
            if (drawTriangle)
            {

                float angle = 0;
                PointF[] p = new PointF[3];

                p[0].X = e.X;

                p[0].Y = e.Y;

                p[1].X = (float)(e.X - int.Parse(txt_ShapeSize.Text) * Math.Cos(angle));

                p[1].Y = (float)(e.Y - int.Parse(txt_ShapeSize.Text) * Math.Sin(angle));

                p[2].X = (float)(e.X - int.Parse(txt_ShapeSize.Text) * Math.Cos(angle + Math.PI / 3));

                p[2].Y = (float)(e.Y - int.Parse(txt_ShapeSize.Text) * Math.Sin(angle + Math.PI / 3));

                g.FillPolygon(sb, p);
                //drawTriangle = false;
            }
        }

        //Button for Setting pen Color
        private void button1_Click(object sender, EventArgs e)
        {
            //Open Color Dialog and Set BackColor of btn_PenColor if user click on OK
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                btn_PenColor.BackColor = c.Color;
            }
        }

        private void btn_CanvasColor_Click_1(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                pnl_Draw.BackColor = c.Color;
            }
        }

        private void btn_Square_Click(object sender, EventArgs e)
        {
            if (picQuadrado.BackColor == Color.White)
            {
                picTriangulo.BackColor = Color.White;
                picCirculo.BackColor = Color.White;
                picRetangulo.BackColor = Color.White;
                drawTriangle = false;
                drawCircle = false;
                drawRectangle = false;


                picQuadrado.BackColor = btn_PenColor.BackColor;
                drawSquare = true;
            }
            else if (picQuadrado.BackColor == btn_PenColor.BackColor)
            {
                drawSquare = false;
                picQuadrado.BackColor = Color.White;
            }
        }

        private void btn_Rectangle_Click(object sender, EventArgs e)
        {

            if (picRetangulo.BackColor == Color.White)
            {
                picTriangulo.BackColor = Color.White;
                picCirculo.BackColor = Color.White;
                picQuadrado.BackColor = Color.White;

                drawTriangle = false;
                drawCircle = false;
                drawSquare = false;

                picRetangulo.BackColor = btn_PenColor.BackColor;
                drawRectangle = true;
            }
            else if (picRetangulo.BackColor == btn_PenColor.BackColor)
            {
                drawRectangle = false;
                picRetangulo.BackColor = Color.White;
            }

        }

        private void btn_Circle_Click(object sender, EventArgs e)
        {
            if (picCirculo.BackColor == Color.White)
            {
                picTriangulo.BackColor = Color.White;
                picRetangulo.BackColor = Color.White;
                picQuadrado.BackColor = Color.White;

                drawTriangle = false;
                drawRectangle = false;
                drawSquare = false;

                picCirculo.BackColor = btn_PenColor.BackColor;

                drawCircle = true;
            }
            else if (picCirculo.BackColor == btn_PenColor.BackColor)
            {
                drawCircle = false;
                picCirculo.BackColor = Color.White;
            }

        }
        private void btn_Triangle_Click(object sender, EventArgs e)
        {
            if (picTriangulo.BackColor == Color.White)
            {
                picCirculo.BackColor = Color.White;
                picRetangulo.BackColor = Color.White;
                picQuadrado.BackColor = Color.White;

                drawCircle = false;
                drawRectangle = false;
                drawSquare = false;

                picTriangulo.BackColor = btn_PenColor.BackColor;
                drawTriangle = true;
            }
            else if (picTriangulo.BackColor == btn_PenColor.BackColor)
            {
                drawTriangle = false;
                picTriangulo.BackColor = Color.White;
            }
        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Deseja mesmo sair?", "GEOMETRICAMENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (picDesenha.BackColor == Color.Transparent)
            {
                Comecar();
                picDesenha.BackColor = Color.GreenYellow;
            }
            else if (picDesenha.BackColor == Color.GreenYellow)
            {
                Salvar();
                picDesenha.BackColor = Color.Transparent;
            }

        }

        private void picApaga_Click(object sender, EventArgs e)
        {
            pnl_Draw.ResetBackColor();
            pnl_Draw.BackColor = Color.White;
            picCirculo.BackColor = Color.White;
            picQuadrado.BackColor = Color.White;
            picRetangulo.BackColor = Color.White;
            picTriangulo.BackColor = Color.White;
        }


        private void tkbTamanho_ValueChanged(object sender, EventArgs e)
        {
            TamanhoForma();  
        }


        private void pnl_Draw_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void TamanhoForma()
        {
            if (tkbTamanho.Value == 0)
            {
                txt_ShapeSize.Text = "25";
            }
            else if (tkbTamanho.Value == 1)
            {
                txt_ShapeSize.Text = "50";
            }
            else if (tkbTamanho.Value == 2)
            {
                txt_ShapeSize.Text = "100";
            }
            else if (tkbTamanho.Value == 3)
            {
                txt_ShapeSize.Text = "150";

            }
            else if (tkbTamanho.Value == 4)
            {
                txt_ShapeSize.Text = "200";

            }
            else if (tkbTamanho.Value == 5)
            {
                txt_ShapeSize.Text = "250";
            }
            else if (tkbTamanho.Value == 6)
            {

                txt_ShapeSize.Text = "300";
            }
            else if (tkbTamanho.Value == 7)
            {
                txt_ShapeSize.Text = "350";
            }
            else if (tkbTamanho.Value == 8)
            {
                txt_ShapeSize.Text = "400";
            }
            else if (tkbTamanho.Value == 9)
            {
                txt_ShapeSize.Text = "450";
            }
            else if (tkbTamanho.Value == 10)
            {
                txt_ShapeSize.Text = "500";
            }
        }

        private void btnCrosshair_Click(object sender, EventArgs e)
        {
            if (btnCrosshair.BackColor == Color.White)
            {
                cross = true;
                btnCrosshair.BackColor = Color.Silver;
                label_X.Visible = false;
                label_Y.Visible = false;
                lblX.Visible = false;
                lblY.Visible = false;
            }
            else if (btnCrosshair.BackColor == Color.Silver)
            {
                cross = false;
                btnCrosshair.BackColor = Color.White;
                label_X.Visible = true;
                label_Y.Visible = true;
                lblX.Visible = true;
                lblY.Visible = true;
            }
        }

        private void pnl_Draw_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (!cross)
            {
                line_X.Show();
                line_Y.Show();
                label_X.Text = e.Location.X.ToString();
                label_Y.Text = e.Location.Y.ToString();
                line_Y.Location = new Point((e.Location.X + 0), 0);
                line_X.Location = new Point(0, (e.Location.Y + 0));
            }
            else if (cross)
            {
                line_X.Hide();
                line_Y.Hide();
            }
        }

        private String TestaPendrive()
        {
            return Environment.CurrentDirectory;
        }
    }
    public enum BitRate
    {
        _50kbit = 5000,
        _100kbit = 10000,
        _500kbit = 50000,
        _1000kbit = 1000000,
        _2000kbit = 2000000,
        _3000kbit = 3000000,
        _4000kbit = 4000000,
        _5000kbit = 5000000
    }

}
