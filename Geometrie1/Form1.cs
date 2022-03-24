using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Problema 1 (dreptunghi)
namespace Geometrie1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }  
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //prima oara generam punctele si dupa generam dreptunghiul
            Graphics g = e.Graphics;
            Random random = new Random();
            Pen p = new Pen(Color.Blue, 2);
            Pen pc = new Pen(Color.Black, 3);

            int one = 0;
            int two = 0;
            int x1 = panel1.Width; 
            int y1 = panel1.Height;

            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(20, panel1.Width - 100);
                int y = random.Next(20, panel1.Height - 100);
                g.DrawEllipse(pc, x, y, 2, 2);
                
                if (x < x1)
                    x1 = x;
                if (y < y1)
                    y1 = y;
                if (x >= one)
                    one = x;
                if (y >= two)
                    two = y;
            }
            g.DrawRectangle(p, new Rectangle(x1, y1, one - x1 + 20, two - y1 + 20));
        }
    }
}
