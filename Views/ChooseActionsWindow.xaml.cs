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
using TableGame.ViewModels;

namespace TableGame.Views
{
    /// <summary>
    /// Interaction logic for ChooseActions.xaml
    /// </summary>
    public partial class ChooseActionsWindow : Window
    {
        public int ResultChoice { get; set; } = -1;

        public ChooseActionsWindow(List<string> choices)
        {
            InitializeComponent();



            for(int i = 0; i < choices.Count; i++)
            {
                var newButton = new Button();
                newButton.Content = choices[i];
                newButton.Tag = i.ToString();
                newButton.Click += ButtonChooseEvent;
                newButton.FontSize = 18;
                MainStackPanel.Children.Add(newButton);
            }

        }

        private void ButtonChooseEvent(object sender, RoutedEventArgs e)
        {
            ResultChoice = Int32.Parse((e.Source as Button).Tag.ToString());
            this.Close();
        }
    }
}
