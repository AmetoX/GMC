using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Problema 4 Invelitoarea convexa algoritm simplu
namespace Geometrie4._5 
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double orientation(double pX, double pY, double qX, double qY, double rX, double rY)
        {
            return pX * qY + qX * rY + pY * rX - rX * qY - pX * rY - qX * pY;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random random = new Random();
            Pen cr = new Pen(Color.DarkCyan, 4);
            Pen inv = new Pen(Color.Black, 2);
            int n = random.Next(10, 20);
            int x1 = 0, y1 = 0;
            Point[] points = new Point[n];
            List<Point> hull = new List<Point>();
            for (int i = 0; i < n; i++)
            {
                x1 = random.Next(50, panel1.Width - 100);
                y1 = random.Next(50, panel1.Height - 100);
                points[i] = new Point(x1, y1);
                g.DrawEllipse(cr, x1 - 2, y1 - 2, 4, 4);
            }
            bool ok;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        ok = true;
                        for (int k = 0; k < n; k++)
                        {
                            if (k != i && k != j)
                            {
                                if (orientation(points[i].X, points[i].Y, points[j].X, points[j].Y, points[k].X, points[k].Y) > 0)
                                {
                                    ok = false;
                                }
                            }
                        }
                        if (ok)
                        {
                            g.DrawLine(inv, points[i].X, points[i].Y, points[j].X, points[j].Y);
                        }
                    }

                }
            }
        }
    }
}
