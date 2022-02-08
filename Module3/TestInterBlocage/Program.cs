using System;
using System.Threading;

namespace TestInterBlocage
{
    class Program
    {
        static object LOCK1 = new object();
        static object LOCK2 = new object();

        private static  void Afficher1()
        {
            int nombre = 0;
            while (true)
            {
                lock(LOCK1)
                {
                    lock(LOCK2)
                    {
                        Console.WriteLine("Afficher1: {0}", nombre);
                        Thread.Sleep(1000);
                    }
                }
            }
        }

        private static void Afficher2()
        {
            int nombre = 0;
            while (true)
            {
                // Génère un interblocage
                lock (LOCK2)
                {
                    lock (LOCK1)
                    {
                        Console.WriteLine("Afficher2: {0}", nombre);
                        Thread.Sleep(1000);
                    }
                }
            }

        }


        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadStart(Afficher1));
            Thread th2 = new Thread(new ThreadStart(Afficher2));
            th1.Start();
            th2.Start();
        }
    }
}
