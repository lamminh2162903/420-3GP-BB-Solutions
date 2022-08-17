using System;
using System.Collections.Generic;

namespace Exercice2
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Livre> fileLivre = new Queue<Livre>();
            fileLivre.Enqueue(new Livre("Game Engine Architecture 3rd ed.", "Jason Grogory", "CRC Press", 1200, 2018));
            fileLivre.Enqueue(new Livre("Python for Data Analysis 2nd ed.", "Wes McKinney", "O'Reilly", 523, 2017));
            fileLivre.Enqueue(new Livre("Fundamentals of Game Design 3rd ed.", "Ernest Adams", "News Rider", 556, 2014));
            fileLivre.Enqueue(new Livre("Game Programming Patterns", "Robert Nystrom", "genever benning", 345, 2014));
            fileLivre.Enqueue(new Livre("Hands-On Machine Learning with Scikit-Learn, Keras & TensorFlow 2nd ed.", "Aurélien Géron", "O'Reilly", 814, 2019));

            // Affichage avant:
            Console.WriteLine("Avant");
            AfficherFile(fileLivre);
            InverserFile(fileLivre);
            Console.WriteLine();

            Console.WriteLine("Après");
            AfficherFile(fileLivre);
        }

        public static void AfficherFile(Queue<Livre> file)
        {
            int taille = file.Count;
            for (int i = 0; i < taille; i++)
            {
                Livre unLivre = file.Dequeue();
                Console.WriteLine(unLivre.ToString());
                file.Enqueue(unLivre);
            }
        }

        public static void InverserFile(Queue<Livre> file)
        {
            Stack<Livre> pileTemporaire = new Stack<Livre>();

            while (file.Count > 0)
            {
                pileTemporaire.Push(file.Dequeue());
            }

            while (pileTemporaire.Count > 0)
            {
                file.Enqueue(pileTemporaire.Pop());
            }
        }
    }
}
