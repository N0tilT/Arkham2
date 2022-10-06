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
        List<Card> _list = new List<Card>();

        public CardList()
        {}
        public CardList(List<Card> list)
        {
            _list = list;
        }

        public void Add(Card card)
        {
            _list.Add(card);
        }

        public void Delete(Card card)
        {
            _list.Remove(card);
        }

        public void Sort()
        {}

        public List<Card> All
        {
            get { return _list; }
        }

        //сортировки
        //отображение конкретных
    }
}
