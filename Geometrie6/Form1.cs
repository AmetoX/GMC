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
        List<PointF> p = new List<PointF>();
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = int.Parse(textBox1.Text);
            n2 = int.Parse(textBox1.Text);
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
            int diagonalenr = 0;
            Tuple<int, int>[] diagonalesave = new Tuple<int, int>[n - 3];
            
            Pen cr = new Pen(Color.DarkCyan, 4);
            for (int i = 0; i < n2 - 2; i++)
            {
                for (int j = i + 2; j < n2; j++)
                {

                    if (i == 0 && j == n2 - 1)
                    {
                        break;
                    }
                    bool intersectie = false;
                    for (int v = 0; v < n - 1; v++)
                        if (i != v && i != (v + 1) && j != v && j != (v + 1) && se_intersecteaza(p[i], p[j], p[v], p[v + 1]))
                        {
                            intersectie = true;
                            break;
                        }
                    //verif si pt ultima latura a poligonului
                    if (i != n - 1 && i != 0 && j != n - 1 && j != 0 && se_intersecteaza(pct[i], p[j], p[n - 1], p[0]))
                    {
                        intersectie = true;
                    }
                    if (!intersectie)
                    {
                        //si daca p_i p_j nu intersecteaza niciuna din diagonalele alese anterior
                        for (int v = 0; v < diagonalenr; v++)
                            if (i != diagonalesave[v].Item1 && i != diagonalesave[v].Item2 &&
                            j != diagonalesave[v].Item1 && j != diagonalesave[v].Item2 &&
                           se_intersecteaza(p[i], p[j], p[diagonalesave[v].Item1], p[diagonalesave[v].Item2]))
                            {
                                intersectie = true;
                                break;
                            }
                        if (!intersectie)
                        {
                            //si daca p_i p_j se afla in interiorul poligonului
                            if (se_afla_in_interiorul_poligonului(i, j))
                            {
                                //se retine diagonala p_i p_j

                                g.DrawLine(cr, p[i], p[j]);
                                diagonalesave[diagonalenr] = new Tuple<int, int>(i, j);
                                diagonalenr++;
                            }
                        }
                        if (diagonalenr == n2 - 3)
                        {
                            return;
                        }
                    }
                }
            }
        }
        public double dist2 = 0;
        public bool latura(Point a, Point b, Point c)
        {
            List<Double> hull = new List<Double>();
            double per = dist(a, b) + dist(b, c) + dist(c, a);

            hull.Add(dist2);
            foreach (double d in hull)
            {
                if (d <= per)
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
        private double Determinant(PointF p1, PointF p2, PointF p3)
        {
            return p1.X * p2.Y + p2.X * p3.Y + p3.X * p1.Y - p3.X * p2.Y - p2.X * p1.Y - p1.X * p3.Y;
        }
        private bool intoarcere_spre_stanga(int p1, int p2, int p3)
        {
            if (Determinant(p[p1], p[p2], p[p3]) < 0)
                return true;
            return false;
        }
        private bool intoarcere_spre_dreapta(int p1, int p2, int p3)
        {
            if (Determinant(p[p1], p[p2], p[p3]) > 0)
                return true;
            return false;
        }
        private bool este_varf_convex(int p)
        {
            int p_ant = (p > 0) ? p - 1 : n - 1;
            int p_urm = (p < n - 1) ? p + 1 : 0;
            return intoarcere_spre_dreapta(p_ant, p, p_urm);
        }
        private bool este_varf_reflex(int p)
        {
            int p_ant = (p > 0) ? p - 1 : n - 1;
            int p_urm = (p < n - 1) ? p + 1 : 0;
            return intoarcere_spre_stanga(p_ant, p, p_urm);
        }
        //verifica daca doua segmente se intersecteaza
        private bool se_intersecteaza(PointF s1, PointF s2, PointF p1, PointF p2)
        {
            if (Determinant(p2, p1, s1) * Determinant(p2, p1, s2) <= 0 && Determinant(s2, s1, p1) * Determinant(s2, s1, p2) <= 0)
                return true;
            return false;
        }
        //verifica daca segmentul p_i p_j se afla in interiorul poligonului
        private bool se_afla_in_interiorul_poligonului(int pi, int pj)
        {
            int pi_ant = (pi > 0) ? pi - 1 : n - 1;
            int pi_urm = (pi < n - 1) ? pi + 1 : 0;
            if ((este_varf_convex(pi) && intoarcere_spre_stanga(pi, pj, pi_urm) && intoarcere_spre_stanga(pi, pi_ant, pj)) ||
            (este_varf_reflex(pi) && !(intoarcere_spre_dreapta(pi, pj, pi_urm) && intoarcere_spre_dreapta(pi, pi_ant, pj))))
                return true;
            return false;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            k++;
            l++;
            Pen cr = new Pen(Color.DarkCyan, 4);
            g.DrawEllipse(cr, e.X, e.Y, 2, 2);
            g.DrawString(l.ToString(), new Font(FontFamily.GenericSansSerif, 10),
                new SolidBrush(Color.Black), e.X, e.Y);
            Point pt = new Point(e.X, e.Y);
            pct[k] = pt;
            p.Add(this.PointToClient(new Point(Form1.MousePosition.X, Form1.MousePosition.Y)));
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
            }
        }
    }
}
