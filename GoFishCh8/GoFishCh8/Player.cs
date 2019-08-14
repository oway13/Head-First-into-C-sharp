using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFishCh8
{
    class Player
    {
        private string name;
        public string Name { get { return name; } }
        private Random random;
        private Deck cards;
        private TextBox textBoxOnForm;

        public Player(String name, Random random, TextBox textBoxOnForm)
        {
            this.name = name;
            this.random = random;
            this.textBoxOnForm = textBoxOnForm;
            this.cards = new Deck(new List<Card>());

            textBoxOnForm.Text += name + " has just joined the game" + Environment.NewLine;
        }

        public IEnumerable<Values> PullOutBooks()
        {
            List<Values> books = new List<Values>();
            for (int i = 1; i <= 13; i++)
            {
                Values value = (Values)i;
                int howMany = 0;
                for (int card = 0; card < cards.Count; card++)
                    if (cards.Peek(card).value == value)
                        howMany++;
                if (howMany == 4)
                {
                    books.Add(value);
                    cards.PullOutValues(value);
                }
            }
            return books;
        }

        public Values GetRandomValue()
        {
            int CardToGetValue = random.Next(cards.Count);
            return cards.Peek(CardToGetValue).value;
        }

        public Deck DoYouHaveAny(Values value)
        {
            Deck cardsIHave = cards.PullOutValues(value);
            textBoxOnForm.Text += Name + " has " + cardsIHave.Count + " "
                   + Card.Plural(value) + Environment.NewLine;
            return cardsIHave;
        }

        public void AskForACard(List<Player> players, int myIndex, Deck stock, Values value)
        {
            textBoxOnForm.Text += Name + " ask if anyone has any " + Card.Plural(value) + Environment.NewLine;
            int howMany = 0;
            Deck playerDeck;
            for(int i = 0; i < players.Count; i++)
            {
                if(i != myIndex)
                {
                    playerDeck = players[i].DoYouHaveAny(value);
                    howMany += playerDeck.Count;
                    while (playerDeck.Count > 0)
                    {
                        cards.Add(playerDeck.Deal());
                    }
                }
                
            }
            if (howMany == 1)
                textBoxOnForm.Text += Name + " was given " + howMany + " " + value.ToString() + Environment.NewLine;
            else
                textBoxOnForm.Text += Name + " was given " + howMany + " " + Card.Plural(value) + Environment.NewLine;
            if (howMany == 0)
            {
                cards.Add(stock.Deal());
                textBoxOnForm.Text += Name + " had to draw from the stock" + Environment.NewLine;
            }
        }

        public void AskForACard(List<Player> players, int myIndex, Deck Stock)
        {
            AskForACard(players, myIndex, Stock, GetRandomValue());
        }

        public int CardCount { get { return cards.Count; } }
        public void TakeCard(Card card) { cards.Add(card); }
        public IEnumerable<string> GetCardNames() { return cards.GetCardNames(); }
        public Card Peek(int cardNumber) { return cards.Peek(cardNumber); }
        public void SortHand() { cards.SortByValue(); }
    }
}
