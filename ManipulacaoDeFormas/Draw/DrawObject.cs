using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml;

using SVGLib;

namespace Draw 
{
	/// <summary>
	/// Base class for all draw objects
	/// </summary>
	public abstract class DrawObject
	{
		public static PointF Dpi;

		#region Members

		// Object properties
		private bool selected;

		private Color _stroke;
		private float _stroke_width;

		private static Color lastUsedStroke = Color.Black;
		private static float lastUsedStroke_width = 1;

		private Color _Fill = Color.Empty;

		#endregion

		#region Properties

		/// <summary>
		/// Selection flag
		/// </summary>
		public bool Selected
		{
			get
			{
				return selected;
			}
			set
			{
				selected = value;
			}
		}

		/// <summary>
		/// Color
		/// </summary>
		public Color Fill
		{
			get
			{
				return _Fill;
			}
			set
			{
				_Fill = value;
			}
		}
		/// <summary>
		/// Color
		/// </summary>
		public Color stroke
		{
			get
			{
				return _stroke;
			}
			set
			{
				_stroke = value;
			}
		}

		/// <summary>
		/// Pen width
		/// </summary>
		public float stroke_width
		{
			get
			{
				return _stroke_width;
			}
			set
			{
				_stroke_width = value;
			}
		}

		/// <summary>
		/// Number of handles
		/// </summary>
		public virtual int HandleCount
		{
			get
			{
				return 0;
			}
		}

		/// <summary>
		/// Last used color
		/// </summary>
		public static Color LastUsedColor
		{
			get
			{
				return lastUsedStroke;
			}
			set
			{
				lastUsedStroke = value;
			}
		}

		/// <summary>
		/// Last used pen width
		/// </summary>
		public static float LastUsedPenWidth
		{
			get
			{
				return lastUsedStroke_width;
			}
			set
			{
				lastUsedStroke_width = value;
			}
		}

		#endregion

		#region Virtual Functions

		/// <summary>
		/// Draw object
		/// </summary>
		/// <param name="g"></param>
		public virtual void Draw(Graphics g)
		{
		}

		/// <summary>
		/// Get handle point by 1-based number
		/// </summary>
		/// <param name="handleNumber"></param>
		/// <returns></returns>
		public virtual PointF GetHandle(int handleNumber)
		{
			return new PointF(0, 0);
		}

		/// <summary>
		/// Get handle rectangle by 1-based number
		/// </summary>
		/// <param name="handleNumber"></param>
		/// <returns></returns>
		public virtual RectangleF GetHandleRectangle(int handleNumber)
		{
			PointF point = GetHandle(handleNumber);

			return new RectangleF(point.X - 3, point.Y - 3, 7, 7);
		}

		/// <summary>
		/// Draw tracker for selected object
		/// </summary>
		/// <param name="g"></param>
		public virtual void DrawTracker(Graphics g)
		{
			if ( ! Selected )
				return;

			SolidBrush brush = new SolidBrush(Color.Black);

			for ( int i = 1; i <= HandleCount; i++ )
			{
				try
				{
					g.FillRectangle(brush, GetHandleRectangle(i));
				} 
				catch
				{}
			}

			brush.Dispose();
		}

		/// <summary>
		/// Hit test.
		/// Return value: -1 - no hit
		///                0 - hit anywhere
		///                > 1 - handle number
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		public virtual int HitTest(PointF point)
		{
			return -1;
		}


		/// <summary>
		/// Test whether point is inside of the object
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		protected virtual bool PointInObject(PointF point)
		{
			return false;
		}
        

		/// <summary>
		/// Get curesor for the handle
		/// </summary>
		/// <param name="handleNumber"></param>
		/// <returns></returns>
		public virtual Cursor GetHandleCursor(int handleNumber)
		{
			return Cursors.Default;
		}

		/// <summary>
		/// Test whether object intersects with rectangle
		/// </summary>
		/// <param name="rectangle"></param>
		/// <returns></returns>
		public virtual bool IntersectsWith(RectangleF rectangle)
		{
			return false;
		}

		/// <summary>
		/// Move object
		/// </summary>
		/// <param name="deltaX"></param>
		/// <param name="deltaY"></param>
		public virtual void Move(float deltaX, float deltaY)
		{
		}

		/// <summary>
		/// Move handle to the point
		/// </summary>
		/// <param name="point"></param>
		/// <param name="handleNumber"></param>
		public virtual void MoveHandleTo(PointF point, int handleNumber)
		{
		}

		/// <summary>
		/// Dump (for debugging)
		/// </summary>
		public virtual void Dump()
		{
			Trace.WriteLine("");
			Trace.WriteLine(this.GetType().Name);
			Trace.WriteLine("Selected = " + selected.ToString(CultureInfo.InvariantCulture));
		}

		/// <summary>
		/// Normalize object.
		/// Call this function in the end of object resizing.
		/// </summary>
		public virtual void Normalize()
		{
		}


		/// <summary>
		/// Save object to serialization stream
		/// </summary>
		/// <param name="info"></param>
		/// <param name="orderNumber"></param>
		public virtual void SaveToXml(XmlTextWriter writer,double scale)
		{
		}

		/// <summary>
		/// Load object from serialization stream
		/// </summary>
		/// <param name="info"></param>
		/// <param name="orderNumber"></param>
		public virtual void LoadFromXml(XmlTextReader reader)
		{
		}

		#endregion

		#region Other functions

		/// <summary>
		/// Initialization
		/// </summary>
		public virtual void Initialize()
		{
			stroke = lastUsedStroke;
			stroke_width = lastUsedStroke_width;
		}

		#endregion
		public static string Color2String(Color c)
		{
			if ( c.IsNamedColor )
			{
				return c.Name;
			}
			else
			{
				byte[] bytes = BitConverter.GetBytes(c.ToArgb());

				string sColor = "#";
				sColor += BitConverter.ToString(bytes, 2, 1);
				sColor += BitConverter.ToString(bytes, 1, 1);
				sColor += BitConverter.ToString(bytes, 0, 1);

				return sColor;
			}
		}
		public virtual string GetXmlStr(SizeF scale)
		{
			return "";
		}
		public string GetStrStyle(SizeF scale)
		{
			return GetStringStyle(stroke,Fill,stroke_width,scale);
		}
		public static string GetStringStyle(Color color,Color fill,float strokewidth,SizeF scale)
		{
			float Sstroke_width = strokewidth/scale.Width;
			string sfill = "none";
			if (fill != Color.Empty)
				sfill = Color2String(fill);
			else
				sfill = "none";
			string sc = " style = \"fill:"+sfill+"; stroke:"+Color2String(color)+"; stroke-width:"+Sstroke_width.ToString(CultureInfo.InvariantCulture)+"\"";
			return sc;
		}
		/// <summary>
		/// Show Properties dialog. Return true if list is changed
		/// </summary>
		/// <param name="parent"></param>
		/// <returns></returns>
		public virtual bool ShowPropertiesDialog(IWin32Window parent)
		{
			GraphicsProperties properties = GetProperties();
			PropertiesDialog dlg = new PropertiesDialog();
			dlg.Properties = properties;
			if ( dlg.ShowDialog(parent) != DialogResult.OK )
				return false;
			ApplyProperties(properties);
			return true;
		}
		/// <summary>
		/// Apply properties for all selected objects
		/// </summary>
		private void ApplyProperties(GraphicsProperties properties)
		{
			if ( properties.ColorDefined )
			{
				stroke = properties.Color;
				DrawObject.LastUsedColor = properties.Color;
			}
			if ( properties.PenWidthDefined )
			{
				stroke_width = properties.PenWidth;
				DrawObject.LastUsedPenWidth = properties.PenWidth;
			}
			if ( properties.FillDefined )
			{
				if (properties.IsFill)
					Fill = properties.FillColor;
				else
					Fill = Color.Empty;
			}
		}
		/// <summary>
		/// Get properties from selected objects and fill GraphicsProperties instance
		/// </summary>
		/// <returns></returns>
		private GraphicsProperties GetProperties()
		{
			GraphicsProperties properties = new GraphicsProperties();
			properties.ColorDefined = true;
			properties.Color = stroke;
			properties.PenWidthDefined = true;
			properties.PenWidth = stroke_width;
			properties.FillDefined = true;
			properties.FillColor = this.Fill;
			return properties;
		}
		public virtual void Resize(SizeF newscale,SizeF oldscale) 
		{
		}
		public static PointF RecalcPoint(PointF pp, SizeF newscale,SizeF oldscale)
		{
			PointF p = pp;
			p.X = p.X/oldscale.Width;
			p.Y = p.Y/oldscale.Height;
			p.X = p.X*newscale.Width;
			p.Y = p.Y*newscale.Height;
			return p;
		}
		public static float RecalcFloat(float val, float newscale1,float oldscale1)
		{
			val = val/oldscale1;
			val = val*newscale1;
			return val;
		}
		public void RecalcStrokeWidth(SizeF newscale,SizeF oldscale)
		{
			stroke_width = RecalcFloat(stroke_width, newscale.Width,oldscale.Width);
		}
		public void SetStyleFromSvg(SvgBasicShape svg)
		{
			stroke = svg.Stroke;
			stroke_width = DrawObject.ParseSize(svg.StrokeWidth,DrawObject.Dpi.X);
			if (svg.Fill != Color.Transparent)
			{
				//				dob.IsFill = true;
				Fill = svg.Fill;
			}
			else
				Fill = Color.Empty;
		}
		public static float ParseSize(string str, float dpi)
		{
			float koef = 1;
			int ind = -1;
			ind = str.IndexOf("pt");
			if (ind == -1)
				ind = str.IndexOf("px");
			if (ind == -1)
				ind = str.IndexOf("pc");
			if (ind == -1)
			{
				ind = str.IndexOf("cm");
				if (ind > 0)
				{
					koef = dpi/2.54f;
				}
			}
			if (ind == -1)
			{
				ind = str.IndexOf("mm");
				if (ind > 0)
				{
					koef = dpi/25.4f;
				}
			}
			if (ind == -1)
			{
				ind = str.IndexOf("in");
				if (ind > 0)
				{
					koef = dpi;
				}
			}
			if (ind > 0 )
				str = str.Substring(0,ind);
			str = RemoveAlphas(str);
			try
			{
				float res = float.Parse(str,CultureInfo.InvariantCulture);
				if (koef != 1.1)
					res *= koef;
				return res;
			} 
			catch (Exception ex)
			{
				ErrH.Log("ParseFloat()", "DrawObject", ex.ToString(), ErrH._LogPriority.Info);
				return 0;
			}
		}
		static string RemoveAlphas(string str)
		{
			string s = str.Trim();
			string res = "";
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] < '0' || s[i] > '9')
					if (s[i] != '.')
						continue;
				res += s[i];
			}
			return res;
		}
	}
}
