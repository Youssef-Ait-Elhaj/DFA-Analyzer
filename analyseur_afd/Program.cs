using System;

namespace analyseur_afd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrez un nom de fichier: ");
            // string fileName = Console.ReadLine();
            AFD afd = AFD.read("/home/youssef/RiderProjects/analyseur_afd/analyseur_afd/test.txt");
            // AFD.print(afd);
        }
    }
}