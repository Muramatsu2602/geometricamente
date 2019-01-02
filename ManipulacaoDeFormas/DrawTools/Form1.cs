using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security;
using System.Runtime.Serialization;
using DocToolkit;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using AForge.Video;
using AForge.Video.FFMPEG;
using SVGLib;
using Draw;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Resources;

/// 
/// Drawing of graphics shapes (line, rectangle,
/// ellipse, polygon) on the window client area
/// using mouse.
/// Program works like MFC sample DRAWCLI
/// and uses some design decisions from this sample.
/// 
/// Dependencies: DocToolkit Library.



namespace DrawTools
{
    /// <summary>
    /// Main application form
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuFileNew;
        private System.Windows.Forms.MenuItem menuFileOpen;
        private System.Windows.Forms.MenuItem menuFileSave;
        private System.Windows.Forms.MenuItem menuFileSaveAs;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuFileRecentFiles;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuFileExit;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuHelpAbout;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbNew;
        private System.Windows.Forms.ToolBarButton tbOpen;
        private System.Windows.Forms.ToolBarButton tbSave;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton tbAbout;
        private DrawTools.DrawArea drawArea;
        private System.Windows.Forms.ToolBarButton tbPointer;
        private System.Windows.Forms.ToolBarButton tbRectangle;
        private System.Windows.Forms.ToolBarButton tbEllipse;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuDrawPointer;
        private System.Windows.Forms.MenuItem menuDrawRectangle;
        private System.Windows.Forms.MenuItem menuDrawEllipse;
        private System.Windows.Forms.ToolBarButton tbLine;
        private System.Windows.Forms.MenuItem menuDrawLine;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuEditSelectAll;
        private System.Windows.Forms.MenuItem menuEditUnselectAll;
        private System.Windows.Forms.MenuItem menuEditDelete;
        private System.Windows.Forms.MenuItem menuEditDeleteAll;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuEditMoveToFront;
        private System.Windows.Forms.MenuItem menuEditMoveToBack;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuEditProperties;
        private System.Windows.Forms.ToolBarButton tbPolygon;
        private System.Windows.Forms.MenuItem menuDrawPolygon;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.ToolBarButton tbText;
        private System.Windows.Forms.ToolBarButton tbBitMap;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolBarButton tbFill;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem miExport;
        private System.Windows.Forms.MenuItem miPrint;
        private System.Windows.Forms.MenuItem miPreview;
        private ToolBarButton tbRecord;
        private MenuItem menuItem11;
        private System.Windows.Forms.MenuItem miScale;

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

        #region Constructor, Dispose



        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            #region CONSTRUTOR'S VARIABLES
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
            #endregion

            _config = Config.Instance(this);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Windows Form Designer generated code

        //		public static string ApplicationName = "SvgPaint";
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuFileNew = new System.Windows.Forms.MenuItem();
            this.menuFileOpen = new System.Windows.Forms.MenuItem();
            this.menuFileSave = new System.Windows.Forms.MenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.MenuItem();
            this.miExport = new System.Windows.Forms.MenuItem();
            this.miPrint = new System.Windows.Forms.MenuItem();
            this.miPreview = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuFileRecentFiles = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuFileExit = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuEditSelectAll = new System.Windows.Forms.MenuItem();
            this.menuEditUnselectAll = new System.Windows.Forms.MenuItem();
            this.menuEditDelete = new System.Windows.Forms.MenuItem();
            this.menuEditDeleteAll = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuEditMoveToFront = new System.Windows.Forms.MenuItem();
            this.menuEditMoveToBack = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuEditProperties = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.miScale = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuDrawPointer = new System.Windows.Forms.MenuItem();
            this.menuDrawRectangle = new System.Windows.Forms.MenuItem();
            this.menuDrawEllipse = new System.Windows.Forms.MenuItem();
            this.menuDrawLine = new System.Windows.Forms.MenuItem();
            this.menuDrawPolygon = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuHelpAbout = new System.Windows.Forms.MenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbSave = new System.Windows.Forms.ToolBarButton();
            this.tbFill = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tbPointer = new System.Windows.Forms.ToolBarButton();
            this.tbLine = new System.Windows.Forms.ToolBarButton();
            this.tbRectangle = new System.Windows.Forms.ToolBarButton();
            this.tbPolygon = new System.Windows.Forms.ToolBarButton();
            this.tbEllipse = new System.Windows.Forms.ToolBarButton();
            this.tbBitMap = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.tbText = new System.Windows.Forms.ToolBarButton();
            this.tbNew = new System.Windows.Forms.ToolBarButton();
            this.tbAbout = new System.Windows.Forms.ToolBarButton();
            this.tbRecord = new System.Windows.Forms.ToolBarButton();
            this.tbOpen = new System.Windows.Forms.ToolBarButton();
            this.drawArea = new DrawTools.DrawArea();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3,
            this.menuItem9,
            this.menuItem2,
            this.menuItem1,
            this.menuItem10});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFileNew,
            this.menuFileOpen,
            this.menuFileSave,
            this.menuFileSaveAs,
            this.miExport,
            this.miPrint,
            this.miPreview,
            this.menuItem7,
            this.menuItem6,
            this.menuFileRecentFiles,
            this.menuItem8,
            this.menuFileExit});
            this.menuItem1.Text = "Arquivo";
            // 
            // menuFileNew
            // 
            this.menuFileNew.Index = 0;
            this.menuFileNew.Text = "Novo Documento";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Index = 1;
            this.menuFileOpen.Text = "Abrir Documento";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Index = 2;
            this.menuFileSave.Text = "Salvar Documento";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Index = 3;
            this.menuFileSaveAs.Text = "Salvar como...";
            this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
            // 
            // miExport
            // 
            this.miExport.Index = 4;
            this.miExport.Text = "Exportar para  jpg/png...";
            this.miExport.Click += new System.EventHandler(this.miExport_Click);
            // 
            // miPrint
            // 
            this.miPrint.Index = 5;
            this.miPrint.Text = "Imprimir...";
            this.miPrint.Click += new System.EventHandler(this.miPrint_Click);
            // 
            // miPreview
            // 
            this.miPreview.Index = 6;
            this.miPreview.Text = "Imprimir/Visualizar...";
            this.miPreview.Click += new System.EventHandler(this.miPreview_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 7;
            this.menuItem7.Text = "Propriedades";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 8;
            this.menuItem6.Text = "-";
            // 
            // menuFileRecentFiles
            // 
            this.menuFileRecentFiles.Index = 9;
            this.menuFileRecentFiles.Text = "Últimos documentos abertos";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 10;
            this.menuItem8.Text = "-";
            // 
            // menuFileExit
            // 
            this.menuFileExit.Index = 11;
            this.menuFileExit.Text = "Sair";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuEditSelectAll,
            this.menuEditUnselectAll,
            this.menuEditDelete,
            this.menuEditDeleteAll,
            this.menuItem4,
            this.menuEditMoveToFront,
            this.menuEditMoveToBack,
            this.menuItem5,
            this.menuEditProperties});
            this.menuItem3.Text = "Editar";
            // 
            // menuEditSelectAll
            // 
            this.menuEditSelectAll.Index = 0;
            this.menuEditSelectAll.Text = "Selecionar Todos";
            this.menuEditSelectAll.Click += new System.EventHandler(this.menuEditSelectAll_Click);
            // 
            // menuEditUnselectAll
            // 
            this.menuEditUnselectAll.Index = 1;
            this.menuEditUnselectAll.Text = "Desselecionar todos";
            this.menuEditUnselectAll.Click += new System.EventHandler(this.menuEditUnselectAll_Click);
            // 
            // menuEditDelete
            // 
            this.menuEditDelete.Index = 2;
            this.menuEditDelete.Text = "Apagar";
            this.menuEditDelete.Click += new System.EventHandler(this.menuEditDelete_Click);
            // 
            // menuEditDeleteAll
            // 
            this.menuEditDeleteAll.Index = 3;
            this.menuEditDeleteAll.Text = "Apagar todos";
            this.menuEditDeleteAll.Click += new System.EventHandler(this.menuEditDeleteAll_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 4;
            this.menuItem4.Text = "-";
            // 
            // menuEditMoveToFront
            // 
            this.menuEditMoveToFront.Index = 5;
            this.menuEditMoveToFront.Text = "Mover para Frente";
            this.menuEditMoveToFront.Click += new System.EventHandler(this.menuEditMoveToFront_Click);
            // 
            // menuEditMoveToBack
            // 
            this.menuEditMoveToBack.Index = 6;
            this.menuEditMoveToBack.Text = "Mover para Trás";
            this.menuEditMoveToBack.Click += new System.EventHandler(this.menuEditMoveToBack_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 7;
            this.menuItem5.Text = "-";
            // 
            // menuEditProperties
            // 
            this.menuEditProperties.Index = 8;
            this.menuEditProperties.Text = "Propriedades";
            this.menuEditProperties.Click += new System.EventHandler(this.menuEditProperties_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miScale});
            this.menuItem9.Text = "Ver";
            // 
            // miScale
            // 
            this.miScale.Index = 0;
            this.miScale.Text = "Escala...";
            this.miScale.Click += new System.EventHandler(this.miScale_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuDrawPointer,
            this.menuDrawRectangle,
            this.menuDrawEllipse,
            this.menuDrawLine,
            this.menuDrawPolygon,
            this.menuItem11});
            this.menuItem2.Text = "Desenhar";
            // 
            // menuDrawPointer
            // 
            this.menuDrawPointer.Index = 0;
            this.menuDrawPointer.Text = "Ponto";
            this.menuDrawPointer.Click += new System.EventHandler(this.menuDrawPointer_Click);
            // 
            // menuDrawRectangle
            // 
            this.menuDrawRectangle.Index = 1;
            this.menuDrawRectangle.Text = "Retângulo";
            this.menuDrawRectangle.Click += new System.EventHandler(this.menuDrawRectangle_Click);
            // 
            // menuDrawEllipse
            // 
            this.menuDrawEllipse.Index = 2;
            this.menuDrawEllipse.Text = "Ellipse";
            this.menuDrawEllipse.Click += new System.EventHandler(this.menuDrawEllipse_Click);
            // 
            // menuDrawLine
            // 
            this.menuDrawLine.Index = 3;
            this.menuDrawLine.Text = "Linha";
            this.menuDrawLine.Click += new System.EventHandler(this.menuDrawLine_Click);
            // 
            // menuDrawPolygon
            // 
            this.menuDrawPolygon.Index = 4;
            this.menuDrawPolygon.Text = "Lápis";
            this.menuDrawPolygon.Click += new System.EventHandler(this.menuDrawPolygon_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 5;
            this.menuItem11.Text = "Triângulo ";
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 4;
            this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuHelpAbout});
            this.menuItem10.Text = "Ajuda";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Index = 0;
            this.menuHelpAbout.Text = "Sobre";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "vicons_camera_bitmap_pixelated.png");
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbSave,
            this.tbFill,
            this.toolBarButton1,
            this.tbPointer,
            this.tbLine,
            this.tbRectangle,
            this.tbPolygon,
            this.tbEllipse,
            this.tbBitMap,
            this.toolBarButton2,
            this.tbText,
            this.tbNew,
            this.tbAbout,
            this.tbRecord,
            this.tbOpen});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(573, 34);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
            this.toolBar1.Wrappable = false;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbSave
            // 
            this.tbSave.ImageIndex = 2;
            this.tbSave.Name = "tbSave";
            this.tbSave.ToolTipText = "save the current svg document";
            // 
            // tbFill
            // 
            this.tbFill.ImageIndex = 11;
            this.tbFill.Name = "tbFill";
            this.tbFill.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbFill.ToolTipText = "fill into all space";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbPointer
            // 
            this.tbPointer.ImageIndex = 4;
            this.tbPointer.Name = "tbPointer";
            this.tbPointer.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbPointer.ToolTipText = "Pointer";
            // 
            // tbLine
            // 
            this.tbLine.ImageIndex = 7;
            this.tbLine.Name = "tbLine";
            this.tbLine.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbLine.ToolTipText = "Line";
            // 
            // tbRectangle
            // 
            this.tbRectangle.ImageIndex = 5;
            this.tbRectangle.Name = "tbRectangle";
            this.tbRectangle.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbRectangle.ToolTipText = "Rectangle";
            // 
            // tbPolygon
            // 
            this.tbPolygon.ImageIndex = 8;
            this.tbPolygon.Name = "tbPolygon";
            this.tbPolygon.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbPolygon.ToolTipText = "Polygon";
            // 
            // tbEllipse
            // 
            this.tbEllipse.ImageIndex = 6;
            this.tbEllipse.Name = "tbEllipse";
            this.tbEllipse.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbEllipse.ToolTipText = "Ellipse";
            // 
            // tbBitMap
            // 
            this.tbBitMap.ImageIndex = 9;
            this.tbBitMap.Name = "tbBitMap";
            this.tbBitMap.ToolTipText = "Image";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbText
            // 
            this.tbText.ImageIndex = 10;
            this.tbText.Name = "tbText";
            this.tbText.ToolTipText = "Text";
            // 
            // tbNew
            // 
            this.tbNew.ImageIndex = 0;
            this.tbNew.Name = "tbNew";
            this.tbNew.ToolTipText = "create a new svg document";
            // 
            // tbAbout
            // 
            this.tbAbout.ImageIndex = 3;
            this.tbAbout.Name = "tbAbout";
            this.tbAbout.ToolTipText = "About program";
            // 
            // tbRecord
            // 
            this.tbRecord.ImageIndex = 12;
            this.tbRecord.Name = "tbRecord";
            this.tbRecord.Text = "&Gravar";
            // 
            // tbOpen
            // 
            this.tbOpen.ImageIndex = 1;
            this.tbOpen.Name = "tbOpen";
            this.tbOpen.ToolTipText = "gravar tela";
            // 
            // drawArea
            // 
            this.drawArea.ActiveTool = DrawTools.DrawArea.DrawToolType.Pointer;
            this.drawArea.Description = "My SVG file";
            this.drawArea.DocManager = null;
            this.drawArea.DrawNetRectangle = false;
            this.drawArea.GraphicsList = null;
            this.drawArea.Location = new System.Drawing.Point(0, 36);
            this.drawArea.Name = "drawArea";
            this.drawArea.NetRectangle = ((System.Drawing.RectangleF)(resources.GetObject("drawArea.NetRectangle")));
            this.drawArea.OldScale = new System.Drawing.SizeF(1F, 1F);
            this.drawArea.OriginalSize = new System.Drawing.SizeF(500F, 400F);
            this.drawArea.Owner = null;
            this.drawArea.ScaleDraw = new System.Drawing.SizeF(1F, 1F);
            this.drawArea.Size = new System.Drawing.Size(150, 150);
            this.drawArea.SizePicture = new System.Drawing.SizeF(500F, 400F);
            this.drawArea.TabIndex = 1;
            this.drawArea.Load += new System.EventHandler(this.drawArea_Load);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(573, 459);
            this.Controls.Add(this.drawArea);
            this.Controls.Add(this.toolBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "SvgPaint";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Main

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            // Check command line
            if (args.Length > 1)
            {
                MessageBox.Show("Invalid number of arguments. Usage: SvgPaint.exe [file]", "SvgPaint");
            }

            // Load main form, taking command line into account
            Form1 form = new Form1();

            if (args.Length == 1)
                form.ArgumentFile = args[0];

            Application.Run(form);
        }

        #endregion

        #region Members

        private DocManager docManager;
        private DragDropManager dragDropManager;
        private MruManager mruManager;
        private Config _config;

        private string argumentFile = "";   // file name from command line

        #endregion

        #region Properties

        /// <summary>
        /// File name from the command line
        /// </summary>
        public string ArgumentFile
        {
            get
            {
                return argumentFile;
            }
            set
            {
                argumentFile = value;
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Helper objects (DocManager and others)
            InitializeHelperObjects();

            LoadSettings();

            // Initialize draw area
            ResizeDrawArea();
            drawArea.Initialize(this, docManager);

            // Submit to Idle event to set controls state at idle time
            Application.Idle += new EventHandler(Application_Idle);
            this.tbFill.Pushed = true;
            // Open file passed in the command line
            if (ArgumentFile.Length > 0)
                OpenDocument(ArgumentFile);
        }

        /// <summary>
        /// Form is closng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!docManager.CloseDocument())
                e.Cancel = true;
        }

        /// <summary>
        /// Idle processing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Idle(object sender, EventArgs e)
        {
            SetStateOfControls();
        }

        /// <summary>
        /// Exit menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// About menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuHelpAbout_Click(object sender, System.EventArgs e)
        {
            CommandAbout();
        }


        /// <summary>
        /// Resize draw area when form is resized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                ResizeDrawArea();
            }
        }

        /// <summary>
        /// Toolbar buttons handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == tbPointer)
                CommandPointer();
            else if (e.Button == tbRectangle)
                CommandRectangle();
            else if (e.Button == tbEllipse)
                CommandEllipse();
            else if (e.Button == tbLine)
                CommandLine();
            else if (e.Button == tbPolygon)
                CommandPolygon();
            else if (e.Button == tbText)
                CommandText();
            else if (e.Button == tbBitMap)
                CommandImage();
            else if (e.Button == tbAbout)
                CommandAbout();
            else if (e.Button == tbSave)
                CommandSave();
            else if (e.Button == tbOpen)
                CommandOpen();
            else if (e.Button == tbNew)
                CommandNew();
            else if (e.Button == tbFill)
            {
                CommandFill(tbFill.Pushed);
                /*				if (!tbFill.Pushed)
                                    tbFill.Pushed = false;
                                else
                                    tbFill.Pushed = true;*/
            }
            else if (e.Button == tbRecord)
            {
                CommandRecord();
            }
        }


        #region File Menu

        /// <summary>
        /// File - New menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileNew_Click(object sender, System.EventArgs e)
        {
            CommandNew();
        }

        /// <summary>
        /// File - Open menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileOpen_Click(object sender, System.EventArgs e)
        {
            CommandOpen();
        }

        /// <summary>
        /// File - Save menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileSave_Click(object sender, System.EventArgs e)
        {
            CommandSave();
        }

        /// <summary>
        /// File - Save As menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileSaveAs_Click(object sender, System.EventArgs e)
        {
            CommandSaveAs();
        }

        #endregion

        #region Draw menu

        /// <summary>
        /// Pointer Tool menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDrawPointer_Click(object sender, System.EventArgs e)
        {
            CommandPointer();
        }

        /// <summary>
        /// Rectangle Tool menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDrawRectangle_Click(object sender, System.EventArgs e)
        {
            CommandRectangle();
        }

        /// <summary>
        /// Ellipse Tool menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDrawEllipse_Click(object sender, System.EventArgs e)
        {
            CommandEllipse();
        }

        /// <summary>
        /// Line Tool menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDrawLine_Click(object sender, System.EventArgs e)
        {
            CommandLine();
        }

        /// <summary>
        /// Polygon Tool menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDrawPolygon_Click(object sender, System.EventArgs e)
        {
            CommandPolygon();
        }

        #endregion

        #region Edit Menu

        private void menuEditSelectAll_Click(object sender, System.EventArgs e)
        {
            drawArea.GraphicsList.SelectAll();
            drawArea.Refresh();
        }

        private void menuEditUnselectAll_Click(object sender, System.EventArgs e)
        {
            drawArea.GraphicsList.UnselectAll();
            drawArea.Refresh();
        }

        private void menuEditDelete_Click(object sender, System.EventArgs e)
        {
            if (drawArea.GraphicsList.DeleteSelection())
            {
                drawArea.SetDirty();
                drawArea.Refresh();
            }
        }

        private void menuEditDeleteAll_Click(object sender, System.EventArgs e)
        {
            if (drawArea.GraphicsList.Clear())
            {
                drawArea.SetDirty();
                drawArea.Refresh();
            }
        }

        private void menuEditMoveToFront_Click(object sender, System.EventArgs e)
        {
            if (drawArea.GraphicsList.MoveSelectionToFront())
            {
                drawArea.SetDirty();
                drawArea.Refresh();
            }
        }

        private void menuEditMoveToBack_Click(object sender, System.EventArgs e)
        {
            if (drawArea.GraphicsList.MoveSelectionToBack())
            {
                drawArea.SetDirty();
                drawArea.Refresh();
            }
        }

        private void menuEditProperties_Click(object sender, System.EventArgs e)
        {
            if (drawArea.GraphicsList.ShowPropertiesDialog(this))
            {
                drawArea.SetDirty();
                drawArea.Refresh();
            }
        }

        #endregion

        #endregion

        #region DocManager Event Handlers

        /// <summary>
        /// DocManager reports hat it executed New command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void docManager_ClearEvent(object sender, EventArgs e)
        {
            if (drawArea.GraphicsList != null)
            {
                drawArea.GraphicsList.Clear();
                drawArea.Refresh();
            }
        }

        /// <summary>
        /// DocManager reports that document was changed (loaded from file)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void docManager_DocChangedEvent(object sender, EventArgs e)
        {
            drawArea.Refresh();
        }

        /// <summary>
        /// DocManager reports about successful/unsuccessful Open File operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void docManager_OpenEvent(object sender, OpenFileEventArgs e)
        {
            // Update MRU List
            if (e.Succeeded)
                mruManager.Add(e.FileName);
            else
                mruManager.Remove(e.FileName);
        }

        /// <summary>
        /// Load document from the stream supplied by DocManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void docManager_LoadEvent(object sender, SerializationEventArgs e)
        {
            // DocManager asks to load document from supplied stream
            try
            {
                //				drawArea.GraphicsList = new GraphicsList(e.XmlReader);
                this.tbFill.Pushed = false;
                if (!drawArea.LoadFromXML(e.XmlReader))
                {
                    MessageBox.Show("Error reading SVG file", "SvgPaint");
                    ErrH.Log("Form1", "LoadEvent", "Error reading SVG file", ErrH._LogPriority.Info);
                }
            }
            catch (ArgumentNullException ex)
            {
                HandleLoadException(ex, e);
            }
            catch (SerializationException ex)
            {
                HandleLoadException(ex, e);
            }
            catch (SecurityException ex)
            {
                HandleLoadException(ex, e);
            }
            catch (Exception ex)
            {
                ErrH.Log("Form1", "LoadEvent", ex.ToString(), ErrH._LogPriority.Info);
            }
        }


        /// <summary>
        /// Save document to stream supplied by DocManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void docManager_SaveEvent(object sender, SerializationEventArgs e)
        {
            // DocManager asks to save document to supplied stream
            try
            {
                //e.Formatter.Serialize(e.SerializationStream, drawArea.GraphicsList);
                drawArea.SaveToXml(e.Writer);
            }
            catch (ArgumentNullException ex)
            {
                HandleSaveException(ex, e);
            }
            catch (SerializationException ex)
            {
                HandleSaveException(ex, e);
            }
            catch (SecurityException ex)
            {
                HandleSaveException(ex, e);
            }
        }

        #endregion

        #region DragDropManager Event Handlers

        private void dragDropManager_FileDroppedEvent(object sender, FileDroppedEventArgs e)
        {
            OpenDocument(e.FileArray.GetValue(0).ToString());
        }

        #endregion

        #region MruManager Event Handlers

        private void mruManager_MruOpenEvent(object sender, MruFileOpenEventArgs e)
        {
            OpenDocument(e.FileName);
        }
        #endregion

        #region Other Functions

        /// <summary>
        /// Set Pointer draw tool
        /// </summary>
        private void CommandPointer()
        {
            drawArea.ActiveTool = DrawArea.DrawToolType.Pointer;
        }

        /// <summary>
        /// Set Rectangle draw tool
        /// </summary>
        private void CommandRectangle()
        {
            drawArea.ActiveTool = DrawArea.DrawToolType.Rectangle;
        }

        /// <summary>
        /// Set Ellipse draw tool
        /// </summary>
        private void CommandEllipse()
        {
            drawArea.ActiveTool = DrawArea.DrawToolType.Ellipse;
        }

        /// <summary>
        /// Set Line draw tool
        /// </summary>
        private void CommandLine()
        {
            drawArea.ActiveTool = DrawArea.DrawToolType.Line;
        }

        /// <summary>
        /// Set Polygon draw tool
        /// </summary>
        private void CommandPolygon()
        {
            drawArea.ActiveTool = DrawArea.DrawToolType.Polygon;
        }
        /// <summary>
        /// Set Ellipse draw tool
        /// </summary>
        private void CommandText()
        {
            PropertiesText dlg = new PropertiesText();
            dlg.FontText = DrawText.LastFontText;
            //			dlg.InputText = DrawText.LastInputText;
            dlg.Stroke = DrawObject.LastUsedColor;
            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;
            DrawText.LastFontText = dlg.FontText;
            DrawText.LastInputText = dlg.InputText;
            DrawObject.LastUsedColor = dlg.Stroke;
            drawArea.ActiveTool = DrawArea.DrawToolType.Text;
        }
        /// <summary>
        /// Set BitMap draw tool
        /// </summary>
        private void CommandImage()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath + "\\Plans";
            openFileDialog1.Filter = Draw.Draw.GRAPHICS_EXTS;
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                DrawImage.CurrentFileName = openFileDialog1.FileName;
                //				byte[] arrpic = DrawImage.ReadPngMemImage(CurrentFileName);
                //				CurrentImage = DrawImage.ImageFromBytes(arrpic);
                DrawImage.CurrentImage = Image.FromFile(DrawImage.CurrentFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file. May be invalid format\n" + ex);
                return;
            }
            drawArea.ActiveTool = DrawArea.DrawToolType.Bitmap;
        }

        /// <summary>
        /// Show About dialog
        /// </summary>
        private void CommandAbout()
        {
            FormAbout frm = new FormAbout();
            frm.ShowDialog(this);
        }

        /// <summary>
        /// Set draw area to all form client space except toolbar
        /// </summary>
        private void ResizeDrawArea()
        {
            try
            {
                Rectangle rect = this.ClientRectangle;

                drawArea.Left = rect.Left;
                drawArea.Top = rect.Top + toolBar1.Height;
                drawArea.Width = rect.Width;
                drawArea.Height = rect.Height - toolBar1.Height;
                if (this.tbFill.Pushed)
                    drawArea.mkResize();
                drawArea.Refresh();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Load application settings from the Config
        /// </summary>
        void LoadSettings()
        {
            try
            {
                DrawObject.LastUsedColor = Color.FromArgb(_config.GetSetting("Color",
                    Color.Black.ToArgb()));

                DrawObject.LastUsedPenWidth = Convert.ToInt32(_config.GetSetting(
                    "Width",
                    1));
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Save application settings to the Config
        /// </summary>
        void SaveSettings()
        {
            try
            {
                _config.PutSetting("Color", DrawObject.LastUsedColor.ToArgb());
                _config.PutSetting("Width", DrawObject.LastUsedPenWidth);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void HandleException(Exception ex)
        {
            Trace.WriteLine("Config operation failed: " + ex.Message);
        }

        /// <summary>
        /// Set state of controls.
        /// Function is called at idle time.
        /// </summary>
        public void SetStateOfControls()
        {
            // Select active tool
            tbPointer.Pushed = (drawArea.ActiveTool == DrawArea.DrawToolType.Pointer);
            tbRectangle.Pushed = (drawArea.ActiveTool == DrawArea.DrawToolType.Rectangle);
            tbEllipse.Pushed = (drawArea.ActiveTool == DrawArea.DrawToolType.Ellipse);
            tbLine.Pushed = (drawArea.ActiveTool == DrawArea.DrawToolType.Line);
            tbPolygon.Pushed = (drawArea.ActiveTool == DrawArea.DrawToolType.Polygon);

            menuDrawPointer.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Pointer);
            menuDrawRectangle.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Rectangle);
            menuDrawEllipse.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Ellipse);
            menuDrawLine.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Line);
            menuDrawPolygon.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Polygon);

            bool objects = (drawArea.GraphicsList.Count > 0);
            bool selectedObjects = (drawArea.GraphicsList.SelectionCount > 0);

            // File operations
            menuFileSave.Enabled = objects;
            menuFileSaveAs.Enabled = objects;
            tbSave.Enabled = objects;

            // Edit operations
            menuEditDelete.Enabled = selectedObjects;
            menuEditDeleteAll.Enabled = objects;
            menuEditSelectAll.Enabled = objects;
            menuEditUnselectAll.Enabled = objects;
            menuEditMoveToFront.Enabled = selectedObjects;
            menuEditMoveToBack.Enabled = selectedObjects;
            menuEditProperties.Enabled = selectedObjects;
        }
        /// <summary>
        /// Gravar a tela 
        /// </summary>
        private void CommandRecord()
        {

        }

        /// <summary>
        /// Open new file
        /// </summary>
        private void CommandNew()
        {
            docManager.NewDocument();
        }

        /// <summary>
        /// Open file
        /// </summary>
        private void CommandOpen()
        {
            docManager.OpenDocument("");
            this.Text = DocManager.ApplicationName;
        }

        /// <summary>
        /// Save file
        /// </summary>
        private void CommandSave()
        {
            docManager.SaveDocument(DocManager.SaveType.Save);
        }

        /// <summary>
        /// Save As
        /// </summary>
        private void CommandSaveAs()
        {
            docManager.SaveDocument(DocManager.SaveType.SaveAs);
        }

        /// <summary>
        /// Handle exception from docManager_LoadEvent function
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="fileName"></param>
        private void HandleLoadException(Exception ex, SerializationEventArgs e)
        {
            MessageBox.Show(this,
                "Error open file: " + e.FileName + "\n" +
                "Message: " + ex.Message,
                DocManager.ApplicationName);

            e.Error = true;
        }

        /// <summary>
        /// Handle exception from docManager_SaveEvent function
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="fileName"></param>
        private void HandleSaveException(Exception ex, SerializationEventArgs e)
        {
            MessageBox.Show(this,
                "Error save file: " + e.FileName + "\n" +
                "Save: " + ex.Message,
                DocManager.ApplicationName);
            e.Error = true;
        }

        /// <summary>
        /// Initialize helper objects from the DocToolkit Library.
        /// 
        /// Called from Form1_Load. Initialized all objects except
        /// PersistWindowState wich must be initialized in the
        /// form constructor.
        /// </summary>
        private void InitializeHelperObjects()
        {
            // DocManager

            DocManagerData data = new DocManagerData();
            data.FormOwner = this;
            data.UpdateTitle = true;
            data.FileDialogFilter = "SVG files (*.svg)|*.svg|All files (*.*)|*.*";
            data.NewDocName = "New.svg";

            docManager = new DocManager(data);
            //docManager.RegisterFileType("svg", "SVGfile", "SVG File");
            docManager.SaveEvent += new SaveEventHandler(docManager_SaveEvent);
            docManager.LoadEvent += new LoadEventHandler(docManager_LoadEvent);
            docManager.OpenEvent += new OpenFileEventHandler(docManager_OpenEvent);
            docManager.DocChangedEvent += new EventHandler(docManager_DocChangedEvent);
            docManager.ClearEvent += new EventHandler(docManager_ClearEvent);

            docManager.NewDocument();

            // DragDropManager
            dragDropManager = new DragDropManager(this);
            dragDropManager.FileDroppedEvent += new FileDroppedEventHandler(this.dragDropManager_FileDroppedEvent);

            // MruManager
            mruManager = new MruManager();
            mruManager.Initialize(
                this,                              // owner form
                menuFileRecentFiles,               // Recent Files menu item
                _config);                     // Registry path to keep MRU list

            mruManager.MruOpenEvent += new MruFileOpenEventHandler(mruManager_MruOpenEvent);
        }
        /// <summary>
        /// Open document.
        /// Used to open file passed in command line or dropped into the window
        /// </summary>
        /// <param name="file"></param>
        public void OpenDocument(string file)
        {
            docManager.OpenDocument(file);
        }

        #endregion

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

                string fullName = string.Format(@"{0}\{1}_{2}.mp4", Environment.CurrentDirectory + "\\video", dados[0], DateTime.Now.ToString("yyyy.MM.dd_HH.mm.ss"));

                DateTime agora = DateTime.Now;
                // Save File option

                try
                {
                    _writer.Open(
                              fullName,
                              _width,
                              _height,
                              10,
                              (VideoCodec),
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

        private void menuItem7_Click(object sender, System.EventArgs e)
        {
            drawArea.EditProperties();
        }
        private void CommandFill(bool pushed)
        {
            if (pushed)
            {
                SizeF sz = this.ClientSize;
                this.drawArea.Width = Convert.ToInt32(sz.Width);
                this.drawArea.Height = Convert.ToInt32(sz.Height) - toolBar1.Height; ;
                drawArea.mkResize();
            }
            else
            {
                drawArea.RestoreScale();
                drawArea.SizePicture = drawArea.OriginalSize;
            }
            drawArea.Refresh();
        }

        private void miScale_Click(object sender, System.EventArgs e)
        {
            DlgScale dlg = new DlgScale();
            dlg.Sc = this.drawArea.ScaleDraw.Width;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                this.tbFill.Pushed = false;
                drawArea.DoScaling(new SizeF(dlg.Sc, dlg.Sc));
                drawArea.Refresh();
            }
        }

        private void Form1_Closed(object sender, System.EventArgs e)
        {
            SaveSettings();
            _config.Save();
        }

        private void drawArea_Load(object sender, System.EventArgs e)
        {

        }
        private void miExport_Click(object sender, System.EventArgs e)
        {
            ExportToPng();
        }

        void ExportToPng()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //txt files (*.txt)|*.txt|All files (*.*)|*.*"
            saveFileDialog1.Filter = "Png files (*.png)|*.png|JPG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif";
            saveFileDialog1.InitialDirectory = Config.Instance().GetSetting("FileDir/Path", Application.StartupPath);
            string flnm = docManager.fileName;
            if (flnm.Length == 0)
                flnm = "New.svg";
            else
                flnm = flnm.Substring(0, flnm.IndexOf(".svg"));
            saveFileDialog1.FileName = flnm;
            DialogResult res = saveFileDialog1.ShowDialog(this);
            if (res != DialogResult.OK)
                return;
            flnm = saveFileDialog1.FileName;
            Graphics g = this.drawArea.CreateGraphics();
            this.drawArea.Draw(g);

            System.Drawing.Bitmap bp = new Bitmap(this.drawArea.Width, this.drawArea.Height, g);
            Graphics g2 = Graphics.FromImage(bp);
            drawArea.Draw(g2);
            //bp.Save(flnm);
            SaveImage(bp, flnm);
        }

        void SaveImage(Image img, string flnm)
        {
            ImageCodecInfo myImageCodecInfo;
            Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            string mimetype = GetMimeType(flnm);
            if (mimetype.Length == 0)
                return;
            myImageCodecInfo = GetEncoderInfo(mimetype);
            myEncoder = Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, (long)55);
            myEncoderParameters.Param[0] = myEncoderParameter;

            img.Save(flnm, myImageCodecInfo, myEncoderParameters);
        }
        string GetMimeType(string flnm)
        {
            if (flnm.LastIndexOf("jpg") > 0)
                return "image/" + "jpeg";
            if (flnm.LastIndexOf("png") > 0)
                return "image/" + "png";
            if (flnm.LastIndexOf("gif") > 0)
                return "image/" + "gif";
            return "";
        }
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                {
                    return encoders[j];
                }
            }
            return null;
        }

        private void miPrint_Click(object sender, System.EventArgs e)
        {
            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            PrintDialog dlg = new PrintDialog();
            dlg.Document = printDocument1;
            if (dlg.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            this.drawArea.Draw(e.Graphics);
        }
        private void miPreview_Click(object sender, System.EventArgs e)
        {
            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = printDocument1;
            dlg.ShowDialog();
        }
    }
}
