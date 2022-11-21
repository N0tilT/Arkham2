using System;
using System.Windows;
using System.Windows.Controls;

namespace TimelonWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static ApplicationViewModel viewModel = new ApplicationViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
            Title.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(LayoutRoot_MouseLeftButtonDown);

        }

        void LayoutRoot_MouseLeftButtonDown(object sender, EventArgs e)
        {
            DragMove();
        }


        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem tmp = sender as ListBoxItem;
            MenuPanel.SelectedItem = tmp;
        }
        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem tmp = sender as ListBoxItem;
            MenuPanel.SelectedItem = tmp;
        }


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

    }
}
