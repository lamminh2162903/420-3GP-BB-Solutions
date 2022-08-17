using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice6
{
    public class GenerateurLivre
    {
        private String[] tabTitres = new string[15];
        private String[] tabAuteurs = new String[15];
        private String[] tabEditeurs = new string[15];
        private int anneeEdition;
        private Random rng;

        public GenerateurLivre()
        {
            AjouterTitres();
            AjouterAuteurs();
            AjouterEditeurs();
            rng = new Random();
            anneeEdition = 1;
        }

        private void AjouterTitres()
        {
            tabTitres[0] = "Game Engine Architecture 3rd ed.";
            tabTitres[1] = "Python for Data Analysis 2nd ed.";
            tabTitres[2] = "Fundamentals of Game Design 3rd ed.";
            tabTitres[3] = "Game Programming Patterns";
            tabTitres[4] = "Hands-On Machine Learning with Scikit-Learn, Keras & TensorFlow 2nd ed.";
            tabTitres[5] = "Learning LibGDX Game Development 2nd. Edition";
            tabTitres[6] = "PHP and MySQL Web Development 4th ed.";
            tabTitres[7] = "Graph Theory and its Applications";
            tabTitres[8] = "Probabilistic Graphical Models";
            tabTitres[9] = "Maven, The Definitive Guide";
            tabTitres[10] = "The Pragmatic Programmer";
            tabTitres[11] = "Linux Command Line and Shell Scripting Bible";
            tabTitres[12] = "How Linux Works";
            tabTitres[13] = "Unity in Action";
            tabTitres[14] = "Developing 2D Games with Unity";
        }

        private void AjouterAuteurs()
        {
            tabAuteurs[0] = "Jason Gregory";
            tabAuteurs[1] = "Wes McKinney";
            tabAuteurs[2] = "Ernest Adams";
            tabAuteurs[3] = "Robert Nystrom";
            tabAuteurs[4] = "Aurélien Géron";
            tabAuteurs[5] = "Andreas Oehlke";
            tabAuteurs[6] = "Luke Welling";
            tabAuteurs[7] = "Laura Thomson";
            tabAuteurs[8] = "Jonathan L. Gross";
            tabAuteurs[9] = "Jay Yellen.";
            tabAuteurs[10] = "Daphne Coller";
            tabAuteurs[11] = "Nir Friedman";
            tabAuteurs[12] = "Sonatype";
            tabAuteurs[13] = "David Thomas";
            tabAuteurs[14] = "Andrew Hunt";
        }

        private void AjouterEditeurs()
        {
            tabEditeurs[0] = "CRC Press";
            tabEditeurs[1] = "O'Reilly";
            tabEditeurs[2] = "News Rider";
            tabEditeurs[3] = "genever benning";
            tabEditeurs[4] = "Chapman & Hall";
            tabEditeurs[5] = "Packt Publishing";
            tabEditeurs[6] = "Addison Wesley";
            tabEditeurs[7] = "The MIT Press";
            tabEditeurs[8] = "Wiley";
            tabEditeurs[9] = "APress";
            tabEditeurs[10] = "Manning";
            tabEditeurs[11] = "No Starch Press";
            tabEditeurs[12] = "Prentice Hall";
            tabEditeurs[13] = "Cambridge";
            tabEditeurs[14] = "Dover";

        }

        public Livre CreerNouveauLivre()
        {
            string titre = tabTitres[rng.Next(0, tabTitres.Length)];
            string auteur = tabAuteurs[rng.Next(0, tabAuteurs.Length)];
            string editeurs = tabEditeurs[rng.Next(0, tabEditeurs.Length)];
            int nombrePages = rng.Next(500, 2501);
            Livre nouveauLivre = new Livre(titre, auteur, editeurs, nombrePages, anneeEdition++);
            return nouveauLivre;
        }
    }
}
