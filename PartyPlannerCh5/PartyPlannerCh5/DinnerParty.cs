using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPlannerCh5
{
    class DinnerParty
    {
        public const int COST_OF_FOOD_PER_PERSON = 25;

        public int NumberOfPeople;
        public decimal CostOfBeveragesPerPerson;
        public decimal CostOfDecorations;

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
