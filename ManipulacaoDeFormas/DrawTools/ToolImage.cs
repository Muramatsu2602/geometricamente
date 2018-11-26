using System;
using System.Windows.Forms;
using Draw;

namespace DrawTools
{
	/// <summary>
	/// Ellipse tool
	/// </summary>
	public class ToolImage : DrawTools.ToolRectangle
	{
		public ToolImage()
		{
            Cursor = new Cursor(GetType(), "Bitmap.cur");
		}

        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            AddNewObject(drawArea, new DrawImage(e.X, e.Y));
        }

	}
}
