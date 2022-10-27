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
            Title.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
        }

        //Хранилище подсписков
        static CardListManager listManager = new CardListManager(new List<CardList>()
        { 
            CardList.Make("Задачи"),
            CardList.Make("Важные")
        });

        static CardList selectedList = listManager.All[0];  //Выбранный список
        static int selectedListID = selectedList.Id;        //ID выбранного спика
        static Card selectedCard = new Card(1,"1", DateTimeContainer.Now ); //Выбранная карточка



        #region ClickEvents

        void layoutRoot_MouseLeftButtonDown(object sender, EventArgs e)
        {
            this.DragMove();
        }


        /// <summary>
        /// Нажатие кнопки "Добавить список" в меню
        /// </summary>
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
        /// <summary>
        /// Нажатие кнопки "Добавить задачу" в меню
        /// </summary>
        private void AddCardButton_Click(object sender, RoutedEventArgs e)
        {
            AddCardToMenu(AddCardTextbox.Text);
            listManager.GetList(selectedListID).Set(Card.Make(AddCardTextbox.Text));
            ShowList(listManager.GetList(selectedListID));

            AddCardTextbox.Text = "";
        }

        /// <summary>
        /// Нажатие кнопки "Поиск" в меню
        /// </summary>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

            List<Card> searchResult = listManager.GlobalSearchByContent(SearchTextbox.Text);

            ShowSearchResult(searchResult);

            

            SearchTextbox.Text = "";
        }


        /// <summary>
        /// Нажатие на кнопку списка в меню
        /// </summary>
        private void ListMenuButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton selectedList = sender as RadioButton;

            SortedList<int, CardList> pool = listManager.All;

            foreach (KeyValuePair<int,CardList> item  in pool)
            {
                if(item.Value.Name == (string)selectedList.Content)
                {
                    selectedListID = item.Key;
                    break;
                }
            }

            ShowList(listManager.GetList(selectedListID));

        }

        /// <summary>
        /// Нажатие на карточку дела в меню
        /// </summary>
        private void Card_Click(object sender, RoutedEventArgs e)
        {
            RadioButton selectedCardbtn = sender as RadioButton;
            CardList cardList = listManager.GetList(selectedListID);

            foreach(KeyValuePair<int,Card> item in cardList.All)
            {
                if(item.Value.Name == (string)selectedCardbtn.Content)
                {
                    selectedCard = item.Value;
                    break;
                }
            }


            ShowCard(selectedCard);

        }
        #endregion

        #region TextChangedEvents
        //Изменение видимости текстовых полей для полей с шаблонами
        private void SearchTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TemplateSearch.Visibility = SearchTextbox.Text == "" ? Visibility.Visible : Visibility.Hidden;
        }

        private void AddListTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TemplateList.Visibility = AddListTextbox.Text == "" ? Visibility.Visible : Visibility.Hidden;
        }

        private void AddCardTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TemplateCard.Visibility = AddCardTextbox.Text == "" ? Visibility.Visible : Visibility.Hidden;
        }
        private void CardNameTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardNameTemplate.Visibility = Visibility.Hidden;
        }

        private void CardDateTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardDateTemplate.Visibility = Visibility.Hidden;
        }

        private void CardImportantTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardImportantTemplate.Visibility = Visibility.Hidden;
        }

        private void CardDoneTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardDoneTemplate.Visibility = Visibility.Hidden;
        }

        private void CardDescriptionTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardDescriptionTemplate.Visibility = Visibility.Hidden;
        }
        #endregion

        #region ShowMethods
        /// <summary>
        /// Метод отображения содержимого списка в меню карт
        /// </summary>
        /// <param name="nextList"> Отображаемый список </param>
        private void ShowList(CardList nextList)
        {
            CardInfoColumn.Width = new GridLength(0);

            CardsPanel.Children.Clear();

            selectedList = nextList;
            selectedListID = nextList.Id;

            foreach(Card card in nextList.GetListDefault())
            {
                AddCardToMenu(card.Name);
            }

        }

        private void ShowSearchResult(List<Card> searchResult)
        {
            foreach (Card card in searchResult)
            {
                ShowFoundCard(card);
            }

        }

        private void ShowFoundCard(Card card)
        {
            RadioButton nextFoundCard = new RadioButton();
            nextFoundCard.Height = 50;
            nextFoundCard.Foreground = new SolidColorBrush(Colors.Black);
            nextFoundCard.FontSize = 14;
            nextFoundCard.Content = card.Name;

            nextFoundCard.Style = (Style)TaskButton.FindResource("CardTheme");
            nextFoundCard.Click += Card_Click;
            CardsPanel.Children.Add(nextFoundCard);
        }

        private void ShowCard(Card selectedCard)
        {

            CardInfoColumn.Width = new GridLength(240);

            string[] cardInfo = new string[]
            {
                selectedCard.Name.ToString(),
                selectedCard.Date.ToString(),
                selectedCard.IsImportant.ToString(),
                selectedCard.IsCompleted.ToString(),
                selectedCard.Description.ToString(),
            };

            int index = 0;

            foreach (Border element in CardInfo.Children)
            {
                Grid grid = (Grid)element.Child;
                TextBox tb = (TextBox)grid.Children[1];
                tb.Text = cardInfo[index];
                index++;
            }
        }
        #endregion

        #region AddMethods

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

        private void AddCardToMenu(string text)
        {
            RadioButton nextCard = new RadioButton();
            nextCard.Height = 50;
            nextCard.Foreground = new SolidColorBrush(Colors.Black);
            nextCard.FontSize = 14;
            nextCard.Content = text;

            nextCard.Style = (Style)TaskButton.FindResource("CardTheme");
            nextCard.Click += Card_Click;
            CardsPanel.Children.Add(nextCard);
        }
        #endregion

    }
}
