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

        Card card = new Card("");

        public void CreateCardTest()
        {
            card = new Card("test1");
            card.Description = "This is a test card";
            card.Priority = 1;
            card.Update();
            PrintCard(card);
            Thread.Sleep(500);
            //CardDone(card);

            card = card.Random();
            PrintCard(card);


        }

        private void CardDone(Card card)
        {
            card.Done = true;
            card.Update();
        }


        public void CreateCardListTest()
        {
            CardList cards = new CardList();

            cards.Add(card.Random());

            cards.Add(card.Random());

            cards.Add(card.Random());

            PrintCardList(cards);
        }


        private void PrintCardList(CardList cards)
        {
            List<Card> cards1 = cards.All;
            Console.WriteLine("\n CardList \n");
            foreach (Card card in cards1)
                Console.Write(card.ID + " "+card.Name + " " + 
                    card.Description + " " + 
                    card.Done +" "+
                    card.Priority+" "+
                    card.GetDateChanged+"\n");
        }

        private void PrintCard(Card card)
        {
            Console.WriteLine("\nNew Card:\n" +
                "Имя: {0}\n" +
                "Описание: {1}\n" +
                "Выполнена: {2}\n" +
                "Приоритет: {3}\n" +
                "Дата обновления: {4}\n" +
                "ID: {5}",
                card.Name,card.Description,
                card.Done,card.Priority,
                card.GetDateChanged,card.ID);
        }
    }
}
