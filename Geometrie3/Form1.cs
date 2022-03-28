﻿using System;
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
            Pen cr = new Pen(Color.Red, 4);
            Pen rz = new Pen(Color.Green, 3);
            float x = 0, y = 0, one = 0, two = 0;
            float[] X = new float[9];
            float[] Y = new float[9];           

            for (int i = 0; i < 9; i++)
            {
                x = random.Next(panel1.Width - 150);
                y = random.Next(panel1.Height - 150);
                X[i] = x;
                Y[i] = y;
                g.DrawEllipse(cr, x, y, 2, 2);
                if (x > one)
                    one = x;
                if (y > two)
                    two = y;
            }

            //int punct = random.Next(0, 9);
            //g.DrawEllipse(p, X[punct], Y[punct], 3, 3);
            float distanta = 0;
            /*
            for (int i = 0; i < 9; i++)
            {
                float dis = (float)Math.Sqrt(Math.Pow(X[i] - X[punct], 2) +
                                Math.Pow(Y[i] - Y[punct], 2));
                if (dis > distanta)
                {
                    distanta = dis;                   
                }
            }
            */
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;

            for(int i = 0; i < 8; i++)
            {
                for(int j = 1; j < 9; j++)
                {
                    float dis = (float)Math.Sqrt(Math.Pow(X[i] - X[j], 2) +
                Math.Pow(Y[i] - Y[j], 2));
                    if (dis >= distanta)
                    {
                        distanta = dis;
                        x1 = i;
                        y1 = i;
                        x2 = j;
                        y2 = j;
                    }
                }
            }

            g.DrawEllipse(p, X[x1], Y[y1], 3, 3);
            g.DrawEllipse(p, X[x2], Y[y2], 3, 3);
            g.DrawEllipse(rz,X[x1]-distanta, Y[y1]-distanta,distanta + distanta+10, distanta + distanta+10);
            //g.DrawEllipse(pen, centerX - radius, centerY - radius,radius + radius, radius + radius);
            //points = points.OrderBy(item => item.X).ThenBy(item => item.Y).ToList();
        }
    }
}
