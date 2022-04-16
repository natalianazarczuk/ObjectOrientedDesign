using System;
using System.Collections.Generic;
using Task3.Subjects;
using Task3.Vaccines;

namespace Task3
{
    class Program
    {
        public class MediaOutlet
        {
            public void Publish(Iterator iter)
            {
                while (iter.HasMore())
                {
                    var v = iter.GetNext();

                    if (v != null)
                    {
                        Console.WriteLine($"Virus: {v.VirusName}");
                        Console.WriteLine($"DeathRate: {v.DeathRate}");
                        Console.WriteLine($"InfectionRate: {v.InfectionRate}");
                        if (v.Genomes.Count > 0)
                        {
                            Console.WriteLine($"{v.Genomes[0]}");
                        }

                        Console.WriteLine();

                    }
                }
            }
        }

        public class Tester
        {
            public void Test()
            {
                var vaccines = new List<IVaccine>() { new AvadaVaccine(), new Vaccinator3000(), new ReverseVaccine() };

                foreach (var vaccine in vaccines)
                {
                    Console.WriteLine($"Testing {vaccine}");
                    var subjects = new List<ISubject>();
                    int n = 5;
                    for (int i = 0; i < n; i++)
                    {
                        subjects.Add(new Cat($"{i}"));
                        subjects.Add(new Dog($"{i}"));
                        subjects.Add(new Pig($"{i}"));
                    }

                    foreach (var subject in subjects)
                    {
                        subject.Vaccinate(vaccine);
                    }

                    Console.WriteLine();
                    var genomeDatabase = Generators.PrepareGenomes();
                    var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
                    // iteration over SimpleGenomeDatabase using solution from 1)
                    // subjects should be tested here using GetTested function


                    var iterator = new SimpleIterator(simpleDatabase, genomeDatabase);
                    while (iterator.HasMore())
                    {
                        var v = iterator.GetNext();
                        foreach (var subject in subjects)
                        {
                            subject.GetTested(v);
                        }
                    }

                    int aliveCount = 0;
                    foreach (var subject in subjects)
                    {
                        if (subject.Alive) aliveCount++;
                    }
                    Console.WriteLine($"{aliveCount} alive!");
                    Console.WriteLine();

                }
            }
        }
        public static void Main(string[] args)
        {
            var genomeDatabase = Generators.PrepareGenomes();
            var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
            var excellDatabase = Generators.PrepareExcellDatabase(genomeDatabase);
            var overcomplicatedDatabase = Generators.PrepareOvercomplicatedDatabase(genomeDatabase);
            var mediaOutlet = new MediaOutlet();

            //part1
            Console.WriteLine("Iterating over SimpleDatabase: ");
            var simpleIterator = new SimpleIterator(simpleDatabase, genomeDatabase);
            mediaOutlet.Publish(simpleIterator);

            //this doesnt always work and idk why
            Console.WriteLine("Iterating over ExcellDatabase: ");
            var excellIterator = new ExcellIterator(excellDatabase, genomeDatabase);
            mediaOutlet.Publish(excellIterator);

            Console.WriteLine("Iterating over OvercomplicatedDatabase: ");
            var overcomplicatedIterator = new OvercomplicatedIterator(overcomplicatedDatabase, genomeDatabase);
            mediaOutlet.Publish(overcomplicatedIterator);

            //part2
            Console.WriteLine("Filtering DeathRate > 15 of data from the ExcellDatabase database: ");
            Func<VirusData, bool> f = delegate (VirusData v) { return v.DeathRate > 15.0; };
            mediaOutlet.Publish(new FilteringIterator(new ExcellIterator(excellDatabase, genomeDatabase), f));

            Console.WriteLine("Mapping and filtering database DeathRate > 15 simultaneously of data from the ExcellDatabase database: ");
            Func<VirusData, VirusData> m = delegate (VirusData virus) { return new VirusData(virus.VirusName, virus.DeathRate + 10, virus.InfectionRate, virus.Genomes); };
            mediaOutlet.Publish(new MappingIterator(new FilteringIterator(new ExcellIterator(excellDatabase, genomeDatabase), f), m));

            Console.WriteLine("Concatenation of data from the ExcellDatabase database and data from the OvercomplicatedDatabase database: ");
            mediaOutlet.Publish(new ConcatenatingIterator(new ExcellIterator(excellDatabase, genomeDatabase), new OvercomplicatedIterator(overcomplicatedDatabase, genomeDatabase)));



            // testing animals
            var tester = new Tester();
            tester.Test();


        }
    }
}
