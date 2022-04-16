using System;
using Defenders;

namespace Enemies
{
    class Ogre : Enemy
    {
        public int Armor { get; }

        public Ogre(string name, int hp, int armor) : base(name, hp)
        {
            Armor = armor;
        }

        public new void GetDamage(int damage)
        {
            base.GetDamage(damage);
        }
        public override void Accept(IDefender defender)
        {
            defender.Attack(this);
        }
    }
}