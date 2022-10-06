using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Geometrical_Figures
{
    /// <summary>
    /// Аналог встроенной структуры Point
    /// </summary>
    public class CPoint
    {
        double x, y;
        /// <summary>
        /// Конструктор по умолчанию
        /// Создает точку (0, 0) - начало координат
        /// </summary>
        public CPoint()
        {
            x = 0; y = 0;
        }
        /// <summary>
        /// Конструктор с параметрами 
        /// </summary>
        /// <param name="x">декартова координата x</param>
        /// <param name="y">декартова координата y </param>
        public CPoint(double x, double y)
        {
            this.x = x; this.y = y;
        }
        /// <summary>
        /// Конструктор копии
        /// Создает копию точки pt
        /// </summary>
        /// <param name="pt">Копируемая точка</param>
        public CPoint(CPoint pt)
        {
            x = pt.x; y = pt.y;
        }
        /// <summary>
        /// Конструктор, создает точку по размерам,
        /// заданным структурой Size 
        /// </summary>
        /// <param name="sz"></param>
        public CPoint(Size sz)
        {
            x = sz.Width; y = sz.Height;
        }
        /// <summary>
        /// Метод - свойство
        /// Доступ к полю - чтение и запись
        /// </summary>
        public double X
        {
            get { return x; }
            set { value = x; }
        }
        /// <summary>
        /// Метод - свойство
        /// Доступ к полю - чтение и запись
        /// </summary>
        public double Y
        {
            get { return y; }
            set { value = y; }
        }
        /// <summary>
        /// Смещение точки по горизонтали и вертикали
        /// </summary>
        /// <param name="dx">Смещение точки по горизонтали </param>
        /// <param name="dy">Смещение точки по вертикали</param>
        public void Offset(double dx, double dy)
        {
            x += dx; y += dy;
        }
        /// <summary>
        /// Определение операции +
        /// К точке можно прибавить размер
        /// </summary>
        /// <param name="pt">точка</param>
        /// <param name="sz">размер</param>
        /// <returns>точку со смещением</returns>
        public static CPoint operator +(CPoint pt, Size sz)
        {
            CPoint p = new CPoint(pt);
            p.x += sz.Width;
            p.y += sz.Height;
            return p;
        }
        /// <summary>
        /// Переопределение метода 
        /// Возращаются координаты точки
        /// </summary>
        /// <returns>строка с координатами точки</returns>
        public override string ToString()
        {            
            return "<x: " + x + ", y: " + y + ">";
        }
        /// <summary>
        /// Расстояние до заданной точки
        /// </summary>
        /// <param name="pt">заданная точка</param>
        /// <returns>расстояние</returns>
        public double Distance(CPoint pt)
        {
            return Math.Sqrt((pt.x - x)*(pt.x - x) +
                (pt.y - y)*(pt.y - y));
        }
       
    }
}
