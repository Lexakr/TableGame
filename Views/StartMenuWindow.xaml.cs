using Microsoft.VisualBasic;
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
using TableGame.Fractions;
using TableGame.GameServices;

namespace TableGame.Views
{
    /// <summary>
    /// Interaction logic for StartMenuWindow.xaml
    /// </summary>
    public partial class StartMenuWindow : Window
    {
        private List<string> fractions = new List<string>() { "Imperium", "Orks" };

        public StartMenuWindow()
        {
            InitializeComponent();

            // DEBUG TEMP = NEW GAME = DOES NOT WORK
            //ButtonStart_Click(null, null);

            foreach (var fraction in fractions)
            {
                ComboBoxPlayer1.Items.Add(fraction);
                ComboBoxPlayer2.Items.Add(fraction);
            }

#if DEBUG
            TextBoxPlayerName1.Text = "first";
            TextBoxPlayerName2.Text = "second";
            TextBoxTotalSteps.Text = "100";
            ComboBoxPlayer1.SelectedValue = "Orks";
            ComboBoxPlayer2.SelectedValue = "Imperium";
#endif
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            if(ComboBoxPlayer1.SelectedValue == null || ComboBoxPlayer2.SelectedValue == null)
            {
                MessageBox.Show("Один из игроков не выбрал фракцию.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TextBoxPlayerName1.Text == "" || TextBoxPlayerName2.Text == "")
            {
                MessageBox.Show("Один из игроков не ввёл своё имя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var p1 = new Player(TextBoxPlayerName1.Text, ComboBoxPlayer1.SelectedValue.ToString() == "Orks" ? new Orks() : new Imperium());
            var p2 = new Player(TextBoxPlayerName2.Text, ComboBoxPlayer2.SelectedValue.ToString() == "Orks" ? new Orks() : new Imperium());

            var totalSteps = 0;

            try { totalSteps = Int32.Parse(TextBoxTotalSteps.Text); }
            catch { MessageBox.Show("Введите коректное цельное число ходов игры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            new MainWindow(p1, p2, totalSteps).Show();
            this.Close();
        }

        private void ComboBoxPlayer1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxPlayer1.SelectedValue == "Orks")
            {
                ComboBoxPlayer1.Items.Remove("Imperium");
                ComboBoxPlayer2.Items.Remove("Orks");
            }
            if (ComboBoxPlayer1.SelectedValue == "Imperium")
            {
                ComboBoxPlayer1.Items.Remove("Orks");
                ComboBoxPlayer2.Items.Remove("Imperium");
            }

        }

        private void ComboBoxPlayer2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxPlayer2.SelectedValue == "Orks")
            {
                ComboBoxPlayer2.Items.Remove("Imperium");
                ComboBoxPlayer1.Items.Remove("Orks");
            }
            if (ComboBoxPlayer2.SelectedValue == "Imperium")
            {
                ComboBoxPlayer2.Items.Remove("Orks");
                ComboBoxPlayer1.Items.Remove("Imperium");
            }
        }
    }
}
