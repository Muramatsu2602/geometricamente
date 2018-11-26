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
	/// Rectangle graphic object
	/// </summary>
	public class DrawRectangle : DrawObject
	{
        private RectangleF rectangle;

        private const string Tag = "rect";

        protected RectangleF RectangleF
        {
            get
            {
                return rectangle;
            }
            set
            {
                rectangle = value;
            }
        }
        
		public DrawRectangle()
		{
            SetRectangleF(0, 0, 1,1);
            Initialize();
		}
        
        public DrawRectangle(float x, float y, float width, float height)
        {
            rectangle.X = x;
            rectangle.Y = y;
            rectangle.Width = width;
            rectangle.Height = height;
            Initialize();
        }

/*		[CLSCompliant(false)]
		public bool FillFromSVG(SvgRect svg)
		{
			try
			{
				float x = DrawObject.ParseSize(svg.X,DrawObject.Dpi.X);
				float y = DrawObject.ParseSize(svg.Y,DrawObject.Dpi.Y);
				float w = DrawObject.ParseSize(svg.Width,DrawObject.Dpi.X);
				float h = DrawObject.ParseSize(svg.Height,DrawObject.Dpi.Y);
				this.RectangleF = new RectangleF(x,y,w,h);
				stroke = svg.Stroke;
				stroke_width = DrawObject.ParseSize(svg.StrokeWidth,DrawObject.Dpi.X);
				if (svg.Fill != Color.Transparent)
					Fill = svg.Fill;
				else
					Fill = Color.Empty;
				return true;
			}
			catch (Exception ex)
			{
				ErrH.Log("DrawRectangle", "SvgRect invalid", ex.ToString(), ErrH._LogPriority.Info);
				return false;
			}
		}*/

        /// <summary>
        /// Draw rectangle
        /// </summary>
        /// <param name="g"></param>
		public override void Draw(Graphics g)
		{
			try
			{
				RectangleF r = DrawRectangle.GetNormalizedRectangle(RectangleF);
				if (Fill != Color.Empty)
				{
					Brush brush = new SolidBrush(this.Fill);
					g.FillRectangle(brush,r);
				}
				Pen pen = new Pen(stroke, stroke_width);
				g.DrawRectangle(pen,r.X,r.Y,r.Width,r.Height);

				pen.Dispose();
			} 
			catch (Exception ex)
			{
				ErrH.Log("DrawRectangle", "Draw", ex.ToString(), ErrH._LogPriority.Info);
			}
		}
        protected void SetRectangleF(float x, float y, float width, float height)
        {
            rectangle.X = x;
            rectangle.Y = y;
            rectangle.Width = width;
            rectangle.Height = height;
        }


        /// <summary>
        /// Get number of handles
        /// </summary>
        public override int HandleCount
        {
            get
            {
                return 8;
            }
        }


        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override PointF GetHandle(int handleNumber)
        {
            float x, y, xCenter, yCenter;

            xCenter = rectangle.X + rectangle.Width/2;
            yCenter = rectangle.Y + rectangle.Height/2;
            x = rectangle.X;
            y = rectangle.Y;

            switch ( handleNumber )
            {
                case 1:
                    x = rectangle.X;
                    y = rectangle.Y;
                    break;
                case 2:
                    x = xCenter;
                    y = rectangle.Y;
                    break;
                case 3:
                    x = rectangle.Right;
                    y = rectangle.Y;
                    break;
                case 4:
                    x = rectangle.Right;
                    y = yCenter;
                    break;
                case 5:
                    x = rectangle.Right;
                    y = rectangle.Bottom;
                    break;
                case 6:
                    x = xCenter;
                    y = rectangle.Bottom;
                    break;
                case 7:
                    x = rectangle.X;
                    y = rectangle.Bottom;
                    break;
                case 8:
                    x = rectangle.X;
                    y = yCenter;
                    break;
            }
            return new PointF(x, y);
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
            return rectangle.Contains(point);
        }
        


        /// <summary>
        /// Get cursor for the handle
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Cursor GetHandleCursor(int handleNumber)
        {
            switch ( handleNumber )
            {
                case 1:
                    return Cursors.SizeNWSE;
                case 2:
                    return Cursors.SizeNS;
                case 3:
                    return Cursors.SizeNESW;
                case 4:
                    return Cursors.SizeWE;
                case 5:
                    return Cursors.SizeNWSE;
                case 6:
                    return Cursors.SizeNS;
                case 7:
                    return Cursors.SizeNESW;
                case 8:
                    return Cursors.SizeWE;
                default:
                    return Cursors.Default;
            }
        }

        /// <summary>
        /// Move handle to new point (resizing)
        /// </summary>
        /// <param name="point"></param>
        /// <param name="handleNumber"></param>
        public override void MoveHandleTo(PointF point, int handleNumber)
        {
            float left = RectangleF.Left;
            float top = RectangleF.Top;
            float right = RectangleF.Right;
            float bottom = RectangleF.Bottom;

            switch ( handleNumber )
            {
                case 1:
                    left = point.X;
                    top = point.Y;
                    break;
                case 2:
                    top = point.Y;
                    break;
                case 3:
                    right = point.X;
                    top = point.Y;
                    break;
                case 4:
                    right = point.X;
                    break;
                case 5:
                    right = point.X;
                    bottom = point.Y;
                    break;
                case 6:
                    bottom = point.Y;
                    break;
                case 7:
                    left = point.X;
                    bottom = point.Y;
                    break;
                case 8:
                    left = point.X;
                    break;
            }

            SetRectangleF(left, top, right - left, bottom - top);
        }


        public override bool IntersectsWith(RectangleF rectangle)
        {
			try
			{
				return RectangleF.IntersectsWith(rectangle);
			} 
			catch(Exception ex)
			{
				ErrH.Log("DrawRectangle", "Intersect", ex.ToString(), ErrH._LogPriority.Info);
				return false;
			}
        }

        /// <summary>
        /// Move object
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        public override void Move(float deltaX, float deltaY)
        {
            rectangle.X += deltaX;
            rectangle.Y += deltaY;
        }

        public override void Dump()
        {
            base.Dump ();

            Trace.WriteLine("rectangle.X = " + rectangle.X.ToString(CultureInfo.InvariantCulture));
            Trace.WriteLine("rectangle.Y = " + rectangle.Y.ToString(CultureInfo.InvariantCulture));
            Trace.WriteLine("rectangle.Width = " + rectangle.Width.ToString(CultureInfo.InvariantCulture));
            Trace.WriteLine("rectangle.Height = " + rectangle.Height.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Normalize rectangle
        /// </summary>
        public override void Normalize()
        {
            rectangle = DrawRectangle.GetNormalizedRectangle(rectangle);
        }

		public static string GetRectStringXml(RectangleF rect,SizeF scale)
		{
			string s = "";
			float x = rect.X/scale.Width;
			float y = rect.Y/scale.Height;
			float w = rect.Width/scale.Width;
			float h = rect.Height/scale.Height;

			s += " x = \""+x.ToString(CultureInfo.InvariantCulture)+"\"";
			s += " y = \""+y.ToString(CultureInfo.InvariantCulture)+"\"";
			s += " width = \""+w.ToString(CultureInfo.InvariantCulture)+"\"";
			s += " height = \""+h.ToString(CultureInfo.InvariantCulture)+"\"";
			return s;
		}
		public override string GetXmlStr(SizeF scale)
		{  
			//  <rect x="1" y="1" width="1198" height="398"
	        //		style="fill:none; stroke:blue"/>

			string s = "<";
			s += Tag;
			s += GetStrStyle(scale);
			s += GetRectStringXml(RectangleF,scale);
			s += " />" + "\r\n";
			return s;
		}

		public static string GetRectangleXmlStr(Color _stroke,bool isFill,Color fill,float strokewidth,RectangleF rect,SizeF scale)
		{  
			string s = "<";
			s += Tag;
			s += GetStringStyle(_stroke,fill,strokewidth,scale);//GetStrStyle(scale);
			s += GetRectStringXml(rect,scale);
			s += " />" + "\r\n";
			return s;
		}


        #region Helper Functions

        public static RectangleF GetNormalizedRectangle(float x1, float y1, float x2, float y2)
        {
            if ( x2 < x1 )
            {
                float tmp = x2;
                x2 = x1;
                x1 = tmp;
            }

            if ( y2 < y1 )
            {
                float tmp = y2;
                y2 = y1;
                y1 = tmp;
            }

            return new RectangleF(x1, y1, x2 - x1, y2 - y1);
        }

        public static RectangleF GetNormalizedRectangle(PointF p1, PointF p2)
        {
            return GetNormalizedRectangle(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static RectangleF GetNormalizedRectangle(RectangleF r)
        {
            return GetNormalizedRectangle(r.X, r.Y, r.X + r.Width, r.Y + r.Height);
        }

        #endregion

		public override void Resize(SizeF newscale,SizeF oldscale)
		{
			PointF p = RecalcPoint(RectangleF.Location, newscale,oldscale);
			PointF ps = new PointF(RectangleF.Width, RectangleF.Height);
			ps = RecalcPoint(ps,newscale,oldscale);
			this.RectangleF = new RectangleF(p.X,p.Y,ps.X,ps.Y);
			RecalcStrokeWidth(newscale,oldscale);
		}

		public static DrawRectangle Create(SvgRect svg)
		{
			try
			{
				DrawRectangle dobj = new DrawRectangle(DrawObject.ParseSize(svg.X,DrawObject.Dpi.X),
					DrawObject.ParseSize(svg.Y,DrawObject.Dpi.Y),
					DrawObject.ParseSize(svg.Width,DrawObject.Dpi.X),
					DrawObject.ParseSize(svg.Height,DrawObject.Dpi.Y));
				dobj.SetStyleFromSvg(svg);
				return dobj;
			}
			catch (Exception ex)
			{
				ErrH.Log("DrawRectangle", "CreateRectangle:", ex.ToString(), ErrH._LogPriority.Info);
				return null;
			}
		}

	}
}
