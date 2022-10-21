using System;
using System.Collections.Generic;
using System.Linq;

namespace TimelonCl
{
    /// <summary>
    /// Список карт
    /// </summary>
    public class CardList
    {
        /// <summary>
        /// Название списка
        /// </summary>
        private string _name;

        /// <summary>
        /// Хранилище карт
        /// </summary>
        private readonly Dictionary<int, Card> _pool = new Dictionary<int, Card>();

        /// <summary>
        /// Отсортированный по убыванию даты обновления
        /// список идентификаторов карт
        /// (только невыполненные обычные)
        /// </summary>
        private readonly List<int> _idListDefault = new List<int>();

        /// <summary>
        /// Отсортированный по важности и убыванию даты обновления
        /// список идентификаторов карт
        /// (только невыполненные важные)
        /// </summary>
        private readonly List<int> _idListImportant = new List<int>();

        /// <summary>
        /// Отсортированный по статусу выполнения и по убыванию даты обновления
        /// список идентификаторов карт
        /// (только выполненные)
        /// </summary>
        private readonly List<int> _idListCompleted = new List<int>();

        /// <summary>
        /// Статус сортировки
        /// TODO: Использовать enum для переключения статуса
        /// </summary>
        private bool _isSorted = false;

        /// <summary>
        /// Конструктор пустого списка
        /// </summary>
        /// <param name="name">Название списка</param>
        public CardList(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Конструктор списка из заданного списка карт
        /// </summary>
        /// <param name="name">Название списка</param>
        /// <param name="list">Список карт</param>
        public CardList(string name, List<Card> list) : this(name)
        {
            foreach (Card card in list)
            {
                Set(card);
            }
        }

        /// <summary>
        /// Доступ к названию списка
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                value = value.Trim();

                if (value.Length == 0)
                {
                    throw new ArgumentException("name не может быть пустой строкой");
                }

                _name = value;
            }
        }

        /// <summary>
        /// Доступ к хранилищу карт
        /// </summary>
        public Dictionary<int, Card> All => _pool;

        /// <summary>
        /// Получить карту из хранилища по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор карты</param>
        /// <returns>Объект карты</returns>
        public Card Get(int id)
        {
            return _pool[id];
        }

        /// <summary>
        /// Получить отсортированный по убыванию
        /// даты обновления список карт
        /// (только невыполненные обычные)
        /// </summary>
        /// <returns>Список карт</returns>
        public List<Card> GetListDefault()
        {
            if (!_isSorted)
            {
                Sort();
            }

            List<Card> result = new List<Card>();

            foreach (int id in _idListDefault)
            {
                result.Add(Get(id));
            }

            return result;
        }

        /// <summary>
        /// Получить отсортированный по важности
        /// и по убыванию даты обновления список карт
        /// (только невыполненные важные)
        /// </summary>
        /// <returns>Список карт</returns>
        public List<Card> GetListImportant()
        {
            if (!_isSorted)
            {
                Sort();
            }

            List<Card> result = new List<Card>();

            foreach (int id in _idListImportant)
            {
                result.Add(Get(id));
            }

            return result;
        }

        /// <summary>
        /// Получить отсортированный по статусу выполнения
        /// и по убыванию даты обновления список карт
        /// (только выполненные)
        /// </summary>
        /// <returns>Список карт</returns>
        public List<Card> GetListCompleted()
        {
            if (!_isSorted)
            {
                Sort();
            }

            List<Card> result = new List<Card>();

            foreach (int id in _idListCompleted)
            {
                result.Add(Get(id));
            }

            return result;
        }

        /// <summary>
        /// Получить список карт по части названия или описания
        /// </summary>
        /// <param name="content">Часть названия или описания карты</param>
        /// <returns>Список карт</returns>
        public List<Card> SearchByContent(string content)
        {
            List<Card> result = new List<Card>();
            content = content.ToLower();

            foreach (KeyValuePair<int, Card> card in _pool.AsQueryable().Where(item =>
                item.Value.Name.ToLower().Contains(content) ||
                item.Value.Description.ToLower().Contains(content))
            )
            {
                result.Add(card.Value);
            }

            return result;
        }

        /// <summary>
        /// Сохранить карту
        /// </summary>
        /// <param name="card">Объект карты</param>
        public void Set(Card card)
        {
            _isSorted = false;
            _pool[card.Id] = card;
        }

        /// <summary>
        /// Удалить карту с заданным идентификатором
        /// </summary>
        /// <param name="id">Идентификатор карты</param>
        /// <returns>Статус успеха удаления</returns>
        public bool Remove(int id)
        {
            _isSorted = false;

            return _pool.Remove(id);
        }

        /// <summary>
        /// Отсортировать списки идентификаторов по убыванию
        /// TODO: Оценить скорость
        /// </summary>
        private void Sort()
        {
            List<Card> listPriority = new List<Card>();

            _idListDefault.Clear();
            _idListImportant.Clear();
            _idListCompleted.Clear();

            // HACK: Найти способ связать updated и created
            foreach (KeyValuePair<int, Card> card in _pool.OrderByDescending(item => item.Value.Date.Updated))
            {
                // Наполнение списка идентификаторов для выполненных
                if (card.Value.IsCompleted == true)
                {
                    _idListCompleted.Add(card.Key);
                    continue;
                }

                // Наполнение списка идентификаторов для важных
                if (card.Value.IsImportant == true)
                {
                    _idListImportant.Add(card.Key);
                    continue;
                }

                // Идентификаторы остальных в общий список
                _idListDefault.Add(card.Key);
            }

            _isSorted = true;
        }
    }
}
