using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacetrackSim
{
    public partial class Form1 : Form
    {

        Greyhound[] dogs;
        Guy[] guys;
        Random random = new Random();
        int RacetrackLength = 500;

        public Form1()
        {
            InitializeComponent();

            dogs = new Greyhound[4];
            dogs[0] = new Greyhound() { StartingPosition = 1, MyPictureBox = dogPic0, Randomizer = random, RacetrackLength = RacetrackLength };
            dogs[1] = new Greyhound() { StartingPosition = 2, MyPictureBox = dogPic1, Randomizer = random, RacetrackLength = RacetrackLength };
            dogs[2] = new Greyhound() { StartingPosition = 3, MyPictureBox = dogPic2, Randomizer = random, RacetrackLength = RacetrackLength };
            dogs[3] = new Greyhound() { StartingPosition = 4, MyPictureBox = dogPic3, Randomizer = random, RacetrackLength = RacetrackLength };

            guys = new Guy[3];
            guys[0] = new Guy() {Name = "Joe", MyBet = null, Cash = 50, MyLabel = guyLabel0, MyRadioButton = guyRadio0 };
            guys[0].UpdateLabels();
            guys[1] = new Guy() { Name = "Bob", MyBet = null, Cash = 75, MyLabel = guyLabel1, MyRadioButton = guyRadio1 };
            guys[1].UpdateLabels();
            guys[2] = new Guy() { Name = "Al", MyBet = null, Cash = 45, MyLabel = guyLabel2, MyRadioButton = guyRadio2 };
            guys[2].UpdateLabels();

            currentBettorLabel.Text = guys[0].Name;
            minBetLabel.Text = "Minimum Bet: " + betUpDown.Minimum;
        }

        private void betButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                if (guys[i].MyRadioButton.Checked)
                {
                    if (guys[i].PlaceBet((int)betUpDown.Value, (int)dogUpDown.Value))
                    {
                        guys[i].UpdateLabels();
                    }
                    else
                    {
                        MessageBox.Show(guys[0].Name + " does not have enough money for that bet.");
                    }
                    return;
                }
            }
            
        }

        private void AllCheckBoxes_CheckedChanged(Object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                if (guys[i].MyRadioButton.Checked)
                {
                    currentBettorLabel.Text = guys[i].Name;
                    return;
                }
            }
        }

        private void raceButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                if (guys[i].MyBet == null) {
                    MessageBox.Show("Everbody must bet before we start the race!");
                    return;
                }
            }
            panel1.Enabled = false;
            bool done = false;
            int winner = -1;
            while (!done)
            {
                for(int i = 0; i < 4; i++)
                {
                    if (dogs[i].Run())
                    {
                        winner = i;
                        done = true;
                        break;
                    }
                }
            }
            MessageBox.Show("We have a winner - Dog #" + (winner + 1));
            for(int i = 0; i < 3; i++)
            {
                guys[i].Collect(winner);
                guys[i].UpdateLabels();
            }
            for (int i = 0; i < 4; i++)
            {
                dogs[i].TakeStartingPosition();
            }
            panel1.Enabled = true;
        }
    }
}
