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
            if (!Directory.Exists("D:\\Geometricamente\\video"))
            {
                Directory.CreateDirectory("D:\\Geometricamente\\video");
            }
            if (!Directory.Exists("D:\\Geometricamente\\audio"))
            {
                Directory.CreateDirectory("D:\\Geometricamente\\audio");
            }
            if (!Directory.Exists("D:\\Geometricamente\\images"))
            {
                Directory.CreateDirectory("D:\\Geometricamente\\images");
            }
            if (!Directory.Exists("D:\\Geometricamente\\app"))
            {
                Directory.CreateDirectory("D:\\Geometricamente\\app");
            }
            if (!Directory.Exists("D:\\Geometricamente\\setup"))
            {
                Directory.CreateDirectory("D:\\Geometricamente\\setup");
            }
        }
  
    }
}
