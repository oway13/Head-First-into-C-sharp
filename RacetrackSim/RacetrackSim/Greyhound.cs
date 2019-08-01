using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RacetrackSim
{
    class Greyhound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer;

        public bool Run() {
            Location += Randomizer.Next(1, 5);
            Point p = MyPictureBox.Location;
            p.X = Location;
            MyPictureBox.Location = p;
            return Location >= RacetrackLength;
        }

        public void TakeStartingPosition()
        {
            Location = 0;
            Point p = MyPictureBox.Location;
            p.X = 0;
            MyPictureBox.Location = p;
        }
    }
}
