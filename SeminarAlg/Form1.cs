using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeminarAlg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
      

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random random = new Random();
            Pen cr = new Pen(Color.DarkCyan, 4);
            Pen inv = new Pen(Color.Black, 2);
            int n = random.Next(10, 20);
            int x1 = 0, y1 = 0;
            float[] X = new float[n];
            float[] Y = new float[n];
            Point[] points = new Point[n];
            //PointF aux = this.PointToClient(new Point(Form1.MousePosition.X, Form1.MousePosition.Y));
           // g.DrawEllipse(cr, aux.X, aux.Y, 4, 4);
            //points[0] = new Point(Form1.MousePosition.X, Form1.MousePosition.Y);
            for (int i = 0; i < n; i++)
            {
                x1 = random.Next(50, panel1.Width - 100);
                y1 = random.Next(50, panel1.Height - 100);
                //points[i] = new Point(x1, y1);
                //g.DrawEllipse(cr, x1 - 2, y1 - 2, 4, 4);
                PointF aux = this.PointToClient(new Point(Form1.MousePosition.X, 
                    Form1.MousePosition.Y));
                g.DrawEllipse(cr, aux.X, aux.Y, 4, 4);
                points[i] = new Point(Form1.MousePosition.X, Form1.MousePosition.Y);


            }
            for(int i = 0; i < points.Length; i++)
            {
                g.DrawString(n.ToString(), new Font(FontFamily.GenericSansSerif, 10),
new SolidBrush(Color.Black), points[i]);
            }

        }
    }
}
