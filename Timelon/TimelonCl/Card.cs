using System;

namespace TimelonCl
{
    /// <summary>
    /// Контейнер с датами
    /// TODO: Добавить ToString()
    /// </summary>
    public class DateTimeContainer
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        private readonly DateTime _created;

        /// <summary>
        /// Запланированная дата
        /// </summary>
        private DateTime? _planned = null;

        /// <summary>
        /// Дата последнего обновления
        /// TODO: Значение по-умолчанию равно дате создания?
        /// </summary>
        private DateTime? _updated = null;

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        /// <param name="created">Дата создания</param>
        public DateTimeContainer(DateTime created)
        {
            _created = created;
        }

        /// <summary>
        /// Конструктор с дополнительными датами
        /// </summary>
        /// <param name="created">Дата создания</param>
        /// <param name="planned">Запланированная дата или null</param>
        /// <param name="updated">Дата последнего обновления или null</param>
        public DateTimeContainer(DateTime created, DateTime? planned, DateTime? updated)
        {
            _created = created;

            Planned = planned;
            Updated = updated;
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

                if (HasPlanned() && value > Planned)
                {
                    throw new ArgumentOutOfRangeException("updated не может быть позже, чем planned");
                }

                _updated = value;
            }
        }

        /// <summary>
        /// Проверить, задана ли запланированная дата
        /// </summary>
        /// <returns>Статус проверки</returns>
        public bool HasPlanned()
        {
            return Planned != null;
        }

        /// <summary>
        /// Проверить, задана ли дата последнего обновления
        /// </summary>
        /// <returns>Статус проверки</returns>
        public bool HasUpdated()
        {
            return Updated != null;
        }
    }

    public class Card
    {
        private int _id;
        private string _name;
        private string _description;
        private bool _isImportant;
        private bool _isCompleted;

        private readonly DateTimeContainer _date;

        public Card(int id, string name, string desc, bool isImportant, bool isCompleted, DateTimeContainer date)
        {
            Id = id;
            Name = name;
            Description = desc;
            IsImportant = isImportant;
            IsCompleted = isCompleted;

            _date = date;
        }

        public Card(int id, string name, string desc = "")
        {
            Id = id;
            Name = name;
            Description = desc;
            IsImportant = false;
            IsCompleted = false;

            _date = DateTimeContainer.Now;
        }

        // Для тестов
        public static Card Random()
        {
            return new Card(
                Util.Random.Next(0, 1024),
                Util.NextString(4, 8),
                Util.NextString(16, 32),
                Util.NextBool(),
                Util.NextBool(),
                new DateTimeContainer(Util.NextDateTime())
            );
        }

        public int Id
        {
            get => _id;
            set
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
                value = value.Trim();

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("name не может быть пустой строкой");
                }

                _name = value;
            }
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

        public DateTimeContainer Date => _date;

        // Для тестов
        // TODO: Использовать xml?
        public override string ToString()
        {
            return $"ID: {Id}\nNAME: {Name}\nDESC: {Description}\nIMPORTANT: {IsImportant}\nCOMPLETE: {IsCompleted}\n" +
                $"CREATED: {Date.Created}\nPLANNED: {Date.Planned}\nUPDATED: {Date.Updated}";
        }
    }
}
