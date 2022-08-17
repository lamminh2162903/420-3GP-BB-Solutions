using System;
using System.Collections.Generic;

namespace Exercice1
{
    class Program
    {
        static void Main(string[] args)
        {
            Livre[] tabLivres = new Livre[5];
            tabLivres[0] = new Livre("Game Engine Architecture 3rd ed.", "Jason Grogory", "CRC Press", 1200, 2018);
            tabLivres[1] = new Livre("Python for Data Analysis 2nd ed.", "Wes McKinney", "O'Reilly", 523, 2017);
            tabLivres[2] = new Livre("Fundamentals of Game Design 3rd ed.", "Ernest Adams", "News Rider", 556, 2014);
            tabLivres[3] = new Livre("Game Programming Patterns", "Robert Nystrom", "genever benning", 345, 2014);
            tabLivres[4] = new Livre("Hands-On Machine Learning with Scikit-Learn, Keras & TensorFlow 2nd ed.", "Aurélien Géron", "O'Reilly", 814, 2019);

            Stack<Livre> pileLivres;
            pileLivres = new Stack<Livre>();

            Console.WriteLine("Affichage avant: ");
            foreach (Livre unLivre in tabLivres)
            {
                Console.WriteLine(unLivre.ToString());
                pileLivres.Push(unLivre);
            }

            Console.WriteLine();
            Console.WriteLine("Affichage après: ");
            while (pileLivres.Count > 0)
            {
                Livre leLivre = pileLivres.Pop();
                Console.WriteLine(leLivre.ToString());
            }
        }
    }
}
