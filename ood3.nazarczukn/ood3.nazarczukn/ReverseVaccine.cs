using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class ReverseVaccine : IVaccine
    {
        public string Immunity => "ACTGAGACAT";

        public double DeathRate => 0.05f;

        private Random randomElement = new Random(0);
        public override string ToString()
        {
            return "ReverseVaccine";
        }

        //cat: kills the cat
        public void vaccinate(Cat c)
        {
            c.Alive = false;
            Console.WriteLine($"ReverseVaccine killed cat {c.ID}. ");
        }

        //dog: assigns its base immunity to the dog but reversed, never kills it
        public void vaccinate(Dog d)
        {
            char[] arr = Immunity.ToCharArray();
            Array.Reverse(arr);
            d.Immunity += new string(arr);
            Console.WriteLine($"Dog {d.ID} vaccinated. ");
        }

        //pig: assigns the pig the vaccine's base immunity concatenated with its inverse. For example: "CTG" -> "CTG" + "GTC" = "CTGGTC"	
        //The pig dies according to the current chance of death. first time you pass it the chances are 0, then DeathRate, then 2*DeathRate etc.
        public void vaccinate(Pig p)
        {
            var rnd = randomElement.Next(0, 100);
            var deathrate = (p.Reverse == 0) ? 0 : DeathRate * p.Reverse;

            if (rnd > deathrate)
            {
                char[] arr = Immunity.ToCharArray();
                Array.Reverse(arr);
                p.Immunity += Immunity + new string(arr);
                p.Reverse++;
                Console.WriteLine($"Pig {p.ID} vaccinated. ");
            }
            else
            {
                p.Alive = false;
                Console.WriteLine($"ReverseVaccine killed pig {p.ID}. ");
            }
        }
    }
}
