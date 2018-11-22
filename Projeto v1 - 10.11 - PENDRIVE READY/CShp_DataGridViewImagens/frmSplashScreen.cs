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
        public String TestaPendrive()
        {
            if (Directory.Exists("D:\\")) { return "D"; }
            if (Directory.Exists("E:\\")) { return "E"; }
            if (Directory.Exists("F:\\")) { return "F"; }
            if (Directory.Exists("G:\\")) { return "G"; }
            if (Directory.Exists("F:\\")) { return "H"; }
            if (Directory.Exists("F:\\")) { return "I"; }
            if (Directory.Exists("F:\\")) { return "J"; }
            if (Directory.Exists("F:\\")) { return "K"; }
            if (Directory.Exists("F:\\")) { return "L"; }
            if (Directory.Exists("F:\\")) { return "M"; }
            if (Directory.Exists("F:\\")) { return "N"; }
            if (Directory.Exists("F:\\")) { return "O"; }
            if (Directory.Exists("F:\\")) { return "P"; }
            if (Directory.Exists("F:\\")) { return "Q"; }
            if (Directory.Exists("F:\\")) { return "R"; }
            if (Directory.Exists("F:\\")) { return "S"; }
            if (Directory.Exists("F:\\")) { return "T"; }
            if (Directory.Exists("F:\\")) { return "U"; }
            if (Directory.Exists("F:\\")) { return "W"; }
            if (Directory.Exists("F:\\")) { return "X"; }
            if (Directory.Exists("F:\\")) { return "Y"; }
            if (Directory.Exists("F:\\")) { return "Z"; }
            return "C";
        }
        public void TestaPasta()
        {
            if(Directory.Exists(TestaPendrive()+":\\Geometricamente"))
            {
                if (!Directory.Exists(TestaPendrive()+":\\Geometricamente\\video"))
                {
                    Directory.CreateDirectory(TestaPendrive()+":\\Geometricamente\\video");
                }
                if (!Directory.Exists(TestaPendrive()+":\\Geometricamente\\audio"))
                {
                    Directory.CreateDirectory(TestaPendrive()+":\\Geometricamente\\audio");
                }
                if (!Directory.Exists(TestaPendrive()+":\\Geometricamente\\images"))
                {
                    Directory.CreateDirectory(TestaPendrive()+":\\Geometricamente\\images");
                }
                if (!Directory.Exists(TestaPendrive()+":\\Geometricamente\\app"))
                {
                    Directory.CreateDirectory(TestaPendrive()+":\\Geometricamente\\app");
                }
                if (!Directory.Exists(TestaPendrive()+":\\Geometricamente\\setup"))
                {
                    Directory.CreateDirectory(TestaPendrive()+":\\Geometricamente\\setup");
                }
            } 
           
        }
  
    }
}
