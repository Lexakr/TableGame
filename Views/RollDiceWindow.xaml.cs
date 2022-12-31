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
    /// Interaction logic for RollDiceWindow.xaml
    /// </summary>
    public partial class RollDiceWindow : Window
    {
        public RollDiceWindow()
        {
            InitializeComponent();
        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            // TASK FOR ROLL


            // after you did roll, disable next try
            this.RollButton.IsEnabled = false;
        }
    }
}
