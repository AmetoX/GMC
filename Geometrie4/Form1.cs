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

            if (val == 0) return 0; // collinear
            return (val > 0) ? 1 : 2; // clock or counterclock wise
        }

        // Prints convex hull of a set of n points.
        public static void convexHull(Point[] points, int n,float[]X,float[]Y,Point[] point2)
        {
            // There must be at least 3 points
            if (n < 3) return;

            // Initialize Result
            List<Point> hull = new List<Point>();

            // Find the leftmost point
            int l = 0;
            for (int i = 1; i < n; i++)
                if (points[i].x < points[l].x)
                    l = i;

            // Start from leftmost point, keep moving
            // counterclockwise until reach the start point
            // again. This loop runs O(h) times where h is
            // number of points in result or output.
            int p = l, q;
            do
            {
                // Add current point to result
                hull.Add(points[p]);

                // Search for a point 'q' such that
                // orientation(p, q, x) is counterclockwise
                // for all points 'x'. The idea is to keep
                // track of last visited most counterclock-
                // wise point in q. If any point 'i' is more
                // counterclock-wise than q, then update q.
                q = (p + 1) % n;

                for (int i = 0; i < n; i++)
                {
                    // If i is more counterclockwise than
                    // current q, then update q
                    if (orientation(points[p], points[i], points[q]) == 2)
                        q = i;
                }

                // Now q is the most counterclockwise with
                // respect to p. Set p as q for next iteration,
                // so that q is added to result 'hull'
                p = q;

            } while (p != l); // While we don't come to first
                              // point


            

            // Print Result
            for(int i = 0; i<hull.Count; i++)
            {
                X[i] = (float)hull[i].x;
                Y[i] = (float)hull[i].y;
                point2[i] = new Point((float)hull[i].x, (float)hull[i].y);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random random = new Random();
            Pen p = new Pen(Color.Blue, 6);
            Pen cr = new Pen(Color.DarkCyan, 4);
            Pen rz = new Pen(Color.Black, 2);
            Pen w = new Pen(Color.White, 4);
            float x1 = 0, y1 = 0, two = 0;
            int one = 0;
            int n = random.Next(10, 20);
            float[] X = new float[n];
            float[] Y = new float[n];
            Point[] points = new Point[n];
            Point[] point2 = new Point[n];
            for (int i = 0; i < n; i++)
            {
                x1 = random.Next(50, panel1.Width - 100);
                y1 = random.Next(50, panel1.Height - 100);
                points[i] = new Point(x1, y1);
                //X[i] = x;
                //Y[i] = y;
                
                g.DrawEllipse(cr, x1, y1, 2, 2);
                if(y1 > two)
                {
                    two = y1;
                    one = i;     
                }              
            }
            
            //g.DrawEllipse(rz, X[one], Y[one], 2, 2);
            //g.DrawLine(rz, X[one], Y[one], panel1.Width, Y[one]);
            convexHull(points, n, X,Y,point2);
            for(int i = 1; i < n-1; i++)
            {
                if(X[i] !=0 && Y[i]!=0)
                    g.DrawLine(w, X[i-1], Y[i-1], X[i], Y[i]);
            }
            //g.DrawLine(rz, X[0], Y[0], X[n-1], Y[n-1]);


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
