using System;
using System.Collections.Generic;
using TimelonCl;
using TimelonCl.Data;

namespace TimelonCA
{
    class Tests
    {
        public void TestCustomCard()
        {
            Console.WriteLine("TestCustomCard:");

            Card card = Card.Make("customName");

            card.Description = "This is a custom new card";

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

            CardList list = CardList.Make("customName");

            for (int i = 0; i < 20; i++)
            {
                list.Set(Card.Random());
            }

            // Все карточки
            Console.WriteLine(list);

            Console.WriteLine();
            Console.WriteLine("DEFAULT LIST UNSORTED:");

            // Несортировка по дате последнего обновления
            foreach (Card card in list.GetListDefault(SortOrder.Unsorted))
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();
            Console.WriteLine("IMPORTANT ASCENDING:");

            // Сортировка важных по дате обновления по возрастанию
            foreach (Card card in list.GetListImportant(SortOrder.Ascending))
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();
            Console.WriteLine("COMPLETED DESCENDING:");

            // Сортировка выполненных по дате обновления по убыванию
            foreach (Card card in list.GetListCompleted(SortOrder.Descending))
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();
        }

        public void TestCardListManager()
        {
            Console.WriteLine("TestCardListManager:");

            List<CardList> all = new List<CardList>();

            Manager manager = Manager.Instance;

            // Данные загружаются из файла
            // Так что мы их перезапишем
            // Но идентификаторы продолжат инкременироваться (это ок)
            manager.All.Clear();

            for (int i = 0; i < 3; i++)
            {
                CardList list = CardList.Make(Util.NextString(8, 16));

                for (int j = 0; j < 5; j++)
                {
                    list.Set(Card.Random());
                }

                all.Add(list);

                manager.SetList(list);
            }

            manager.Sync();

            foreach (KeyValuePair<int, CardList> item in manager.All)
            {
                Console.WriteLine(item.Value);
            }

            Console.WriteLine();
        }
    }
}
