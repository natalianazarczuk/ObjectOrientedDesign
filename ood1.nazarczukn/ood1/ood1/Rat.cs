using System;
using Defenders;

namespace Enemies
{
    class Rat : Enemy
    {
        public int Speed { get; private set; }

        public Rat(string name, int hp, int speed) : base(name, hp)
        {
            Speed = speed;
        }

        public new void GetDamage(int damage)
        {
            base.GetDamage(damage);
            Speed++;
        }
        public override void Accept(IDefender defender)
        {
            defender.Attack(this);
        }
    }
}