using System.Collections.Generic;

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
        /// Конструктор менеджера без списков
        /// </summary>
        public CardListManager() { }

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
    }
}
