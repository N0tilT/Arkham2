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
                result &= item;
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
                result |= item;
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
        /// <param name="count">Количество булевых переменных (столбцов)</param>
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
        /// Доступ к списку строк таблицы (кортежей)
        /// </summary>
        public Sensor[] Table => _table;

        /// <summary>
        /// Доступ к количеству столбцов таблицы (булевых переменных)
        /// </summary>
        public int Count => Table[0].List.Count();

        /// <summary>
        /// Получить строку таблицы под указанным индексом
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Строка (кортеж)</returns>
        public Sensor Row(int index)
        {
            return Table[index];
        }

        /// <summary>
        /// Получить столбец таблицы под указанным индексом
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Столбец (кортеж)</returns>
        public Sensor Grid(int index)
        {
            int count = Table.Count();
            bool[] list = new bool[count];
            int i = 0;

            foreach (Sensor sensor in Table)
            {
                list[i++] = sensor.List[index];
            }

            return Sensor.Custom(list);
        }

        /// <summary>
        /// Получить новую таблицу с противоположными значениями
        /// </summary>
        /// <returns>Новая таблица с противоположными значениями</returns>
        public TruthTable Negate()
        {
            int count = Table.Count();
            TruthTable table = new TruthTable(Count);

            for (int i = 0; i < count; i++)
            {
                table.Table[i] = Row(i).Negate();
            }

            return table;
        }

        /// <summary>
        /// Применить операцию отрицания к указанному столбцу
        /// </summary>
        /// <returns>Столбец (кортеж) с противоположными значениями</returns>
        public Sensor Negate(int index)
        {
            Sensor sensor = Grid(index);

            return sensor.Negate();
        }

        /// <summary>
        /// Применить операцию конъюнкции
        /// </summary>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor And()
        {
            int count = Table.Count();
            bool[] list = new bool[count];

            for (int i = 0; i < count; i++)
            {
                list[i] = Row(i).And();
            }

            return Sensor.Custom(list);
        }

        /// <summary>
        /// Применить операцию конъюнкции к указанным столбцам
        /// </summary>
        /// <param name="indexX">Первый столбец</param>
        /// <param name="indexY">Второй столбец</param>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor And(int indexX, int indexY)
        {
            Sensor X = Grid(indexX);
            Sensor Y = Grid(indexY);

            int count = X.List.Count();
            bool[] list = new bool[count];

            for (int i = 0; i < count; i++)
            {
                list[i] = Sensor.Custom(new bool[] { X.List[i], Y.List[i] }).And();
            }

            return Sensor.Custom(list);
        }

        /// <summary>
        /// Применить операцию дизъюнкции
        /// </summary>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor Or()
        {
            int count = Table.Count();
            bool[] list = new bool[count];

            for (int i = 0; i < count; i++)
            {
                list[i] = Row(i).Or();
            }

            return Sensor.Custom(list);
        }

        /// <summary>
        /// Применить операцию дизъюнкции к указанным столбцам
        /// </summary>
        /// <param name="indexX">Первый столбец</param>
        /// <param name="indexY">Второй столбец</param>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor Or(int indexX, int indexY)
        {
            Sensor X = Grid(indexX);
            Sensor Y = Grid(indexY);

            int count = X.List.Count();
            bool[] list = new bool[count];

            for (int i = 0; i < count; i++)
            {
                list[i] = Sensor.Custom(new bool[] { X.List[i], Y.List[i] }).Or();
            }

            return Sensor.Custom(list);
        }

        public override string ToString()
        {
            return string.Join("\r\n", Table.Select(x => x.ToString()));
        }
    }
}
