using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest
{
    class Ghoul : Enemy
    {
        public Ghoul(Game game, Point location) : base(game, location, 10)
        {
        }

        public override void Move(Random random)
        {
            if (random.Next(2) != 0)
                base.Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);

            if (base.Nearby(game.PlayerLocation, 10) && HitPoints > 0)
                game.HitPlayer(4, random);
        }
    }
}
