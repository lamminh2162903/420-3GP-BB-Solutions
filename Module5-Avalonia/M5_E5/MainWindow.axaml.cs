using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.IO;
using System.Threading.Tasks;

namespace M5_E5
{
    public partial class MainWindow : Window
    {

        private char DIR_SEPARATOR = Path.DirectorySeparatorChar;
        private string pathFichier;

        public MainWindow()
        {
            InitializeComponent();
        }


        private async void ChargerFichierClick(object source, RoutedEventArgs args)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AllowMultiple = false;
            ofd.Directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Task<string[]> fichiers = ofd.ShowAsync(this);
            await fichiers;
            pathFichier = fichiers.Result[0];
            string content = File.ReadAllText(pathFichier);
            ZoneTexte.Text = content;
            string[] tokens = pathFichier.Split(DIR_SEPARATOR);
            NomFichier.Text = tokens[tokens.Length - 1];
        }

        private void SauvegarderFichierClick(object source, RoutedEventArgs args)
        {
            File.WriteAllText(pathFichier, ZoneTexte.Text);
        }

        private async void SauvegarderSousClick(object source, RoutedEventArgs args)
        {
            SaveFileDialog save = new SaveFileDialog();
            Task<string?> fileName = save.ShowAsync(this);
            await fileName;
            if (fileName.Result != null)
            {
                File.WriteAllText(fileName.Result, ZoneTexte.Text);
                pathFichier = fileName.Result;
                string[] tokens = pathFichier.Split(DIR_SEPARATOR);
                NomFichier.Text = tokens[tokens.Length - 1];
            }
        }

        private void ViderTexteClick(object source, RoutedEventArgs args)
        {
            ZoneTexte.Text = "";
        }
    }
}