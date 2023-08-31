// Utilisation de la classe Task au lieu de Thread

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
Task<int>[] tabTask = new Task<int>[TAILLE_ECHANTILLON];
for (int i = 0; i < TAILLE_ECHANTILLON; i++)
{
    int copieI = i;    // Pour éviter que la variable i soit modifiée pendant l'exécution de la tâche
    tabTask[copieI] = Task.Run(() => Utilitaires.CalculerFibonnaci(copieI));
}

for (int i=0; i<tabTask.Length; i++)
{
    tabTask[i].Wait();
    tabFibonnaci[i] = tabTask[i].Result;
}
sw.Stop();
Console.WriteLine("Temps de calcul avec des tasks: {0}", sw.ElapsedMilliseconds);
Utilitaires.AfficherNombresFibonnaci(tabFibonnaci);
