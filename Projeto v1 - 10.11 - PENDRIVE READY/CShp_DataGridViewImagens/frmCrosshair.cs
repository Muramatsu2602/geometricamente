using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometricamente_V1
{
    public partial class frmCrosshair : Form
    {
        Pen crossPen;
        Pen rectanglePen;
        Brush rectangleBrush;

        public frmCrosshair()
        { 
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            crossPen = new Pen(Color.Red, 5);
   
        }
        bool mouseDown = false;
        Point startPoint = Point.Empty;
        Point endPoint = Point.Empty;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            startPoint = e.Location;
            mouseDown = true;
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            mouseDown = false;
            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            endPoint = e.Location;
            this.Invalidate();
            base.OnMouseMove(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            if (this.ClientRectangle.Contains(endPoint))
                DrawCross(e.Graphics, endPoint);

        }
        void DrawCross(Graphics g, Point point)
        {
            g.DrawLine(crossPen, new Point(0, point.Y), new Point(Width, point.Y));
            g.DrawLine(crossPen, new Point(point.X, 0), new Point(point.X, Height));
        }
        void DrawRectangle(Graphics g, Point point1, Point point2)
        {
            var rectangle = new Rectangle(
                Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y),
                Math.Abs(point1.X - point2.X), Math.Abs(point1.Y - point2.Y));
        }
        protected override void Dispose(bool disposing)
        {
            crossPen.Dispose();
            base.Dispose(disposing);
        }

        private void lblCoordenadas_MouseMove(object sender, MouseEventArgs e)
        {
            lblCoordenadas.Text = string.Format("X = {0}, Y = {1}", e.X-1, e.Y-40);
        }

     
    }
}
