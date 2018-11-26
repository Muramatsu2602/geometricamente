using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;

using SVGLib;

namespace Draw
{
	/// <summary>
	/// DrawImage graphic object
	/// </summary>
	public class DrawImage : DrawRectangle
	{
		public static Image CurrentImage = null;
		public static string CurrentFileName = "";

		private const string Tag = "image";
		public string FileName = "";
		public Image image = null;
		public string id = "";
		public DrawImage()
		{
            SetRectangleF(0, 0, 1, 1);
            Initialize();
		}
		void InitBox()
		{
			this.stroke = Color.Red;
			this.stroke_width = 1;
		}
        public DrawImage(float x, float y)
        {
			if (DrawImage.CurrentImage == null)
				throw(new ArgumentNullException());
			InitBox();
			image = DrawImage.CurrentImage;
			this.FileName = DrawImage.CurrentFileName;
			RectangleF = new RectangleF(x, y, image.Width, image.Height);
			Initialize();
		}
		public DrawImage(string fileName,float x, float y,float width,float height)
		{
			InitBox();
			this.FileName = fileName;
			try
			{
				this.image = Image.FromFile(FileName);
			}
			catch (Exception ex)
			{
				ErrH.Log("DrawArea", "DrawImage", ex.ToString(), ErrH._LogPriority.Info);
			}
			RectangleF = new RectangleF(x, y, width, height);
			Initialize();
		}
		/// <summary>
		/// Load image from file to byte array
		/// </summary>
		/// <param name="flnm">File name</param>
		/// <returns>byte array</returns>
		public static byte[] ReadPngMemImage(string flnm)
		{
			try
			{
				FileStream fs = new FileStream(flnm, FileMode.Open, FileAccess.Read);
				MemoryStream ms = new MemoryStream();
				Bitmap bm = new Bitmap(fs);
				bm.Save(ms,ImageFormat.Png);
				BinaryReader br = new BinaryReader(ms);
				ms.Position = 0;
				byte[] arrpic = br.ReadBytes((int)ms.Length);
				br.Close();
				fs.Close();
				ms.Close();
				return arrpic;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error reading file "+ex, "");
				ErrH.Log("DrawImagee", "ReadPngMemImage", ex.ToString(), ErrH._LogPriority.Info);
				return null;
			}
		}
		/// <summary>
		/// Get Image object from byte array
		/// </summary>
		/// <param name="arrb"></param>
		/// <returns></returns>
		public static Image ImageFromBytes(byte[] arrb)
		{
			Image im= null;
			if (arrb == null)
				return null;
			try
			{
				// Perform the conversion 
				MemoryStream ms = new MemoryStream();
				int offset = 0;      // should be 0
				ms.Write(arrb, offset, arrb.Length - offset);
				im = new Bitmap(ms); //Image.FromStream(ms);
				ms.Close();
				return im;
			}
			catch (Exception ex)
			{
				ErrH.Log("DrawImagee", "ImageFromBytes", ex.ToString(), ErrH._LogPriority.Info);
				return null;
			}
		}
		public override void Draw(Graphics g)
		{
			try
			{
				if (image != null)
					g.DrawImage(this.image,this.RectangleF);
				else
					base.Draw(g);
			} 
			catch (Exception ex)
			{
				ErrH.Log("DrawImage", "Draw", ex.ToString(), ErrH._LogPriority.Info);
			}
		}
		public override string GetXmlStr(SizeF scale)
		{  
			//  <image x="200" y="200" width="100px" height="100px"
			//  xlink:href="myimage.png">
			//  <title>My image</title>
			//  </image>

			string s = "<";
			s += Tag;
			if (id.Length > 0)
			{
				s += " id= \""+id+"\" ";
			}
			s += GetRectStringXml(RectangleF,scale) + "\r\n";
			// trim directory name
			string flnm = FileName;
			if (FileName.IndexOf(":",0)> 0)
			{
				string dir = Directory.GetCurrentDirectory();
				if (FileName.IndexOf(dir,0)==0 && dir.Length<FileName.Length)
				{
					flnm = FileName.Substring(dir.Length+1,FileName.Length-dir.Length-1);
				}
			}
			s += " xlink:href = \""+flnm+"\">" + "\r\n";
			s += "<title>"+FileName+"</title>" + "\r\n";
			s += "</"+Tag+">" + "\r\n";
			return s;
		}
		/// <summary>
		/// Show Properties dialog. Return true if list is changed
		/// </summary>
		/// <param name="parent"></param>
		/// <returns></returns>
		public override bool ShowPropertiesDialog(IWin32Window parent)
		{
			PropertiesImage dlg = new PropertiesImage();
			dlg.FileName = this.FileName;
			dlg.Rect = this.RectangleF;
			if ( dlg.ShowDialog(parent) != DialogResult.OK )
				return false;
			FileName = dlg.FileName;
			RectangleF = dlg.Rect;
			return true;
		}
		public static DrawObject Create(SvgImage svg)
		{
			try
			{
				DrawImage dobj = null;
				if (svg.Id == null || svg.Id == "")
					dobj = new DrawImage(svg.HRef,DrawObject.ParseSize(svg.X,DrawObject.Dpi.X),
						DrawObject.ParseSize(svg.Y,DrawObject.Dpi.Y),
						DrawObject.ParseSize(svg.Width,DrawObject.Dpi.X),
						DrawObject.ParseSize(svg.Height,DrawObject.Dpi.Y));
				else
				{
					DrawImage di = new DrawImage();
					if (!di.FillFromSVG(svg))
						return null;
					dobj = di;
				}
				return dobj;
			}
			catch (Exception ex)
			{
				ErrH.Log("DrawImage", "Create", ex.ToString(), ErrH._LogPriority.Info);
				return null;
			}
		}
		[CLSCompliant(false)]
		public bool FillFromSVG(SvgImage svg)
		{
			try
			{
				float x = DrawObject.ParseSize(svg.X,DrawObject.Dpi.X);
				float y = DrawObject.ParseSize(svg.Y,DrawObject.Dpi.Y);
				float w = DrawObject.ParseSize(svg.Width,DrawObject.Dpi.X);
				float h = DrawObject.ParseSize(svg.Height,DrawObject.Dpi.Y);
				this.RectangleF = new RectangleF(x,y,w,h);
				this.FileName = svg.HRef;
				this.id = svg.Id;
				try
				{
					this.image = Image.FromFile(this.FileName);
					return true;
				}
				catch(Exception ex)
				{
					ErrH.Log("DrawImage", "FillFromSvg", ex.ToString(), ErrH._LogPriority.Info);
					return false;
				}
			}
			catch(Exception ex0)
			{
				ErrH.Log("DrawImage", "FillFromSvg", ex0.ToString(), ErrH._LogPriority.Info);
				return false;
			}
		}
	}
}
