using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BeehiveSimulator
{
    [Serializable]
    public class Flower
    {
        public Flower(Point Location, Random random)
        {
            this.Location = Location;
            Age = 0;
            Alive = true;
            Nectar = InitialNectar;
            NectarHarvested = 0;
            lifespan = random.Next(LifeSpanMin, LifeSpanMax + 1);
        }

        private const int LifeSpanMin = 15000;
        private const int LifeSpanMax = 30000;
        private const double InitialNectar = 1.5;
        private const double MaxNectar = 5.0;
        private const double NectarAddedPerTurn = 0.01;
        private const double NectarGatheredPerTurn = 0.3;


        private int lifespan;
        public Point Location { get; private set; }
        public int Age { get; private set; }
        public bool Alive { get; private set; }
        public double  Nectar{ get; private set; }
        public double NectarHarvested { get; set; }
        
        public double HarvestNectar()
        {
            if(NectarGatheredPerTurn > Nectar)
                return 0;
            else
            {
                Nectar -= NectarGatheredPerTurn;
                NectarHarvested += NectarGatheredPerTurn;
                return NectarGatheredPerTurn;
            }
        }

        public void Go()
        {
            if(++Age > lifespan)
                Alive = false;
            else
            {
                Nectar = Math.Min(MaxNectar, Nectar + NectarAddedPerTurn);
            }
            
        }
    }
}
