using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public int RollResult { get; set; } = 0;

        public RollDiceWindow(string textToTitle)
        {
            InitializeComponent();

            TopText.Text = textToTitle;

            new Thread (() =>
            {
                Thread.Sleep(1000);

                Dispatcher.Invoke(() => {
                    RollResult = new Random().Next(1, 6);
                    DiceText.Text = RollResult.ToString();

#if DEBUG
                    this.Close();
#endif
                });

            }).Start();

        }
    }
}
