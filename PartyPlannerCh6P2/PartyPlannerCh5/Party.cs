using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPlannerCh6
{
    class Party
    {
        public const int CostOfFoodPerPerson = 25;
        private int numberOfPeople;
        public virtual int NumberOfPeople
        {
            get
            {
                return numberOfPeople;
            }

            set
            {
                numberOfPeople = value;
                CalculateCostOfDecorations(fancyDecorations);
            }
        }
        public decimal CostOfDecorations = 0;
        private bool fancyDecorations;
        public void CalculateCostOfDecorations(bool fancyOption)
        {
            fancyDecorations = fancyOption;
            if (fancyOption)
                CostOfDecorations = 15M * NumberOfPeople + 50M;
            else
                CostOfDecorations = 7.5M * NumberOfPeople + 30M;
        }

        public Party(int numberOfPeople, bool fancyDecorations)
        {
            this.numberOfPeople = numberOfPeople;
            this.fancyDecorations = fancyDecorations;
            CalculateCostOfDecorations(fancyDecorations);
        }

        public virtual decimal CalculateCost()
        {
            decimal TotalCost = CostOfDecorations + (CostOfFoodPerPerson * NumberOfPeople);
            if (numberOfPeople >= 12)
                TotalCost += 100M;
        
            return TotalCost;
        }
    }
}
