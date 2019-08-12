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
        Room stairs;
        RoomWithHidingPlace upstairsHallway;
        RoomWithHidingPlace masterBedroom;
        RoomWithHidingPlace secondBedroom;
        RoomWithHidingPlace bathroom;

        OutsideWithDoor frontYard;
        OutsideWithHidingPlace garden;
        OutsideWithDoor backYard;
        OutsideWithHidingPlace driveway;

        Location currentLocation;
        Opponent opponent;
        bool hid;
        int Moves;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            Moves = 0;
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("living room", "an antique carpet", "behind the couch", "an oak door with a brass knob");
            kitchen = new RoomWithDoor("kitchen", "stainless steel appliances", "under the table", "a screen door");
            diningRoom = new Room("dining room", "a crystal chandelier");
            stairs = new Room("stairs", "a wooden bannister");
            upstairsHallway = new RoomWithHidingPlace("upstairs hallway", "a picture of a dog", "in the closet");
            masterBedroom = new RoomWithHidingPlace("master bedroom", "a large bed", "under the bed");
            secondBedroom = new RoomWithHidingPlace("second bedroom", "a small bed", "under the bed");
            bathroom = new RoomWithHidingPlace("bathroom", "a sink and toilet", "in the shower");

            frontYard = new OutsideWithDoor("front yard", false, "an oak door with a brass knob");
            garden = new OutsideWithHidingPlace("garden", false, "in the shed");
            backYard = new OutsideWithDoor("back yard", true, "a screen door");
            driveway = new OutsideWithHidingPlace("driveway", false, "in the garage");

            livingRoom.Exits = new Location[] { frontYard, diningRoom, stairs };
            livingRoom.DoorLocation = frontYard;

            diningRoom.Exits = new Location[] { livingRoom, kitchen };

            kitchen.Exits = new Location[] { diningRoom, backYard };
            kitchen.DoorLocation = backYard;

            stairs.Exits = new Location[] { livingRoom, upstairsHallway };

            upstairsHallway.Exits = new Location[] { stairs, masterBedroom, secondBedroom, bathroom };

            masterBedroom.Exits = new Location[] { upstairsHallway };
            secondBedroom.Exits = new Location[] { upstairsHallway };
            bathroom.Exits = new Location[] { upstairsHallway };

            frontYard.Exits = new Location[] { livingRoom, garden, driveway };
            frontYard.DoorLocation = livingRoom;

            garden.Exits = new Location[] { frontYard, backYard };

            backYard.Exits = new Location[] { kitchen, garden, driveway };
            backYard.DoorLocation = kitchen;

            driveway.Exits = new Location[] { frontYard, backYard };

            currentLocation = livingRoom;
            opponent = new Opponent(frontYard);
            hid = false;
            updateForm();
        }

        private void MoveToANewLocation(Location destination)
        {
            currentLocation = destination;
            Moves++;
            updateForm();
            
        }

        private void updateForm()
        {
            description.Text = "";
            if (hid)
            {
                exits.Visible = true;
                goHere.Visible = true;
                exits.Items.Clear();

                foreach (Location exit in currentLocation.Exits)
                {
                    exits.Items.Add(exit.Name);
                }

                exits.SelectedIndex = 0;
                description.Text = currentLocation.Description;

                goThroughTheDoor.Visible = (currentLocation is IHasExteriorDoor);

                if (currentLocation is IHidingPlace)
                {
                    IHidingPlace hasHide = currentLocation as IHidingPlace;
                    check.Visible = true;
                    check.Text = "Check " + hasHide.HidingPlace;
                }
                else
                {
                    check.Visible = false;
                }
                hide.Visible = false;
            }
            else
            {
                hide.Visible = true;
                check.Visible = false;
                exits.Visible = false;
                goHere.Visible = false;
                goThroughTheDoor.Visible = false;
            }
            

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

        private void ResetGame()
        {
            hid = false;
            Moves = 0;
            opponent = new Opponent(frontYard);
            currentLocation = livingRoom;
            updateForm();
        }

        private void check_Click(object sender, EventArgs e)
        {
            if (opponent.Check(currentLocation))
            {
                IHidingPlace hasHide = currentLocation as IHidingPlace;
                MessageBox.Show("You found your opponent in the " + currentLocation.Name + " " + hasHide.HidingPlace+" in " + Moves +" moves!");
                ResetGame();
            }

            else
            {
                description.Text += " Your opponent is not here! ";
                check.Visible = false;
            }
                
        }

        private void hide_Click(object sender, EventArgs e)
        {
            hid = true;
            description.Text = "Hiding\r\n";
            for (int i = 1; i < 11; i++)
            {
                description.Text += i + "...\r\n";
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
                opponent.Move();
            }
            description.Text = "Ready or not, here I come!";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            updateForm();
        }
    }
}
