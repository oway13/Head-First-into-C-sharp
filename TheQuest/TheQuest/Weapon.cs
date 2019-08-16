using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class Weapon
    {
        public string Name { get; }
        public bool PickedUp { get; internal set; }
        public Point Location { get; }
    }
}
