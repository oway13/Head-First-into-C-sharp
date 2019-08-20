using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckSaveCh9
{
    [Serializable]
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

        public static string Plural(Values value)
        {
            if (value == Values.Six)
                return "Sixes";        
            else            
                return value.ToString() + "s";
        }
    }
}
