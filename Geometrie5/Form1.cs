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

namespace Geometrie5
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }
        
        List<Point> hull = new List<Point>();
        public int i = 0;
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Pen cr = new Pen(Color.DarkCyan, 4);
            Point aux = new Point(e.X, e.Y);
            textBox1.Text = (string.Format("X: {0} Y: {1}", e.X, e.Y));
            hull.Append(aux);
            
                g.DrawEllipse(cr, e.X, e.Y, 2, 2);
            i++;
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            
            Pen cr = new Pen(Color.Black, 4);
            for (int i = 1; i < hull.Count-1; i++)
            {
                g.DrawLine(cr, hull[i], hull[i - 1]);
                //g.DrawLine(cr, hull[i], hull[i + 1]);
                //g.DrawEllipse(cr, hull[i].X, hull[i].Y, 2, 2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            i = 0;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            

        }
    }
}
