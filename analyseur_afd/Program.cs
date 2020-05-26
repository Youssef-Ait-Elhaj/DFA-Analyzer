using System;

namespace analyseur_afd
{
    class Program
    {
        static void Main(string[] args)
        {
            AFD afd = new AFD();
            afd.read("/home/youssef/RiderProjects/analyseur_afd/analyseur_afd/test.txt");
            
        }
    }
}