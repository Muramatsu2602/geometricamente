using System;
using System.Windows.Forms;

using Draw;

namespace DrawTools
{
	/// <summary>
	/// Ellipse tool
	/// </summary>
	public class ToolText : DrawTools.ToolRectangle
	{
		public ToolText()
		{
            Cursor = new Cursor(GetType(), "Text.cur");
		}

        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            AddNewObject(drawArea, new DrawText(e.X, e.Y));
        }

	}
}
