using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeehiveSimulator
{
    public partial class Form1 : Form
    {
        private World world;
        private Random random = new Random();
        private DateTime start = DateTime.Now;
        private DateTime end;
        private int framesRun = 0;

        public Form1()
        {
            InitializeComponent();
            world = new World();

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(RunFrame);
            timer1.Enabled = false;
            UpdateStats(new TimeSpan());
        }

        private void UpdateStats(TimeSpan frameDuration)
        {
            Bees.Text = world.Bees.Count.ToString();
            Flowers.Text = world.Flowers.Count.ToString();
            HoneyInHive.Text = String.Format("{0:f3}", world.Hive.Honey);
            double nectar = 0;
            foreach (Flower flower in world.Flowers)
                nectar += flower.Nectar;
            NectarInFlowers.Text = String.Format("{0:f3}", nectar);
            FramesRun.Text = framesRun.ToString();
            double milliSeconds = frameDuration.TotalMilliseconds;
            if (milliSeconds != 0.0)
                FrameRate.Text = string.Format("{(0:f0)} ({1:f1}ms)", 1000 / milliSeconds, milliSeconds);
            else
                FrameRate.Text = "N/A";
        }

        private void RunFrame(object sender, EventArgs e)
        {
            framesRun++;
            world.Go(random);
            end = DateTime.Now;
            TimeSpan frameDuration = end - start;
            start = end;
            UpdateStats(frameDuration);
        }

        private void startSim_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                startSim.Text = "Resume Simulation";
                timer1.Stop();
            }
            else
            {
                startSim.Text = "Pause Simulation";
                timer1.Start();
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            framesRun = 0;
            world = new World();
            if (!timer1.Enabled)
                startSim.Text = "Start Simulation";
        }
    }
}
