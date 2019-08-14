using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFishCh8
{
    class Game
    {
        List<Player> players;
        private Dictionary<Values, Player> books;
        private Deck stock;
        private TextBox textBoxOnForm;

        public Game(string playerName, IEnumerable<string> opponentNames, TextBox textBoxOnForm)
        {
            Random random = new Random();
            this.textBoxOnForm = textBoxOnForm;
            players = new List<Player>();
            players.Add(new Player(playerName, random, textBoxOnForm));
            foreach (string player in opponentNames)
                players.Add(new Player(player, random, textBoxOnForm));
            books = new Dictionary<Values, Player>();
            stock = new Deck();
            Deal();
            players[0].SortHand();
        }

        private void Deal()
        {
            stock.Shuffle();
            foreach (Player player in players)
            {
                for(int i = 0; i < 5; i++)
                {
                    player.TakeCard(stock.Deal());
                }
                player.PullOutBooks();
            }
        }

        public bool PlayOneRound(int selectedPlayerCard)
        {
            Values playerVal = players[0].Peek(selectedPlayerCard).value;

            for (int i = 0; i < players.Count; i++)
            {
                if (i == 0)
                    players[0].AskForACard(players, 0, stock, playerVal);
                else
                    players[i].AskForACard(players, i, stock);
                if(PullOutBooks(players[i]))
                {
                    textBoxOnForm.Text += players[i].Name + " drew a new hand" + Environment.NewLine;
                    int card = 1;
                    while (card <= 5 && stock.Count > 0)
                    {
                        players[i].TakeCard(stock.Deal());
                        card++;
                    }
                }
                players[0].SortHand();
                if (stock.Count == 0)
                {
                    textBoxOnForm.Text = "The stock is out of cards. Game over!" + Environment.NewLine;
                    return true;
                }
            }
            return false;
        }

        public bool PullOutBooks(Player player)
        {
            List<Values> booksPulled = (List<Values>)player.PullOutBooks();
            foreach(Values bookValue in booksPulled)
            {
                books.Add(bookValue, player);
            }

            if (player.CardCount == 0)
                return true;
            return false;
        }

        public string DescribeBooks()
        {
            string returnString = "";
            foreach (KeyValuePair<Values, Player> entry in books)
                returnString += entry.Value.Name + " has a book of " + Card.Plural(entry.Key) + Environment.NewLine;
            return returnString;
        }

        public string GetWinnerName()
        {
            Dictionary<string, int> scores = new Dictionary<string, int>();
            foreach(Player player in players)
            {
                scores.Add(player.Name, 0);
            }
            foreach (Values value in books.Keys)
            {
                scores[books[value].Name]++;
            }

            int highScore = scores.Values.Max();
            List<string> winners = new List<string>();
            foreach (string playerName in scores.Keys)
            {
                if (scores[playerName] == highScore)
                    winners.Add(playerName);
            }
            if (winners.Count == 1)
            {
                return winners[0] + " with " + scores[winners[0]] + " books." + Environment.NewLine;
            }
            else
            {
                string returnString = "A tie between ";
                for(int i = 0; i < winners.Count; i++)
                {
                    returnString += winners[i] + " and ";
                }
                returnString = returnString.Substring(0, returnString.Length - 5);
                returnString += " with " + scores[winners[0]] + " books" + Environment.NewLine;
                return returnString;
            }
        }

        public IEnumerable<string> GetPlayerCardNames()
        {
            return players[0].GetCardNames();
        }

        public string DescribePlayerHands()
        {
            string description = "";
            for (int i = 0; i < players.Count; i++)
            {
                description += players[i].Name + " has " +players[i].CardCount;
                if (players[i].CardCount == 1)
                    description += " card." +Environment.NewLine;
                else
                    description += " cards." +Environment.NewLine; }
            description += "The stock has " +stock.Count + " cards left.";
            return description;
        }
    }
}

