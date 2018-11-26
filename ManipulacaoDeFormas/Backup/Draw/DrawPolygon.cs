using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Xml;

using SVGLib;

namespace Draw
{
	/// <summary>
	/// Polygon graphic object
	/// </summary>
	public class DrawPolygon : DrawLine
	{
		private const string Tag = "polyline";
		private ArrayList pointArray;         // list of points
        private Cursor handleCursor;

        private const string entryLength = "Length";
        private const string entryPoint = "Point";


		public DrawPolygon()
		{
            pointArray = new ArrayList();

            LoadCursor();
            Initialize();
		}

        public DrawPolygon(float x1, float y1, float x2, float y2)
        {
            pointArray = new ArrayList();
            pointArray.Add(new PointF(x1, y1));
            pointArray.Add(new PointF(x2, y2));

            LoadCursor();
            Initialize();
        }
		public DrawPolygon(PointF[] points)
		{
			pointArray = new ArrayList();
			for (int i = 0;i<points.Length;i++)
			{
				pointArray.Add(points[i]);
			}
			LoadCursor();
			Initialize();
		}

		public override void Draw(Graphics g)
		{
			float x1 = 0, y1 = 0;     // previous point
			float x2, y2;             // current point
			try
			{
				g.SmoothingMode = SmoothingMode.AntiAlias;

				if (Fill != Color.Empty)
				{
					PointF[] arr = new PointF[pointArray.Count];
					for (int i = 0; i < pointArray.Count; i++)
						arr[i] = (PointF )pointArray[i];
					Brush brush = new SolidBrush(this.Fill);
					g.FillPolygon(brush,arr);
				}

				Pen pen = new Pen(stroke, stroke_width);

				IEnumerator enumerator = pointArray.GetEnumerator();

				if ( enumerator.MoveNext() )
				{
					x1 = ((PointF)enumerator.Current).X;
					y1 = ((PointF)enumerator.Current).Y;
				}
	
				while ( enumerator.MoveNext() )
				{
					x2 = ((PointF)enumerator.Current).X;
					y2 = ((PointF)enumerator.Current).Y;

					g.DrawLine(pen, x1, y1, x2, y2);

					x1 = x2;
					y1 = y2;
				}

				pen.Dispose();
			} 
			catch (Exception ex)
			{
				ErrH.Log("DrawPolygon", "Draw", ex.ToString(), ErrH._LogPriority.Info);
			}
		}

        public void AddPoint(PointF point)
        {
            pointArray.Add(point);
        }

        public override int HandleCount
        {
            get
            {
                return pointArray.Count;
            }
        }

        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override PointF GetHandle(int handleNumber)
        {
            if ( handleNumber < 1 )
                handleNumber = 1;

            if ( handleNumber > pointArray.Count )
                handleNumber = pointArray.Count;

            return ((PointF)pointArray[handleNumber - 1]);
        }

        public override Cursor GetHandleCursor(int handleNumber)
        {
            return handleCursor;
        }

        public override void MoveHandleTo(PointF point, int handleNumber)
        {
            if ( handleNumber < 1 )
                handleNumber = 1;

            if ( handleNumber > pointArray.Count)
                handleNumber = pointArray.Count;

            pointArray[handleNumber-1] = point;

            Invalidate();
        }

        public override void Move(float deltaX, float deltaY)
        {
            int n = pointArray.Count;
            PointF point;

            for ( int i = 0; i < n; i++ )
            {
                point = new PointF( ((PointF)pointArray[i]).X + deltaX, ((PointF)pointArray[i]).Y + deltaY);

                pointArray[i] = point;
            }

            Invalidate();
        }

        /// <summary>
        /// Create graphic object used for hit test
        /// </summary>
        protected override void CreateObjects()
        {
            if ( AreaPath != null )
                return;
			try
			{
				// Create closed path which contains all polygon vertexes
				AreaPath = new GraphicsPath();

				float x1 = 0, y1 = 0;     // previous point
				float x2, y2;             // current point

				IEnumerator enumerator = pointArray.GetEnumerator();

				if ( enumerator.MoveNext() )
				{
					x1 = ((PointF)enumerator.Current).X;
					y1 = ((PointF)enumerator.Current).Y;
				}

				while ( enumerator.MoveNext() )
				{
					x2 = ((PointF)enumerator.Current).X;
					y2 = ((PointF)enumerator.Current).Y;

					AreaPath.AddLine(x1, y1, x2, y2);

					x1 = x2;
					y1 = y2;
				}

				AreaPath.CloseFigure();

				// Create region from the path
				AreaRegion = new Region(AreaPath);
			} 
			catch(Exception ex)
			{
				ErrH.Log("DrawPolygon", "Create", ex.ToString(), ErrH._LogPriority.Info);
			}
        }

        private void LoadCursor()
        {
			handleCursor = Cursors.SizeAll;
		}
		public override string GetXmlStr(SizeF scale)
		{  
			//  <polyline style="fill:none; stroke:blue; stroke-width:10"
            //points="50,375 150,375 
			string s = "<";
			s += Tag;
			s += GetStrStyle(scale);
			s += " points = "+"\"";
			IEnumerator enumerator = pointArray.GetEnumerator();
			while ( enumerator.MoveNext() )
			{
				float x = ((PointF)enumerator.Current).X/scale.Width;
				float y = ((PointF)enumerator.Current).Y/scale.Height;
				s += x.ToString(CultureInfo.InvariantCulture)+","+y.ToString(CultureInfo.InvariantCulture);
				s += " ";
			}
			s += "\"";
			s += " />" + "\r\n";
			return s;
		}
		public override void Resize(SizeF newscale,SizeF oldscale)
		{
			for (int i = 0; i < pointArray.Count; i ++)
				pointArray[i] = RecalcPoint((PointF )pointArray[i], newscale,oldscale);
			RecalcStrokeWidth(newscale,oldscale);
			Invalidate();
		}
		public static DrawPolygon Create(SvgPolyline svg)
		{
			try
			{
				string s = svg.Points.Trim();
				string[] arr = s.Split(' ');
				PointF[] points = new PointF[arr.Length];
				for (int i = 0; i < arr.Length; i++)
				{
					string[] arrp = arr[i].Split(',');
					points[i]=new PointF(DrawObject.ParseSize(arrp[0],DrawObject.Dpi.X),
						DrawObject.ParseSize(arrp[1],DrawObject.Dpi.Y));
				}
				DrawPolygon dobj = new DrawPolygon(points);
				dobj.SetStyleFromSvg(svg);
				return dobj;
			}
			catch (Exception ex)
			{
				ErrH.Log("DrawPolygon", "Create", ex.ToString(), ErrH._LogPriority.Info);
				return null;
			}
		}
	}
}
