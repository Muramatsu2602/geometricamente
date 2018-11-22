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
    public partial class ShapeMovementTrial01 : Form
    {
        public ShapeMovementTrial01()
        {
            InitializeComponent();
        }
        
        Rectangle rect = new Rectangle(125, 125, 50, 50);
        bool isMouseDown = false;
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.RoyalBlue), rect);
        }
 
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }
 
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                rect.Location = e.Location;
 
                if (rect.Right > pictureBox1.Width)
                {
                    rect.X = pictureBox1.Width - rect.Width;
                }
                if (rect.Top < 0)
                {
                    rect.Y = 0;
                }
                if (rect.Left < 0 )
                {
                    rect.X =  0;
                }
                if (rect.Bottom > pictureBox1.Height)
                {
                    rect.Y = pictureBox1.Height - rect.Height;
                }
                Refresh();
            }
        }
 
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

    }
}
