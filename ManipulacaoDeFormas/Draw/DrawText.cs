using System;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

using SVGLib;

namespace Draw
{
	/// <summary>
	/// text graphic object
	/// </summary>
	public class DrawText : DrawRectangle
	{
		public static Font LastFontText = new Font("Microsoft Sans Serif",12);
		public static string LastInputText = "";
		public static StringFormat LastStringFormat = new StringFormat();

		private const string Tag = "text";
		public string text = "";
		public Font font = new Font("Microsoft Sans Serif",9);
		public StringFormat TextAnchor = null;
		public DrawText()
		{
            SetRectangleF(0, 0, 1, 1);
            Initialize();
			TextAnchor = new StringFormat();
		}
		public float Y
		{
			get
			{
				return RectangleF.Y;
			}
			set
			{
				RectangleF = new RectangleF(RectangleF.X,value,RectangleF.Width,RectangleF.Height);
			}
		}
        public DrawText(float x, float y)
        { 
			font = DrawText.LastFontText;
			text = DrawText.LastInputText;
			TextAnchor = new StringFormat(DrawText.LastStringFormat);
			RectangleF = new RectangleF(x, y, 0, 0);
			Initialize();
        }
		public static RectangleF CalcSize(Graphics g,string txt,Font fnt,float x,float y,StringFormat fmt)
		{
			SizeF rectNeed = g.MeasureString(txt, fnt);
			RectangleF rect = new RectangleF(x,y,rectNeed.Width,rectNeed.Height);
			if (fmt.Alignment == StringAlignment.Center)
				rect.X -= rect.Width/2;
			else if (fmt.Alignment == StringAlignment.Far)
				rect.X -= rect.Width;
			return rect;
		}
		public override void Draw(Graphics g)
        {
			if (RectangleF.Width == 0 || RectangleF.Height == 0)
				RectangleF = CalcSize(g,text,font,RectangleF.X,RectangleF.Y,this.TextAnchor);
			Brush brush = new SolidBrush(this.stroke);
			try
			{
				g.DrawString(text,font,brush,this.RectangleF,TextAnchor);
			} 
			catch(Exception ex)
			{
				ErrH.Log("DrawText", "Draw", ex.ToString(), ErrH._LogPriority.Info);
			}
        }

		public override string GetXmlStr(SizeF scale)
		{  
			return GetXmlText(RectangleF,stroke,font,text,scale,TextAnchor);
		}
		public static string GetXmlText(RectangleF rect,Color color,Font font,string txt,SizeF scale,StringFormat anchor)
		{  
			//  <text x="2.5cm" y="1.5cm" 
			//style="font-family:Verdana; font-size:16pt; fill:blue">
			//Hello, out there
			//</text>
			string temp = font.ToString();
			Console.WriteLine(font);
			string s = "<";
			s += Tag;
			string sc = " style = \"fill:"+Color2String(color)+
				"; font-family:"+font.FontFamily.Name;
			if (font.Bold)
				sc += "; font-weight:bold";
			if (font.Italic)
				sc += "; font-style:italic";
			float fs = font.Size/scale.Height;
			sc += "; font-size:"+fs.ToString(CultureInfo.InvariantCulture)+"pt";
			if (anchor.Alignment != StringAlignment.Near)
			{
				string sa = "";
				switch (anchor.Alignment)
				{
					case StringAlignment.Center:
						sa = "middle";
						break;
					case StringAlignment.Far:
						sa = "end";
						break;
				}
				if (sa.Length>0)
					sc += "; text-anchor:"+sa; 
			}
			sc += "\"";
			s += sc;
			RectangleF crect = rect;
			if (anchor.Alignment == StringAlignment.Center)
			{
				crect.X += crect.Width/2;
			}
			else if (anchor.Alignment == StringAlignment.Far)
			{
				crect.X += crect.Width;
			}
			//			Font f = new Font(font.FontFamily.Name,newfw,font.Style);
			float fy = font.Height/scale.Height;
			crect.Y += font.Height;
			s += GetRectStringXml(crect,scale);
			s += " >";
			s += txt;
			s += "</"+Tag+">";
			s += "\r\n";
			return s;
		}
		/// <summary>
		/// Show Properties dialog. Return true if list is changed
		/// </summary>
		/// <param name="parent"></param>
		/// <returns></returns>
		public override bool ShowPropertiesDialog(IWin32Window parent)
		{
			PropertiesText dlg = new PropertiesText();
			dlg.FontText = this.font;
			dlg.InputText = this.text;
			dlg.Stroke = this.stroke;
			dlg.TextAnchor = this.TextAnchor;
			if (dlg.ShowDialog(parent) != DialogResult.OK)
				return false;
			this.font = dlg.FontText;
			this.text = dlg.InputText;
			this.stroke = dlg.Stroke;
			this.TextAnchor = dlg.TextAnchor;
			return true;
		}
		public override void Resize(SizeF newscale,SizeF oldscale)
		{
			base.Resize(newscale,oldscale);
			float newfw = RecalcFloat(this.font.Size, newscale.Width,oldscale.Width);
			font = new Font(font.FontFamily.Name,newfw,font.Style);
		}
		[CLSCompliant(false)]
		public bool SetStyleFromSvg(SvgText svg)
		{
			try
			{
				float x = DrawObject.ParseSize(svg.X,DrawObject.Dpi.X);
				float y = DrawObject.ParseSize(svg.Y,DrawObject.Dpi.Y);
				float w = DrawObject.ParseSize(svg.Width,DrawObject.Dpi.X);
				float h = DrawObject.ParseSize(svg.Height,DrawObject.Dpi.Y);
				this.text = svg.Value;
				//font
				stroke = svg.Fill;
				string family = svg.FontFamily;
				string style = svg.FontStyle;
				float size = DrawObject.ParseSize(svg.FontSize,DrawObject.Dpi.X);
				int fs = 0;
				if (svg.FontWeight.IndexOf("bold")>=0)
					fs = 1;
				if (svg.FontStyle.IndexOf("italic")>=0)
					fs = fs|2;
				font = new Font(family,size,(FontStyle )fs);
				//				y -= font.Size;
				y -= font.Height;
				this.RectangleF = new RectangleF(x,y,w,h);
				if (svg.TextAnchor.Length > 0)
				{
					switch (svg.TextAnchor)
					{
						case "start":
							TextAnchor.Alignment = StringAlignment.Near;
							break;
						case "end":
							TextAnchor.Alignment = StringAlignment.Far;
							RectangleF = new RectangleF(x-w,y,w,h);
							break;
						case "middle":
							TextAnchor.Alignment = StringAlignment.Center;
							RectangleF = new RectangleF(x-w/2,y,w,h);
							break;
					}
				}
				return true;
			}
			catch
			{
				ErrH.Log("DrawText", "SetStyleFromSvg", "SetStyleFromSvg", ErrH._LogPriority.Info);
				return false;
			}
		}
		public static DrawText Create(SvgText svg)
		{
			if (svg.Value == null || svg.Value.Length == 0)
				return null;
			try
			{
				DrawText dobj = new DrawText(DrawObject.ParseSize(svg.X,DrawObject.Dpi.X),
					DrawObject.ParseSize(svg.Y,DrawObject.Dpi.Y));
				dobj.text = svg.Value;
				dobj.SetStyleFromSvg(svg);
				//				dobj.Y -= dobj.font.Size;
				//dobj.Y -= dobj.font.Height;
				return dobj;
			}
			catch (Exception ex)
			{
				ErrH.Log("DrawText", "DrawText", ex.ToString(), ErrH._LogPriority.Info);
				return null;
			}
		}
	}
}
