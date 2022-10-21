﻿using System;
using System.Collections.Generic;
using TimelonCl;

namespace TimelonCA
{
    class Tests
    {
        public void TestCustomCard()
        {
            Console.WriteLine("TestCustomCard:");

            Card card = new Card(Util.UniqueId(typeof(Card)), "customName", "This is a custom new card");

            Console.WriteLine(card);
            Console.WriteLine();
        }

        public void TestRandomCard()
        {
            Console.WriteLine("TestRandomCard:");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(Card.Random());
            }

            Console.WriteLine();
        }

        public void TestCardList()
        {
            Console.WriteLine("TestCardList:");

            CardList list = new CardList(Util.UniqueId(typeof(CardList)), "customName");

            for (int i = 0; i < 10; i++)
            {
                list.Set(Card.Random());
            }

            // Все карточки
            foreach (KeyValuePair<int, Card> card in list.All)
            {
                Console.WriteLine(card.Value);
            }

            Console.WriteLine();
            Console.WriteLine("Default list sorted by last update DateTime:");

            // Сортировка по дате последнего обновления
            foreach (Card card in list.GetListDefault())
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();
            Console.WriteLine("List sorted by importance flag:");

            // Сортировка по важности
            foreach (Card card in list.GetListImportant())
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();
            Console.WriteLine("Completed:");

            // Сортировка по статусу выполнения
            foreach (Card card in list.GetListCompleted())
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();
        }

        public void TestCardListManager()
        {
            Console.WriteLine("TestCardListManager:");

            List<CardList> all = new List<CardList>();

            for(int i = 0; i < 3; i++)
            {
                CardList list = new CardList(Util.UniqueId(typeof(CardList)), Util.NextString(8, 16));

                for (int j = 0; j < 5; j++)
                {
                    list.Set(Card.Random());
                }

                all.Add(list);
            }

            CardListManager manager = new CardListManager(all);

            foreach (KeyValuePair<int, CardList> item in manager.All)
            {
                Console.WriteLine();
                Console.WriteLine("CARDLIST_ID: " + item.Value.Id);
                Console.WriteLine("CARDLIST_NAME: " + item.Value.Name);

                foreach (KeyValuePair<int, Card> card in item.Value.All)
                {
                    Console.WriteLine(card.Value);
                }
            }

            Console.WriteLine();
        }
    }
}
