using System;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

using SVGLib;

namespace Draw
{
	/// <summary>
	/// Ellipse graphic object
	/// </summary>
	public class DrawEllipse : DrawRectangle
	{
		private const string Tag = "ellipse";
		public DrawEllipse()
		{
            SetRectangleF(0, 0, 1, 1);
            Initialize();
		}

        public DrawEllipse(float x, float y, float width, float height)
        {
            RectangleF = new RectangleF(x, y, width, height);
            Initialize();
        }

        public override void Draw(Graphics g)
        {
			RectangleF r = DrawRectangle.GetNormalizedRectangle(RectangleF);
			if (this.Fill != Color.Empty)
			{
				Brush brush = new SolidBrush(this.Fill);
				g.FillEllipse(brush,r);
			}
			Pen pen = new Pen(stroke, stroke_width);
            g.DrawEllipse(pen, r);
            pen.Dispose();
        }

		public override string GetXmlStr(SizeF scale)
		{  
			//          <ellipse cx="125" cy="125" rx="100" ry="50"
            //     style="fill:none; stroke:#888888; stroke-width:2"/>

			string s = "<";
			s += Tag;
			s += GetStrStyle(scale);
			float cx = (RectangleF.X+this.RectangleF.Width/2)/scale.Width;
			float cy = (RectangleF.Y+this.RectangleF.Height/2)/scale.Height;
			float rx = (RectangleF.Width/2)/scale.Width;
			float ry = ((RectangleF.Height/2))/scale.Height;

			s += " cx = \""+cx.ToString(CultureInfo.InvariantCulture)+"\"";
			s += " cy = \""+cy.ToString(CultureInfo.InvariantCulture)+"\"";
			s += " rx = \""+rx.ToString(CultureInfo.InvariantCulture)+"\"";
			s += " ry = \""+ry.ToString(CultureInfo.InvariantCulture)+"\"";
			s += " />" + "\r\n";
			return s;
		}

		public static DrawEllipse Create(SvgEllipse svg)
		{
			try
			{
				float cx = DrawObject.ParseSize(svg.CX,DrawObject.Dpi.X);
				float cy = DrawObject.ParseSize(svg.CY,DrawObject.Dpi.Y);
				float rx = DrawObject.ParseSize(svg.RX,DrawObject.Dpi.X);
				float ry = DrawObject.ParseSize(svg.RY,DrawObject.Dpi.Y);
				DrawEllipse dobj = new DrawEllipse(cx-rx,cy-ry,rx*2,ry*2);
				dobj.SetStyleFromSvg(svg);
				return dobj;
			}
			catch (Exception ex)
			{
				ErrH.Log("DrawEllipse", "CreateRectangle", ex.ToString(), ErrH._LogPriority.Info);
				return null;
			}
		}
	}
}
