using System;
using System.Windows.Media;

namespace TimelonCl
{
    /// <summary>
    /// Список идентификаторов приоритетов
    /// TODO: Переименовать константы
    /// </summary>
    public enum PriorityId
    {
        DEFAULT,
        HIGH,
        HIGHER,
        HIGHERER,
        HIGHEST
    }

    /// <summary>
    /// Класс приоритетов
    /// </summary>
    public class CardPriority
    {
        /// <summary>
        /// Список имен приоритетов
        /// TODO: Переименовать
        /// </summary>
        public static readonly string[] NameList = new string[]
        {
            "Обычный",
            "Важный",
            "Важнее важного",
            "Очень важный",
            "Самый важный"
        };

        /// <summary>
        /// Список цветов приоритетов
        /// TODO: Проверить
        /// </summary>
        public static readonly Color[] ColorList = new Color[]
        {
            Color.FromRgb(0, 255, 255), // Бирюзовый
            Color.FromRgb(0, 255, 0),   // Зелёный
            Color.FromRgb(255, 255, 0), // Жёлтый
            Color.FromRgb(255, 125, 0), // Оранжевый
            Color.FromRgb(255, 0, 0)    // Красный
        };

        /// <summary>
        /// Идентификатор приоритета
        /// </summary>
        private PriorityId _id;

        /// <summary>
        /// Основной конструктор приоритета
        /// </summary>
        /// <param name="id">Идентификатор приоритета</param>
        public CardPriority(PriorityId id)
        {
            _id = id;
        }

        /// <summary>
        /// Получить случайный идентификатор приоритета
        /// </summary>
        /// <returns>Случайный идентификатор приоритета</returns>
        public static PriorityId RandomId()
        {
            int[] val = (int[]) Enum.GetValues(typeof(PriorityId));

            return (PriorityId) Util.NextCollectionIndex(val);
        }

        /// <summary>
        /// Получить случайный приоритет
        /// </summary>
        /// <returns>Случайный приоритет</returns>
        public static CardPriority Random()
        {
            return new CardPriority(RandomId());
        }

        /// <summary>
        /// Доступ к идентификатору приоритета
        /// </summary>
        public PriorityId Id => _id;

        /// <summary>
        /// Доступ к имени приоритета
        /// </summary>
        public string Name => NameList[(int) _id];

        /// <summary>
        /// Доступ к цвету приоритета
        /// </summary>
        public Color Color => ColorList[(int) _id];

        public override string ToString()
        {
            return Name;
        }
    }
}
