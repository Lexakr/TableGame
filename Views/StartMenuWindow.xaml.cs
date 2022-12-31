using System;
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
using System.Windows.Shapes;

namespace TableGame.Views
{
    /// <summary>
    /// Interaction logic for StartMenuWindow.xaml
    /// </summary>
    public partial class StartMenuWindow : Window
    {
        public StartMenuWindow()
        {
            InitializeComponent();

            // DEBUG
            ButtonStart_Click(null, null);
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            var p = new Player("test", "Imper", new List<Units.Unit>());

            new MainWindow(p).Show();
            this.Close();
        }
    }
}
