using System;
using M1_E3;

FormeGeometrique rectangle = new Rectangle(2.5, 4.3);
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
IDessinable? rectangleDessinable = rectangle as IDessinable;
string dessinRectangle = rectangleDessinable?.DessinerObjet() ?? "Non dessinable";
Console.WriteLine(dessinRectangle);

// On dessine le carré
Console.WriteLine("Voici le carre: ");
IDessinable? carreDessinable = carre as IDessinable;
string dessinCarre = carreDessinable?.DessinerObjet() ?? "Non dessinable";
Console.WriteLine(dessinCarre);

// On teste avec le cercle qui n'est pas dessinable
Console.WriteLine("Voici le cercle: ");
IDessinable? cercleDessinable = cercle as IDessinable;
string dessinCercle = cercleDessinable?.DessinerObjet() ?? "Non dessinable";
Console.WriteLine(dessinCercle);
