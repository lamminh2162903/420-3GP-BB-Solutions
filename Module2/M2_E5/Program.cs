using System;
using System.Collections.Generic;

namespace Exercice4
{
    class Program
    {
        const int TAILLE_ECHANTILLON = 500000;
        static void Main(string[] args)
        {
            List<int> listeTableau = new List<int>();
            LinkedList<int> listeChainee = new LinkedList<int>();
            SortedList<int, int> listeTriee = new SortedList<int, int>();
            SortedSet<int> arbre = new SortedSet<int>();
            HashSet<int> hachage = new HashSet<int>();

            int[] tableauValeurs = new int[TAILLE_ECHANTILLON];
            for (int i=0; i<tableauValeurs.Length; i++)
            {
                tableauValeurs[i] = i;
            }
            BrasserTableau(tableauValeurs);
            BrasserTableau(tableauValeurs);

            InsererArrayList(listeTableau, tableauValeurs);
            InsererLinkedList(listeChainee, tableauValeurs);
            InsererSortedList(listeTriee, tableauValeurs);
            InsererSortedSet(arbre, tableauValeurs);
            InsererHashSet(hachage, tableauValeurs);
            Console.WriteLine();

            ParcourirArrayList(listeTableau);
            ParcourirLinkedList(listeChainee);
            ParcourirSortedList(listeTriee);
            ParcourirSortedSet(arbre);
            ParcourirHashSet(hachage);
            Console.WriteLine();

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
        }

        static void BrasserTableau(int[] tableau)
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

        static void InsererArrayList(List<int> liste, int[] tableau)
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

        static void InsererLinkedList(LinkedList<int> liste, int[] tableau)
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

        static void InsererSortedList(SortedList<int, int> liste, int[] tableau)
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
        static void InsererSortedSet(SortedSet<int> arbre, int[] tableau)
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

        static void InsererHashSet(HashSet<int> hachage, int[] tableau)
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

        static void ParcourirArrayList(List<int> liste)
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

        static void ParcourirLinkedList(LinkedList<int> liste)
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

        static void ParcourirSortedList(SortedList<int, int> liste)
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
        static void ParcourirSortedSet(SortedSet<int> arbre)
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

        static void ParcourirHashSet(HashSet<int> hachage)
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

        static void ChercherArrayList(List<int> liste, int[] tableau)
        {
            Console.Write("Recherches dans ArrayList: ");
            long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            for (int i=0; i < 100000; i++)
            {
                bool present = liste.Contains(tableau[i]);
            }

            long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long tempsOperation = apres - avant;
            Console.WriteLine(tempsOperation + " millisecondes.");
        }

        static void ChercherLinkedList(LinkedList<int> liste, int[] tableau)
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

        static void ChercherSortedList(SortedList<int, int> liste, int[] tableau)
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

        static void ChercherSortedSet(SortedSet<int> arbre, int[] tableau)
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

        static void ChercherHashSet(HashSet<int> hachage, int[] tableau)
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

        static void SupprimerArrayList(List<int> liste, int[] tableau)
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

        static void SupprimerLinkedList(LinkedList<int> liste, int[] tableau)
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

        static void SupprimerSortedList(SortedList<int, int> liste, int[] tableau)
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

        static void SupprimerSortedSet(SortedSet<int> arbre, int[] tableau)
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

        static void SupprimerHashSet(HashSet<int> hachage, int[] tableau)
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
    }
}
