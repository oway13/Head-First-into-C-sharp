using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HideAndSeekCh7
{
    public partial class Form1 : Form
    {
        RoomWithDoor livingRoom;
        RoomWithDoor kitchen;
        Room diningRoom;
        OutsideWithDoor frontYard;
        Outside garden;
        OutsideWithDoor backYard;

        Location currentLocation;
        public Form1()
        {
            InitializeComponent();
            CreateObjects();

            currentLocation = livingRoom;
            updateForm();
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("living room", "an antique carpet", "an oak door with a brass knob");
            kitchen = new RoomWithDoor("kitchen", "stainless steel appliances", "a screen door");
            diningRoom = new Room("dining room", "a crystal chandelier");

            frontYard = new OutsideWithDoor("front yard", false, "an oak door with a brass knob");
            garden = new Outside("garden", false);
            backYard = new OutsideWithDoor("back yard", true, "a screen door");

            livingRoom.Exits = new Location[] { frontYard, diningRoom };
            livingRoom.DoorLocation = frontYard;

            diningRoom.Exits = new Location[] { livingRoom, kitchen };

            kitchen.Exits = new Location[] { diningRoom, backYard };
            kitchen.DoorLocation = backYard;

            frontYard.Exits = new Location[] { livingRoom, garden };
            frontYard.DoorLocation = livingRoom;

            garden.Exits = new Location[] { frontYard, backYard };

            backYard.Exits = new Location[] { kitchen, garden };
            backYard.DoorLocation = kitchen;
        }

        private void MoveToANewLocation(Location destination)
        {
            currentLocation = destination;
            updateForm();
            
        }

        private void updateForm()
        {
            exits.Items.Clear();

            foreach (Location exit in currentLocation.Exits)
            {
                exits.Items.Add(exit.Name);
            }

            exits.SelectedIndex = 0;
            description.Text = currentLocation.Description;
            goThroughTheDoor.Visible = (currentLocation is IHasExteriorDoor);

        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);
            
        }
    }
}
