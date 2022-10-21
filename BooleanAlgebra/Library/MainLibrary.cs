using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class MainLibrary
    {
        // Английский алфавит
        public const int COUNT_MIN = 1;
        public const int COUNT_MAX = 26;
    }

    /// <summary>
    /// Кортеж булевых значений
    /// </summary>
    public struct Sensor
    {
        /// <summary>
        /// Список булевых значений
        /// </summary>
        private readonly bool[] _list;

        /// <summary>
        /// Конструктор кортежа
        /// </summary>
        /// <param name="count">Количество булевых переменных</param>
        public Sensor(int count)
        {
            _list = new bool[count];
        }

        /// <summary>
        /// Настраиваемый конструктор кортежа
        /// </summary>
        /// <param name="list">Список булевых значений</param>
        /// <returns>Объект кортежа</returns>
        public static Sensor Custom(bool[] list)
        {
            int count = list.Count();
            Sensor sensor = new Sensor(count);

            for (int i = 0; i < count; i++)
            {
                sensor.List[i] = list[i];
            }

            return sensor;
        }

        /// <summary>
        /// Доступ к списку булевых значений
        /// </summary>
        public bool[] List => _list;

        /// <summary>
        /// Сравнить все значения кортежа с указанным значением
        /// </summary>
        /// <param name="state">Значение</param>
        /// <returns>Статус сравнения</returns>
        public bool All(bool state)
        {
            return List.All(item => item == state);
        }

        /// <summary>
        /// Сравнить с другим кортежем
        /// </summary>
        /// <param name="sensor">Кортеж булевых значений</param>
        /// <returns>Статус сравнения</returns>
        public bool Compare(Sensor sensor)
        {
            return sensor.List.SequenceEqual(List);
        }

        /// <summary>
        /// Получить новый кортеж с противоположными значениями
        /// </summary>
        /// <returns>Новый кортеж с противоположными значениями</returns>
        public Sensor Negate()
        {
            int count = List.Count();
            bool[] result = new bool[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = !List[i];
            }

            return Custom(result);
        }

        /// <summary>
        /// Применить операцию конъюнкции
        /// </summary>
        /// <returns>Статус операции</returns>
        public bool And()
        {
            bool result = List[0];

            foreach (bool item in List.Skip(1))
            {
                result = result && item;
            }

            return result;
        }

        /// <summary>
        /// Применить операцию дизъюнкции
        /// </summary>
        /// <returns>Статус операции</returns>
        public bool Or()
        {
            bool result = List[0];

            foreach (bool item in List.Skip(1))
            {
                result = result || item;
            }

            return result;
        }

        public override string ToString()
        {
            return string.Join(" ", List.Select(x => x == true ? 1 : 0));
        }
    }

    /// <summary>
    /// Таблица истинности
    /// </summary>
    public struct TruthTable
    {
        /// <summary>
        /// Список кортежей
        /// </summary>
        private readonly Sensor[] _table;

        /// <summary>
        /// Конструктор таблицы
        /// </summary>
        /// <param name="count">Количество булевых переменных</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public TruthTable(int count)
        {
            if (count < MainLibrary.COUNT_MIN || count > MainLibrary.COUNT_MAX)
            {
                throw new ArgumentOutOfRangeException();
            }

            int powered = (int)Math.Pow(2, count);
            _table = new Sensor[powered];

            for (int i = 0; i < powered; i++)
            {
                _table[i] = new Sensor(count);

                for (int j = 0; j < count; j++)
                {
                    _table[i].List[count - (j + 1)] = (i / (int)Math.Pow(2, j)) % 2 == 1;
                }
            }
        }

        /// <summary>
        /// Получить новую таблицу с противоположными значениями
        /// </summary>
        /// <returns>Новая таблица с противоположными значениями</returns>
        public TruthTable Negate()
        {
            int count = Table.Count();
            TruthTable table = new TruthTable(count);

            for (int i = 0; i < count; i++)
            {
                table.Table[i] = Table[i].Negate();
            }

            return table;
        }

        /// <summary>
        /// Применить операцию конъюнкции
        /// </summary>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor And()
        {
            bool[] list = new bool[Table.Count()];

            foreach (Sensor sensor in Table)
            {
                list.Append(sensor.And());
            }

            return Sensor.Custom(list);
        }

        /// <summary>
        /// Применить операцию дизъюнкции
        /// </summary>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor Or()
        {
            bool[] list = new bool[Table.Count()];

            foreach (Sensor sensor in Table)
            {
                list.Append(sensor.Or());
            }

            return Sensor.Custom(list);
        }

        /// <summary>
        /// Доступ к списку кортежей
        /// </summary>
        public Sensor[] Table => _table;

        public override string ToString()
        {
            return string.Join("\n", Table.Select(x => x.ToString()));
        }
    }
}
