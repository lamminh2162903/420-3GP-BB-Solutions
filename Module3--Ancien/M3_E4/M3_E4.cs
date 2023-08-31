// Programme qui montre qu'un programme peut être accéléré en utilisant plusieurs threads

using System.Diagnostics;
using M3_Fibonacci;

const int TAILLE_ECHANTILLON = 40; // Testez avec les valeurs 30, 20 et 10. 41, 42, 43, etc... juste pour voir l'impact d'un algoritme dont
                                   // la complexité est exponentielle

// Calcul des TAILLE_ECHANTILLON premier nombres de Fibonacci
int[] tabFibonnaci = new int[TAILLE_ECHANTILLON];

Stopwatch sw = new Stopwatch();
// On calcule les nombres de fibonacci sans utiliser de threads
sw.Start();
for (int i = 0; i < TAILLE_ECHANTILLON; i++)
{
    tabFibonnaci[i] = Utilitaires.CalculerFibonnaci(i);
}
sw.Stop();
Console.WriteLine("Temps de calcul sans thread: {0}", sw.ElapsedMilliseconds);
Utilitaires.AfficherNombresFibonnaci(tabFibonnaci);

// On calcule les nombres de fibonacci en utilisant des threads
tabFibonnaci = new int[TAILLE_ECHANTILLON];
sw.Restart();
Thread[] tabThread = new Thread[TAILLE_ECHANTILLON];
for (int i = 0; i < TAILLE_ECHANTILLON; i++)
{
    tabThread[i] = new Thread(new ParameterizedThreadStart(CalculerFibonnaciThread));
    tabThread[i].Start(i);
}

foreach (Thread th in tabThread)
{
    th.Join();
}
sw.Stop();
Console.WriteLine("Temps de calcul avec threads: {0}", sw.ElapsedMilliseconds);
Utilitaires.AfficherNombresFibonnaci(tabFibonnaci);

void CalculerFibonnaciThread(object n)
{
    int nombre = (int)n;
    tabFibonnaci[nombre] = Utilitaires.CalculerFibonnaci(nombre);
}
