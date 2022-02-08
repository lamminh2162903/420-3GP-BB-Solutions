using System;
using System.Collections.Generic;

namespace Exercice3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listeTableau = new List<int>();
            LinkedList<int> listeChaine = new LinkedList<int>();


            int[] tabNombres = new int[500000];
            for (int i=0; i<tabNombres.Length; i++)
            {
                tabNombres[i] = i;
            }


            Console.Write("Insertions à la fin dans liste tableau: ");
            long avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            foreach (int valeur in tabNombres)
            {
                listeTableau.Add(valeur);
            }
            long apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long tempsOperation = apres - avant;
            Console.WriteLine(tempsOperation + " millisecondes");

            Console.Write("Insertions à la fin dans liste chaînées: ");
            avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            foreach (int valeur in tabNombres)
            {
                listeChaine.AddLast(valeur);
            }
            apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            tempsOperation = apres - avant;
            Console.WriteLine(tempsOperation + " millisecondes");

            listeTableau.Clear();
            listeChaine.Clear();

            Console.Write("Insertions au debut dans liste tableau: ");
            avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            foreach (int valeur in tabNombres)
            {
                listeTableau.Insert(0, valeur);
            }
            apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            tempsOperation = apres - avant;
            Console.WriteLine(tempsOperation + " millisecondes");

            Console.Write("Insertions au début dans liste chaînée: ");
            avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            foreach (int valeur in tabNombres)
            {
                listeChaine.AddFirst(valeur);
            }
            apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            tempsOperation = apres - avant;
            Console.WriteLine(tempsOperation + " millisecondes");



            // On boucle sur tous les éléments

            Console.Write("Consultation de l'indice dans liste tableau: ");
            avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            for (int i = 0; i < listeTableau.Count; i++)
            {
                int valeur = listeTableau[i];
            }
            apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            tempsOperation = apres - avant;
            Console.WriteLine(tempsOperation + " millisecondes");

            Console.Write("Consultation du noeud dans liste chaînée: ");
            avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            LinkedListNode<int> node = listeChaine.First;
            while (node != null)
            {
                int valeur = node.Value;
                node = node.Next;
            }
            apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            tempsOperation = apres - avant;
            Console.WriteLine(tempsOperation + " millisecondes");


            Console.Write("Foreach dans liste tableau: ");
            avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            foreach (int i in listeTableau)
            {
                int valeur = i;
            }
            apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            tempsOperation = apres - avant;
            Console.WriteLine(tempsOperation + " millisecondes");

            Console.Write("Foreach dans liste chaînée: ");
            avant = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            foreach (int i in listeChaine)
            {
                int valeur = i;
            }
            apres = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            tempsOperation = apres - avant;
            Console.WriteLine(tempsOperation + " millisecondes");
        }
    }
}
