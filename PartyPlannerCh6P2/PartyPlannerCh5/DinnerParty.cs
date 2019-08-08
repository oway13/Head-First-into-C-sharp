using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPlannerCh6
{
    class DinnerParty : Party
    {

        public decimal CostOfBeveragesPerPerson;

        public DinnerParty(int numberOfPeople, bool fancyDecorations, bool healthyOption) : base(numberOfPeople, fancyDecorations)
        {
            SetHealthyOption(healthyOption);
            CalculateCostOfDecorations(fancyDecorations);
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



        public decimal CalculateCost(bool healthyOption)
        {
            decimal totalCost = base.CalculateCost();
            if (healthyOption)
                return totalCost*0.95M;
            else
                return totalCost;
        }
    }
}
