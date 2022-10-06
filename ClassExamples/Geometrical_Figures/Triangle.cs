using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometrical_Figures
{
    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle
    {
        CPoint pointA, pointB, pointC;
        double sideAB, sideBC, sideCA;
        double squareT;
        Random rnd = new Random();
        const string NL = "\n\r";
        public Triangle()
        {
            pointA = new CPoint(1, 1);
            pointB = new CPoint(2, 2);
            pointC = new CPoint(1, 3);
        }
        public Triangle(CPoint p1, CPoint p2, CPoint p3)
        {
            pointA = p1; pointB = p2; pointC = p3;
            GetSides();
        }
        public Triangle(Triangle t)
        {
            this.pointA = t.pointA;
            this.pointB = t.pointB;
            this.pointC = t.pointC;
            GetSides();
        }
        public Triangle RandomT(int min, int max)
        {
            CPoint p1, p2, p3;
            p1 = new CPoint(rnd.Next(min, max), 
                rnd.Next(min, max));
            p2 = new CPoint(rnd.Next(min, max),
                rnd.Next(min, max));
            p3 = new CPoint(rnd.Next(min, max),
                rnd.Next(min, max));
            return new Triangle(p1, p2, p3);
        }
        
        void GetSides()
        {
            sideAB = pointA.Distance(pointB);
            sideBC = pointB.Distance(pointC);
            sideCA = pointC.Distance(pointA);
            double p = (sideAB + sideBC + sideCA) / 2;
            squareT = Math.Sqrt(p * (p - sideAB) *
                (p - sideBC) * (p - sideCA));
        }
        public bool Contains(CPoint p)
        {
            CPoint right;
            right = new CPoint(p.X +
                Math.Max(sideAB, Math.Max(sideBC, sideCA)), p.Y);
            int count = 0;
            if (Segments_Intersect(p, right, pointA, pointB))
                count++;
            if (Segments_Intersect(p, right, pointB, pointC))
                count++;
            if (Segments_Intersect(p, right, pointC, pointA))
                count++;
            if (count % 2 == 1) return true;
            else return false;

        }
        bool Segments_Intersect(CPoint p1, CPoint p2,
            CPoint p3, CPoint p4)
        {           
            double d1, d2, d3, d4;
            d1 = Direction(p1, p3, p4);
            d2 = Direction(p2, p3, p4);
            d3 = Direction(p3, p1, p2);
            d4 = Direction(p4, p1, p2);
            if(((d1 > 0 && d2 < 0) || 
                (d1 < 0) && (d2 > 0)) &&
               ((d3 > 0 && d4 < 0) || 
                (d3 < 0) && (d4 > 0))) 
                return true;
            if( (d1 == 0) && OnSegment(p1, p3, p4))
                return true;
            if((d2 == 0) && OnSegment(p2, p3, p4))
                return true;
            if((d3 == 0) && OnSegment(p3, p1, p2))
                return true;
            if((d4 == 0) && OnSegment(p4, p1, p2))
                return true;
            return false;
        }
        double Direction(CPoint p1, CPoint p2, CPoint p3)
        {
            return ((p2.X - p1.X) * (p3.Y - p1.Y) -
                (p3.X - p1.X) * (p2.Y - p1.Y));
        }
        bool OnSegment(CPoint p1, CPoint p2, CPoint p3)
        {
            if ((p1.X >= Math.Min(p2.X, p3.X)) &&
                (p1.X <= Math.Max(p2.X, p3.X)) &&
                (p1.Y >= Math.Min(p2.Y, p3.Y)) &&
                (p1.Y <= Math.Max(p2.Y, p3.Y)))
                return true;
            else return false;
        }
        public override string ToString()
        {
            return "ВершинаА : " + pointA.ToString() + NL +
                "ВершинаB : " + pointB.ToString() + NL +
                "ВершинаC : " + pointC.ToString();
        }


    }
}
