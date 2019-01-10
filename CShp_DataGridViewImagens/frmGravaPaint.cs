using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Accord;
using Accord.Video;
using Accord.Video.FFMPEG;
using CapturaTela;

namespace Geometricamente_V1
{
    public partial class frmGravaPaint : Form
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

        private void picDesenha_Click(object sender, EventArgs e)
        {
            if (picDesenha.BackColor == Color.Silver)
            {
                Comecar();
                picDesenha.BackColor = Color.GreenYellow;
            }
            else if (picDesenha.BackColor == Color.GreenYellow)
            {
                Salvar();
                picDesenha.BackColor = Color.Silver;
            }
        }

        public frmGravaPaint(String[] dados)
        {
            this.dados = dados;
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

                string fullName = string.Format(@"{0}\{1}_{2}.mp4", TestaPendrive() + "\\video", dados[0], DateTime.Now.ToString("yyyy.MM.dd_HH.mm.ss"));

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
                              (int)5000000);
                }
                catch (Exception e)
                {
                    MessageBox.Show("PASTA NAO ENCONTRADA!");
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

        private void btnSettings_Click(object sender, EventArgs e)
        {
           Settings();
        }

        private void frmGravaPaint_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Deseja Sair?", "GEOMETRICAMENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    Process[] pname = Process.GetProcessesByName("MSPAINT");
                    if (pname.Length > 0)
                    {
                        dr = new DialogResult();
                        dr = MessageBox.Show("Deseja Fechar o Paint?", "GEOMETRICAMENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            foreach (Process proc in Process.GetProcessesByName("MSPAINT"))
                            {
                                proc.Kill();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel fechar o Paint automaticamente! Feche manualmente. Mais detalhes \n" + ex.Message);
                }
            }
            else
            {
                e.Cancel = true;
            }


        }

        private void frmGravaPaint_Load(object sender, EventArgs e)
        {

        }

        private String TestaPendrive()
        {
            return Environment.CurrentDirectory;
        }

        private void Settings()
        {
             if (btnSettings.BackColor == Color.Transparent)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label5.Visible = true;
                cb_BitRate.Visible = true;
                cb_screenSelector.Visible = true;
                cb_VideoCodec.Visible = true;
                nud_FPS.Visible = true;
                btnSettings.BackColor = Color.Silver;
            }
            else if (btnSettings.BackColor == Color.Silver)
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label5.Visible = false;
                cb_BitRate.Visible = false;
                cb_screenSelector.Visible = false;
                cb_VideoCodec.Visible = false;
                nud_FPS.Visible = false;
                btnSettings.BackColor = Color.Transparent;
            }
        }
      
    }
}
