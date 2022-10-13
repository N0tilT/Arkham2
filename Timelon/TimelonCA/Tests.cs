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

            Card card = new Card(13, "customName", "This is a custom new card");

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

            for (int i = 0; i < 10; i++)
            {
                provider.Set(Card.Random());
            }

            // Все карточки
            foreach (KeyValuePair<int, Card> card in provider.All)
            {
                Console.WriteLine(card.Value);
            }

            Console.WriteLine();
            Console.WriteLine("Default list sorted by last update DateTime:");

            // Сортировка по дате последнего обновления
            foreach (Card card in provider.GetListDefault())
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();
            Console.WriteLine("List sorted by Priority:");

            // Сортировка по приоритету
            foreach (Card card in provider.GetListPriority())
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();
            Console.WriteLine("Completed:");

            // Сортировка по статусу выполнения
            foreach (Card card in provider.GetListCompleted())
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();
        }
    }
}
