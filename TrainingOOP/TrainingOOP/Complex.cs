using System;

namespace TrainingOOP
{
    /// <summary>
    /// Класс комплексного числа
    /// определяет новый тип данных - комплексные числа и основные
    /// операции над ними - сложение, умножение, вычитание и деление.
    /// Комплексное число задается парой вещественных чисел (real, imaginary). 
    /// Число real называется реальной частью,
    /// imaginary - мнимой частью комплексного числа.
    /// </summary>
    public class Complex
    {
        #region fields

        /// <summary>
        /// Реальная часть комплексного числа
        /// </summary>
        private double _real;

        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        private double _imaginary;

        private static Random rnd = new Random();

        /// <summary>
        /// Доступ к реальной части комплексного числа
        /// </summary>
        public double real
        {
            get { return _real; }
            set { _real = value; }
        }

        /// <summary>
        /// Доступ к мнимой части комплексного числа
        /// </summary>
        public double imaginary
        {
            get { return _imaginary; }
            set { _imaginary = value; }
        }

        #endregion

        #region constructors

        /// <summary>
        /// Конструктор комплексного числа
        /// </summary>
        /// <param name="real">Реальная часть</param>
        /// <param name="imaginary">Мнимая часть</param>
        public Complex(double real, double imaginary)
        {
            _real = real;
            _imaginary = imaginary;
        }

        /// <summary>
        /// Конструктор комплексного числа
        /// </summary>
        /// <param name="num">Комплексное число</param>
        public Complex(Complex num)
        {
            _real = num.real;
            _imaginary = num.imaginary;
        }

        /// <summary>
        /// Конструктор нулевого комплексного числа
        /// </summary>
        public Complex()
        {
            _real = 0;
            _imaginary = 0;
        }

        /// <summary>
        /// Создать случайное комплексное число
        /// </summary>
        /// <returns>Случайное комплексное число</returns>
        public static Complex Random()
        {
            Complex num = new Complex();

            num.real = rnd.NextDouble();
            num.imaginary = rnd.NextDouble();

            return num;
        }

        /// <summary>
        /// Создать случайное комплексное число из указанного диапазона
        /// </summary>
        /// <param name="low">Нижняя граница</param>
        /// <param name="high">Верхняя граница</param>
        /// <returns>Случайное комплексное число</returns>
        public static Complex Random(double low, double high)
        {
            Complex num = new Complex();
            double range = high - low;

            num.real = low + range * rnd.NextDouble();
            num.imaginary = low + range * rnd.NextDouble();

            return num;
        }

        #endregion

        #region operators

        /// <summary>
        /// Прибавить к комплексному числу другое комплексное число
        /// </summary>
        /// <param name="num">Комплексное число</param>
        /// <returns>Объект комплексного числа - результат сложения</returns>
        public Complex Plus(Complex num)
        {
            return new Complex(_real + num.real, _imaginary + num.imaginary);
        }

        /// <summary>
        /// Оператор сложения двух комплексных чисел
        /// </summary>
        /// <param name="a">Первое комплексное число</param>
        /// <param name="b">Второе комплексное число</param>
        /// <returns>Объект комплексного числа - результат сложения</returns>
        public static Complex operator +(Complex a, Complex b)
        {
            return a.Plus(b);
        }

        /// <summary>
        /// Отнять от комплексного числа другое комплексное число
        /// </summary>
        /// <param name="num">Комплексное число</param>
        /// <returns>Объект комплексного числа - результат вычитания</returns>
        public Complex Minus(Complex num)
        {
            return new Complex(_real - num.real, _imaginary - num.imaginary);
        }

        /// <summary>
        /// Оператор вычитания двух комплексных чисел
        /// </summary>
        /// <param name="a">Первое комплексное число</param>
        /// <param name="b">Второе комплексное число</param>
        /// <returns>Объект комплексного числа - результат вычитания</returns>
        public static Complex operator -(Complex a, Complex b)
        {
            return a.Minus(b);
        }

        /// <summary>
        /// Умножить комплексное число на другое комплексное число
        /// </summary>
        /// <param name="num">Комплексное число</param>
        /// <returns>Объект комплексного числа - результат умножения</returns>
        public Complex Multiply(Complex num)
        {
            return new Complex(
                _real * num.real - _imaginary * num.imaginary,
                _real * num.imaginary + _imaginary * num.real);
        }

        /// <summary>
        /// Умножить комплексное число на вещественное число
        /// </summary>
        /// <param name="num">Вещественное число</param>
        /// <returns>Объект комплексного числа - результат умножения</returns>
        public Complex Multiply(double num)
        {
            Complex res = new Complex();

            res.real = _real * num;
            res.imaginary = _imaginary * num;

            return res;
        }

        /// <summary>
        /// Оператор умножения двух комплексных чисел
        /// </summary>
        /// <param name="a">Первое комплексное число</param>
        /// <param name="b">Второе комплексное число</param>
        /// <returns>Объект комплексного числа - результат умножения</returns>
        public static Complex operator *(Complex a, Complex b)
        {
            return a.Multiply(b);
        }

        /// <summary>
        /// Оператор умножения комплексного и вещественного чисел
        /// </summary>
        /// <param name="a">Комплексное число</param>
        /// <param name="num">вещественное число</param>
        /// <returns>Объект комплексного числа - результат умножения</returns>
        public static Complex operator *(Complex a, double num)
        {
            return a.Multiply(num);
        }

        /// <summary>
        /// Разделить одно комплексное число на другое комплексное число
        /// </summary>
        /// <param name="num">Комплексное число</param>
        /// <returns>Объект комплексного числа - результат деления</returns>
        public Complex Divide(Complex num)
        {
            double value = num.real * num.real + num.imaginary * num.imaginary;

            return new Complex(
                (_real * num.real + _imaginary * num.imaginary) / value,
                (_imaginary * num.real - _real * num.imaginary) / value);
        }

        /// <summary>
        /// Разделить комплексное число на вещественное число
        /// </summary>
        /// <param name="num">Вещественное число</param>
        /// <returns>Объект комплексного числа - результат деления</returns>
        public Complex Divide(double num)
        {
            Complex res = new Complex();

            res.real = _real / num;
            res.imaginary = _imaginary / num;

            return res;
        }

        /// <summary>
        /// Оператор деления двух комплексных чисел
        /// </summary>
        /// <param name="a">Первое комплексное число</param>
        /// <param name="b">Второе комплексное число</param>
        /// <returns>Объект комплексного числа - результат деления</returns>
        public static Complex operator /(Complex a, Complex b)
        {
            return a.Divide(b);
        }

        /// <summary>
        /// Оператор деления комплексного и вещественного чисел
        /// </summary>
        /// <param name="a">Комплексное число</param>
        /// <param name="num">Вещественное число</param>
        /// <returns>Объект комплексного числа - результат деления</returns>
        public static Complex operator /(Complex a, double num)
        {
            return a.Divide(num);
        }

        /// <summary>
        /// Сравнить комплексное число с другим комплексным числом
        /// </summary>
        /// <param name="num">Комплексное число</param>
        /// <returns>Показатель идентичности</returns>
        public bool IsIdentical(Complex num)
        {
            return _real == num.real && _imaginary == num.imaginary;
        }

        /// <summary>
        /// Оператор сравнения двух комплексных чисел
        /// </summary>
        /// <param name="a">Первое комплексное число</param>
        /// <param name="b">Второе комплексное число</param>
        /// <returns>Показатель идентичности</returns>
        public static bool operator ==(Complex a, Complex b)
        {
            return a.IsIdentical(b);
        }

        /// <summary>
        /// Оператор сравнения двух комплексных чисел
        /// </summary>
        /// <param name="a">Первое комплексное число</param>
        /// <param name="b">Второе комплексное число</param>
        /// <returns>Показатель неидентичности</returns>
        public static bool operator !=(Complex a, Complex b)
        {
            return !a.IsIdentical(b);
        }

        #endregion

        #region overrides

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return _real.GetHashCode() ^ _imaginary.GetHashCode();
        }

        public override string ToString()
        {
            string pos = _imaginary >= 0 ? " + " : " - ";
            
            return _real + pos + Math.Abs(_imaginary) + "i";
        }

        #endregion
    }
}
