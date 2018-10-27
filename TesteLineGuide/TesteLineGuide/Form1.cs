using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TesteLineGuide
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //Apresenta as Coordenadas
            label_X.Text = e.Location.X.ToString();
            label_Y.Text = e.Location.Y.ToString();

            line_Y.Location = new Point((e.Location.X + 12), 108);
            line_X.Location = new Point(12, (e.Location.Y+108));
        }

    }
}
