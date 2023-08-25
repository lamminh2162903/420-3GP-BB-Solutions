using System.Diagnostics;
using System.Text;

const uint NOMBRE_ITERATIONS = 100000;  // Le nombre d'itérations

Stopwatch  sw = new Stopwatch(); // Pour évaluer le temps des opérations

// On va concaténer les nombres de 0 à NOMBRE_ITERATIONS-1 dans une
// chaîne de caractères
sw.Start();
string premiereChaine = "";
for (int i = 0; i < NOMBRE_ITERATIONS; i++)
{
    premiereChaine = premiereChaine + i + ' ';
}
sw.Stop();
Console.WriteLine($"La concaténation a pris {sw.ElapsedMilliseconds} millisecondes");

// On fait la même chose mais cette fois avec un StringBuilder
sw.Restart();
StringBuilder sb = new StringBuilder();
for (int i = 0; i < NOMBRE_ITERATIONS; i++)
{
    sb.Append(i);
    sb.Append(' ');
}

string deuxiemeChaine = sb.ToString();
sw.Stop();
Console.WriteLine($"L'utilisation de StringBuilder a pris {sw.ElapsedMilliseconds} millisecondes");