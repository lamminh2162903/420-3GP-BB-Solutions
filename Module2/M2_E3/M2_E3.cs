using System;
using System.Diagnostics;
using System.Collections.Generic;
using M2_ClassesAffaire;

const int NOMBRE_LIVRES = 40000;


Livre[] tableauLivres = new Livre[NOMBRE_LIVRES];   // Les livres aléatoires
SortedSet<Livre> arbreLivres = new SortedSet<Livre>(); // l'arbre binaire de fouille
HashSet<Livre> hashLivres = new HashSet<Livre>();  // la table de hachage
Dictionary<string, Livre> dicLivres = new Dictionary<string, Livre>();  // le dictionnaire


CreerLivres(tableauLivres);

InsererDansArbre(arbreLivres, tableauLivres);
InsererDansTable(hashLivres, tableauLivres);
InsererDansDictionnaire(dicLivres, tableauLivres);

ChercherDansArbre(arbreLivres, tableauLivres);
ChercherDansTable(hashLivres, tableauLivres);
ChercherDansDictionnaire(dicLivres, tableauLivres);


// Création des livres
void CreerLivres(Livre[] tab)
{
    GenerateurLivre generateur = new GenerateurLivre();
    for (int i = 0; i < NOMBRE_LIVRES; i++)
    {
        tab[i] = generateur.CreerNouveauLivre();
    }
}

//Insertion dans arbre
void InsererDansArbre(SortedSet<Livre> arbreLivres, Livre[] tableauLivres)
{
    Console.Write("Insertions dans SortedSet: ");
    Stopwatch sw = new Stopwatch();
    sw.Start();
    foreach (Livre unLivre in tableauLivres)
    {
        arbreLivres.Add(unLivre);
    }
    sw.Stop();
    Console.WriteLine($" {sw.ElapsedMilliseconds} millisecondes.");
}

//Insertion dans table de hachage
void InsererDansTable(HashSet<Livre> hashLivres, Livre[] tableauLivres)
{
    Console.Write("Insertions dans HashSet: ");
    Stopwatch sw = new Stopwatch();
    sw.Start();
    foreach (Livre unLivre in tableauLivres)
    {
        hashLivres.Add(unLivre);
    }
    sw.Stop();
    Console.WriteLine($" {sw.ElapsedMilliseconds} millisecondes.");
}

// Insertion dans dictionnaire
void InsererDansDictionnaire(Dictionary<string, Livre> dicLivres, Livre[] tableauLivres)
{
    Console.Write("Insertions dans Dictionnary: ");
    Stopwatch sw = new Stopwatch();
    sw.Start();
    foreach (Livre unLivre in tableauLivres)
    {
        string cle = unLivre.Cle;
        dicLivres[cle] = unLivre;
    }
    sw.Stop();
    Console.WriteLine($" {sw.ElapsedMilliseconds} millisecondes.");
}

// Recherche dans arbre
void ChercherDansArbre(SortedSet<Livre> arbreLivres, Livre[] tableauLivres)
{
    Console.Write("Recherches dans SortedSet: ");
    Stopwatch sw = new Stopwatch();
    sw.Start();
    foreach (Livre unLivre in tableauLivres)
    {
        bool present = arbreLivres.Contains(unLivre);
        if (!present)
        {
            Console.WriteLine("Livre absent: " + unLivre.ToString());
        }
    }
    sw.Stop();
    Console.WriteLine($" {sw.ElapsedMilliseconds} millisecondes.");
}

// Recherches dans table de hachage
void ChercherDansTable(HashSet<Livre> hashLivres, Livre[] tableauLivres)
{
    Console.Write("Recherches dans table de hachage: ");
    Stopwatch sw = new Stopwatch();
    sw.Start();
    foreach (Livre unLivre in tableauLivres)
    {
        bool present = hashLivres.Contains(unLivre);
        if (!present)
        {
            Console.WriteLine("Livre absent: " + unLivre.ToString());
        }
    }
    sw.Stop();
    Console.WriteLine($" {sw.ElapsedMilliseconds} millisecondes.");
}

// Recherche dans dictionnaire
void ChercherDansDictionnaire(Dictionary<string, Livre> dicLivres, Livre[] tableauLivres)
{
    Console.Write("Recherches dans Dictionnary: ");
    Stopwatch sw = new Stopwatch();
    sw.Start();
    foreach (Livre unLivre in tableauLivres)
    {
        string cle = unLivre.Cle;
        bool present = dicLivres.ContainsKey(cle);
        if (present)
        {
            Livre leLivre = dicLivres[cle];
        }
        else
        {
            Console.WriteLine("Livre absent: " + unLivre.ToString());
        }
    }
    sw.Stop();
    Console.WriteLine($" {sw.ElapsedMilliseconds} millisecondes.");
}
