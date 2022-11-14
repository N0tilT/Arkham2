using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace TimelonCl
{
    /// <summary>
    /// Статус / направление сортировки
    /// </summary>
    public enum SortOrder
    {
        Initial,
        Unsorted,
        Ascending,
        Descending
    }

    /// <summary>
    /// Список карт
    /// </summary>
    [Serializable]
    public class CardList : Unique<CardList>
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        private int _id;
        
        /// <summary>
        /// Название списка
        /// </summary>
        private string _name;

        /// <summary>
        /// Хранилище карт
        /// </summary>
        private readonly Dictionary<int, Card> _pool = new Dictionary<int, Card>();

        /// <summary>
        /// Отсортированный по дате обновления
        /// список идентификаторов карт
        /// (только невыполненные обычные)
        /// </summary>
        private readonly List<int> _idListDefault = new List<int>();

        /// <summary>
        /// Отсортированный по важности и дате обновления
        /// список идентификаторов карт
        /// (только невыполненные важные)
        /// </summary>
        private readonly List<int> _idListImportant = new List<int>();

        /// <summary>
        /// Отсортированный по статусу выполнения и дате обновления
        /// список идентификаторов карт
        /// (только выполненные)
        /// </summary>
        private readonly List<int> _idListCompleted = new List<int>();

        /// <summary>
        /// Статус сортировки
        /// </summary>
        private SortOrder _status = SortOrder.Initial;

        /// <summary>
        /// Конструктор списка из заданного списка карт
        /// </summary>
        /// <param name="id">Уникальный идентификатор</param>
        /// <param name="name">Название списка</param>
        /// <param name="list">Список карт</param>
        public CardList(int id, string name, List<Card> list) : this(id, name)
        {
            foreach (Card card in list)
            {
                Set(card);
            }
        }

        /// <summary>
        /// Конструктор пустого списка
        /// </summary>
        /// <param name="id">Уникальный идентификатор</param>
        /// <param name="name">Название списка</param>
        /// <exception cref="ArgumentException"></exception>
        public CardList(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name не может быть пустой строкой");
            }

            _id = id;
            _name = name.Trim();
        }

        /// <summary>
        /// Пустой конструктор для корректной сериализации
        /// </summary>
        public CardList()
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Создать новый список карт
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Новый список карт</returns>
        public static CardList Make(string name)
        {
            return new CardList(UniqueId(), name);
        }

        /// <summary>
        /// Доступ к идентификатору списка
        /// Сеттер заблокирован и служит для сериализации
        /// </summary>
        [XmlAttribute]
        public int Id
        {
            get => _id;
            set => throw new InvalidOperationException();
        }

        /// <summary>
        /// Доступ к названию списка
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("name не может быть пустой строкой");
                }

                _name = value.Trim();
            }
        }

        /// <summary>
        /// Доступ к хранилищу карт
        /// </summary>
        [XmlIgnore]
        public Dictionary<int, Card> All => _pool;

        /// <summary>
        /// Доступ к библиотеке в виде списка
        /// Сеттер заблокирован и служит для сериализации
        /// </summary>
        public List<Card> List
        {
            get
            {
                List<Card> result = new List<Card>();

                foreach (KeyValuePair<int, Card> item in All)
                {
                    result.Add(item.Value);
                }

                return result;
            }
            set => throw new InvalidOperationException();
        }

        /// <summary>
        /// Доступ к статусу сортировки
        /// </summary>
        [XmlIgnore]
        public SortOrder Status
        {
            get => _status;
            private set => _status = value;
        }

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
        /// Получить отсортированный
        /// по дате обновления список карт
        /// (только невыполненные обычные)
        /// </summary>
        /// <param name="order">Направление сортировки</param>
        /// <returns>Список карт</returns>
        public List<Card> GetListDefault(SortOrder order = SortOrder.Descending)
        {
            if (order != Status)
            {
                Sort(order);
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
        /// и дате обновления список карт
        /// (только невыполненные важные)
        /// </summary>
        /// <param name="order">Направление сортировки</param>
        /// <returns>Список карт</returns>
        public List<Card> GetListImportant(SortOrder order = SortOrder.Descending)
        {
            if (order != Status)
            {
                Sort(order);
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
        /// и дате обновления список карт
        /// (только выполненные)
        /// </summary>
        /// <param name="order">Направление сортировки</param>
        /// <returns>Список карт</returns>
        public List<Card> GetListCompleted(SortOrder order = SortOrder.Descending)
        {
            if (order != Status)
            {
                Sort(order);
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
            content = content.Trim().ToLower();

            List<Card> result = new List<Card>();
            IEnumerable<KeyValuePair<int, Card>> source = _pool.AsQueryable().Where(
                item => item.Value.Name.ToLower().Contains(content) ||
                item.Value.Description.ToLower().Contains(content));

            foreach (KeyValuePair<int, Card> card in source)
            {
                result.Add(card.Value);
            }

            return result;
        }

        /// <summary>
        /// Получить список карт по дате обновления в заданном промежутке
        /// </summary>
        /// <param name="minDate">Начало</param>
        /// <param name="maxDate">Конец</param>
        /// <returns>Список карт</returns>
        public List<Card> SearchByDateUpdated(DateTime minDate, DateTime maxDate)
        {
            List<Card> result = new List<Card>();
            IEnumerable<KeyValuePair<int, Card>> source = _pool.AsQueryable().Where(
                item => minDate <= item.Value.Date.Updated && maxDate >= item.Value.Date.Updated);

            foreach (KeyValuePair<int, Card> card in source)
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
            Status = SortOrder.Initial;
            _pool[card.Id] = card;
        }

        /// <summary>
        /// Удалить карту с заданным идентификатором
        /// </summary>
        /// <param name="id">Идентификатор карты</param>
        /// <returns>Статус успеха удаления</returns>
        public bool Remove(int id)
        {
            Status = SortOrder.Initial;

            return _pool.Remove(id);
        }

        /// <summary>
        /// Выбрать подходящий источник для указанного направления сортировки
        /// </summary>
        /// <param name="order">Направление сортировки</param>
        /// <returns>Источник</returns>
        private IEnumerable<KeyValuePair<int, Card>> Source(SortOrder order)
        {
            if (order == SortOrder.Unsorted)
            {
                return All;
            }

            if (order == SortOrder.Ascending)
            {
                return All.OrderBy(item => item.Value.Date.Updated ?? item.Value.Date.Created);
            }

            return All.OrderByDescending(item => item.Value.Date.Updated ?? item.Value.Date.Created);
        }

        /// <summary>
        /// Определить идентификатор карты в один из списков для сортировки
        /// </summary>
        /// <param name="card">Карта</param>
        private void Cache(Card card)
        {
            if (card.IsCompleted == true)
            {
                _idListCompleted.Add(card.Id);
                return;
            }

            if (card.IsImportant == true)
            {
                _idListImportant.Add(card.Id);
                return;
            }

            _idListDefault.Add(card.Id);
        }

        /// <summary>
        /// Отсортировать списки идентификаторов
        /// TODO: Оценить скорость
        /// </summary>
        /// <param name="order">Направление сортировки</param>
        private void Sort(SortOrder order)
        {
            _idListDefault.Clear();
            _idListImportant.Clear();
            _idListCompleted.Clear();

            foreach (KeyValuePair<int, Card> item in Source(order))
            {
                Cache(item.Value);
            }

            Status = order;
        }

        /// <summary>
        /// Привести объект к сериализованной в xml формате строке
        /// </summary>
        /// <returns>Строка в xml формате</returns>
        public string ToXmlString()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CardList));
            StringWriter writer = new StringWriter();

            serializer.Serialize(writer, this);

            string result = writer.ToString();

            writer.Close();

            return result;
        }

        public override string ToString()
        {
            return ToXmlString();
        }
    }
}
