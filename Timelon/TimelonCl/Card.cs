using System;

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
        private readonly DateTime _created;

        /// <summary>
        /// Дата последнего обновления
        /// (значение по-умолчанию равно дате создания)
        /// </summary>
        private DateTime _updated;

        /// <summary>
        /// Запланированная дата
        /// </summary>
        private DateTime? _planned = null;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="created">Дата создания</param>
        /// <param name="updated">Дата последнего обновления или null</param>
        /// <param name="planned">Запланированная дата или null</param>
        public DateTimeContainer(DateTime created, DateTime? updated = null, DateTime? planned = null)
        {
            _created = created;

            Updated = updated ?? created;
            Planned = planned;
        }

        /// <summary>
        /// Создание контейнера по-умолчанию с текущей датой
        /// </summary>
        public static DateTimeContainer Now => new DateTimeContainer(DateTime.Now);

        /// <summary>
        /// Доступ к дате создания
        /// </summary>
        public DateTime Created => _created;

        /// <summary>
        /// Доступ к дате последнего обновления
        /// </summary>
        public DateTime Updated
        {
            get => _updated;
            set
            {
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
            return Updated != Created;
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

    public class Card : Unique<Card>
    {
        private int _id;
        private string _name;
        private DateTimeContainer _date;

        private string _description = String.Empty;
        private bool _isImportant = false;
        private bool _isCompleted = false;

        public Card(int id, string name, DateTimeContainer date, string description, bool isImportant, bool isCompleted)
        {
            Id = id;
            Name = name;
            Date = date;

            Description = description;
            IsImportant = isImportant;
            IsCompleted = isCompleted;
        }

        public Card(int id, string name, DateTimeContainer date)
        {
            Id = id;
            Name = name;
            Date = date;
        }

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

        // Для тестов
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

        public int Id
        {
            get => _id;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("id не может быть отрицательным числом");
                }

                _id = value;
            }
        }

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

        public DateTimeContainer Date
        {
            get => _date;
            private set => _date = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value.Trim();
        }

        public bool IsImportant
        {
            get => _isImportant;
            set => _isImportant = value;
        }

        public bool IsCompleted
        {
            get => _isCompleted;
            set => _isCompleted = value;
        }

        public override string ToString()
        {
            string result = $"ID: {Id}\nNAME: {Name}\n{Date}";

            result += !String.IsNullOrWhiteSpace(Description) ? $"\nDESC: {Description}" : "";
            result += IsImportant ? $"\nIMPORTANT: {IsImportant}" : "";
            result += IsCompleted ? $"\nCOMPLETED: {IsCompleted}" : "";

            return result;
        }
    }
}
