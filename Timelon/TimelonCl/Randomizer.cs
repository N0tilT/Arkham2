using System;
using System.Collections;

namespace TimelonCl
{
    /// <summary>
    /// Дополненный генератор псевдо-случайных чисел
    /// </summary>
    public class ExtendedRandom : Random
    {
        /// <summary>
        /// Получить следующее случайное булевое значение
        /// </summary>
        /// <returns>Случайное булевое значение</returns>
        public bool NextBool()
        {
            return Next(2) == 1;
        }

        /// <summary>
        /// Получить следующую случайную строку заданной длины
        /// </summary>
        /// <param name="minLength">Минимальная длина</param>
        /// <param name="maxLength">Максимальная длина</param>
        /// <returns>Случайная строка</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string NextString(int minLength, int maxLength = 64)
        {
            if (minLength < 0 || minLength > maxLength)
            {
                throw new ArgumentOutOfRangeException("minLength не может быть отрицательным числом или превышать maxLength");
            }

            string str = String.Empty;
            int length = Next(minLength, maxLength);

            for (int i = 0; i < length; i++)
            {
                // Английский алфавит в верхнем регистре
                str += Convert.ToChar(Next(0, 26) + 65);
            }

            return str;
        }

        /// <summary>
        /// Получить следующий случайный индекс заданной коллекции
        /// </summary>
        /// <param name="col">Коллекция</param>
        /// <returns>Случайный индекс</returns>
        public int NextCollectionIndex(ICollection col)
        {
            return Next(col.Count);
        }

        /// <summary>
        /// Получить следующие случайные дату и время в заданном промежутке
        /// </summary>
        /// <param name="minDate">Начало</param>
        /// <param name="maxDate">Конец</param>
        /// <returns>Случайные дата и время</returns>
        /// <exception cref="ArgumentException"></exception>
        public DateTime NextDateTime(DateTime minDate, DateTime maxDate)
        {
            if (minDate >= maxDate)
            {
                throw new ArgumentException("minDate не может быть позже, чем maxDate");
            }

            int range = (int)(maxDate - minDate).TotalSeconds;

            return minDate.AddSeconds(Next(range));
        }

        /// <summary>
        /// Получить следующие случайные дату и время текущего года
        /// </summary>
        /// <returns>Случайные дата и время</returns>
        public DateTime NextDateTime()
        {
            int year = DateTime.Today.Year;

            DateTime minDate = new DateTime(year, 1, 1);
            DateTime maxDate = new DateTime(year, 12, DateTime.DaysInMonth(year, 12));

            return NextDateTime(minDate, maxDate);
        }
    }

    /// <summary>
    /// Глобальная точка доступа к генератору псевдо-случайных чисел
    /// </summary>
    public static class Randomizer
    {
        /// <summary>
        /// Глобальный дополненный генератор псевдо-случайных чисел
        /// </summary>
        private static readonly ExtendedRandom _random = new ExtendedRandom();

        /// <summary>
        /// Доступ к дополненному генератору псевдо-случайных чисел
        /// </summary>
        public static ExtendedRandom Random => _random;
    }
}
