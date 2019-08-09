using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuysCh7
{
    class ScaryScary : FunnyFunny, IScaryClown
    {
        public string ScaryThingIHave
        {
            get
            {
                return "I have " + numberOfScaryThings + " spiders!";
            }
        }

        private int numberOfScaryThings;

        public ScaryScary(string funnyThing, int numberOfScaryThings) : base(funnyThing)
        {
            this.numberOfScaryThings = numberOfScaryThings;
        }

        public void ScareLittleChildren()
        {
            MessageBox.Show("Boo! Gotcha!");
        }
    }
}
