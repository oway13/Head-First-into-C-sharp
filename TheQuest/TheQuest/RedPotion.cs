using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest
{
    class RedPotion : Weapon, IPotion
    {
        private Game game;
        private Point point;

        public RedPotion(Game game, Point point)
        {
            this.game = game;
            this.point = point;
        }
    }
}
