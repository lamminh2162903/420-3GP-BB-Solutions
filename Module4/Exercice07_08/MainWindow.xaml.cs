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

namespace Exercice7
{
    public partial class MainWindow : Window
    {
        private string pathFichier;

        public MainWindow()
        {
            InitializeComponent();
            pathFichier = "";
        }

        private void BoutonVider_Click(object sender, RoutedEventArgs e)
        {
            ContenuFichier.Text = "";
        }

        private void ChargerFichier_Click(object sender, RoutedEventArgs e)
        {
            bool? result;
            OpenFileDialog fileDialog = new OpenFileDialog();

            result = fileDialog.ShowDialog();

            if (result.Value)
            {
                pathFichier = fileDialog.FileName;
                StreamReader leFichier = File.OpenText(pathFichier);
                NomFichier.Text = Path.GetFileName(pathFichier);
                ContenuFichier.Text = leFichier.ReadToEnd();
                leFichier.Close();
            }
        }

        private void SauvegarderSous_Click(object sender, RoutedEventArgs e)
        {
            bool? result;
            SaveFileDialog fileDialog = new SaveFileDialog();
            result = fileDialog.ShowDialog();

            if(result.Value)
            {
                pathFichier = fileDialog.FileName;
                SauvegarderFichier();
            }
        }

        private void Sauvegarder_Click(object sender, RoutedEventArgs e)
        {
            if (pathFichier.Equals(""))
            {
                SauvegarderSous_Click(sender, e);
            }
            else
            {
                SauvegarderFichier();
            }
        }

        private void SauvegarderFichier()
        {
            StreamWriter leFichier = File.CreateText(pathFichier);
            NomFichier.Text = Path.GetFileName(pathFichier);
            leFichier.Write(ContenuFichier.Text);
            leFichier.Close();
        }
    }
}
