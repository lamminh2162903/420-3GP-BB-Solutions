// Programme qui illustre un inter-blocage. Il devrait bloquer assez rapidement

using System;
using System.Threading;


object LOCK1 = new object();
object LOCK2 = new object();

Thread th1 = new Thread(new ThreadStart(Afficher1));
Thread th2 = new Thread(new ThreadStart(Afficher2));
th1.Start();
th2.Start();

void Afficher1()
{
    int nombre = 0;
    while (true)
    {
        lock (LOCK1)
        {
            lock (LOCK2)
            {
                Console.WriteLine("Afficher1: {0}", nombre);
                Thread.Sleep(1000);
            }
        }
    }
}

void Afficher2()
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

