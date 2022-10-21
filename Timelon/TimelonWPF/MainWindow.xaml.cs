using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TimelonCl;

namespace TimelonWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string nextListName = "123123";
        public MainWindow()
        {
            InitializeComponent();
        }

        CardList _provider = new CardList("test");

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

        private void Button_Click_AddList(object sender, RoutedEventArgs e)
        {
            RadioButton nextList = new RadioButton();
            nextList.Height = 50;
            nextList.Foreground = new SolidColorBrush(Colors.White);
            nextList.FontSize = 14;
            //nextList.Content = "123123";

            Style tbStyle = (Style)AddListTextbox.FindResource("AddListTextBox");

            nextList.Content = nextListName;

            nextList.Style = (Style)TaskButton.FindResource("MenuButtonTheme");

            MessageBox.Show(nextList.Content.ToString());

            MenuPanel.Children.Add(nextList);

            //nextList.Style = (Style)Resources["MenuButtonTheme"];

        }

        private void AddListTextbox_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            nextListName = AddListTextbox.Text;
        }
    }
}
