using System;
using System.Windows.Forms;

namespace SimpleStopwatch
{
    public partial class Form1 : Form
    {
        private TimeSpan elapsedTime;
        private DateTime startTime;
        private bool running = false;

        public Form1()
        {
            InitializeComponent();
            labelTime.Text = "00:00:00.000";
            timer1.Interval = 10;
            timer1.Tick += Timer1_Tick;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                startTime = DateTime.Now - elapsedTime;
                timer1.Start();
                running = true;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (running)
            {
                timer1.Stop();
                elapsedTime = DateTime.Now - startTime;
                running = false;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            elapsedTime = TimeSpan.Zero;
            labelTime.Text = "00:00:00.000";
            running = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            elapsedTime = DateTime.Now - startTime;
            labelTime.Text = elapsedTime.ToString(@"hh\:mm\:ss\.fff");
        }
    }
}

