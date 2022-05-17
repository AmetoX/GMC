using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//otectonie

namespace Geometrie7
{
    public partial class Form1 : Form
    {
        Graphics g;
        int n = 0;
        int c = 0;
        const int raza = 3;
        List<PointF> p = new List<PointF>();
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Pen cr = new Pen(Color.DarkCyan, 2);
            Pen cr1 = new Pen(Color.Red, 7);
            Pen cr2 = new Pen(Color.Orange, 7);
            Pen cr3 = new Pen(Color.Purple, 7);
            p.Add(this.PointToClient(new Point(Form1.MousePosition.X, Form1.MousePosition.Y)));
            
            if (c == 0)            
                g.DrawEllipse(cr1, p[n].X, p[n].Y, raza, raza);
            if(c == 1)
                g.DrawEllipse(cr2, p[n].X, p[n].Y, raza, raza);
            if (c == 2)
                g.DrawEllipse(cr3, p[n].X, p[n].Y, raza, raza);
            c++;
            if (c == 3)
                c = 0;
            g.DrawString((n + 1).ToString(), new Font(FontFamily.GenericSansSerif, 10),
            new SolidBrush(Color.Navy), p[n].X + raza, p[n].Y - raza);
            if (n > 0)
                g.DrawLine(cr, p[n - 1], p[n]);
            n++;
        }
        private float Sarrus(PointF p1, PointF p2, PointF p3)
        {
            float sarus = p1.X * p2.Y + p2.X * p3.Y + p3.X * p1.Y - p3.X * p2.Y - p2.X * p1.Y - p1.X * p3.Y;
            return sarus;
        }
        private bool intoarcere_spre_stanga(int p1, int p2, int p3)
        {
            if (Sarrus(p[p1], p[p2], p[p3]) < 0)
                return true;
            return false;
        }
        private bool intoarcere_spre_dreapta(int p1, int p2, int p3)
        {
            if (Sarrus(p[p1], p[p2], p[p3]) > 0)
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
            {
                return true;
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Pen cr = new Pen(Color.DarkCyan, 2);
            if (n < 3)
                return;
            g.DrawLine(cr, p[n - 1], p[0]);
        }
        int nr_diagonale = 0;
        private bool diagonala(int i, int j)
        {
            int m = n;
            Pen cr = new Pen(Color.Red, 2);            
            Tuple<int, int>[] diagonale = new Tuple<int, int>[m - 3];
            bool intersectie = false;
            for (int k = 0; k < m - 1; k++)
            {
                if (i != k && i != (k + 1) && j != k && j != (k + 1) && se_intersecteaza(p[i], p[j], p[k], p[k + 1]))
                {
                    intersectie = true;
                    break;
                }
            }
            if (i != m - 1 && i != 0 && j != m - 1 && j != 0 && se_intersecteaza(p[i], p[j], p[m - 1], p[0]))
            {
                intersectie = true;
            }
            if (!intersectie)
            {
                for (int k = 0; k < nr_diagonale; k++)
                {
                    if (i != diagonale[k].Item1 && i != diagonale[k].Item2 &&
                     j != diagonale[k].Item1 && j != diagonale[k].Item2 &&
                    se_intersecteaza(p[i], p[j], p[diagonale[k].Item1], p[diagonale[k].Item2]))
                    {
                        intersectie = true;
                        break;
                    }
                }
                if (!intersectie)
                {
                    if (se_afla_in_interiorul_poligonului(i, j))
                    {
                        //g.DrawLine(cr, p[i].X, p[i].Y, p[j].X, p[j].Y);
                        diagonale[nr_diagonale] = new Tuple<int, int>(i, j);                       
                    }
                }
            }
            if (!intersectie)
                return true;
            else
                return false;
        }          
        private void button2_Click(object sender, EventArgs e)
        {
            Pen cr = new Pen(Color.Red, 2);
            Pen sterg = new Pen(Color.White, 5);
            while (n > 3)
            {
                for(int i = 1; i < n; i++)
                {
                    if (diagonala(i, i + 2))
                    {
                        g.DrawLine(cr, p[i].X, p[i].Y, p[i+2].X, p[i+2].Y);
                        g.DrawEllipse(sterg, p[i + 1].X, p[i + 1].Y, raza, raza);
                        p.Remove(p[i+1]);
                        n = n - 1;
                        break;
                    }
                }
            }
        }
    }
}
