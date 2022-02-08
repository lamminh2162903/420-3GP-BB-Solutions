using System;
using System.Threading;

namespace Synchronisation
{
    class Program
    {
        static readonly object LOCK = new Object();

        const int NOMBRE_THREADS = 100;
        const int NOMBRE_BOUCLES = 10000;
        
        static int valeurPartagee = 0;

        public static void IncrementerValeur()
        {
                for (int i = 0; i < NOMBRE_BOUCLES; i++)
                {
                    lock (LOCK)
                    {
                        valeurPartagee = valeurPartagee + 1;
                    }
                }
        }

        static void Main(string[] args)
        {
            Thread[] tabThread = new Thread[NOMBRE_THREADS];

            for (int i=0; i<NOMBRE_THREADS; i++)
            {
                tabThread[i] = new Thread(new ThreadStart(IncrementerValeur));
            }

            foreach (Thread th in tabThread)
            {
                th.Start();
            }

            foreach (Thread th in tabThread)
            {
                th.Join();
            }

            Console.WriteLine("{0} * {1} = {2} .... ben oui !!!", NOMBRE_BOUCLES, NOMBRE_THREADS, valeurPartagee);
        }
    }
}
