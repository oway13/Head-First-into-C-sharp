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

                while (PullOutbooks(players[0]))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (stock.Peek(0) != null)
                            players[0].TakeCard(stock.Deal());
                        else
                        {
                            PullOutbooks(players[0]);
                            return true;
                        }
                    }
                }
            }
            //TODO
            return false;
        }

        public bool PullOutbooks(Player player)
        {
            player.PullOutBooks();
            if (player.CardCount == 0)
                return true;
            return false;
        }
    }
}

//new List<Player> { players[], players[] }
