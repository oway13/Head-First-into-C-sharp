using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacetrackSim
{
    class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            MyRadioButton.Text = Name + " has " + Cash + " bucks";
            if(MyBet == null)
            {
                MyLabel.Text = Name + "'s Bet";
            }
            else
            {
                MyLabel.Text = MyBet.GetDescription();
            }
            
        }

        public void ClearBet()
        {
            MyBet = null;
        }

        public bool PlaceBet(int Amount, int Dog)
        {
            if (Amount > Cash) return false;
            MyBet = new Bet() { Amount = Amount, Dog = Dog, Bettor = this };
            return true;
        }

        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
            ClearBet();
        }

    }
}
