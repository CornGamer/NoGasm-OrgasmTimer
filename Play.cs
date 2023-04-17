using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Game
{

    public partial class Play : Form
    {
        int time1; int tmax1; int tmin1; int rmax1; int rmin1;bool smart1;int count=5;
        public Play(int time, int tmax, int tmin, int rmax, int rmin, bool smart)
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            time1 = time * 1000; tmax1 = tmax * 1000; tmin1 = tmin * 1000; rmax1 = rmax * 1000; rmin1 = rmin * 1000;smart1 = smart;
        }

        private void Play_Load(object sender, EventArgs e)
        {
            stt(time1, tmax1, tmin1, rmax1, rmin1);
        }
        void stt(int time, int tmax, int tmin, int rmax, int rmin)
        {
       //     if (smart1)
            {
              //  var thd5 = new Thread(thdr5);thd5.Start();
            }
            var thd = new Thread(thdr);
            thd.Start();


        }

        void thdr5()
        {
            int Totaltime = time1 * 60;
            label1.Text = "Totaltime=" + (Totaltime / 1000 / 60).ToString() + "min";
            var flag = 1;
            //var timer = new Timer();
            while (count > 0)
            {
                var rand = new Random();count--;
                if (flag == 1)
                {
                    label2.Visible = true; label3.Visible = false;
                    label4.Visible = true; label5.Visible = false;
                    label6.Visible = true;
                    var randgreen = rand.Next(10, 16);
                    label4.Text = (randgreen / 1000).ToString();
                    rb();
                    flag = 0;
                    System.Threading.Thread.Sleep(randgreen);

                }
                else
                {
                    label2.Visible = false; label3.Visible = true;
                    label4.Visible = false; label5.Visible = true;
                    label6.Visible = false;
                    var randred = rand.Next(2, 6);
                    label5.Text = (randred / 1000).ToString();
                    flag = 1;
                    System.Threading.Thread.Sleep(randred);
                }
            }
            label7.Visible = false;
        }
        void thdr()
        {
            int Totaltime = time1 * 60;
            label1.Text = "Totaltime=" + (Totaltime / 1000 / 60).ToString() + "min";
            var flag = 1;
            //var timer = new Timer();
            while (Totaltime > 0)
            {
                var rand = new Random();
                if (flag == 1)
                {
                    label2.Visible = true; label3.Visible = false;
                    label4.Visible = true; label5.Visible = false;
                    label6.Visible = true;
                    var randgreen = rand.Next(tmin1, tmax1);
                    Totaltime -= randgreen;
                    label4.Text = (randgreen / 1000).ToString();
                    rb();
                    flag = 0;
                    System.Threading.Thread.Sleep(randgreen);

                }
                else
                {
                    label2.Visible = false; label3.Visible = true;
                    label4.Visible = false; label5.Visible = true;
                    label6.Visible = false;
                    var randred = rand.Next(rmin1, rmax1);
                    Totaltime -= randred;
                    label5.Text = (randred / 1000).ToString();
                    flag = 1;
                    System.Threading.Thread.Sleep(randred);
                }
            }
        }
        void rb()
        {
            var rd = new Random();
            var rd1 = rd.Next(1, 4);
            switch (rd1)
            {
                case 1: radioB1.Checked = true;
                    radioB1.Visible = true; radioB2.Visible = false; radioB3.Visible = false;
                    return;
                case 2: radioB2.Checked = true;
                    radioB1.Visible = false; radioB2.Visible = true; radioB3.Visible = false;
                    return;
                case 3: radioB3.Checked = true;
                    radioB1.Visible = false; radioB2.Visible = false; radioB3.Visible = true;
                    return;
            }
        }

        private void Play_Deactivate(object sender, EventArgs e)
        {
            Application.ExitThread();
            this.Close();
            System.Environment.Exit(0);
        }
    }
}
