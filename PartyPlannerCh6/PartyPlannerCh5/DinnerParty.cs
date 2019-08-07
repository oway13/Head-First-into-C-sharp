using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPlannerCh6
{
    class DinnerParty
    {
        public const int COST_OF_FOOD_PER_PERSON = 25;

        private int numberOfPeople;
        public int NumberOfPeople {
            get
            {
                return numberOfPeople;
            }

            set
            {
                numberOfPeople = value;
                CalculateCostOfDecorations(fancyDecor);
            }
        }

        public decimal CostOfBeveragesPerPerson;
        public decimal CostOfDecorations;
        private bool fancyDecor;

        public DinnerParty(int numberOfPeople, bool healthyOption, bool fancyDecor)
        {
            this.numberOfPeople = numberOfPeople;
            this.fancyDecor = fancyDecor;
            SetHealthyOption(healthyOption);
            CalculateCostOfDecorations(fancyDecor);

        }

        public void SetHealthyOption(bool healthyOption) {
            if (healthyOption)
            {
                CostOfBeveragesPerPerson = 5M;
            }
            else
            {
                CostOfBeveragesPerPerson = 20M;
            }
        }

        public void CalculateCostOfDecorations(bool fancyOption)
        {
            fancyDecor = fancyOption;
            if (fancyOption)
            {
                CostOfDecorations = 15M * NumberOfPeople + 50M;
            }
            else
            {
                CostOfDecorations = 7.5M * NumberOfPeople + 30M;
            }
        }


        public decimal CalculateCost(bool healthyOption)
        {
            decimal totalCost = (CostOfBeveragesPerPerson + COST_OF_FOOD_PER_PERSON) * NumberOfPeople + CostOfDecorations;
            if (healthyOption)
            {
                return totalCost*0.95M;
            }
            else
            {
                return totalCost;
            }
        }
    }
}
