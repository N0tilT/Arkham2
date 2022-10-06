﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
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

        CardList cardlist = new CardList();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cardlist.Add(Card.Random());

            string tmp = "";
            List<Card> cards = cardlist.All;

            foreach (Card card in cards)
                tmp += card + "\n";

            tbCards.Text = tmp;
        }
    }
}
