using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("t");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // timer1.Start();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += time_elapsed;
            timer.Start();
        }

        private void time_elapsed(object sender, ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                label1.Text = DateTime.Now.ToString("T");
            }));
        }
    }
}
