using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;

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
        private readonly List<CardList> _list = new List<CardList>();

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
            _list = list;
        }

        /// <summary>
        /// Доступ к спискам карт
        /// </summary>
        public List<CardList> All => _list;

        /// <summary>
        /// Получить список карт по названию
        /// </summary>
        /// <param name="name">Название списка карт</param>
        /// <returns>Список карт</returns>
        public CardList GetList(string name)
        {
            return _list.Find(item => item.Name == name);
        }

        /// <summary>
        /// Вставить список карт
        /// </summary>
        /// <param name="list">Список карт</param>
        public void SetList(CardList list)
        {
            int index = _list.FindIndex(item => item.Name == list.Name);

            if (index == -1)
            {
                _list.Add(list);
                return;
            }

            _list.Insert(index, list);
        }

        /// <summary>
        /// Удалить список карт по его названию
        /// </summary>
        /// <param name="name">Название списка карт</param>
        /// <returns>Статус успешности удаления</returns>
        public bool RemoveList(string name)
        {
            int index = _list.FindIndex(item => item.Name == name);

            if (index == -1)
            {
                return false;
            }

            _list.RemoveAt(index);
            return true;
        }

        /// <summary>
        /// Проверить, существует ли список карт с указанным названием
        /// </summary>
        /// <param name="name">Название списка карт</param>
        /// <returns>Статус проверки</returns>
        public bool Exists(string name)
        {
            return _list.Any(item => item.Name == name);
        }
    }
}
