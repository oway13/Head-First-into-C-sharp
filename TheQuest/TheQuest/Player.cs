using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest
{
    class Player : Mover
    {

        public Player(Game game, Point point) :base(game, point)
        {
            hitPoints = 10;
        }

        private int hitPoints;
        public int HitPoints { get { return hitPoints; } }
        private Weapon equippedWeapon;
        private List<Weapon> inventory = new List<Weapon>();
        public List<String> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                    names.Add(weapon.Name);
                return names;
            }
        }


        public void Equip(string weaponName)
        {
            foreach(Weapon weapon in inventory)
            {
                if (weapon.Name == weaponName)
                    equippedWeapon = weapon;
            }
        }

        public  void Hit(int maxDamage, Random random)
        {
            hitPoints -= random.Next(1, maxDamage);
        }

        internal void IncreaseHealth(int health, Random random)
        {
            hitPoints += random.Next(1, health);
        }


        internal void Attack(Direction direction, Random random)
        {
            throw new NotImplementedException();
        }

        public void Move(Direction direction)
        {
            base.location = Move(direction, game.Boundaries);
            if (!game.WeaponInRoom.PickedUp)
            {
                if(base.Nearby(game.WeaponInRoom.Location, 1))
                {
                    inventory.Add(game.WeaponInRoom);
                    if(inventory.Count == 1)
                        Equip(game.WeaponInRoom.Name);
                }
            }
        }
    }
}
