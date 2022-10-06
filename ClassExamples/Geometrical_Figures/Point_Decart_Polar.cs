using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometrical_Figures
{
    /// <summary>
    /// Точка на плоскости
    /// </summary>
    public struct Point_Decart_Polar
    {
        double x, y; //декартовы координаты
        double r, fi; //полярные координаты 
       
        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="x">декартова координата x</param>
        /// <param name="y">декартова координата y</param>
        public Point_Decart_Polar(double x, double y)
        {
            this.x = x; this.y = y;
            r = Math.Sqrt(x * x + y * y);
            fi = (r == 0)? 0 : Math.Asin(y / r);
        }
        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="r">полярная координата r</param>
        /// <param name="fi">полярная координата fi</param>
        /// <param name="s">дополнительный параметр
        /// устраняет конфликт перегрузки
        /// значение не используется</param>
        public Point_Decart_Polar(double r, double fi, string s)
        {
            this.r = r; this.fi = fi;
            x = r * Math.Cos(fi);
            y = r * Math.Sin(fi);
        }
        public double X
        { get { return x; } }
        public double Y
        { get { return y; } }
        public double R
        { get { return r; } }
        public double Fi
        { get { return fi; } }
        
        /// <summary>
        /// Перемещение точки по горизонтали
        /// </summary>
        /// <param name="a">сдвиг по x</param>
        public void MoveX(double a)
        {
            x += a;
            GetPolar();
        }
        /// <summary>
        /// Перемещение точки по вертикали
        /// </summary>
        /// <param name="a">сдвиг по y</param>
        public void MoveY(double a)
        {
            y += a;
            GetPolar();
        }
        /// <summary>
        /// Перемещение точки по горизонтали и вертикали
        /// </summary>
        /// <param name="a">сдвиг по x</param>
        /// <param name="b">сдвиг по y</param>
        public void MoveXY(double a, double b)
        {
            x += a; y += b;
            GetPolar();
        }
        /// <summary>
        /// Вычисление полярных координат по декартовым
        /// </summary>
        void GetPolar()
        {
            r = Math.Sqrt(x * x + y * y);
            fi = (r == 0) ? 0 : Math.Asin(y / r);
        }
        /// <summary>
        /// Растяжение по радиусу 
        /// </summary>
        /// <param name="a"></param>
        public void Stretch(double a)
        {
            r *= a;
            GetDecart();
        }
        /// <summary>
        /// Поворот на угол
        /// </summary>
        /// <param name="b"></param>
        public void Turn(double b)
        {
            fi += b;
            GetDecart();
        }
        /// <summary>
        /// Вычисление декартовых координат по полярным
        /// </summary>
        void GetDecart()
        {
            x = r * Math.Cos(fi);
            y = r * Math.Sin(fi);
        }
        /// <summary>
        /// Расстояние до точки 
        /// </summary>
        /// <param name="p">точка</param>
        /// <returns>расстояние</returns>
        public double Distance(Point_Decart_Polar p)
        {
            double dx = p.x - x;
            double dy = p.y - y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        public override string ToString()
        {            
            return "X = " + x.ToString() + ";  "+
                "Y = " + y.ToString();
        }
    }
}
