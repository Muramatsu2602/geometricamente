using System;
using System.Windows.Forms;
using System.Drawing;

using Draw;

namespace DrawTools
{
	/// <summary>
	/// Rectangle tool
	/// </summary>
	public class ToolTriangle : DrawTools.ToolObject
	{

		public ToolTriangle()
		{
			Type t = GetType();
            //Cursor = new Cursor(t, "Triangle.cur");
		}

        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            AddNewObject(drawArea, new DrawTriangle(e.X, e.Y, 1, 1));
        }

        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursor;

            if (e.Button == MouseButtons.Left && drawArea.GraphicsList.Count > 0)
            {
                Point point = new Point(e.X, e.Y);
                drawArea.GraphicsList[0].MoveHandleTo(point, 5);
                drawArea.Refresh();
            }
        }
	}
}
