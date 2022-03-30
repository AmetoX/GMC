using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Problema 4 Invelitoarea convexa
namespace Geometrie4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random random = new Random();
            Pen p = new Pen(Color.Blue, 4);
            Pen cr = new Pen(Color.DarkCyan, 4);
            Pen rz = new Pen(Color.Black, 2);
            float x = 0, y = 0, two = 0,trei = 0;
            int one = 0;
            int n = random.Next(10, 20);
            float[] X = new float[n];
            float[] Y = new float[n];

            for (int i = 0; i < n; i++)
            {
                x = random.Next(50, panel1.Width - 100);
                y = random.Next(50, panel1.Height - 100);
                X[i] = x;
                Y[i] = y;
                g.DrawEllipse(cr, x, y, 2, 2);
                if(y > two)
                {
                    two = y;
                    one = i;     
                }              
            }
            float distanta = 0;
            float x2 = 0;
            float y2 = 0;
            int patru = 0;
            for(int i = 0; i < n; i++)
            {
                if (y > Y[i])
                {
                    trei = Y[i];
                    patru = i;
                }
            }
            
            g.DrawEllipse(rz, X[one], Y[one], 2, 2);

        }
    }
}
