// Programme qui compare les différentes structures de données

using System;
using System.Collections.Generic;

const int TAILLE_ECHANTILLON = 125000;  // Le nombre d'éléments

List<int> listeTableau = new List<int>();
LinkedList<int> listeChainee = new LinkedList<int>();
SortedList<int, int> listeTriee = new SortedList<int, int>();
SortedSet<int> arbre = new SortedSet<int>();
HashSet<int> hachage = new HashSet<int>();

int[] tableauValeurs = new int[TAILLE_ECHANTILLON];
for (int i = 0; i < tableauValeurs.Length; i++)
{
    tableauValeurs[i] = i;
}

// On brasse les données avant d'insérer
BrasserTableau(tableauValeurs);
BrasserTableau(tableauValeurs);

InsererArrayList(listeTableau, tableauValeurs);
InsererLinkedList(listeChainee, tableauValeurs);
InsererSortedList(listeTriee, tableauValeurs);
InsererSortedSet(arbre, tableauValeurs);
InsererHashSet(hachage, tableauValeurs);
Console.WriteLine();

// On parcourt les différentes structures 
ParcourirArrayList(listeTableau);
ParcourirLinkedList(listeChainee);
ParcourirSortedList(listeTriee);
ParcourirSortedSet(arbre);
ParcourirHashSet(hachage);
Console.WriteLine();

// On brasse avant de faire les recherches car on ne veut pas le même ordre que l'ordre d'insertion
BrasserTableau(tableauValeurs);
BrasserTableau(tableauValeurs);

ChercherArrayList(listeTableau, tableauValeurs);
ChercherLinkedList(listeChainee, tableauValeurs);
ChercherSortedList(listeTriee, tableauValeurs);
ChercherSortedSet(arbre, tableauValeurs);
ChercherHashSet(hachage, tableauValeurs);
Console.WriteLine();

SupprimerArrayList(listeTableau, tableauValeurs);
SupprimerLinkedList(listeChainee, tableauValeurs);
SupprimerSortedList(listeTriee, tableauValeurs);
SupprimerSortedSet(arbre, tableauValeurs);
SupprimerHashSet(hachage, tableauValeurs);
Console.WriteLine();

void BrasserTableau(int[] tableau)
{
    Random rng = new Random();
    for (int i = 0; i < tableau.Length; i++)
    {
        int candidat = rng.Next(0, tableau.Length);
        int temp = tableau[candidat];
        tableau[candidat] = tableau[i];
        tableau[i] = temp;
    }
}

void InsererArrayList(List<int> liste, int[] tableau)
{
    Console.Write("Insertions dans ArrayList: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    foreach (int valeur in tableau)
    {
        liste.Add(valeur);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void InsererLinkedList(LinkedList<int> liste, int[] tableau)
{
    Console.Write("Insertions dans LinkedList: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    foreach (int valeur in tableau)
    {
        liste.AddLast(valeur);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void InsererSortedList(SortedList<int, int> liste, int[] tableau)
{
    Console.Write("Insertions dans SortedList: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    foreach (int valeur in tableau)
    {
        liste.Add(valeur, valeur);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void InsererSortedSet(SortedSet<int> arbre, int[] tableau)
{
    Console.Write("Insertions dans SortedSet: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    foreach (int valeur in tableau)
    {
        arbre.Add(valeur);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void InsererHashSet(HashSet<int> hachage, int[] tableau)
{
    Console.Write("Insertions dans HashSet: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    foreach (int valeur in tableau)
    {
        hachage.Add(valeur);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void ParcourirArrayList(List<int> liste)
{
    Console.Write("Parcours dans ArrayList: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    foreach (int valeur in liste)
    {
        int v = valeur;
    }


    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void ParcourirLinkedList(LinkedList<int> liste)
{
    Console.Write("Parcours dans LinkedList: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    foreach (int valeur in liste)
    {
        int v = valeur;
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void ParcourirSortedList(SortedList<int, int> liste)
{
    Console.Write("Parcours dans SortedList: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    foreach (int valeur in liste.Keys)
    {
        int v = valeur;
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void ParcourirSortedSet(SortedSet<int> arbre)
{
    Console.Write("Parcours dans SortedSet: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    foreach (int valeur in arbre)
    {
        int v = valeur;
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void ParcourirHashSet(HashSet<int> hachage)
{
    Console.Write("Parcours dans HashSet: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    foreach (int valeur in hachage)
    {
        int v = valeur;
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void ChercherArrayList(List<int> liste, int[] tableau)
{
    Console.Write("Recherches dans ArrayList: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    for (int i = 0; i < 100000; i++)
    {
        bool present = liste.Contains(tableau[i]);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void ChercherLinkedList(LinkedList<int> liste, int[] tableau)
{
    Console.Write("Recherches dans LinkedList: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    for (int i = 0; i < 100000; i++)
    {
        bool present = liste.Contains(tableau[i]);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void ChercherSortedList(SortedList<int, int> liste, int[] tableau)
{
    Console.Write("Recherches dans SortedList: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    for (int i = 0; i < 100000; i++)
    {
        bool present = liste.ContainsKey(tableau[i]);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void ChercherSortedSet(SortedSet<int> arbre, int[] tableau)
{
    Console.Write("Recherches dans SortedSet: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    for (int i = 0; i < 100000; i++)
    {
        bool present = arbre.Contains(tableau[i]);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void ChercherHashSet(HashSet<int> hachage, int[] tableau)
{
    Console.Write("Recherches dans HashSet: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    for (int i = 0; i < 100000; i++)
    {
        bool present = hachage.Contains(tableau[i]);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void SupprimerArrayList(List<int> liste, int[] tableau)
{
    Console.Write("Suppressions dans ArrayList: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    for (int i = 0; i < 50000; i++)
    {
        liste.Remove(tableau[i]);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void SupprimerLinkedList(LinkedList<int> liste, int[] tableau)
{
    Console.Write("Suppressions dans LinkedList: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    for (int i = 0; i < 50000; i++)
    {
        liste.Remove(tableau[i]);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void SupprimerSortedList(SortedList<int, int> liste, int[] tableau)
{
    Console.Write("Suppressions dans SortedList: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    for (int i = 0; i < 50000; i++)
    {
        liste.Remove(tableau[i]);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void SupprimerSortedSet(SortedSet<int> arbre, int[] tableau)
{
    Console.Write("Suppressions dans SortedSet: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    for (int i = 0; i < 50000; i++)
    {
        arbre.Remove(tableau[i]);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void SupprimerHashSet(HashSet<int> hachage, int[] tableau)
{
    Console.Write("Suppressions dans HashSet: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    for (int i = 0; i < 50000; i++)
    {
        hachage.Remove(tableau[i]);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}
