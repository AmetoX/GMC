using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometri1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Blue, 5);
            g.DrawLine(p, 0, 0, 100, 100);
            g.DrawLine(p, 100, 100, 400, 100);
            g.DrawLine(p, 400, 100, -900, 900);
        }

    }
}
