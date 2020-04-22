using System;
using System.IO;
using System.Linq;

namespace Nuotrauku_redagavimas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Nuotrauku redagavimas";
            
            var dir = "";

            while (true)

            {
                Console.WriteLine(@"Iveskite nuotrauku direktorija kaip parodyta pavyzdyje: C:\Users\User1\Nuotraukos");
                Console.WriteLine();
                Console.WriteLine("Rasykite 'STOP' jei norite baigti\n");

                dir = Console.ReadLine();

                Console.WriteLine();

                if (dir.ToLower() == "stop")

                    return;
                try

                {

                    if (Directory.Exists(dir))
                    {
                        Console.WriteLine("Direktorijos informacija");
                        info(dir);
                        Console.WriteLine();
                        Console.WriteLine("Spaudo uždėjimas ");
                        Spaudas(dir);
                        info(dir);
                    }

                    dir = dir == string.Empty ? "Empty value" : dir.Trim();

                }

                catch (Exception e)

                {
                    Console.WriteLine(e);

                    Console.WriteLine("Bandykite per nauja\n");

                }
            }

        }
        private static void info(string directory)

        {

            var dir = new DirectoryInfo(directory);

            Console.WriteLine($"{dir.FullName}\n");

            foreach (var file in dir.GetFiles().Where(file => file.Name.Contains(".jpg")))

            {

                Console.WriteLine($"{file.Name}");

            }

            Console.WriteLine();

            Console.WriteLine($"jpg failu skaičius: {dir.GetFiles().Count(file => file.Name.Contains(".jpg"))}\n");

        }
        private static void Spaudas(string directory)
        {
            var dir = new DirectoryInfo(directory);

            foreach (var file in dir.GetFiles().Where(file => file.Name.Contains(".jpg")))

            {
                try
                {
                    if (file.Name.Contains("Algirdas Stankūnas"))
                        break;
                    var newname = dir + @"\Algirdas Stankūnas " + file.Name;
                    System.IO.File.Move(dir+@"\"+file.Name, newname);
                }
                catch (System.IO.FileNotFoundException e)
                {
                    Console.WriteLine(e);
                }

            }


        }
    }
    
}
