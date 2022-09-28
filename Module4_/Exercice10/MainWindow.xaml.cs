using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

using Microsoft.Win32;

namespace Exercice9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static RoutedCommand AProposCmd = new RoutedCommand();
        public static RoutedCommand ViderCmd = new RoutedCommand();
        public static RoutedCommand OuvirCmd = new RoutedCommand();
        public static RoutedCommand EnregistrerCmd = new RoutedCommand();
        public static RoutedCommand EnregistrerSousCmd = new RoutedCommand();
        public static RoutedCommand Quitter = new RoutedCommand();

        private string PathFichier
        {
            set;
            get;
        }

        private const string NOM_APPLICATION = " -- Mini éditeur";

        public MainWindow()
        {
            InitializeComponent();
            PathFichier = "";
            Title = "Sans nom" + NOM_APPLICATION;
            ContenuFichier.Text = "";
        }

        private void EnregistrerSous()
        {
            bool? result;
            SaveFileDialog fileDialog = new SaveFileDialog();
            result = fileDialog.ShowDialog();

            if (result.Value)
            {
                PathFichier = fileDialog.FileName;
                SauvegarderFichier();
            }
        }

        private void SauvegarderFichier()
        {
            StreamWriter leFichier = File.CreateText(PathFichier);
            Title = Path.GetFileName(PathFichier) + NOM_APPLICATION;
            leFichier.Write(ContenuFichier.Text);
            leFichier.Close();
        }

        private void OuvrirFichier()
        {
            bool? result;
            OpenFileDialog fileDialog = new OpenFileDialog();

            result = fileDialog.ShowDialog();

            if (result.Value)
            {
                PathFichier = fileDialog.FileName;
                StreamReader leFichier = File.OpenText(PathFichier);
                Title = Path.GetFileName(PathFichier) + NOM_APPLICATION;
                ContenuFichier.Text = leFichier.ReadToEnd();
                leFichier.Close();
            }
        }

        // Commandes et événements
        private void APropos_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Mini éditeur \n Version 0.9");
        }

        private void APropos_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Vider_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ContenuFichier.Text = "";
        }
        private void Vider_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ContenuFichier != null && ContenuFichier.Text.Length != 0;
        }

        private void Ouvrir_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OuvrirFichier();
        }
        private void Ouvrir_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Enregistrer_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (PathFichier.Equals(""))
            {
                EnregistrerSous();
            }
            else
            {
                SauvegarderFichier();
            }

        }
        private void Enregistrer_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void EnregistrerSous_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            EnregistrerSous();
        }
        private void EnregistrerSous_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Quitter_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Quitter_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}