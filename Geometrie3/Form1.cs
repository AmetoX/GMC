using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Problema 3 (cerc)
namespace Geometrie3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random random = new Random();
            Pen p = new Pen(Color.Blue, 4);
            Pen cr = new Pen(Color.DarkCyan, 4);
            Pen rz = new Pen(Color.Black, 2);
            float x = 0, y = 0, one = 0, two = 0;
            int n = random.Next(10, 20);
            float[] X = new float[n];
            float[] Y = new float[n];           

            for (int i = 0; i < n; i++)
            {
                x = random.Next(100,panel1.Width-100);
                y = random.Next(100,panel1.Height-100);
                X[i] = x;
                Y[i] = y;
                g.DrawEllipse(cr, x, y, 2, 2);
            }
            float distanta = 0;
            float x1 = 0;
            float y1 = 0;

            for(int i = 0; i < n-1; i++)
            {
                for(int j = 1; j < n; j++)
                {
                    float dis = (float)Math.Sqrt(Math.Pow(X[i] - X[j], 2) +
                Math.Pow(Y[i] - Y[j], 2));
                    if (dis > distanta)
                    {
                        distanta = dis;
                        x1 = (X[j]+X[i])/2;
                        y1 = (Y[j]+Y[i])/2;
                        //one = X[j];
                        //two = Y[j];
                    }
                }
            }
            distanta /= 2;
            for(int j = 0; j < n; j++)
            {
                float dis = (float)Math.Sqrt(Math.Pow(x1 - X[j], 2) +
                Math.Pow(y1 - Y[j], 2));
                if (dis > distanta)
                {
                    distanta = dis;
                }
            }
            //float distanta = (float)Math.Sqrt(Math.Pow(x1 - one, 2) +Math.Pow(y1 - two, 2));
            
            g.DrawEllipse(rz, x1, y1, 2, 2);
            g.DrawEllipse(rz, x1 - distanta, y1 - distanta, distanta + distanta + 5, distanta + distanta + 5);

            //g.DrawEllipse(rz, x1 - distanta, y1 - distanta, distanta + distanta + 15, distanta + distanta + 15);            
            //g.DrawEllipse(pen, centerX - radius, centerY - radius,radius + radius, radius + radius);
            //points = points.OrderBy(item => item.X).ThenBy(item => item.Y).ToList();
        }
    }
}
