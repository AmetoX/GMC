using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometrie5._1
{
    public partial class Form1 : Form
    {
        Graphics g;
        public int i = -1;
        public int j = 0;
        public int n,m;
        
        Point[] pct;
        Random rnd = new Random();
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
            textBox1.Text = (string.Format("X: {0} Y: {1}", e.X, e.Y));
            g.DrawEllipse(cr, e.X, e.Y, 2, 2);
            Point pt = new Point(e.X, e.Y);
            pct[i] = pt;
            if (i > 0)
            {
                g.DrawLine(cr, pct[i-1].X, pct[i - 1].Y, pct[i].X, pct[i].Y);
            }
            
            textBox2.Text = m.ToString()+ " "+i.ToString();
            n--;
            m--;
        }

        private void Reset_Click(object sender, EventArgs e)
        {           
            i = -1;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void init_Click(object sender, EventArgs e)
        {
            n = rnd.Next(5, 10);
            m = n - 1;
            i = -1;
            j = 0;
            pct = new Point[n];
        }

        private void Poligon_Click(object sender, EventArgs e)
        {            
            Pen cr = new Pen(Color.DarkCyan, 4);
            g.DrawLine(cr,pct[0].X, pct[0].Y, pct[j-1].X, pct[j-1].Y);
        }
    }
}
