using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardSort
{
    class Card
    {

        public Card(Suits suit, Values value)
        {
            this.suit = suit;
            this.value = value;
        }

        public Suits suit;
        public Values value;
        public string Name
        {
            get
            {
                return value.ToString() + " of " + suit.ToString();
            }
        }
    }
}
