using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Problema 2 (triunghi)
namespace Geometrie2
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random random = new Random();
            Pen p = new Pen(Color.Blue, 2);
            Pen pc = new Pen(Color.Red, 6);

            int[] ariiX = new int[10];
            int[] ariiY = new int[10];

            float arie = 0;
            float x1 = 0;
            float y1 = 0;
            float x2 = 0;
            float y2 = 0;
            float x3 = 0;
            float y3 = 0;
            for (int i = 0; i < 10; i++)
            {
                //1/2*(x1y2-x2y1)
                //det:x1y2+x2y3+x3y1-x3y2-x1y3-x2y1
                int x = random.Next(10, 750);
                int y = random.Next(10, 400);
                g.DrawEllipse(pc, x, y, 2, 2);
                ariiX[i] = x;
                ariiY[i] = y;
            }            
            float[] arii = new float[10];
            for (int i = 2; i < 10; i++)
            {
                arie = (ariiX[i - 2] * ariiY[i - 1] + ariiX[i - 1] * ariiY[i] + ariiX[i] * ariiY[i - 2] - ariiX[i]
                    * ariiY[i - 1] - ariiX[i - 2] * ariiY[i] - ariiX[i - 1] * ariiY[i - 2]);
                if (arie < 0)
                    arie *= -1;
                arie /= 2;
                
                arii[i] = arie;
                for (int j = 0; j < arii.Length; j++)
                {
                    if (arie < arii[j])
                    {
                        x1 = ariiX[i - 2];
                        y1 = ariiY[i - 2];
                        x2 = ariiX[i - 1];
                        y2 = ariiY[i - 1];
                        x3 = ariiX[i];
                        y3 = ariiY[i];
                        
                    }
                }
                
            }
            
               
            
            g.DrawLine(p, x1, y1, x2, y2);
            g.DrawLine(p, x2, y2, x3, y3);
            g.DrawLine(p, x3, y3, x1, y1);
        }
    }
}
