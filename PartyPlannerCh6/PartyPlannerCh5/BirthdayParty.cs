using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PartyPlannerCh6
{
    class BirthdayParty
    {
        public const int CostOfFoodPerPerson = 25;
        public decimal CostOfDecorations = 0;
        
        public int CakeSize;

        private bool fancyDecorations;
        private string cakeWriting = "";
        private int numberOfPeople;

        public BirthdayParty(int numberOfPeople, bool fancyDecorations, string cakeWriting)
        {
            this.numberOfPeople = numberOfPeople;
            this.fancyDecorations = fancyDecorations;
            CalculateCakeSize();
            this.CakeWriting = cakeWriting;
            CalculateCostOfDecorations(fancyDecorations);
        }

        public void CalculateCostOfDecorations(bool fancyOption)
        {
            fancyDecorations = fancyOption;
            if (fancyOption)
                CostOfDecorations = 15M * NumberOfPeople + 50M;
            else
                CostOfDecorations = 7.5M * NumberOfPeople + 30M;
        }

        private void CalculateCakeSize()
        {
            if (NumberOfPeople <= 4)
                CakeSize = 8;
            else
                CakeSize = 16;
        }

        
        public int NumberOfPeople
        {
            get
            {
                return numberOfPeople;
            }

            set
            {
                numberOfPeople = value;
                CalculateCostOfDecorations(fancyDecorations);
                CalculateCakeSize();
                this.CakeWriting = cakeWriting;
            }
        }

        
        public string CakeWriting
        {
            get
            {
                return this.cakeWriting;
            }
            set
            {
                int maxLength;
                if (CakeSize == 8)
                    maxLength = 16;
                else
                    maxLength = 40;
                if (value.Length > maxLength)
                {
                    MessageBox.Show("Too many letters for a " +CakeSize + " inch cake") ;
                    if (maxLength > this.cakeWriting.Length)
                        maxLength = this.cakeWriting.Length;
                    this.cakeWriting = cakeWriting.Substring(0, maxLength);
                }
                else
                    this.cakeWriting = value;
            }
        }

        public decimal CalculateCost()
        {
            decimal TotalCost = CostOfDecorations + (CostOfFoodPerPerson * NumberOfPeople);
            decimal CakeCost;

            if (CakeSize == 8)
                CakeCost = 40M + CakeWriting.Length * .25M;
            else
                CakeCost = 75M + CakeWriting.Length * .25M;
            return TotalCost + CakeCost;
        }
    }
}
