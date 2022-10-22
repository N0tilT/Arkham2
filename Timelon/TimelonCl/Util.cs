using System;
using System.Collections;
using System.Collections.Generic;

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
        /// Глобальный список статических счетчиков
        /// </summary>
        private static readonly SortedList<string, int> _incrementor = new SortedList<string, int>();

        /// <summary>
        /// Доступ к генератору псевдо-случайных чисел
        /// </summary>
        public static Random Random => _random;

        /// <summary>
        /// Доступ к списку статических счетчиков
        /// </summary>
        public static SortedList<string, int> Incrementor => _incrementor;

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
        /// Получить следующую случайную дату текущего года
        /// TODO: Добавить возможность задавать временные рамки
        /// </summary>
        /// <returns>Случайная дата</returns>
        public static DateTime NextDateTime()
        {
            int year = DateTime.Today.Year;
            int month = Random.Next(1, 12);
            int day = Random.Next(1, DateTime.DaysInMonth(year, month));

            return new DateTime(year, month, day);
        }

        /// <summary>
        /// Получить уникальный идентификатор для указанного типа данных
        /// </summary>
        /// <param name="type">Задекларированный тип</param>
        /// <returns>Уникальный идентификатор</returns>
        public static int UniqueId(Type type)
        {
            string key = type.Name;
            
            if (!Incrementor.ContainsKey(key))
            {
                Incrementor.Add(key, 0);
            }

            return Incrementor[key]++;
        }
    }
}
