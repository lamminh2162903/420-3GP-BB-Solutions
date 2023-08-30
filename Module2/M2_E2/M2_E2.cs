using System;
using System.Collections.Generic;
using M2_ClassesAffaire;
using System.Diagnostics;

const int TAILLE_ECHANTILLON = 125000;  // Le nombre d'éléments
const int NOMBRE_RECHERCHES = 100000;  // Le nombre de recherches
const int NOMBRE_SUPPRESSIONS = 50000; // Le nombre de suppressions

SortedList<int, int> listeTriee = new SortedList<int, int>();
SortedSet<int> arbre = new SortedSet<int>();

int[] tableauValeurs = new int[TAILLE_ECHANTILLON];
for (int i = 0; i < tableauValeurs.Length; i++)
{
    tableauValeurs[i] = i;
}

// On brasse les données avant d'insérer
Utilitaires.BrasserTableau(tableauValeurs);
Utilitaires.BrasserTableau(tableauValeurs);

InsererSortedList(listeTriee, tableauValeurs);
InsererSortedSet(arbre, tableauValeurs);
Console.WriteLine();

// On parcourt les différentes structures 
ParcourirSortedList(listeTriee);
ParcourirSortedSet(arbre);
Console.WriteLine();

// On brasse avant de faire les recherches car on ne veut pas le même ordre que l'ordre d'insertion
Utilitaires.BrasserTableau(tableauValeurs);
Utilitaires.BrasserTableau(tableauValeurs);

// Recherche dans les listes
ChercherSortedList(listeTriee, tableauValeurs);
ChercherSortedSet(arbre, tableauValeurs);
Console.WriteLine();

// Suppression dans les listes
SupprimerSortedList(listeTriee, tableauValeurs);
SupprimerSortedSet(arbre, tableauValeurs);
Console.WriteLine();


// Insère dans la liste triée
void InsererSortedList(SortedList<int, int> liste, int[] tableau)
{
    Console.Write("Insertions dans SortedList: ");
    Stopwatch sw = new Stopwatch();
    sw.Start();
    foreach (int valeur in tableau)
    {
        liste.Add(valeur, valeur);
    }
    sw.Stop();
    Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");
}

// Insère dans l'arbre binaire de fouille
void InsererSortedSet(SortedSet<int> arbre, int[] tableau)
{
    Console.Write("Insertions dans SortedSet: ");
    Stopwatch sw = new Stopwatch();
    sw.Start(); 
    foreach (int valeur in tableau)
    {
        arbre.Add(valeur);
    }
    sw.Stop();
    Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");
}

//Parcours dans la liste triée
void ParcourirSortedList(SortedList<int, int> liste)
{
    Console.Write("Parcours dans SortedList: ");
    Stopwatch sw = new Stopwatch();
    sw.Start(); 
    foreach (int valeur in liste.Keys)
    {
        int v = valeur;
    }
    sw.Stop();
    Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");
}

//Parcours dans l'arbre binaire de fouille
void ParcourirSortedSet(SortedSet<int> arbre)
{
    Console.Write("Parcours dans SortedSet: ");
    Stopwatch sw = new Stopwatch();
    sw.Start(); 
    foreach (int valeur in arbre)
    {
        int v = valeur;
    }
    sw.Stop();
    Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");
}

//Recherches dans la liste triée
void ChercherSortedList(SortedList<int, int> liste, int[] tableau)
{
    Console.Write("Recherches dans SortedList: ");
    Stopwatch sw = new Stopwatch();
    sw.Start(); 
    for (int i = 0; i < NOMBRE_RECHERCHES; i++)
    {
        bool present = liste.ContainsKey(tableau[i]);
    }
    sw.Stop();
    Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");
}

//Recherches dans l'arbre binaire
void ChercherSortedSet(SortedSet<int> arbre, int[] tableau)
{
    Console.Write("Recherches dans SortedSet: ");
    Stopwatch sw = new Stopwatch();
    sw.Start(); 
    for (int i = 0; i < NOMBRE_RECHERCHES; i++)
    {
        bool present = arbre.Contains(tableau[i]);
    }
    sw.Stop();
    Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");
}

//Suppressions dans la liste triée
void SupprimerSortedList(SortedList<int, int> liste, int[] tableau)
{
    Console.Write("Suppressions dans SortedList: ");
    Stopwatch sw = new Stopwatch();
    sw.Start(); 
    for (int i = 0; i < NOMBRE_SUPPRESSIONS; i++)
    {
        liste.Remove(tableau[i]);
    }
    sw.Stop();
    Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");
}

//Suppressions dans l'arbre binaire de fouille
void SupprimerSortedSet(SortedSet<int> arbre, int[] tableau)
{
    Console.Write("Suppressions dans SortedSet: ");
    Stopwatch sw = new Stopwatch();
    sw.Start(); 
    for (int i = 0; i < NOMBRE_SUPPRESSIONS; i++)
    {
        arbre.Remove(tableau[i]);
    }
    sw.Stop();
    Console.WriteLine($"{sw.ElapsedMilliseconds} millisecondes.");
}
