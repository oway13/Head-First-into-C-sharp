﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest
{
    class Bow : Weapon
    {
        public Bow(Game game, Point location) : base(game, location)
        {
        }

        public override string Name { get { return "bow"; } }

        public override void Attack(Direction direction, Random random)
        {
            DamageEnemy(direction, MoveInterval*3, 1, random);
        }
    }
}
