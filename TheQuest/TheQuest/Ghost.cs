using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest
{
    class Ghost : Enemy
    {
        public Ghost(Game game, Point location) : base(game, location, 8)
        {
        }

        public override void Move(Random random)
        {
            if (random.Next(2) == 0)
                location = base.Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);

            if (base.Nearby(game.PlayerLocation, MoveInterval) && HitPoints > 0)
                game.HitPlayer(3, random);
        }
    }
}
