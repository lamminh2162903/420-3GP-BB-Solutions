int NOMBRE_BOUCLES = 10;
int NOMBRE_THREADS = 10;

Thread[] tabThreads = new Thread[NOMBRE_THREADS];
for (int i = 0; i < tabThreads.Length; i++)
{
    tabThreads[i] = new Thread(new ThreadStart(Afficher));
}

foreach (Thread th in tabThreads)
{
    th.Start();
}

foreach (Thread th in tabThreads)
{
    th.Join();
}

void Afficher()
{
    for (int i = 0; i < NOMBRE_BOUCLES; i++)
    {
        Console.WriteLine("Nous sommes dans un thread");
    }
}
