using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    abstract class Weapon : Mover
    {
        public Weapon(Game game, Point location) : base(game, location)
        {
            pickedUp = false;
        }

        public abstract string Name { get; }
        private bool pickedUp;
        public bool PickedUp { get { return pickedUp; } }

        public void PickUpWeapon() { pickedUp = true; }

        public abstract void Attack(Direction direction, Random random);

        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            Point target = game.PlayerLocation;
            for (int distance = 0; distance < radius; distance++)
            {
                foreach(Enemy enemy in game.Enemies)
                {
                    if(Nearby(enemy.Location, target, radius))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
                target = Move(direction, game.Boundaries);
            }
            return false;
        }

        public bool Nearby(Point locationToCheck, Point target, int distance)
        {
            return (Math.Abs(target.X - locationToCheck.X) < distance &&
                (Math.Abs(target.Y - locationToCheck.Y) < distance));
        }
    }
}
