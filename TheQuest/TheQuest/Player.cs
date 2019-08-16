using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest
{
    class Player
    {
        private Game game;
        private Point point;

        public Player(Game game, Point point)
        {
            this.game = game;
            this.point = point;
        }

        public List<String> Weapons { get; internal set; }
        public int HitPoints { get; internal set; }
        public Point Location { get; internal set; }

        public void Equip(string weaponName)
        {
            throw new NotImplementedException();
        }

        public void Move(Direction direction)
        {
            throw new NotImplementedException();
        }

        public  void Hit(int maxDamage, Random random)
        {
            throw new NotImplementedException();
        }

        internal void IncreaseHealth(int health, Random random)
        {
            throw new NotImplementedException();
        }

        internal void Attack(Direction direction, Random random)
        {
            throw new NotImplementedException();
        }
    }
}
