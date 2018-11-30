using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Globalization;
using System.Xml;

using DocToolkit;
using SVGLib;
using Draw;

namespace DrawTools
{
	/// <summary>
	/// Working area.
	/// Handles mouse input and draws graphics objects.
	/// </summary>
	public class DrawArea : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#region Constructor, Dispose

		public DrawArea()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// DrawArea
			// 
			this.Name = "DrawArea";
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseUp);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawArea_Paint);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseMove);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseDown);

		}
		#endregion

		#region Enumerations

		public enum DrawToolType
		{
			Pointer,
			Rectangle,
			Ellipse,
			Line,
			Polygon,
			Bitmap,
			Text,
			NumberOfDrawTools,
            Triangle
		};

		#endregion

		#region Members

		private GraphicsList graphicsList;    // list of draw objects
		// (instances of DrawObject-derived classes)

		private DrawToolType activeTool;      // active drawing tool
		private Tool[] tools;                 // array of tools

		// group selection rectangle
		private RectangleF netRectangle;
		private bool drawNetRectangle = false;

		// Information about owner form
		private Form1 owner;
		private DocManager docManager;

		private SizeF m_Scale = new SizeF(1.0f,1.0f);
		private SizeF m_SizePicture = new SizeF(500,400);
		private SizeF m_OriginalSize = new SizeF(500,400);
		private string m_Description = "Svg picture";

		#endregion

		#region Properties

		/// <summary>
		/// Reference to the owner form
		/// </summary>
		public Form1 Owner
		{
			get
			{
				return owner;
			}
			set
			{
				owner = value;
			}
		}

		/// <summary>
		/// Reference to DocManager
		/// </summary>
		public DocManager DocManager
		{
			get
			{
				return docManager;
			}
			set
			{
				docManager = value;
			}
		}

		/// <summary>
		/// Group selection rectangle. Used for drawing.
		/// </summary>
		public RectangleF NetRectangle
		{
			get
			{
				return netRectangle;
			}
			set
			{
				netRectangle = value;
			}
		}

		/// <summary>
		/// Flas is set to true if group selection rectangle should be drawn.
		/// </summary>
		public bool DrawNetRectangle
		{
			get
			{
				return drawNetRectangle;
			}
			set
			{
				drawNetRectangle = value;
			}
		}

		/// <summary>
		/// Active drawing tool.
		/// </summary>
		public DrawToolType ActiveTool
		{
			get
			{
				return activeTool;
			}
			set
			{
				activeTool = value;
			}
		}

		/// <summary>
		/// List of graphics objects.
		/// </summary>
		[CLSCompliant(false)]
		public GraphicsList GraphicsList
		{
			get
			{
				return graphicsList;
			}
			set
			{
				graphicsList = value;
			}
		}
		public SizeF ScaleDraw
		{
			get
			{
				return this.m_Scale;
			}
			set
			{
				m_Scale = value;
			}
		}
		public SizeF OriginalSize
		{
			get
			{
				return this.m_OriginalSize;
			}
			set
			{
				m_OriginalSize = value;
			}
		}
		public SizeF OldScale
		{
			get
			{
				return this.m_Scale;
			}
			set
			{
				m_Scale = value;
			}
		}
		public SizeF SizePicture
		{
			get
			{
				return this.m_SizePicture;
			}
			set
			{
				m_SizePicture = value;
			}
		}
		public string Description
		{
			get
			{
				return this.m_Description;
			}
			set
			{
				m_Description = value;
			}
		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// Draw graphic objects and 
		/// group selection rectangle (optionally)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DrawArea_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
			e.Graphics.FillRectangle(brush, 
				this.ClientRectangle);
			// draw rect svg size
			Pen pen = new Pen(Color.FromArgb(0, 0, 255), 1);
			e.Graphics.DrawRectangle(pen,0,0,this.SizePicture.Width,this.SizePicture.Height);

			if ( graphicsList != null )
			{
				graphicsList.Draw(e.Graphics);
			}

			DrawNetSelection(e.Graphics);

			brush.Dispose();
		}
		public void Draw(Graphics g)
		{
			SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
			g.FillRectangle(brush, 
				this.ClientRectangle);
			// draw rect svg size
			Pen pen = new Pen(Color.FromArgb(0, 0, 255), 1);
			g.DrawRectangle(pen,0,0,this.SizePicture.Width,this.SizePicture.Height);
			if ( graphicsList != null )
			{
				graphicsList.Draw(g);
			}
			brush.Dispose();
		}

		/// <summary>
		/// Mouse down.
		/// Left button down event is passed to active tool.
		/// Right button down event is handled in this class.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DrawArea_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if ( e.Button == MouseButtons.Left )
				tools[(int)activeTool].OnMouseDown(this, e);
			else if ( e.Button == MouseButtons.Right )
				OnContextMenu(e);
		}


		/// <summary>
		/// Mouse move.
		/// Moving without button pressed or with left button pressed
		/// is passed to active tool.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DrawArea_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				int ind = -1;
				if ( e.Button == MouseButtons.Left  ||  e.Button == MouseButtons.None )
				{
					ind = (int)activeTool;
					tools[ind].OnMouseMove(this, e);
				}
				else
					this.Cursor = Cursors.Default;
			}
			catch (Exception ex)
			{
				ErrH.Log("DrawArea", "DrawArea_MouseMove", ex.ToString(), ErrH._LogPriority.Info);
				this.Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// Mouse up event.
		/// Left button up event is passed to active tool.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DrawArea_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if ( e.Button == MouseButtons.Left )
				tools[(int)activeTool].OnMouseUp(this, e);
		}

		#endregion

		#region Other Functions

		/// <summary>
		/// Initialization
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="docManager"></param>
		public void Initialize(Form1 owner, DocManager docManager)
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | 
				ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

			// Keep reference to owner form
			this.Owner = owner;
			this.DocManager = docManager;

			// set default tool
			activeTool = DrawToolType.Pointer;

			// create list of graphic objects
			graphicsList = new GraphicsList();

			// create array of drawing tools
			tools = new Tool[(int)DrawToolType.NumberOfDrawTools];
			tools[(int)DrawToolType.Pointer] = new ToolPointer();
			tools[(int)DrawToolType.Rectangle] = new ToolRectangle();
			tools[(int)DrawToolType.Ellipse] = new ToolEllipse();
			tools[(int)DrawToolType.Line] = new ToolLine();
			tools[(int)DrawToolType.Polygon] = new ToolPolygon();
			tools[(int)DrawToolType.Text] = new ToolText();
			tools[(int)DrawToolType.Bitmap] = new ToolImage();
			Graphics g = Owner.CreateGraphics();
			DrawObject.Dpi = new PointF(g.DpiX,g.DpiY);
		}

		/// <summary>
		/// Set dirty flag (file is changed after last save operation)
		/// </summary>
		public void SetDirty()
		{
			DocManager.Dirty = true;
		}

		/// <summary>
		///  Draw group selection rectangle
		/// </summary>
		/// <param name="g"></param>
		public void DrawNetSelection(Graphics g)
		{
			if ( ! DrawNetRectangle )
				return;
			Rectangle r = new Rectangle(Convert.ToInt32(NetRectangle.X),Convert.ToInt32(NetRectangle.Y),
				Convert.ToInt32(NetRectangle.Width),Convert.ToInt32(NetRectangle.Height));
			ControlPaint.DrawFocusRectangle(g, r, Color.Black, Color.Transparent);
		}

		/// <summary>
		/// Right-click handler
		/// </summary>
		/// <param name="e"></param>
		private void OnContextMenu(MouseEventArgs e)
		{
			// Change current selection if necessary

			Point point = new Point(e.X, e.Y);

			int n = GraphicsList.Count;
			DrawObject o = null;

			for ( int i = 0; i < n; i++ )
			{
				if ( GraphicsList[i].HitTest(point) == 0 )
				{
					o = GraphicsList[i];
					break;
				}
			}

			if ( o != null )
			{
				if ( ! o.Selected )
					GraphicsList.UnselectAll();

				// Select clicked object
				o.Selected = true;
			}
			else
			{
				GraphicsList.UnselectAll();
			}

			Refresh();

			// Show context menu.
			// Make ugly trick which saves a lot of code.
			// Get menu items from Edit menu in main form and
			// make context menu from them.
			// These menu items are handled in the parent form without
			// any additional efforts.

			MainMenu mainMenu = Owner.Menu;    // Main menu
			MenuItem editItem = mainMenu.MenuItems[1];            // Edit submenu

			// Make array of items for ContextMenu constructor
			// taking them from the Edit submenu
			MenuItem[] items = new MenuItem[editItem.MenuItems.Count];

			for ( int i = 0; i < editItem.MenuItems.Count; i++ )
			{
				items[i] = editItem.MenuItems[i];
			}

			Owner.SetStateOfControls();  // enable/disable menu items

			// Create and show context menu
			ContextMenu menu = new ContextMenu(items);
			menu.Show(this, point);

			// Restore items in the Edit menu (without this line Edit menu
			// is empty after forst right-click)
			editItem.MergeMenu(menu);
		}

		public bool SaveToXml(StreamWriter sw)
		{
			try
			{
				string m_sXmlDeclaration = "<?xml version=\"1.0\" standalone=\"no\"?>";
				string m_sXmlDocType = "<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.0//EN\" \"http://www.w3.org/TR/2001/REC-SVG-20010904/DTD/svg10.dtd\">";
				string sXML;

				sXML = m_sXmlDeclaration + "\r\n";
				sXML += m_sXmlDocType + "\r\n";
//				float w = this.SizePicture.Width/m_Scale.Width;
//				float h = this.SizePicture.Height/m_Scale.Height;
				sXML += "<svg width=\""+this.m_OriginalSize.Width.ToString(CultureInfo.InvariantCulture)+
					"\" height=\""+m_OriginalSize.Height.ToString(CultureInfo.InvariantCulture)+"\">" + "\r\n";
				sXML += "<desc>"+this.Description+"</desc>" + "\r\n";
				sXML += graphicsList.GetXmlString(this.m_Scale);
				sXML += "</svg>" + "\r\n";
				sw.Write(sXML);
				sw.Close();
				return true;
			} 
			catch
			{
				return false;
			}
		}
		public void EditProperties()
		{
			dlgProperties dlg = new dlgProperties();
			dlg.desc = Description;
			float w = SizePicture.Width/this.m_Scale.Width;
			float h = SizePicture.Height/this.m_Scale.Height;
			dlg.SizePicture = new SizeF(w,h);
			if (dlg.ShowDialog(this)!= DialogResult.OK)
				return;
			SizeF sz = dlg.SizePicture;
			this.m_OriginalSize = dlg.SizePicture;
			w = sz.Width*m_Scale.Width;
			h = sz.Height*m_Scale.Height;
			SizePicture = new SizeF(w,h);
			Description = dlg.desc;
			Refresh();
		}
		public bool LoadFromXML(XmlTextReader reader)
		{
			ErrH.Log("DrawArea", "LoadFromXML", "", ErrH._LogPriority.Info);
			this.graphicsList.Clear();
			SvgDoc svg = new SvgDoc();
			if (!svg.LoadFromFile(reader))
				return false;
			SvgRoot root = svg.GetSvgRoot();
			if (root == null)
				return false;
			try
			{
				SizePicture = new SizeF(DrawObject.ParseSize(root.Width,DrawObject.Dpi.X),
					DrawObject.ParseSize(root.Height,DrawObject.Dpi.Y));
			} 
			catch
			{
			}
			m_OriginalSize = SizePicture;
			SvgElement ele = root.getChild();
			this.m_Scale = new SizeF(1,1);
			if (ele != null)
				graphicsList.AddFromSvg(ele);
			return true;
		}
		#endregion
		public void mkResize()
		{
			SizeF oldscale = m_Scale;
			this.m_Scale.Width = this.Width/this.m_OriginalSize.Width;
			this.m_Scale.Height = this.Height/this.m_OriginalSize.Height;
			this.graphicsList.Resize(m_Scale,oldscale);
			SizePicture = new SizeF(DrawObject.RecalcFloat(SizePicture.Width, m_Scale.Width,oldscale.Width),
				DrawObject.RecalcFloat(SizePicture.Height, m_Scale.Height,oldscale.Height));
		}
		public void RestoreScale()
		{
			graphicsList.Resize(new SizeF(1,1),m_Scale);
			m_Scale = new SizeF(1,1);
		}
		public void DoScaling(SizeF sc)
		{
			graphicsList.Resize(sc,m_Scale);
			m_Scale = sc;
			this.m_SizePicture = new SizeF(m_Scale.Width*this.OriginalSize.Width,
				m_Scale.Height*this.OriginalSize.Height);
		}
	}
}
