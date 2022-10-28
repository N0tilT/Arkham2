using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrainingOOP
{
    public class Polinom
    {
        #region fields
        int n; //степень
        double[] kf; //коэффициенты
        #endregion

        #region constructors
        public Polinom(double[] kf)
        {
            this.kf = kf;
            n = this.kf.Length - 1;
        }
        #endregion

        #region propirties
        public int N
        {
            get { return n; }
            set { if (value > 0) n = value; }
        } 

        public double[] Koef
        {
            get { return kf; }
            set { kf = value; }
        }
        #endregion
    }
}
