using System.IO;

char DIR_SEPARATOR = Path.DirectorySeparatorChar;   // Permet d'avoir un séparateur portable

Console.WriteLine("Dans cet exercice, il fallait créer le fichier XML dans un dossier Fichiers-3GP.");
Console.WriteLine("Bonnne nouvelle !! Ce programme place justement le fichier au bon endroit.");

if (ConfirmerOperation("Voulez-vous placer le fichier au bon endroit"))
{
    CopierFichier("contacts.xml");
}
else
{
    Console.WriteLine("Aucun changement n'est effectué");
}

bool ConfirmerOperation(string description)
{
    Console.Write($"{description} (Oui pour confirmer)? ");
    string? reponse = Console.ReadLine();
    return reponse.Equals("Oui");
}

void CopierFichier(string nomFichier)
{
    string pathMesDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    string pathDossier = $"{pathMesDocuments}{DIR_SEPARATOR}Fichiers-3GP";
    string pathFichier = $"{pathDossier}{DIR_SEPARATOR}{nomFichier}";
 
    // Création du dossier s'il n'existe pas
    if (! Directory.Exists(pathDossier))
    {
        Directory.CreateDirectory(pathDossier);
    }

    bool doitCopier = true;

    // On regarde si le fichier existe
    if (File.Exists(pathFichier))
    {
        doitCopier = ConfirmerOperation("Le fichier existe. Voulez-vous l'écraser");
    }

    // On regarde s'il faut copier
    if (doitCopier)
    {
        Console.WriteLine($"Écriture du fichier sous {pathFichier}");
        File.Copy(nomFichier, pathFichier, true);
    }
    else
    {
        Console.WriteLine("Aucun changement n'est effectué");
    }
}
