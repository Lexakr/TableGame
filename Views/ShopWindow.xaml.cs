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
using TableGame.GameServices;
using TableGame.ViewModels;

namespace TableGame.Views
{
    /// <summary>
    /// Interaction logic for ShowWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        public ShopWindow(Player activePlayer)
        {
            InitializeComponent();

            DataContext = new ShopWindowVM(activePlayer);

#if DEBUG
            DebugMenu.Visibility = Visibility.Visible;
#endif
        }
    }
}
