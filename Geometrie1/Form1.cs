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
            //prima oara generam punctele si dupa generam dreptunghiul
            Graphics g = e.Graphics;
            Random random = new Random();
            Pen p = new Pen(Color.Blue, 5);
            Pen pc = new Pen(Color.Red, 5);
            int one = 0;
            int two = 0;
            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(20, 780);
                int y = random.Next(20, 380);
                g.DrawEllipse(pc, x, y, 2, 2);
                if (x >= one)
                    one = x;
                if (y >= two)
                    two = y;
                    
            }
            g.DrawRectangle(p, new Rectangle(10, 10, one, two));
            
        }
    }
}
