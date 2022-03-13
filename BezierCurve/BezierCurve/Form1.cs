using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BezierCurve
{
    public partial class Form1 : Form
    {
        Point[] Q = new Point[5];
        int clickcount = 0;
        bool mouse = false;
        Control[] ct = new Control[5];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 255));  //設定筆刷
            Pen p = new Pen(Color.FromArgb(255, 255, 0, 255));  //設定筆刷
            if (clickcount == 4)
            {

                Point p1 = Q[0];   // 起始點
                Point c1 = Q[1];   // 第一個控制點
                Point c2 = Q[2];   // 第二個控制點
                Point p2 = Q[3];   // 終點
                
                for (double t = 0.00; t <= 1.0; t += 0.001)
                {
                    double x = (-t * t * t + 3 * t * t - 3 * t + 1) * p1.X
                            + (3 * t * t * t - 6 * t * t + 3 * t) * c1.X
                            + (-3 * t * t * t + 3 * t * t) * c2.X
                            + (t * t * t) * p2.X;
                    double y = (-t * t * t + 3 * t * t - 3 * t + 1) * p1.Y
                            + (3 * t * t * t - 6 * t * t + 3 * t) * c1.Y
                            + (-3 * t * t * t + 3 * t * t) * c2.Y
                            + (t * t * t) * p2.Y;
                    e.Graphics.FillRectangle(Brushes.Red, Convert.ToInt32(x), Convert.ToInt32(y), 2, 2); //點出所有計算出的中間點
                }
            }
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (clickcount < 4)
            {
                Control cr = new Control(); //產生一個Control
                Q[clickcount] = new Point(e.X, e.Y);  //存取點擊的位置
                ct[clickcount] = cr;  //存取產生出的Control
                clickcount += 1;  //紀錄點擊次數+1
                this.Controls.Add(cr);  //將Contorl放入From的Controls中
                cr.Location = new Point(e.X - 4, e.Y - 4);  //將Control中心點移置點擊處
                cr.Size = new Size(8, 8);  //設定Contron大小為8x8
                cr.BackColor = Color.Black; //設定Contronu顏色
                cr.MouseDown += Cr_Down;  //設定Contron的MouseDown function
                cr.MouseMove += Cr_Move;  //設定Contron的MouseMove function
                cr.MouseUp += Cr_Up;  //設定Contron的MouseUp function
            }
            if (clickcount == 4)
            {
                this.Refresh(); //當設定完4個點後刷新畫布
            }
        }

        void Cr_Move(object sender, MouseEventArgs e)
        {
            if (mouse == true)  //當滑鼠為點擊狀態時
            {
                Control cr = sender as Control;
                int x = e.Location.X;
                int y = e.Location.Y;
                cr.Location = new Point(cr.Location.X + x, cr.Location.Y + y); //Control的位置隨滑鼠移動
                if (cr == ct[0])
                {
                    Q[0].X = Q[0].X + x;
                    Q[0].Y = Q[0].Y + y;
                    this.Refresh();  //Control移動時刷新
                }
                if (cr == ct[1])
                {
                    Q[1].X = Q[1].X + x;
                    Q[1].Y = Q[1].Y + y;
                    this.Refresh();  //Control移動時刷新
                }
                if (cr == ct[2])
                {
                    Q[2].X = Q[2].X + x;
                    Q[2].Y = Q[2].Y + y;
                    this.Refresh();  //Control移動時刷新
                }
                if (cr == ct[3])
                {
                    Q[3].X = Q[3].X + x;
                    Q[3].Y = Q[3].Y + y;
                    this.Refresh();  //Control移動時刷新
                }
            }
        }
        void Cr_Down(object sender, MouseEventArgs e)
        {
            mouse = true; //將滑鼠狀態設為點擊
        }
        void Cr_Up(object sender, MouseEventArgs e)
        {
            mouse = false;  //將滑鼠狀態設為未點擊
            this.Refresh();  //刷新
        }
    }
}
