using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Accord.Video.FFMPEG;
using Accord.Video;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using DrawTools;


namespace SVGEditor2.Tools.ToolBoxes
{
    public partial class ToolBox : Form
    {
        public String ToolSelection = "";

        // Declare the delegate (if using non-generic pattern).
        public delegate void ToolSelectionChangedEventHandler(object sender, EventArgs e);

        // Declare the event.
        public event ToolSelectionChangedEventHandler ToolSelectionChanged;

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
        private ToolBarButton tbTriangle;
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
        // AQUI VEM O NOME
        public string fullName;
        string dh_save;

        public ToolBox(String[] ui)
        {
            InitializeComponent();
            if (ui != null)
            {
                this.dados = ui;
            }

            MessageBox.Show(Environment.CurrentDirectory);


            #region CONSTRUTOR'S VARIABLES
            _isRecording = false;
            //this._screenSize = Screen.PrimaryScreen.Bounds;

            _frameCount = 0;
            _width = SystemInformation.VirtualScreen.Width;
            _height = SystemInformation.VirtualScreen.Height;
            _stopWatch = new Stopwatch();
            _screenArea = Rectangle.Empty;

            _writer = new VideoFileWriter();

            _screenNames = new List<string>
            {
                @"Select ALL",
                @"Custom screen area"
            };
            foreach (var screen in Screen.AllScreens)
            {
                _screenNames.Add(screen.DeviceName);
            }
            #endregion

            // MessageBox.Show( Environment.CurrentDirectory);


        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            String ToolSelected = ((RadioButton)(sender)).Name;

            if (!((RadioButton)(sender)).Checked)
                return;

            switch (ToolSelected)
            {
                case "radioButton_Pointer":
                    ToolSelection = "Pointer";
                    break;
                case "radioButton_rectangle":
                    ToolSelection = "Rectangle";
                    break;
                case "radioButton_line":
                    ToolSelection = "Line";
                    break;
                case "radioButton_ellipse":
                    ToolSelection = "Ellipse";
                    break;
                case "radioButton_pan":
                    ToolSelection = "Pan";
                    break;
                case "radioButton_pencil":
                    ToolSelection = "Pencil";
                    break;
                case "radioButton_text":
                    ToolSelection = "Text";
                    break;
                case "radioButton_path":
                    ToolSelection = "Path";
                    break;
                case "radioButton_image":
                    ToolSelection = "Image";
                    break;
            }
            ToolSelectionChanged?.Invoke(ToolSelection, null);
        }

        public void SetToolSelection(DrawTools.DrawArea.DrawToolType tool)
        {
            switch (tool)
            {
                case DrawTools.DrawArea.DrawToolType.Pointer:
                    radioButton_Pointer.Checked = true;
                    break;
                case DrawTools.DrawArea.DrawToolType.Ellipse:
                    radioButton_ellipse.Checked = true;
                    break;
                case DrawTools.DrawArea.DrawToolType.Rectangle:
                    radioButton_rectangle.Checked = true;
                    break;
                case DrawTools.DrawArea.DrawToolType.Line:
                    radioButton_line.Checked = true;
                    break;
                case DrawTools.DrawArea.DrawToolType.Pan:
                    radioButton_pan.Checked = true;
                    break;
                case DrawTools.DrawArea.DrawToolType.Polygon:
                    radioButton_pencil.Checked = true;
                    break;
                default:
                    radioButton_Pointer.Checked = true;
                    break;
            }
        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (btnGravar.BackColor == SystemColors.Control)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Deseja Gravar a tela?", "GEOMETRICAMENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        Comecar();
                        btnGravar.BackColor = Color.Red;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível gravar a tela!  Mais detalhes \n" + ex.Message);
                    }
                }
            }
            else if (btnGravar.BackColor == Color.Red)
            {

                Salvar();
                btnGravar.BackColor = SystemColors.Control;
            }

        }

        #region Metodos Para Gravacao


        private void Comecar()
        {
            Start(false);
        }
        private void Salvar()
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Pronto! deseja salvar o video?", "GEOMETRIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                // metodo para gravar no video

                SetVisible(false);
                MessageBox.Show(@"Vídeo Salvo com sucesso!");

                //Gravar no BD 
                //try
                //{
                //    /*    // as datas estao no metodo start_rec para sincronizar data do banco e data no nome do arquivo (aqui o nome forma ja no inicio)
                //        Video_DAO vDAO = new Video_DAO();
                //        Video video = new Video
                //        {
                //            Nome_arquivo = fullName,
                //            Audio_id = 0,
                //            Idade = Convert.ToInt32(dados[1]),
                //            Artista = dados[0],
                //            Data = dh_save
                //        };
                //        vDAO.inserir(video);*/
                //}
                //catch (Exception er)
                //{
                //    MessageBox.Show("Erro ao inserir video no Banco de Dados!\n" + "mais detalhes:" + er.Message);
                //}
            }
        }

        private void Start(bool selectArea)
        {
            try
            {
                StartRec(selectArea);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro ao iniciar gravação ! \n Método Start \n mais detalhes " + exc.Message);
            }
        }

        private void StartRec(bool selectArea)
        {
            if (_isRecording == false)
            {
                SetScreenArea(selectArea);
                SetVisible(true);
                _frameCount = 0;



                // Save File option

                DateTime agora = DateTime.Now;
                string dh_arquivo = agora.ToString("yyyy-MM-dd_HH-mm-ss");
                string dh_save = agora.ToString("yyyy-MM-dd HH:mm:ss");

                string fullName = TestaPendrive() + "\\video\\" + dh_arquivo + "_" + dados[0] + "_" + dados[1] + "anos" + ".mp4";
                try
                {
                    _writer = new VideoFileWriter();
                    _writer.Open(
                              fullName,
                              _width,
                              _height,
                              10,
                              VideoCodec.MPEG4,
                              (int)5000000);

                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao executar o método StartRec \n " + e.Message);

                }

                // Start main work
                StartRecord();
            }
        }

        private string TestaPendrive()
        {
            return Environment.CurrentDirectory;
        }

        private void SetScreenArea(bool selectArea)
        {
            screenLeft = screenTop = 0;
            useArea = false;

            // get entire desktop area size
            string screenName = "Select ALL";
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
    }
}
