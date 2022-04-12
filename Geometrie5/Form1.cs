using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometrie5
{
    public partial class Form1 : Form
    {        
        
        public Form1()
        {
            InitializeComponent();
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
                PointF aux = this.PointToClient(new Point(Form1.MousePosition.X, Form1.MousePosition.Y));
                x1 = Form1.MousePosition.X;
                y1 = Form1.MousePosition.Y;
                points[i] = new Point(x1, y1);
                g.DrawString(n.ToString(), new Font(FontFamily.GenericSansSerif, 10), new SolidBrush(Color.Black), aux);
                g.DrawEllipse(cr, aux.X, aux.Y, 3, 3);
            }
            e.Graphics.DrawPolygon(inv, points);
        }
        private void panel1_Click(object sender, EventArgs e)
        {
 
        }
    }
}
