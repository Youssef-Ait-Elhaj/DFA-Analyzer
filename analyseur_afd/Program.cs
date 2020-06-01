using System;
using System.IO;

namespace analyseur_afd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrez le nom de fichier:");
            string path = Console.ReadLine(); // Absolute path should be given
            AFD afd = AFD.read(path);
            AFD.print(afd);
            string mot;
            do{
                Console.WriteLine("Entrez un mot:");
                mot = Console.ReadLine();
                Console.WriteLine(
                    AFD.accept(afd, mot)
                        ? "Le mot {0} est accepté par la language de l'automate!"
                        : "Le mot {0} n'est pas accepté par la language de l'automate!", mot);
            } while (true); // loop thru the accept function | CTRL+C to exit
        }
    }
}