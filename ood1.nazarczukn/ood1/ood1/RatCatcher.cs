using System;
using Enemies;

namespace Defenders
{
    class RatCatcher : IDefender
    {
        protected readonly string name;
        private bool hasRat;

        public RatCatcher(string name)
        {
            this.name = name;
            hasRat = false;
        }

        public void Attack(Giant g)
        {

        }

        public void Attack(Ogre o)
        {
            if (hasRat)
            {
                Console.WriteLine($"RatCatcher {name} throws rat's body on Ogre {o.Name}.");
                o.GetDamage(o.HP);
                hasRat = false;
            }
        }

        public void Attack(Rat r)
        {
            if (!hasRat)
            {
                Console.WriteLine($"RatCatcher {name} has body of Rat {r.Name}.");
                r.GetDamage(r.HP);
                hasRat = true;
            }
        }
    } 
}