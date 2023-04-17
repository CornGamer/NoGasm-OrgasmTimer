using System;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            var tmax = (int)numericUpDown1.Value;
            var tmin = (int)numericUpDown2.Value;
            var rmax = (int)numericUpDown3.Value;
            var rmin = (int)numericUpDown4.Value;
            var totalmax = (int)numericUpDown5.Value;
            var totalmin = (int)numericUpDown6.Value;
            var smart = checkBox1.Checked;
            var rand = new Random();
            var randtotaltime = rand.Next(totalmin, totalmax);
            Form play = new Play(randtotaltime, tmax, tmin, rmax, rmin, smart);
            play.ShowDialog();
        }
    }
}
