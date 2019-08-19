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
        public RedPotion(Game game, Point location) : base(game, location)
        {
            used = false;
        }

        public override string Name { get { return "red potion"; } }

        private bool used;
        public bool Used { get { return used; } }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(10, random);
            used = true;
        }
    }
}
