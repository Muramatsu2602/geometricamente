using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometricamente_V1
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();

            TestaPasta();
        }
        public void TestaPasta()
        {
            if (!Directory.Exists("C:\\Geometricamente\\video"))
            {
                Directory.CreateDirectory("C:\\Geometricamente\\video");
            }
            if (!Directory.Exists("C:\\Geometricamente\\audio"))
            {
                Directory.CreateDirectory("C:\\Geometricamente\\audio");
            }
            if (!Directory.Exists("C:\\Geometricamente\\images"))
            {
                Directory.CreateDirectory("C:\\Geometricamente\\images");
            }
            if (!Directory.Exists("C:\\Geometricamente\\app"))
            {
                Directory.CreateDirectory("C:\\Geometricamente\\app");
            }
            if (!Directory.Exists("C:\\Geometricamente\\setup"))
            {
                Directory.CreateDirectory("C:\\Geometricamente\\setup");
            }
        }
  
    }
}
