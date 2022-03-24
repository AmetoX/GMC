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

            float[] ariiX = new float[9];
            float[] ariiY = new float[9];

            float arie = 0;
            float x1 = 0;
            float y1 = 0;
            float x2 = 0;
            float y2 = 0;
            float x3 = 0;
            float y3 = 0;
            for (int i = 0; i < 9; i++)
            {
                //1/2*(x1y2-x2y1)
                //det:x1y2+x2y3+x3y1-x3y2-x1y3-x2y1               
                int x = random.Next(10, panel1.Width-100);
                int y = random.Next(10, panel1.Height-100);
                g.DrawEllipse(pc, x, y, 2, 2);
                ariiX[i] = x;
                ariiY[i] = y;
            }            
            float[] arii = new float[100];
            for (int i = 2; i < 9; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    for (int k = 0; k < j; k++)
                    {
                        arie = (ariiX[k] * ariiY[j] + ariiX[j] * ariiY[i] + ariiX[i] * ariiY[k] - ariiX[i]
                            * ariiY[j] - ariiX[k] * ariiY[i] - ariiX[j] * ariiY[k]);
                        if (arie < 0)
                            arie *= -1;
                        arie /= 2;

                        arii[i] = arie;
                        for (int l = 2; l < arii.Length; l++)
                        {
                            if (arie <= arii[l])
                            {
                                x1 = ariiX[k];
                                y1 = ariiY[k];
                                x2 = ariiX[j];
                                y2 = ariiY[j];
                                x3 = ariiX[i];
                                y3 = ariiY[i];
                            }
                        }
                    }
                }                
            }            
            g.DrawLine(p, x1, y1, x2, y2);
            g.DrawLine(p, x2, y2, x3, y3);
            g.DrawLine(p, x3, y3, x1, y1);
        }
    }
}
