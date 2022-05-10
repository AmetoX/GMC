using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Geometrie6._1
{
    public partial class Form1 : Form
    {
        Graphics g;
        public int i = -1;
        public int j = 0;
        public int n, m,n2;
        PointF[] pct;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            i++;
            j++;
            Pen cr = new Pen(Color.DarkCyan, 4);
            //textBox1.Text = (string.Format("X: {0} Y: {1}", e.X, e.Y));
            g.DrawEllipse(cr, e.X, e.Y, 2, 2);
            g.DrawString(j.ToString(), new Font(FontFamily.GenericSansSerif, 10),
                new SolidBrush(Color.Black), e.X, e.Y);
            PointF pt = new PointF(e.X, e.Y);
            pct[i] = pt;
            if (i > 0)
            {
                g.DrawLine(cr, pct[i - 1].X, pct[i - 1].Y, pct[i].X, pct[i].Y);
            }
            textBox2.Text = m.ToString();
            n2--;
            m--;
            if (n2 == 0)
            {
                g.DrawLine(cr, pct[0].X, pct[0].Y, pct[j - 1].X, pct[j - 1].Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = int.Parse(textBox1.Text);
            n2 = int.Parse(textBox1.Text);
            m = n - 1;
            i = -1;
            j = 0;
            pct = new PointF[n];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i = -1;
            textBox1.Text = "";
            textBox2.Text = "";
            this.Hide();
            this.Show();
        }
        private double Sarrus(PointF p1, PointF p2, PointF p3)
        {
            return p1.X * p2.Y + p2.X * p3.Y + p3.X * p1.Y - p3.X * p2.Y - p2.X * p1.Y - p1.X * p3.Y;
        }
        private bool intoarcere_spre_stanga(int p1, int p2, int p3)
        {
            if (Sarrus(pct[p1], pct[p2], pct[p3]) < 0)
                return true;
            return false;
        }
        private bool intoarcere_spre_dreapta(int p1, int p2, int p3)
        {
            if (Sarrus(pct[p1], pct[p2], pct[p3]) > 0)
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
        private bool se_intersecteaza(PointF s1, PointF s2, PointF p1, PointF p2)
        {
            if (Sarrus(p2, p1, s1) * Sarrus(p2, p1, s2) <= 0 && Sarrus(s2, s1, p1) * Sarrus(s2, s1, p2) <= 0)
                return true;
            return false;
        }
        private bool se_afla_in_interiorul_poligonului(int pi, int pj)
        {
            int pi_ant = (pi > 0) ? pi - 1 : n - 1;
            int pi_urm = (pi < n - 1) ? pi + 1 : 0;
            if ((este_varf_convex(pi) && intoarcere_spre_stanga(pi, pj, pi_urm) && intoarcere_spre_stanga(pi, pi_ant, pj)) ||
            (este_varf_reflex(pi) && !(intoarcere_spre_dreapta(pi, pj, pi_urm) && intoarcere_spre_dreapta(pi, pi_ant, pj))))
                return true;
            return false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int nr_diagonale = 0;
            Tuple<int, int>[] diagonale = new Tuple<int, int>[n - 3];
            Pen cr = new Pen(Color.Red, 4);
            for (int i = 0; i < n - 3; i++)
                for (int j = i + 2; j < n-1; j++)
                {
                    if (i == 0 && j == n - 1)
                        break;
                    bool intersectie = false;
                    //daca p_i p_j nu intersecteaza nicio latura neincidenta a poligonului
                    for (int k = 0; k < n - 1; k++)
                        if (i != k && i != (k + 1) && j != k && j != (k + 1))
                        {
                            if (se_intersecteaza(pct[i], pct[j], pct[k], pct[k + 1]))
                            {
                                intersectie = true;                             
                            }
                        }
                    //verif si pt ultima latura a poligonului
                    if (i != n - 1 && i != 0 && j != n - 1 && j != 0)
                    {
                        if(se_intersecteaza(pct[i], pct[j], pct[n - 1], pct[0]))
                            intersectie = true;
                    }
                    if (!intersectie)
                    {
                        //si daca p_i p_j nu intersecteaza niciuna din diagonalele alese anterior
                        for (int k = 0; k < nr_diagonale; k++)
                            if (i != diagonale[k].Item1 && i != diagonale[k].Item2 &&
                            j != diagonale[k].Item1 && j != diagonale[k].Item2)
                            {
                                if(se_intersecteaza(pct[i], pct[j], pct[diagonale[k].Item1], pct[diagonale[k].Item2]))
                                {
                                    intersectie = true;
                                    
                                }
                            }
                        if (!intersectie)
                        {
                            //si daca p_i p_j se afla in interiorul poligonului
                            if (se_afla_in_interiorul_poligonului(i, j))
                            {
                                //se retine diagonala p_i p_j
                                Thread.Sleep(100);
                                g.DrawLine(cr, pct[i], pct[j]);
                                diagonale[nr_diagonale] = new Tuple<int, int>(i, j);
                                nr_diagonale++;
                            }
                        }
                    }
                    if (nr_diagonale == n - 3)
                        return;
                }
        }
    }
}
