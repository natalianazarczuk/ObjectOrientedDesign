using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class AvadaVaccine : IVaccine
    {
        public string Immunity => "ACTAGAACTAGGAGACCA";

        public double DeathRate => 0.2f;

        private Random randomElement = new Random(0);

        public override string ToString()
        {
            return "AvadaVaccine";
        }

        //cat: dies with probability DeathRate, assigns basic immunity but omits the first 3 nucleotides
        public void vaccinate(Cat c)
        {
            var rnd = randomElement.Next(0, 100);
            if (rnd > DeathRate)
            {
                c.Immunity += Immunity.Substring(3);
                Console.WriteLine($"Cat {c.ID} vaccinated. ");
            }
            else
            {
               c.Alive = false;
                Console.WriteLine($"AvadaVaccine killed cat {c.ID}. ");
            }
        }

        // dog: assigns basic immunity, there is no possibility to kill the dog
        public void vaccinate(Dog d)
        {
            d.Immunity += Immunity;
            Console.WriteLine($"Dog {d.ID} vaccinated. ");
        }

        //pig: kills the pig
        public void vaccinate(Pig p)
        {
            p.Alive = false;
            Console.WriteLine($"AvadaVaccine killed pig {p.ID}. ");
        }
    }
}
