using System.Diagnostics;
using M2_ClassesAffaire;

// Programme qui fait des tests de performances sur les classes List et LinkedList
const int NOMBRE_ELEMENTS = 500000; // Le nombre d'éléments à traiter
const int NOMBRE_RECHERCHES = 50000;  // Le nombre d'incices à chercher
List<int> listeTableau = new List<int>(); // La liste implémentée avec un tableau
LinkedList<int> listeChaine = new LinkedList<int>(); // La liste implémentée avec un chaînage
Stopwatch sw = new Stopwatch();  // Pour mesurer le temps des opérations.

// On insère les éléments dans le tableau. Ce tableau sert à faire les insertions.
// Il sera brassé afin de faire les recherches.
int[] tabNombres = new int[NOMBRE_ELEMENTS];
for (int i = 0; i < tabNombres.Length; i++)
{
    tabNombres[i] = i;
}

// Les insertions à la fin
Console.Write("Insertions à la fin dans liste tableau: ");
sw.Start();
foreach (int valeur in tabNombres)
{
    listeTableau.Add(valeur);
}
sw.Stop();
Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");

Console.Write("Insertions à la fin dans liste chaînée: ");
sw.Restart();
foreach (int valeur in tabNombres)
{
    listeChaine.AddLast(valeur);
}
sw.Stop();
Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");

// Les insertions au début
listeTableau.Clear();
listeChaine.Clear();

// Les insertions au début
Console.Write("Insertions au début dans liste tableau: ");
sw.Restart();
foreach (int valeur in tabNombres)
{
    listeTableau.Insert(0, valeur);
}
sw.Stop();
Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");

Console.Write("Insertions au début dans liste chaînée: ");
sw.Restart();
foreach (int valeur in tabNombres)
{
    listeChaine.AddFirst(valeur);
}
sw.Stop();
Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");

// Recherche d'éléments dans les listes.
// On brasse le tableau et on consulte les NOMBRE_RECHERCHES premiers indices.
Utilitaires.BrasserTableau(tabNombres);

Console.Write("Recherches dans la liste tableau: ");
sw.Restart();
for (int i = 0; i<NOMBRE_RECHERCHES; i++)
{
    int valeur = listeTableau.ElementAt(tabNombres[i]);
}
sw.Stop();
Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");

Console.Write("Recherches dans la liste chaînée: ");
sw.Restart();
for (int i = 0; i < NOMBRE_RECHERCHES; i++)
{
    int valeur = listeChaine.ElementAt(tabNombres[i]);
}
sw.Stop();
Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");

// Suppressions d'éléments dans les listes. Les valeurs dans
// le tableau brassé correspondent aux éléments à retirer et non
// l'indice.
Console.Write("Suppressions dans liste tableau: ");
sw.Restart();
for (int i = 0; i < NOMBRE_RECHERCHES; i++)
{
    listeTableau.Remove(tabNombres[i]);
}
sw.Stop();
Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");

Console.Write("Suppressions dans liste chaînée: ");
sw.Restart();
for (int i = 0; i < NOMBRE_RECHERCHES; i++)
{
    listeChaine.Remove(tabNombres[i]);
}
sw.Stop();
Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");
