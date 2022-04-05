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
        public class Point
        {
            public float x, y;
            public Point(float x, float y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public static float orientation(Point p, Point q, Point r)
        {
            float val = (q.y - p.y) * (r.x - q.x) -
                    (q.x - p.x) * (r.y - q.y);

            if (val == 0) 
                return 0; 
            return (val > 0) ? 1 : 2; 
        }
       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random random = new Random();
            Pen cr = new Pen(Color.DarkCyan, 4);
            Pen rz = new Pen(Color.Black, 2);
            Pen w = new Pen(Color.White, 4);
            int n = random.Next(10, 20);
            float x1 = 0, y1 = 0;
            Point[] points = new Point[n];
            List<Point> hull = new List<Point>();
            for (int i = 0; i < n; i++)
            {
                x1 = random.Next(50, panel1.Width - 100);
                y1 = random.Next(50, panel1.Height - 100);
                points[i] = new Point(x1, y1);
                g.DrawEllipse(cr, x1, y1, 2, 2);
            }

            int l = 0;
            for (int i = 1; i < n; i++)
                if (points[i].x < points[l].x)
                    l = i;
            
            int p = l, q;
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
                g.DrawLine(rz,hull[i].x,hull[i].y,hull[i+1].x,hull[i+1].y);
            }
            g.DrawLine(rz, hull[hull.Count-1].x, hull[hull.Count-1].y, hull[0].x, hull[0].y);

        }

    }
}
