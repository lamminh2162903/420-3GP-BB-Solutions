namespace M2_ClassesAffaire
{ 
    /// <summary>
    /// Classe qui génère des livres de façons de façon aléatoire
    /// </summary>
    public class GenerateurLivre
    {
        private string[] _tabTitres = new string[15];   // Les titres
        private string[] _tabAuteurs = new string[15]; // Les auteurs
        private string[] _tabEditeurs = new string[15]; // Les éditeurs
        private int _anneeEdition;    // L'année d'édition va monter de 1 à chaque livre pour éviter les doublons
        private Random _rng;

        /// <summary>
        /// Constructeur
        /// </summary>
        public GenerateurLivre()
        {
            AjouterTitres();
            AjouterAuteurs();
            AjouterEditeurs();
            _rng = new Random();
            _anneeEdition = 1;
        }
         
        /// <summary>
        /// Ajoute les titres au tableau de titres
        /// </summary>
        private void AjouterTitres()
        {
            _tabTitres[0] = "Game Engine Architecture 3rd ed.";
            _tabTitres[1] = "Python for Data Analysis 2nd ed.";
            _tabTitres[2] = "Fundamentals of Game Design 3rd ed.";
            _tabTitres[3] = "Game Programming Patterns";
            _tabTitres[4] = "Hands-On Machine Learning with Scikit-Learn, Keras & TensorFlow 2nd ed.";
            _tabTitres[5] = "Learning LibGDX Game Development 2nd. Edition";
            _tabTitres[6] = "PHP and MySQL Web Development 4th ed.";
            _tabTitres[7] = "Graph Theory and its Applications";
            _tabTitres[8] = "Probabilistic Graphical Models";
            _tabTitres[9] = "Maven, The Definitive Guide";
            _tabTitres[10] = "The Pragmatic Programmer";
            _tabTitres[11] = "Linux Command Line and Shell Scripting Bible";
            _tabTitres[12] = "How Linux Works";
            _tabTitres[13] = "Unity in Action";
            _tabTitres[14] = "Developing 2D Games with Unity";
        }

        // Ajoute les auteurs au tableau d'auteurs
        private void AjouterAuteurs()
        {
            _tabAuteurs[0] = "Jason Gregory";
            _tabAuteurs[1] = "Wes McKinney";
            _tabAuteurs[2] = "Ernest Adams";
            _tabAuteurs[3] = "Robert Nystrom";
            _tabAuteurs[4] = "Aurélien Géron";
            _tabAuteurs[5] = "Andreas Oehlke";
            _tabAuteurs[6] = "Luke Welling";
            _tabAuteurs[7] = "Laura Thomson";
            _tabAuteurs[8] = "Jonathan L. Gross";
            _tabAuteurs[9] = "Jay Yellen.";
            _tabAuteurs[10] = "Daphne Coller";
            _tabAuteurs[11] = "Nir Friedman";
            _tabAuteurs[12] = "Sonatype";
            _tabAuteurs[13] = "David Thomas";
            _tabAuteurs[14] = "Andrew Hunt";
        }

        // Ajoute les éditeurs au tableau d'éditeurs
        private void AjouterEditeurs()
        {
            _tabEditeurs[0] = "CRC Press";
            _tabEditeurs[1] = "O'Reilly";
            _tabEditeurs[2] = "News Rider";
            _tabEditeurs[3] = "genever benning";
            _tabEditeurs[4] = "Chapman & Hall";
            _tabEditeurs[5] = "Packt Publishing";
            _tabEditeurs[6] = "Addison Wesley";
            _tabEditeurs[7] = "The MIT Press";
            _tabEditeurs[8] = "Wiley";
            _tabEditeurs[9] = "APress";
            _tabEditeurs[10] = "Manning";
            _tabEditeurs[11] = "No Starch Press";
            _tabEditeurs[12] = "Prentice Hall";
            _tabEditeurs[13] = "Cambridge";
            _tabEditeurs[14] = "Dover";

        }

        /// <summary>
        /// Retourne un livre créé de façon aléatoire
        /// </summary>
        /// <returns>Le livre créé</returns>
        public Livre CreerNouveauLivre()
        {
            string titre = _tabTitres[_rng.Next(0, _tabTitres.Length)];
            string auteur = _tabAuteurs[_rng.Next(0, _tabAuteurs.Length)];
            string editeurs = _tabEditeurs[_rng.Next(0, _tabEditeurs.Length)];
            int nombrePages = _rng.Next(500, 2501);
            Livre nouveauLivre = new Livre(titre, auteur, editeurs, nombrePages, _anneeEdition++);
            return nouveauLivre;
        }
    }
}
