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

            Card card = new Card(13, "customName", "This is a custom card", 1);

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

        public void TestCardList()
        {
            Console.WriteLine("TestCardList:");

            CardList list = new CardList();

            for (int i = 0; i < 5; i++)
            {
                list.Add(Card.Random());
            }

            // Для наглядности
            foreach (Card card in list.All)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();
        }
    }
}
