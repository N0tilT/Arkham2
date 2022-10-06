using System;

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
        private static readonly Random _rnd = new Random();

        /// <summary>
        /// Получить генератор псевдо-случайных чисел
        /// </summary>
        /// <returns>Объект генератора</returns>
        public static Random Random()
        {
            return _rnd;
        }

        /// <summary>
        /// Получить следующее случайное булевое значение
        /// </summary>
        /// <returns>Случайное булевое значение</returns>
        public static bool RandomBool()
        {
            return _rnd.Next(2) == 1;
        }
        
        /// <summary>
        /// Получить следующую случайную строку заданной длины
        /// </summary>
        /// <param name="minLength">Минимальная длина</param>
        /// <param name="maxLength">Максимальная длина</param>
        /// <returns>Случайная строка</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string RandomString(int minLength, int maxLength = 64)
        {
            if (minLength < 0 || minLength > maxLength)
            {
                throw new ArgumentOutOfRangeException("minLength не может быть отрицательным числом или превышать maxLength");
            }

            string str = "";
            int length = _rnd.Next(minLength, maxLength);

            for (int i = 0; i < length; i++)
            {
                str += Convert.ToChar(_rnd.Next(0, 26) + 65);
            }

            return str;
        }

        /// <summary>
        /// Получить следующую случайную дату текущего года
        /// </summary>
        /// <returns>Случайная дата</returns>
        public static DateTime RandomDateTime()
        {
            DateTime today = DateTime.Today;

            return new DateTime(today.Year, _rnd.Next(1, 12), _rnd.Next(1, 28));
        }
    }
}
