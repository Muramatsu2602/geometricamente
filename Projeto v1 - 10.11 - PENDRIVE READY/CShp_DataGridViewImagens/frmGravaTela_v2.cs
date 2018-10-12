using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CShp_DataGridViewImagens
{
    /// <summary>
    /// Este exemplo se baseia no video </https://www.youtube.com/watch?v=KMX0mhMv_j8>
    ///também salva em bitmap
    ///
    /// Bitmap bm = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
    /// Graphics g = Graphics.FromImage(bm); g.CopyFromScreen(0, 0, 0, 0, bm.Size); 
    /// bm.Save(txtFP.Text + Guid.NewGuid() + ".MP4");﻿
    /// 
    /// </summary>
    public partial class frmGravaTela_v2 : Form
    {
        public frmGravaTela_v2()
        {
            InitializeComponent();
        }
      
        private void btnCapturaTela_Click(object sender, EventArgs e)
        {     
                Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics gr = Graphics.FromImage(bmp);
                gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);
                picMostraTela.Image = bmp;

         
        }
          void Capturar()
        {
            while(true)
            {
                Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics gr = Graphics.FromImage(bmp);
                gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);
                picMostraTela.Image = bmp;
                Thread.Sleep(500);
            }
      
        } 
        private void button2_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(Capturar);
            t.Start();
        }

        private void btnTerminaGravacao_Click(object sender, EventArgs e)
        {

        }
        
    }
}
