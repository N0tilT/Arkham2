using System;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        


        //Хранилище подсписков
        CardListManager listManager = new CardListManager(new List<CardList>()
        { 
            new CardList(Util.UniqueId(typeof(Card)), "Задачи"),
            new CardList(Util.UniqueId(typeof(Card)), "Важные" )
        });

        static string selectedList = "Задачи";
        static int selectedListID = 0;

        //CardList _provider = new CardList(1,"test");

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    _provider.Set(Card.Random());

        //    string tmp = "";
        //    List<Card> list = _provider.All.Values.ToList();

        //    foreach (Card card in list)
        //    {
        //        tmp += card + "\n";
        //    }

        //    //tbCards.Text = tmp;
        //}

        private void AddListButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(RadioButton btn in MenuPanel.Children)
            {
                btn.IsChecked = false;
            }

            AddListToMenu(AddListTextbox.Text);

            

            CardList nextList = new CardList(listManager.All.Count, AddListTextbox.Text);

            //Добавляем подсписок в хранилище
            listManager.SetList(nextList);

            ShowList(nextList);

            AddListTextbox.Text = "";

        }

        private void ShowList(CardList nextList)
        {
            CardsPanel.Children.Clear();

            selectedList = nextList.Name;
            selectedListID = nextList.Id;

            foreach(Card card in nextList.GetListDefault())
            {
                AddCardToMenu(card.Name);
            }

        }

        private void AddListToMenu(string text)
        {
            RadioButton nextList = new RadioButton();
            nextList.Height = 50;
            nextList.Foreground = new SolidColorBrush(Colors.White);
            nextList.FontSize = 14;
            nextList.Content = text;
            nextList.IsChecked = true;
            nextList.Style = (Style)TaskButton.FindResource("MenuButtonTheme");
            nextList.Click += ListMenuButton_Click;
            MenuPanel.Children.Add(nextList);
        }


        private void AddListTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TemplateList.Visibility = AddListTextbox.Text == "" ? Visibility.Visible : Visibility.Hidden;
        }


        private void AddCardButton_Click(object sender, RoutedEventArgs e)
        {
            AddCardToMenu(AddCardTextbox.Text);
            listManager.GetList(selectedListID).Set(new Card(Util.UniqueId(typeof(Card)), AddCardTextbox.Text, ""));
            ShowList(listManager.GetList(selectedListID));

            AddCardTextbox.Text = "";
        }

        private void AddCardToMenu(string text)
        {
            RadioButton nextCard = new RadioButton();
            nextCard.Height = 50;
            nextCard.Foreground = new SolidColorBrush(Colors.White);
            nextCard.FontSize = 14;
            nextCard.Content = text;

            nextCard.Style = (Style)TaskButton.FindResource("MenuButtonTheme");

            CardsPanel.Children.Add(nextCard);
        }

        private void AddCardTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TemplateCard.Visibility = AddCardTextbox.Text == "" ? Visibility.Visible : Visibility.Hidden;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton nextCard = new RadioButton();
            nextCard.Height = 50;
            nextCard.Foreground = new SolidColorBrush(Colors.White);
            nextCard.FontSize = 14;
            nextCard.Content = SearchTextbox.Text;

            nextCard.Style = (Style)TaskButton.FindResource("MenuButtonTheme");

            CardsPanel.Children.Add(nextCard);

            SearchTextbox.Text = "";
        }

        private void SearchTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TemplateSearch.Visibility = SearchTextbox.Text == "" ? Visibility.Visible : Visibility.Hidden;
        }

        private void ListMenuButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton selectedList = sender as RadioButton;

            SortedList<int, CardList> pool = listManager.All;

            for (int i = 0; i < pool.Count; i++)
            {
                if(pool[i].Name == (string)selectedList.Content)
                {
                    selectedListID = pool[i].Id;
                    break;
                }
            }
            ShowList(listManager.GetList(selectedListID));

        }
    }
}
