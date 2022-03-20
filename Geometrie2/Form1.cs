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
            Graphics g = e.Graphics;
            Random random = new Random();
            Pen p = new Pen(Color.Blue, 5);
            Pen pc = new Pen(Color.Red, 5);
            
            int[] ariiX = new int[10];
            int[] ariiY = new int[10];  
            
            float arie2 = 0;
            float x1 = 0;
            float y1 = 0;
            float x2 = 0;
            float y2 = 0;
            float x3 = 0;
            float y3 = 0;

            for (int i = 0; i < 10; i++)
            {
                //1/2*(x1y2-x2y1)
                //det:x1y2+x2y3+x3y1-x2y1-x1y3-x3y2
                int x = random.Next(10,750);
                int y = random.Next(10,400);
                g.DrawEllipse(pc, x, y, 2, 2);
                ariiX[i] = x;
                ariiY[i] = y;       
            }
            for(int i = 2; i < 10; i++)
            {
                for(int j = 2; j < 10; j++)
                {
                    float arie = (ariiX[i - 2] * ariiY[j - 1] + ariiX[i - 1] * ariiY[j] + ariiX[i] * ariiY[j - 2] - ariiX[i - 1]
                        * ariiY[j - 2] - ariiX[i - 2] * ariiY[j] - ariiX[i] * ariiY[j - 1]) / 2;
                    if (arie < 0)
                        arie *= -1;

                    listBox1.Items.Add(arie.ToString());
                    if (arie < arie2)
                    {
                        x1 = ariiX[i - 2];
                        y1 = ariiY[j - 2];
                        x2 = ariiX[i - 1];
                        y2 = ariiY[j - 1];
                        x3 = ariiX[i];
                        y3 = ariiY[j];
                    }
                    arie2 = arie;
                }
            }

            g.DrawLine(p, x1, y1, x2, y2);
            g.DrawLine(p,x2, y2, x3, y3);
            g.DrawLine(p,x3,y3,x1,y1);                       
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
