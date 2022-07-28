using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();
        int width = 300, height = 200, secHand = 140, minHand = 110, hrHand = 80;
        int cx, cy;
        Bitmap map;
        Graphics g;
        public Form1()
        {
           
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // tao map
            map = new Bitmap(width + 1, height + 1);
            //center
            cx = width / 2;
            cy = height / 2;
            // Mau sac
            this.BackColor = Color.White;
            // thoi gian
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_tick);
            t.Start();
        }
        private void t_tick(object val, EventArgs e) {
            g = Graphics.FromImage(map);
            // hien thi
            int ss = DateTime.Now.Second;
            int mm = DateTime.Now.Minute;
            int HH = DateTime.Now.Hour;
            int[] hanCoord = new int[2];
            // lam sach
            g.Clear(Color.White);
            // vong lap
            g.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, width, height);
            // vong xu li
            g.DrawString("12", new Font("Arial", 12), Brushes.Black, new Point(180, 20));
            hanCoord = mrCoord(ss, secHand);
            g.DrawLine(new Pen(Color.Red, 1f), new Point(cx, cy), new Point(hanCoord[0], hanCoord[1]));
            // phut
            hanCoord = mrCoord(mm, minHand);
            g.DrawLine(new Pen(Color.Black, 2f), new Point(cx, cy), new Point(hanCoord[0], hanCoord[1]));
            // gio
            hanCoord = mrCoord(HH, hrHand);
            g.DrawLine(new Pen(Color.Gray, 3f), new Point(cx, cy), new Point(hanCoord[0], hanCoord[1]));
            // load
            pictureBox1.Image = map;
            // lap
            this.Text = "Analog clock-" + HH + ":" + mm + ":" + ss;
            // 
            g.Dispose();
        }
        // coord for minute ad secendhand
        private int[] mrCoord(int val, int hlen)
        {
            int[] coord = new int[2];
            val *= 6;
            if(val>=0 && val <= 180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI* val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));

            }
            return coord;
        }
        // gio
        private int[] hrCoord(int mval, int hlen, int hval){
            int[] coord = new int[2];
           
            int val = (int)((hval * 30) + (mval * 0.5));
            if (val >= 0 && val <= 180)
            {
                
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                
                coord[0] = cx - (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));

            }
            return coord;
        }
    }
}
