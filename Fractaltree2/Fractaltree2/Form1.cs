using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractaltree2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 10;
            this.Height = 800;
            this.Width = 1000;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int nudv = Convert.ToInt32(numericUpDown1.Value);
            grow(1,500, 700,600,Math.PI/2, e);
        }
        double tg = Math.PI / 4;
        void grow(int depth, int x, int y, int high, double t, PaintEventArgs e)
        {
            if (depth<= Convert.ToInt32(numericUpDown1.Value)) { 
                Pen pen;
                if (depth < 6)
                {
                    pen = new Pen(Color.Brown, 15 - depth * 2);
                }
                else if (depth < 8)
                {
                    pen = new Pen(Color.Green, 15 - depth * 2);
                }
                else
                {
                    pen = new Pen(Color.Pink, 15 - depth * 2);
                }
                int x2 = Convert.ToInt16(x - high * Math.Cos(t));
                int y2;
                if (depth > 1)
                {

                    y2 = y;
                    y = y + high;
                    MessageBox.Show(y2.ToString());
                }
                else if (depth > 2)
                {
                    y2 = y + Convert.ToInt32((high - high * Math.Pow(4 / 7, Convert.ToInt32(numericUpDown1.Value) - 1)));
                }
                else
                {
                    y2 = (y - high);
                }
                e.Graphics.DrawLine(pen, new Point(x, y), new Point(x2, y2));
                depth += 1;
                grow(depth, x2, y2, high*3/7, t-1 * Math.PI * 1 / 3, e);
                grow(depth, x2, y2, high*3/7, t+1*Math.PI*1/3, e);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
