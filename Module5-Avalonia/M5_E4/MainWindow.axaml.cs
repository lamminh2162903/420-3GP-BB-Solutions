using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MessageBox.Avalonia;     // Pour avoir un message box, il faut ajouter le package MessageBox.Avalonia-mainthread.
                               // Avec .NET CLI: dotnet add package MessageBox.Avalonia-mainthread


namespace M5_E4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nom = ChampNom.Text;
            MessageBoxManager.GetMessageBoxStandardWindow("Saluation", $"Bonjour {nom}").Show();
        }
    }
}