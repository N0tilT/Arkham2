using System;
using System.IO;
using System.Xml.Serialization;

namespace TimelonCl
{
    /// <summary>
    /// Контейнер с датами
    /// </summary>
    public class DateTimeContainer
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        private DateTime _created;

        /// <summary>
        /// Дата последнего обновления
        /// </summary>
        private DateTime? _updated = null;

        /// <summary>
        /// Запланированная дата
        /// </summary>
        private DateTime? _planned = null;

        /// <summary>
        /// Основной конструктор
        /// </summary>
        /// <param name="created">Дата создания</param>
        /// <param name="updated">Дата последнего обновления или null</param>
        /// <param name="planned">Запланированная дата или null</param>
        public DateTimeContainer(DateTime created, DateTime? updated = null, DateTime? planned = null)
        {
            _created = created;

            Updated = updated;
            Planned = planned;
        }

        /// <summary>
        /// Пустой конструктор для корректной сериализации
        /// </summary>
        public DateTimeContainer() => throw new InvalidOperationException();

        /// <summary>
        /// Создание контейнера по-умолчанию с текущей датой
        /// </summary>
        public static DateTimeContainer Now => new DateTimeContainer(DateTime.Now);

        /// <summary>
        /// Доступ к дате создания
        /// Сеттер заблокирован и служит для сериализации
        /// </summary>
        public DateTime Created
        {
            get => _created;
            set => throw new InvalidOperationException();
        }

        /// <summary>
        /// Доступ к дате последнего обновления
        /// </summary>
        public DateTime? Updated
        {
            get => _updated;
            set
            {
                if (value == null)
                {
                    _updated = value;
                    return;
                }

                if (value < _created)
                {
                    throw new ArgumentOutOfRangeException("updated не может быть раньше, чем created");
                }

                _updated = value;
            }
        }

        /// <summary>
        /// Доступ к запланированной дате
        /// </summary>
        public DateTime? Planned
        {
            get => _planned;
            set
            {
                if (value == null)
                {
                    _planned = value;
                    return;
                }
                
                if (value < _created)
                {
                    throw new ArgumentOutOfRangeException("planned не может быть раньше, чем created");
                }

                _planned = value;
            }
        }

        /// <summary>
        /// Проверить, задана ли дата последнего обновления
        /// </summary>
        /// <returns>Статус проверки</returns>
        public bool HasUpdated()
        {
            return Updated != null;
        }

        /// <summary>
        /// Проверить, задана ли запланированная дата
        /// </summary>
        /// <returns>Статус проверки</returns>
        public bool HasPlanned()
        {
            return Planned != null;
        }

        public override string ToString()
        {
            string result = $"CREATED: {Created}";

            result += HasUpdated() ? $"\nUPDATED: {Updated}" : "";
            result += HasPlanned() ? $"\nPLANNED: {Planned}" : "";

            return result;
        }
    }

    /// <summary>
    /// Карта
    /// </summary>
    [Serializable]
    public class Card : Unique<Card>
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        private int _id;

        /// <summary>
        /// Название
        /// </summary>
        private string _name;

        /// <summary>
        /// Контейнер с датами
        /// </summary>
        private DateTimeContainer _date;

        /// <summary>
        /// Описание
        /// </summary>
        private string _description = String.Empty;

        /// <summary>
        /// Статус важности
        /// </summary>
        private bool _isImportant = false;

        /// <summary>
        /// Статус выполнения
        /// </summary>
        private bool _isCompleted = false;

        /// <summary>
        /// Расширенный конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Название</param>
        /// <param name="date">Контейнер с датами</param>
        /// <param name="description">Описание</param>
        /// <param name="isImportant">Статус важности</param>
        /// <param name="isCompleted">Статус выполнения</param>
        public Card(int id, string name, DateTimeContainer date, string description, bool isImportant, bool isCompleted) : this(id, name, date)
        {
            Description = description;
            IsImportant = isImportant;
            IsCompleted = isCompleted;
        }

        /// <summary>
        /// Базовый конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Название</param>
        /// <param name="date">Контейнер с датами</param>
        /// <exception cref="ArgumentException"></exception>
        public Card(int id, string name, DateTimeContainer date)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name не может быть пустой строкой");
            }

            _id = id;
            _name = name.Trim();
            _date = date;
        }

        /// <summary>
        /// Пустой конструктор для корректной сериализации
        /// </summary>
        public Card() => throw new InvalidOperationException();

        /// <summary>
        /// Создать новую карту
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="created">Дата создания или null</param>
        /// <returns>Новая карта</returns>
        public static Card Make(string name, DateTime? created = null)
        {
            DateTimeContainer date = new DateTimeContainer(created ?? DateTime.Now);

            return new Card(UniqueId(), name, date);
        }

        /// <summary>
        /// Создать новую случайную карту
        /// </summary>
        /// <returns>Карта со случайными данными</returns>
        public static Card Random()
        {
            return new Card(
                UniqueId(),
                Util.NextString(4, 8),
                new DateTimeContainer(Util.NextDateTime()),
                Util.NextString(16, 32),
                Util.NextBool(),
                Util.NextBool()
            );
        }

        /// <summary>
        /// Доступ к уникальному идентификатору
        /// Сеттер заблокирован и служит для сериализации
        /// </summary>
        [XmlAttribute]
        public int Id
        {
            get => _id;
            set => throw new InvalidOperationException();
        }

        /// <summary>
        /// Доступ к названию
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
        /// Доступ к контейнеру с датами
        /// Сеттер заблокирован и служит для сериализации
        /// </summary>
        public DateTimeContainer Date
        {
            get => _date;
            set => throw new InvalidOperationException();
        }

        /// <summary>
        /// Доступ к описанию
        /// </summary>
        public string Description
        {
            get => _description;
            set => _description = value.Trim();
        }

        /// <summary>
        /// Доступ к статусу важности
        /// </summary>
        public bool IsImportant
        {
            get => _isImportant;
            set => _isImportant = value;
        }

        /// <summary>
        /// Доступ к статусу выполнения
        /// </summary>
        public bool IsCompleted
        {
            get => _isCompleted;
            set => _isCompleted = value;
        }

        /// <summary>
        /// Привести объект к сериализованной в xml формате строке
        /// </summary>
        /// <returns>Строка в xml формате</returns>
        public string ToXmlString()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Card));
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
