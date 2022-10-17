using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TimelonCl;

namespace TimelonWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        CardProvider _provider = new CardProvider();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _provider.Set(Card.Random());

            string tmp = "";
            List<Card> list = _provider.All.Values.ToList();

            foreach (Card card in list)
            {
                tmp += card + "\n";
            }

            //tbCards.Text = tmp;
        }
    }
}
