using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveManagerCh6
{
    class Bee
    {
        public virtual int ShiftsLeft
        {
            get { return 0; }
        }
        public int weight;

        public Bee(int weight)
        {
            this.weight = weight;
        }

        public virtual double GetHoneyConsumption()
        {
            double honey = 0;
            if (ShiftsLeft == 0)
                honey += 7.5;
            else
                honey += 9 + ShiftsLeft;
            if (weight > 150)
                honey *= 1.35;
            return honey;
        }
    }
}
