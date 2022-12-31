using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TableGame.GameServices;
using TableGame.ViewModels;

namespace TableGame.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Player player1, Player player2, int totalSteps)
        {
            InitializeComponent();

            DataContext = new MainWindowVM(player1, player2, totalSteps);

        }

        private void MenuItemStartNewGame_Click(object sender, RoutedEventArgs e)
        {
            new StartMenuWindow().Show();
            this.Close();
        }
    }
}
