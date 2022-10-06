using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimelonCl;

namespace TimelonCl
{
    public class CardList
    {
        List<Card> cards = new List<Card>();

        public CardList()
        {
        }
        public CardList(List<Card> list)
        {
            cards = list;
        }

        public void Add(Card card)
        {
            cards.Add(card);
        }

        public void Delete(Card card)
        {
            cards.Remove(card) ;
        }

        public void Sort()
        {

        }

        public List<Card> All
        {
            get { return cards; }
        }

        //сортировки
        //отображение конкретных


    }
}
