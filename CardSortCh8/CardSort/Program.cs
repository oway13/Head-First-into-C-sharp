using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardSort
{
    class Program
    {

       


        static void Main(string[] args)
        {
            Random rand = new Random();
            List<Card> cards = new List<Card> {
                new Card((Suits)rand.Next(4), (Values)rand.Next(1, 14)),
                new Card((Suits)rand.Next(4), (Values)rand.Next(1, 14)),
                new Card((Suits)rand.Next(4), (Values)rand.Next(1, 14)),
                new Card((Suits)rand.Next(4), (Values)rand.Next(1, 14)),
                new Card((Suits)rand.Next(4), (Values)rand.Next(1, 14))
            };
            PrintCards(cards);

            CardComparer_byValue valComp = new CardComparer_byValue();
            cards.Sort(valComp);
            PrintCards(cards);

            Console.ReadKey();
        }

        public static void PrintCards(List<Card> cards)
        {
            foreach (Card card in cards)
                Console.WriteLine(card.Name);
            Console.WriteLine("End of cards!\r\n\r\n");
        }
    }
}
