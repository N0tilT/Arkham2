using System;
using System.Collections;

namespace TimelonCl
{
    /// <summary>
    /// Класс различных вспомогательных функций
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Глобальный генератор псевдо-случайных чисел
        /// </summary>
        private static readonly Random _random = new Random();

        /// <summary>
        /// Доступ к генератору псевдо-случайных чисел
        /// </summary>
        public static Random Random => _random;

        /// <summary>
        /// Получить следующее случайное булевое значение
        /// </summary>
        /// <returns>Случайное булевое значение</returns>
        public static bool NextBool()
        {
            return Random.Next(2) == 1;
        }

        /// <summary>
        /// Получить следующую случайную строку заданной длины
        /// </summary>
        /// <param name="minLength">Минимальная длина</param>
        /// <param name="maxLength">Максимальная длина</param>
        /// <returns>Случайная строка</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string NextString(int minLength, int maxLength = 64)
        {
            if (minLength < 0 || minLength > maxLength)
            {
                throw new ArgumentOutOfRangeException("minLength не может быть отрицательным числом или превышать maxLength");
            }

            string str = "";
            int length = Random.Next(minLength, maxLength);

            for (int i = 0; i < length; i++)
            {
                str += Convert.ToChar(Random.Next(0, 26) + 65);
            }

            return str;
        }

        /// <summary>
        /// Получить следующий случайный индекс заданной коллекции
        /// </summary>
        /// <param name="col">Коллекция</param>
        /// <returns>Случайный индекс</returns>
        public static int NextCollectionIndex(ICollection col)
        {
            return Random.Next(col.Count);
        }

        /// <summary>
        /// Получить следующие случайные дату и время текущего года
        /// </summary>
        /// <returns>Случайные дата и время</returns>
        public static DateTime NextDateTime()
        {
            int year = DateTime.Today.Year;

            DateTime minDate = new DateTime(year, 1, 1);
            DateTime maxDate = new DateTime(year, 12, DateTime.DaysInMonth(year, 12));

            return NextDateTime(minDate, maxDate);
        }

        /// <summary>
        /// Получить следующие случайные дату и время в заданном промежутке
        /// </summary>
        /// <param name="minDate">Начало</param>
        /// <param name="maxDate">Конец</param>
        /// <returns>Случайные дата и время</returns>
        /// <exception cref="ArgumentException"></exception>
        public static DateTime NextDateTime(DateTime minDate, DateTime maxDate)
        {
            if (minDate >= maxDate)
            {
                throw new ArgumentException("minDate не может быть позже, чем maxDate");
            }
            
            int range = (int)(maxDate - minDate).TotalSeconds;

            return minDate.AddSeconds(Random.Next(range));
        }
    }
}
