using System.Runtime.ExceptionServices;
using System.Xml;

char DIR_SEPARATOR = Path.DirectorySeparatorChar;

string pathFichier = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{DIR_SEPARATOR}" +
                     $"Fichiers-3GP{DIR_SEPARATOR}contacts.xml";

// On vérifie si le fichier contacts.xml existe 
if (! File.Exists(pathFichier))
{
    Console.Error.WriteLine($"Le fichier {pathFichier} n'existe pas");
    System.Environment.Exit(1);
}


// Chargement du fichier
XmlDocument document = new XmlDocument();
document.Load(pathFichier);

// Récupération de la racine
XmlElement root = document.DocumentElement;

// Affichage du nombre d'éléments avec la balise contact
XmlNodeList elements = root.GetElementsByTagName("contact");
Console.WriteLine($"Il y a {elements.Count} contacts dans le fichier.");

// Affichage du nombre de contacts qui ont Simpson comme nom de famille
int nombreSimpsons = 0;
foreach (XmlNode node in elements)
{
    XmlElement? element = node as XmlElement;
    if (element != null)
    {
        if (element.GetAttribute("nom").Equals("Simpson"))
        {
            nombreSimpsons++;
        }
    }
}

Console.WriteLine($"Il y a {nombreSimpsons} Simpson dans les contacts.");

// On affiche l'adresse de Ned Flanders
XmlElement? elementNed = null;
foreach (XmlNode node in elements)
{
    XmlElement? element = node as XmlElement;
    if (element != null)
    {
        if (element.GetAttribute("nom").Equals("Flanders"))
        {
            elementNed = element;
            break;
        }
    }
}

if (elementNed != null)
{
    XmlElement adresse = elementNed["adresse"];
    string numero = adresse.GetAttribute("numero");
    string rue = adresse.GetAttribute("rue");
    Console.WriteLine($"L'adresse de Ned Flanders est {numero} {rue}.");
}

// Affichage de la description de monsieur Burns
XmlElement? elementBurns = null;
foreach (XmlNode node in elements)
{
    XmlElement? element = node as XmlElement;
    if (element != null)
    {
        if (element.GetAttribute("nom").Equals("Burns"))
        {
            elementBurns = element;
            break;
        }
    }
}

if (elementBurns != null)
{
    XmlElement description = elementBurns["description"];
    Console.WriteLine($"La description de monsier Burns est:\n{description.InnerText.Trim()}");
}
