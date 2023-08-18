using System;
using System.Collections.Generic;
using M2_ClassesAffaire;
using M2_E5;

const int NOMBRE_LIVRES = 40000;


Livre[] tableauLivres = new Livre[NOMBRE_LIVRES];

CreerLivres(tableauLivres);

SortedSet<Livre> arbreLivres = new SortedSet<Livre>();
HashSet<Livre> hashLivres = new HashSet<Livre>();
Dictionary<string, Livre> dicLivres = new Dictionary<string, Livre>();

InsererDansArbre(arbreLivres, tableauLivres);
InsererDansTable(hashLivres, tableauLivres);
InsererDansDictionnaire(dicLivres, tableauLivres);

ChercherDansArbre(arbreLivres, tableauLivres);
ChercherDansTable(hashLivres, tableauLivres);
ChercherDansDictionnaire(dicLivres, tableauLivres);


void CreerLivres(Livre[] tab)
{
    GenerateurLivre generateur = new GenerateurLivre();
    for (int i = 0; i < NOMBRE_LIVRES; i++)
    {
        tab[i] = generateur.CreerNouveauLivre();
    }
}

void InsererDansArbre(SortedSet<Livre> arbreLivres, Livre[] tableauLivres)
{
    Console.Write("Insertions dans SortedSet: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    foreach (Livre unLivre in tableauLivres)
    {
        arbreLivres.Add(unLivre);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void InsererDansTable(HashSet<Livre> hashLivres, Livre[] tableauLivres)
{
    Console.Write("Insertions dans HashSet: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    foreach (Livre unLivre in tableauLivres)
    {
        hashLivres.Add(unLivre);
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void InsererDansDictionnaire(Dictionary<string, Livre> dicLivres, Livre[] tableauLivres)
{
    Console.Write("Insertions dans Dictionnary: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    foreach (Livre unLivre in tableauLivres)
    {
        string cle = unLivre.Cle;
        dicLivres[cle] = unLivre;
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void ChercherDansArbre(SortedSet<Livre> arbreLivres, Livre[] tableauLivres)
{
    Console.Write("Recherches dans SortedSet: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    foreach (Livre unLivre in tableauLivres)
    {
        bool present = arbreLivres.Contains(unLivre);
        if (!present)
        {
            Console.WriteLine("Livre absent: " + unLivre.ToString());
        }
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void ChercherDansTable(HashSet<Livre> hashLivres, Livre[] tableauLivres)
{
    Console.Write("Recherches dans HashSet: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    foreach (Livre unLivre in tableauLivres)
    {
        bool present = hashLivres.Contains(unLivre);
        if (!present)
        {
            Console.WriteLine("Livre absent: " + unLivre.ToString());
        }
    }

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}

void ChercherDansDictionnaire(Dictionary<string, Livre> dicLivres, Livre[] tableauLivres)
{
    Console.Write("Recherches dans Dictionnary: ");
    long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

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

    long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    long tempsOperation = apres - avant;
    Console.WriteLine(tempsOperation + " millisecondes.");
}
