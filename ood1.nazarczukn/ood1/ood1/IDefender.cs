using System;
using Enemies;

namespace Defenders
{
    interface IDefender
    {
        // public void Attack(Enemy e);
        public void Attack(Giant g);
        public void Attack(Ogre o);
        public void Attack(Rat r);
    }
   
    //defender is visitor, enemy is element
}