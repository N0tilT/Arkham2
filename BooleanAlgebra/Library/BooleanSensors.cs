using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BooleanSensors
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
        /// Применить операцию импликации
        /// </summary>
        /// <returns>Статус операции</returns>
        public bool Implicate()
        {
            bool result = List[0];

            foreach (bool item in List.Skip(1))
            {
                result = !result | item;
            }

            return result;
        }

        /// <summary>
        /// Применить операцию эквализации
        /// TODO: эквализация?
        /// </summary>
        /// <returns>Статус операции</returns>
        public bool Equalite()
        {
            bool result = List[0];

            foreach (bool item in List.Skip(1))
            {
                if (result != item)
                {
                    return false;
                }
            }

            return true;
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

        /// <summary>
        /// Применить операцию исключающей дизъюнкции
        /// </summary>
        /// <returns>Статус операции</returns>
        public bool Xor()
        {
            bool result = List[0];

            foreach (bool item in List.Skip(1))
            {
                result = (result & !item) | (!result & item);
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
            if (count < BooleanSensors.COUNT_MIN || count > BooleanSensors.COUNT_MAX)
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
        /// Применить операцию отрицания к указанному столбцу
        /// </summary>
        /// <param name="index">Индекс столбца</param>
        /// <returns>Столбец (кортеж) с противоположными значениями</returns>
        public Sensor Negate(int index)
        {
            return Grid(index).Negate();
        }

        /// <summary>
        /// Применить операцию импликации к кортежам
        /// </summary>
        /// <param name="x">Первый кортеж</param>
        /// <param name="y">Второй кортеж</param>
        /// <returns>Кортеж из статусов операции</returns>
        public static Sensor Implicate(Sensor x, Sensor y)
        {
            int count = x.List.Count();
            bool[] list = new bool[count];

            for (int i = 0; i < count; i++)
            {
                list[i] = Sensor.Custom(new bool[] { x.List[i], y.List[i] }).Implicate();
            }

            return Sensor.Custom(list);
        }

        /// <summary>
        /// Применить операцию импликации к столбцу и кортежу
        /// </summary>
        /// <param name="index">Столбец</param>
        /// <param name="sensor">Кортеж</param>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor Implicate(int index, Sensor sensor)
        {
            return Implicate(Grid(index), sensor);
        }

        /// <summary>
        /// Применить операцию импликации к указанным столбцам
        /// </summary>
        /// <param name="indexX">Первый столбец</param>
        /// <param name="indexY">Второй столбец</param>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor Implicate(int indexX, int indexY)
        {
            return Implicate(Grid(indexX), Grid(indexY));
        }

        /// <summary>
        /// Применить операцию эквализации к кортежам
        /// </summary>
        /// <param name="x">Первый кортеж</param>
        /// <param name="y">Второй кортеж</param>
        /// <returns>Кортеж из статусов операции</returns>
        public static Sensor Equalite(Sensor x, Sensor y)
        {
            int count = x.List.Count();
            bool[] list = new bool[count];

            for (int i = 0; i < count; i++)
            {
                list[i] = Sensor.Custom(new bool[] { x.List[i], y.List[i] }).Equalite();
            }

            return Sensor.Custom(list);
        }

        /// <summary>
        /// Применить операцию эквализации к столбцу и кортежу
        /// </summary>
        /// <param name="index">Столбец</param>
        /// <param name="sensor">Кортеж</param>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor Equalite(int index, Sensor sensor)
        {
            return Equalite(Grid(index), sensor);
        }

        /// <summary>
        /// Применить операцию эквализации к указанным столбцам
        /// </summary>
        /// <param name="indexX">Первый столбец</param>
        /// <param name="indexY">Второй столбец</param>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor Equalite(int indexX, int indexY)
        {
            return Equalite(Grid(indexX), Grid(indexY));
        }

        /// <summary>
        /// Применить операцию конъюнкции к кортежам
        /// </summary>
        /// <param name="x">Первый кортеж</param>
        /// <param name="y">Второй кортеж</param>
        /// <returns>Кортеж из статусов операции</returns>
        public static Sensor And(Sensor x, Sensor y)
        {
            int count = x.List.Count();
            bool[] list = new bool[count];

            for (int i = 0; i < count; i++)
            {
                list[i] = Sensor.Custom(new bool[] { x.List[i], y.List[i] }).And();
            }

            return Sensor.Custom(list);
        }

        /// <summary>
        /// Применить операцию конъюнкции к столбцу и кортежу
        /// </summary>
        /// <param name="index">Столбец</param>
        /// <param name="sensor">Кортеж</param>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor And(int index, Sensor sensor)
        {
            return And(Grid(index), sensor);
        }

        /// <summary>
        /// Применить операцию конъюнкции к указанным столбцам
        /// </summary>
        /// <param name="indexX">Первый столбец</param>
        /// <param name="indexY">Второй столбец</param>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor And(int indexX, int indexY)
        {
            return And(Grid(indexX), Grid(indexY));
        }

        /// <summary>
        /// Применить операцию дизъюнкции к кортежам
        /// </summary>
        /// <param name="x">Первый кортеж</param>
        /// <param name="y">Второй кортеж</param>
        /// <returns>Кортеж из статусов операции</returns>
        public static Sensor Or(Sensor x, Sensor y)
        {
            int count = x.List.Count();
            bool[] list = new bool[count];

            for (int i = 0; i < count; i++)
            {
                list[i] = Sensor.Custom(new bool[] { x.List[i], y.List[i] }).Or();
            }

            return Sensor.Custom(list);
        }

        /// <summary>
        /// Применить операцию дизъюнкции к столбцу и кортежу
        /// </summary>
        /// <param name="index">Столбец</param>
        /// <param name="sensor">Кортеж</param>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor Or(int index, Sensor sensor)
        {
            return Or(Grid(index), sensor);
        }

        /// <summary>
        /// Применить операцию дизъюнкции к указанным столбцам
        /// </summary>
        /// <param name="indexX">Первый столбец</param>
        /// <param name="indexY">Второй столбец</param>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor Or(int indexX, int indexY)
        {
            return Or(Grid(indexX), Grid(indexY));
        }

        /// <summary>
        /// Применить операцию исключающей дизъюнкции к кортежам
        /// </summary>
        /// <param name="x">Первый кортеж</param>
        /// <param name="y">Второй кортеж</param>
        /// <returns>Кортеж из статусов операции</returns>
        public static Sensor Xor(Sensor x, Sensor y)
        {
            int count = x.List.Count();
            bool[] list = new bool[count];

            for (int i = 0; i < count; i++)
            {
                list[i] = Sensor.Custom(new bool[] { x.List[i], y.List[i] }).Xor();
            }

            return Sensor.Custom(list);
        }

        /// <summary>
        /// Применить операцию исключающей дизъюнкции к столбцу и кортежу
        /// </summary>
        /// <param name="index">Столбец</param>
        /// <param name="sensor">Кортеж</param>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor Xor(int index, Sensor sensor)
        {
            return Xor(Grid(index), sensor);
        }

        /// <summary>
        /// Применить операцию исключающей дизъюнкции к указанным столбцам
        /// </summary>
        /// <param name="indexX">Первый столбец</param>
        /// <param name="indexY">Второй столбец</param>
        /// <returns>Кортеж из статусов операции</returns>
        public Sensor Xor(int indexX, int indexY)
        {
            return Xor(Grid(indexX), Grid(indexY));
        }

        public override string ToString()
        {
            return string.Join("\r\n", Table.Select(x => x.ToString()));
        }
    }
}
