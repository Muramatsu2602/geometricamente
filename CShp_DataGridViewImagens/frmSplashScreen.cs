using System;
using System.IO;
using System.Windows.Forms;

namespace Geometricamente_V1
{
    public partial class frmSplashScreen : Form
    {
        private int i = 0;
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
           // TestaPasta();
        }
        public String TestaPendrive()
        {
            return Environment.CurrentDirectory;
        }
        public void TestaPasta()
        {
            if (!Directory.Exists(TestaPendrive() + "\\video"))
            {
                Directory.CreateDirectory(TestaPendrive() + "\\video");
            }
            if (!Directory.Exists(TestaPendrive() + "\\audio"))
            {
                Directory.CreateDirectory(TestaPendrive() + "\\audio");
            }
            if (!Directory.Exists(TestaPendrive() + "\\images"))
            {
                Directory.CreateDirectory(TestaPendrive() + "\\images");
            }
            if (!Directory.Exists(TestaPendrive() + "\\app"))
            {
                Directory.CreateDirectory(TestaPendrive() + "\\app");
            }
            if (!Directory.Exists(TestaPendrive() + "\\setup"))
            {
                Directory.CreateDirectory(TestaPendrive() + "\\setup");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            i += timer1.Interval;
            if (i == 5000)
                this.Close();
        }
    }
}
