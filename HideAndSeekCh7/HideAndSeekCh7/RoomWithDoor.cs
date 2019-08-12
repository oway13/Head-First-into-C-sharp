﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeekCh7
{
    class RoomWithDoor : RoomWithHidingPlace, IHasExteriorDoor
    {
        public RoomWithDoor(string name, string Decoration, string HidingPlace, string DoorDescription) : base(name, Decoration, HidingPlace)
        {
            this.doorDescription = DoorDescription;
        }

        private string doorDescription;
        public string DoorDescription
        {
            get { return doorDescription; }
        }

        private Location doorLocation;
        public Location DoorLocation
        {
            get { return doorLocation; }
            set { doorLocation = value; }
        }

        public override string Description
        {
            get
            {
                string description = base.Description;
                description += "There is " + DoorDescription + " that leads to " + DoorLocation.Name + ".";
                return description;
            }
        }
    }
}
