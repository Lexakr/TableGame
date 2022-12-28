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

namespace TableGame.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var grid = new UniformGrid();

            grid.Columns = 32;
            grid.Rows = 32;

            for (int row = 0; row < 32; row++)
            {
                for (int column = 0; column < 32; column++)
                {
                    

                   
                   //grid.Children.Add();
                }
            }

            Content = grid;

        }
    }
}
