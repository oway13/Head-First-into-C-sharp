﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest
{
    class Bat : Enemy
    {

        public Bat(Game game, Point location) : base(game, location, 6)
        {
        }

        public override void Move(Random random)
        {
            if(random.Next(1) == 0)
                base.Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            else
                base.Move((Direction)random.Next(4), game.Boundaries);

            if (base.Nearby(game.PlayerLocation, 10) && HitPoints > 0)
                game.HitPlayer(2, random);
        }
    }
}