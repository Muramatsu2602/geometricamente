using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Xml;

using SVGLib;

namespace Draw
{
	/// <summary>
	/// Line graphic object
	/// </summary>
	public class DrawLine : DrawObject
	{
		private const string Tag = "line";
		private PointF startPoint;
        private PointF endPoint;

        /// <summary>
        ///  Graphic objects for hit test
        /// </summary>
        private GraphicsPath areaPath = null;
        private Pen areaPen = null;
        private Region areaRegion = null;

		public DrawLine()
		{
            startPoint.X = 0;
            startPoint.Y = 0;
            endPoint.X = 1;
            endPoint.Y = 1;

            Initialize();
		}

        public DrawLine(float x1, float y1, float x2, float y2)
        {
            startPoint.X = x1;
            startPoint.Y = y1;
            endPoint.X = x2;
            endPoint.Y = y2;

            Initialize();
        }

		public override void Draw(Graphics g)
		{
			try
			{
				g.SmoothingMode = SmoothingMode.AntiAlias;

				Pen pen = new Pen(stroke, stroke_width);

				g.DrawLine(pen, startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);

				pen.Dispose();
			} 
			catch (Exception ex)
			{
				ErrH.Log("DrawLine", "Draw", ex.ToString(), ErrH._LogPriority.Info);
			}
		}

        public override int HandleCount
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override PointF GetHandle(int handleNumber)
        {
            if ( handleNumber == 1 )
                return startPoint;
            else
                return endPoint;
        }

        /// <summary>
        /// Hit test.
        /// Return value: -1 - no hit
        ///                0 - hit anywhere
        ///                > 1 - handle number
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override int HitTest(PointF point)
        {
            if ( Selected )
            {
                for ( int i = 1; i <= HandleCount; i++ )
                {
                    if ( GetHandleRectangle(i).Contains(point) )
                        return i;
                }
            }

            if ( PointInObject(point) )
                return 0;

            return -1;
        }

        protected override bool PointInObject(PointF point)
        {
            CreateObjects();

            return AreaRegion.IsVisible(point);
        }

        public override bool IntersectsWith(RectangleF rectangle)
        {
            CreateObjects();

            return AreaRegion.IsVisible(rectangle);
        }

        public override Cursor GetHandleCursor(int handleNumber)
        {
            switch ( handleNumber )
            {
                case 1:
                case 2:
                    return Cursors.SizeAll;
                default:
                    return Cursors.Default;
            }
        }

        public override void MoveHandleTo(PointF point, int handleNumber)
        {
            if ( handleNumber == 1 )
                startPoint = point;
            else
                endPoint = point;

            Invalidate();
        }

        public override void Move(float deltaX, float deltaY)
        {
            startPoint.X += deltaX;
            startPoint.Y += deltaY;

            endPoint.X += deltaX;
            endPoint.Y += deltaY;

            Invalidate();
        }
        /// <summary>
        /// Invalidate object.
        /// When object is invalidated, path used for hit test
        /// is released and should be created again.
        /// </summary>
        protected void Invalidate()
        {
            if ( AreaPath != null )
            {
                AreaPath.Dispose();
                AreaPath = null;
            }

            if ( AreaPen != null )
            {
                AreaPen.Dispose();
                AreaPen = null;
            }

            if ( AreaRegion != null )
            {
                AreaRegion.Dispose();
                AreaRegion = null;
            }
        }

        /// <summary>
        /// Create graphic objects used from hit test.
        /// </summary>
        protected virtual void CreateObjects()
        {
            if ( AreaPath != null )
                return;

            // Create path which contains wide line
            // for easy mouse selection
            AreaPath = new GraphicsPath();
            AreaPen = new Pen(Color.Black, 7);
            AreaPath.AddLine(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
            AreaPath.Widen(AreaPen);

            // Create region from the path
            AreaRegion = new Region(AreaPath);
        }

        protected GraphicsPath AreaPath
        {
            get
            {
                return areaPath;
            }
            set
            {
                areaPath = value;
            }
        }

        protected Pen AreaPen
        {
            get
            {
                return areaPen;
            }
            set
            {
                areaPen = value;
            }
        }

        protected Region AreaRegion
        {
            get
            {
                return areaRegion;
            }
            set
            {
                areaRegion = value;
            }
        }

		public override string GetXmlStr(SizeF scale)
		{  
			//style="fill:red; stroke:#C04000; stroke-width:5"
			string s = "<";
			s += Tag;
			s += GetStrStyle(scale);
			float x1 = startPoint.X/scale.Width;
			float y1 = startPoint.Y/scale.Height;
			float x2 = endPoint.X/scale.Width;
			float y2 = endPoint.Y/scale.Height;

			s += " x1 = \""+x1.ToString(CultureInfo.InvariantCulture)+"\"";
			s += " y1 = \""+y1.ToString(CultureInfo.InvariantCulture)+"\"";
			s += " x2 = \""+x2.ToString(CultureInfo.InvariantCulture)+"\"";
			s += " y2 = \""+y2.ToString(CultureInfo.InvariantCulture)+"\"";
			s += " />" + "\r\n";
			return s;
		}

		public override void SaveToXml(XmlTextWriter writer,double scale)
		{
			//<line style="stroke-width:5" x1="100" y1="300" x2="300" y2="100" />
			writer.WriteStartElement("line");
			string s = "stroke-width:"+stroke_width.ToString();
			writer.WriteAttributeString("style",s);
			writer.WriteAttributeString("x1",this.startPoint.X.ToString());
			writer.WriteAttributeString("y1",this.startPoint.Y.ToString());
			writer.WriteAttributeString("x2",this.endPoint.X.ToString());
			writer.WriteAttributeString("y2",this.endPoint.Y.ToString());
			writer.WriteEndElement();
		}

		public override void Resize(SizeF newscale,SizeF oldscale)
		{
			this.startPoint = RecalcPoint(this.startPoint, newscale,oldscale);
			this.endPoint = RecalcPoint(this.endPoint, newscale,oldscale);
			RecalcStrokeWidth(newscale,oldscale);
			Invalidate();
		}

		public static DrawLine Create(SvgLine svg)
		{
			try
			{
				DrawLine dobj = new DrawLine(DrawObject.ParseSize(svg.X1,DrawObject.Dpi.X),
					DrawObject.ParseSize(svg.Y1,DrawObject.Dpi.Y),
					DrawObject.ParseSize(svg.X2,DrawObject.Dpi.X),
					DrawObject.ParseSize(svg.Y2,DrawObject.Dpi.Y));
				dobj.SetStyleFromSvg(svg);
				return dobj;
			}
			catch (Exception ex)
			{
				ErrH.Log("CreateLine", "Draw", ex.ToString(), ErrH._LogPriority.Info);
				return null;
			}
		}
	}
}
