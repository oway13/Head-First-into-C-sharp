using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BeehiveSimulator
{
    class Hive
    {
        public Hive()
        {
            
            Honey = InitialHoney;
            InitializeLocations();
            Random random = new Random();
            for (int i = 0; i < InitialBees; i++)
            {
                AddBee(random);
            }
        }

        private const int InitialBees = 6;
        private const double InitialHoney = 3.2;
        private const double MaxHoney = 15;
        private const double NectarToHoney = 0.25;
        private const int MaxBees = 8;
        private const double BirthCost = 4;

        public double Honey { get; private set; }
        private Dictionary<string, Point> locations;
        private int beeCount;

        public void InitializeLocations()
        {
            locations = new Dictionary<string, Point>();
            locations.Add("Entrance", new Point(600, 100));
            locations.Add("Nursery", new Point(95, 174));
            locations.Add("HoneyFactory", new Point(157, 98));
            locations.Add("Exit", new Point(194, 213));
        }

        public bool AddHoney(double Nectar)
        {
            throw new NotImplementedException();
        }

        public bool ConsumeHoney(double amount)
        {
            throw new NotImplementedException();
        }

        public void AddBee(Random random)
        {
            throw new NotImplementedException();
        }

        public void Go(Random random)
        {
            throw new NotImplementedException();
        }

        public Point GetLocation(string location)
        {
            if (locations.ContainsKey(location))
                return locations[location];
            else
                throw new ArgumentException(location + " is not a location within the hive.");


        }


    }
}
