﻿using System.Collections.Generic;

namespace TimelonCl
{
    /// <summary>
    /// Менеджер списков карт
    /// </summary>
    public class CardListManager
    {
        /// <summary>
        /// Списки карт
        /// </summary>
        private readonly SortedList<int, CardList> _list = new SortedList<int, CardList>();

        /// <summary>
        /// Конструктор менеджера списков карт
        /// </summary>
        /// <param name="list">Списки карт</param>
        public CardListManager(List<CardList> list)
        {
            foreach (CardList item in list)
            {
                SetList(item);
            }
        }

        /// <summary>
        /// Конструктор пустого менеджера
        /// </summary>
        public CardListManager() { }

        /// <summary>
        /// Доступ к спискам карт
        /// </summary>
        public SortedList<int, CardList> All => _list;

        /// <summary>
        /// Получить список карт по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор списка карт</param>
        /// <returns>Список карт</returns>
        public CardList GetList(int id)
        {
            return _list[id];
        }

        /// <summary>
        /// Вставить список карт
        /// </summary>
        /// <param name="list">Список карт</param>
        public void SetList(CardList list)
        {
            _list[list.Id] = list;
        }

        /// <summary>
        /// Удалить список карт по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор списка карт</param>
        /// <returns>Статус успешности удаления</returns>
        public bool RemoveList(int id)
        {
            return _list.Remove(id);
        }

        /// <summary>
        /// Поиск по части названия или описания по всем подспискам
        /// </summary>
        /// <param name="content">искомое значение</param>
        /// <returns>Список найденных карт</returns>
        public List<Card> SearchByContent(string content)
        {
            List<Card> result = new List<Card>();

            foreach(KeyValuePair<int,CardList> item in _list)
            {
                List<Card> found = item.Value.SearchByContent(content);

                foreach (Card card in found)
                {
                    result.Add(card);
                }
            }

            return result;
        }
    }
}
