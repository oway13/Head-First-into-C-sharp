﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuysCh7
{
    class FunnyFunny : IClown
    {
        private string funnyThingIHave;
        public string FunnyThingIHave
        {
            get
            {
                return "Honk Honk! I have a " + funnyThingIHave;
            }
        }

        public void Honk()
        {
            MessageBox.Show(FunnyThingIHave);
        }

        public FunnyFunny(string FunnyThing)
        {
            funnyThingIHave = FunnyThing;
        }
    }
}
