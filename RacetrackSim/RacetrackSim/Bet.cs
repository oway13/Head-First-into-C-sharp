using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacetrackSim
{
    class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            return Bettor.Name + " bets " + Amount + " bucks on dog #" + Dog;
        }

        public int PayOut(int Winner)
        {
            if (Dog == Winner) {
                MessageBox.Show(Bettor.Name + " has won " + Amount + " bucks!");
                return Amount;
            }
            else
            {
                MessageBox.Show(Bettor.Name + " has lost " + Amount + " bucks!");
                return -Amount;
            }
        }
    }
}
