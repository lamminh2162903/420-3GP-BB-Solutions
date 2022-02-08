using System;

namespace Exercice_2
{
    class Program
    {
        static void Main(string[] args)
        {

            FormeGeometrique rectangle= new Rectangle(2.5, 4.3);
            FormeGeometrique cercle = new Cercle(3.3);
            FormeGeometrique carre = new Carre(2.5);

            // Teste les fonctions de périmètres
            Console.WriteLine("Le périmètre du rectangle est : " + rectangle.CalculerPerimetre());
            Console.WriteLine("Le périmètre du cercle est : " + cercle.CalculerPerimetre());
            Console.WriteLine("Le périmètre du carré est : " + carre.CalculerPerimetre());

            // On teste les exceptions
            try
            {
                FormeGeometrique cercleInvalide = new Cercle(-1.0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // On dessine le rectangle
            Console.WriteLine("Voici le rectangle: ");
            ((IDessinable)rectangle).DessinerObjet();
            Console.WriteLine();

            // On dessine le carré
            Console.WriteLine("Voici le carre: ");
            ((IDessinable)carre).DessinerObjet();
            Console.WriteLine();
        }
    }
}
