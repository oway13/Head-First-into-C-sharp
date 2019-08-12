using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HideAndSeekCh7
{
    class Opponent
    {
        public Opponent(Location startingLocation)
        {
            myLocation = startingLocation;
            random = new Random();
        }

        private Location myLocation;
        private Random random;

        public void Move()
        {
            if (myLocation is IHasExteriorDoor)
            {
                if (random.Next(2) == 1)
                {
                    IHasExteriorDoor hasDoor = myLocation as IHasExteriorDoor;
                    myLocation = hasDoor.DoorLocation;
                }
            }
            do
            {
                myLocation = myLocation.Exits[random.Next(myLocation.Exits.Length)];
            } while (!(myLocation is IHidingPlace));
            MessageBox.Show(myLocation.Name);
        }

        public bool Check(Location checkedPlace)
        {
            return checkedPlace == myLocation;
        }
    }
}
