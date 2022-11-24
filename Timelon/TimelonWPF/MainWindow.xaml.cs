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
            if (CardInfoColumn.Width == new GridLength(240))
                CardInfoColumn.Width = new GridLength(0);
        }
        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            if (CardInfoColumn.Width == new GridLength(0))
                CardInfoColumn.Width = new GridLength(240);
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

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            Canvas.SetZIndex(CloseButton, 1);
        }

        private void Image_MouseDown_2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
            this.WindowState = WindowState.Normal;
        }
    }
}
