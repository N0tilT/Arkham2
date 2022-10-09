using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TimelonCl;

namespace TimelonCA
{
    class Tests
    {
        public void TestCustomCard()
        {
            Console.WriteLine("TestCustomCard:");

            Card card = new Card(13, "customName", "This is a custom card", PriorityId.DEFAULT, false, DateTime.Now);

            Console.WriteLine(card.Update());
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

        public void TestCardProvider()
        {
            Console.WriteLine("TestCardProvider:");

            CardProvider provider = new CardProvider();
            List<Card> list = new List<Card>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(Card.Random());
            }

            provider.Set(list);

            // Все карточки
            foreach (KeyValuePair<int, Card> card in provider.All)
            {
                Console.WriteLine(card.Value);
            }

            Console.WriteLine();
            Console.WriteLine("Sorted by last change DateTime:");

            // Сортировка по дате последнего изменения
            foreach (Card card in provider.GetListByLastChange())
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();
            Console.WriteLine("Sorted by Priority:");

            // Сортировка по приоритету
            foreach (Card card in provider.GetListByPriority())
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();
            Console.WriteLine("Sorted by completion:");

            // Сортировка по статусу выполнения
            foreach (Card card in provider.GetListCompleted())
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();
        }
    }
}
