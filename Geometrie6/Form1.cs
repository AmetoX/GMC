using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometrie6
{
    public partial class Form1 : Form
    {
        Graphics g;
        public int k = -1;
        public int l = 0;
        public int n, m;
        public int n2;
        Point[] pct;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = int.Parse(textBox1.Text);
            n2= int.Parse(textBox1.Text);
            m = n - 1;
            k = -1;
            l = 0;
            pct = new Point[n];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            k = -1;
            textBox1.Text = "";
            textBox2.Text = "";
            this.Hide();
            this.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //diag
            Pen cr = new Pen(Color.DarkCyan, 4);                 
            //g.DrawLine(cr, pct[0].X, pct[0].Y, pct[2].X, pct[2].Y);

            //textBox3.Text = diagonale.ToString();      
        }
        public double dist2 = 0;     
        public bool latura(Point a, Point b,Point c)
        {
            List<Double> hull = new List<Double>();
            double per = dist(a,b)+dist(b,c)+dist(c,a);
            hull.Add(dist2);
            foreach (double d in hull)
            {
                if (d != per)
                {
                    hull.Add(per);
                    textBox3.Text = per.ToString();
                    return true;
                }
            }
            return false;
        }
        public double dist(Point p, Point q)
        {
            // The distance between vertices `(x1, y1)` & `(x2,
            // y2)` is `√((x2 − x1) ^ 2 + (y2 − y1) ^ 2)
            return Math.Sqrt((q.X - p.X) * (q.X - p.X) +
                     (q.Y - p.Y) * (q.Y - p.Y));
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {            
            k++;
            l++;
            Pen cr = new Pen(Color.DarkCyan, 4);
            //textBox1.Text = (string.Format("X: {0} Y: {1}", e.X, e.Y));
            g.DrawEllipse(cr, e.X, e.Y, 2, 2);
            g.DrawString(l.ToString(), new Font(FontFamily.GenericSansSerif, 10),
                new SolidBrush(Color.Black), e.X, e.Y);
            Point pt = new Point(e.X, e.Y);
            pct[k] = pt;
            if (k > 0)
            {
                g.DrawLine(cr, pct[k - 1].X, pct[k - 1].Y, pct[k].X, pct[k].Y);
            }

            textBox2.Text = m.ToString();
            n--;
            m--;
            if (n == 0)
            {
                g.DrawLine(cr, pct[0].X, pct[0].Y, pct[l - 1].X, pct[l - 1].Y);
                int diagonale = 0;
                //g.DrawLine(cr, pct[0].X, pct[0].Y, pct[2].X, pct[2].Y);
                for (int i = 0; i < n2 - 3; i++)
                {
                    for (int j = i + 2; j < n2 - 1; j++)
                    {
                        if(i==0&&j==2)
                            g.DrawLine(cr, pct[i].X, pct[i].Y, pct[j].X, pct[j].Y);
                        if (i == 0 && j == 0)
                        {
                            break;
                        }
                        if (latura(pct[i], pct[i + 1], pct[j]))
                        {
                            g.DrawLine(cr, pct[i].X, pct[i].Y, pct[j].X, pct[j].Y);
                            diagonale++;
                        }
                        if (diagonale == n2 - 3)
                        {
                            return;
                        }
                    }
                }
            }
        }
    }
}
