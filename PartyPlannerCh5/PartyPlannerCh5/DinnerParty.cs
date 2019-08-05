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
        public bool healthyOption;
        public bool fancyOption;

        public void SetHealthyOption(bool healthyOption) {
            this.healthyOption = healthyOption;
        }

        public void CalculateCostOfDecorations()
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


        public decimal CalculateCost()
        {
            if (healthyOption)
            {
                CostOfBeveragesPerPerson = 5M;
                return ((CostOfBeveragesPerPerson+COST_OF_FOOD_PER_PERSON) * NumberOfPeople + CostOfDecorations)*0.95M;
            }
            else
            {
                CostOfBeveragesPerPerson = 20M;
                return (CostOfBeveragesPerPerson + COST_OF_FOOD_PER_PERSON) * NumberOfPeople + CostOfDecorations;
            }
        }
    }
}
