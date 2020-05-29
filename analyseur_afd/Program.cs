using System;

namespace analyseur_afd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrez le nom de fichier:");
            string fileName = Console.ReadLine();
            string path = "/home/youssef/RiderProjects/analyseur_afd/analyseur_afd/" + fileName;
            AFD afd = AFD.read(path);
            AFD.print(afd);
            Console.WriteLine("Entrez un mot:");
            string w = Console.ReadLine();
            if (AFD.accept(afd, w))
                Console.WriteLine("Le mot {0} est accepté par la language de l'automate!", w);
            else
                Console.WriteLine("Le mot {0} n'est pas accepté par la language de l'automate!", w);
        }
    }
}