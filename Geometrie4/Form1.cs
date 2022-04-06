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

        public static float orientation(Point p, Point q, Point r)
        {
            float val = (q.Y - p.Y) * (r.X - q.X) -
                    (q.X - p.X) * (r.Y - q.Y);

            if (val == 0) 
                return 0;//colineare
            return (val > 0) ? 1 : 2;//in sensul acelor de ceasornic sau invers
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
                g.DrawEllipse(cr, x1-2, y1-2, 4, 4);
            }

            int l = 0;
            for (int i = 1; i < n; i++)
            {
                if (points[i].X < points[l].X)
                    l = i;
            }

            int p = l;
            int q;
            do
            {
                hull.Add(points[p]);
                q = (p + 1) % n;
                for (int i = 0; i < n; i++)
                {
                    if (orientation(points[p], points[i], points[q]) == 2)
                        q = i;
                }
                p = q;
            } while (p != l);

            for(int i = 0; i < hull.Count-1; i++)
            {
                g.DrawLine(inv,hull[i].X,hull[i].Y,hull[i+1].X,hull[i+1].Y);
            }
            g.DrawLine(inv, hull[hull.Count-1].X, hull[hull.Count-1].Y, hull[0].X, hull[0].Y);
        }
    }
}
