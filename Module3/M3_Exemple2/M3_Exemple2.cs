int NOMBRE_BOUCLES = 1000;
int NOMBRE_THREADS = 10;

Thread[] tabThreads = new Thread[NOMBRE_THREADS];
for (int i = 0; i < tabThreads.Length; i++)
{
    tabThreads[i] = new Thread(new ParameterizedThreadStart(Afficher));
}

for (int i = 0; i < tabThreads.Length; i++)
{
    tabThreads[i].Start(i);
}

foreach (Thread th in tabThreads)
{
    th.Join();
}


void Afficher(object? valeur)
{
    for (int i = 0; i < NOMBRE_BOUCLES; i++)
    {
        Console.WriteLine("Nous sommes dans le thread {0}", valeur);
    }
}
