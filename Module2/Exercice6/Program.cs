using System;
using System.Collections.Generic;

namespace Exercice6
{

    class Program
    {
        private const int NOMBRE_LIVRES = 40000;

        static void Main(string[] args)
        {
            Livre[] tableauLivres = new Livre[NOMBRE_LIVRES];

            CreerLivres(tableauLivres);

            SortedSet<Livre> arbreLivres = new SortedSet<Livre>();
            HashSet<Livre> hashLivres = new HashSet<Livre>();

            InsererDansArbre(arbreLivres, tableauLivres);
            InsererDansTable(hashLivres, tableauLivres);

            ChercherDansArbre(arbreLivres, tableauLivres);
            ChercherDansTable(hashLivres, tableauLivres);
        }


        private static void CreerLivres(Livre[] tab)
        {
            GenerateurLivre generateur = new GenerateurLivre();
            for (int i=0; i<NOMBRE_LIVRES; i++)
            {
                tab[i] = generateur.CreerNouveauLivre();
            }
        }

        private static void InsererDansArbre(SortedSet<Livre> arbreLivres, Livre[] tableauLivres)
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
        
        private static void InsererDansTable(HashSet<Livre> hashLivres, Livre[] tableauLivres)
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

        private static void ChercherDansArbre(SortedSet<Livre> arbreLivres, Livre[] tableauLivres)
        {
            Console.Write("Recherches dans SortedSet: ");
            long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            foreach (Livre unLivre in tableauLivres)
            {
                bool present = arbreLivres.Contains(unLivre);
                if (! present)
                {
                    Console.WriteLine("Livre absent: " + unLivre.ToString());
                }
            }

            long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long tempsOperation = apres - avant;
            Console.WriteLine(tempsOperation + " millisecondes.");
        }

        private static void ChercherDansTable(HashSet<Livre> hashLivres, Livre[] tableauLivres)
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
    }
}
