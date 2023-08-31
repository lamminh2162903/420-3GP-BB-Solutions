Thread t = new Thread(new ParameterizedThreadStart(Minuterie));

t.Start(10);
t.Join();
Console.WriteLine("Fin du compte à rebours");

void Minuterie(object? secondes)
{
    int secondes_restantes = (int) secondes;
    while (secondes_restantes > 0)
    {
        Console.WriteLine(secondes_restantes);
        Thread.Sleep(1000);
        secondes_restantes--;
    }
    Console.WriteLine(secondes_restantes);
}
