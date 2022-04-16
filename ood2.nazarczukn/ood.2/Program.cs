using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new DummyDirectory("root");

            var csProjects = new DummyDirectory("CSharpProjects", root);
            var csProject1 = new DummyDirectory("CSharpHelloWorld", csProjects);
            new DummyFile("HelloWorld.cs", "--C-o-n-sol--e-.-W---r-i-teLine-(---\"Hello, World!\");", csProject1);
            var csProject2 = new DummyDirectory("CSharpDE", csProjects);
            new DummyFile("HelloWorld.cs", "Console.WriteL----ine(\"Hallo, Welt!\");", csProject2);

            var pythonProjects = new DummyDirectory("python-projects", root);
            var pythonProject1 = new DummyDirectory("python-hw", pythonProjects);
            var pythonProject1Package = new DummyDirectory("hello_world", pythonProject1);
            new DummyFile("requirements.txt", "pyt---est", pythonProject1);
            new DummyFile("main.py", "prin---t('Hello W--orld!')", pythonProject1Package);

            var rustProjects = new DummyDirectory("rust", root);
            var rustProject1 = new DummyDirectory("hello-rust", rustProjects);
            var rustSrc = new DummyDirectory("src", rustProject1);
            new DummyFile("Cargo.toml", "[pac---kage]\nnam---e = \"hello-rust\"", rustProject1);
            new DummyFile("main.rs", "fn main() { pri--nt-l--n--!(\"Hello, student!\"); }", rustSrc);

            var dir1 = new DummyDirectory("very-important-documents", root);
            var dir2 = new DummyDirectory("homework", dir1);
            var dir3 = new DummyDirectory("DONTENTERHERE", dir2);
            var dir4 = new DummyDirectory("dangerous-zone", dir3);
            new DummyFile("cats.txt.cipher", "#9U9w9W---9-#-B-9G9---A-#-u-H-xuH9", dir4);

            Console.WriteLine("--------BFS--------");
            // 1. Iterate over the dummy filesystem (strating from root) in BFS order
            // For each node please print its name and contents if it's available

            root.alg = "BFS";
            foreach (var node in root)
            {
                Console.WriteLine(node.GetPrintableName());

                var printableContent = node.GetPrintableContent();
                if (printableContent != null)
                {
                    Console.WriteLine($"Content of a file: {printableContent}");
                }
            }

            Console.WriteLine("-----------------");
            Console.WriteLine("--------DFS--------");
            // 2. Iterate over the dummy filesystem (strating from root) in DFS order
            // For each node please print its name and contents if it's available
            root.alg = "DFS";
            foreach (var node in root)
            {
                var decorator = new Transformation1(new Transformation2(new Transformation3(node)));
                Console.WriteLine(decorator.GetPrintableName());

                var printableContent = decorator.GetPrintableContent();
                if (printableContent != null)
                {
                    Console.WriteLine($"Content of a file: \n{printableContent}");
                }
            }

            // Make sure that:
            // 1. Before each name print '|' and N times '-', where N is the depth of the file in the filesystem
            // (number of parents until null is reached)
            // 2. If node is not a directory, apply a transformation to its content which removes all hyphens ('-').
            // 3. If node is not a directory and its name doesn't end with ".cipher", append newline character to
            // its content ('\n').
            // 4. If node's name ends with ".cipher", in addition to all previous transformations, apply two more:
            //      - Reverse its content (character-wise, e.g. "asd" becomes "dsa")
            //      - Subtract 25 from each character in its content (cast char to int), e.g. 'z' - 25 = 'a'
            Console.WriteLine("-------------------");
        }
    }
}
