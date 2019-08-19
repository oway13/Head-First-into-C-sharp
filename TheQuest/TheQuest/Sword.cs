using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest
{
    class Sword : Weapon
    {
        public Sword(Game game, Point location) : base(game, location)
        {
        }

        public override string Name { get { return "sword"; } }

        public override void Attack(Direction direction, Random random)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (DamageEnemy(direction, 10, 3, random))
                        return;
                    else if (DamageEnemy(Direction.Right, 10, 3, random))
                        return;
                    else
                        DamageEnemy(Direction.Left, 10, 3, random);
                    break;
                case Direction.Left:
                    if (DamageEnemy(direction, 10, 3, random))
                        return;
                    else if (DamageEnemy(Direction.Up, 10, 3, random))
                        return;
                    else
                        DamageEnemy(Direction.Down, 10, 3, random);
                    break;
                case Direction.Right:
                    if (DamageEnemy(direction, 10, 3, random))
                        return;
                    else if (DamageEnemy(Direction.Down, 10, 3, random))
                        return;
                    else
                        DamageEnemy(Direction.Up, 10, 3, random);
                    break;
                case Direction.Down:
                    if (DamageEnemy(direction, 10, 3, random))
                        return;
                    else if (DamageEnemy(Direction.Left, 10, 3, random))
                        return;
                    else
                        DamageEnemy(Direction.Right, 10, 3, random);
                    break;
                default:
                    break;
            }
        }
    }
}
