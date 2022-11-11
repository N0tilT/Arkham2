using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainingOOP;

namespace MainFormOOP
{
    public partial class PolynomWF : Form
    {
        public PolynomWF()
        {
            InitializeComponent();
        }
        const int MAX_N = 1000;  // максимальная степень полинома
        const double MAX_COEF = 1000000; // максимальное значение коэффициента
        const double MIN_COEF = -1000000; // минимальное значение коэффициента
        Polinom A = new Polinom(new double[] { 1, 2, 3 });  // полином А с заданными коэфициентами, созданный в конструкторе класса
        Polinom B = new Polinom(new double[] { 9, 8, 7 });  // полином В с заданными коэфициентами, созданный в конструкторе класса
        Polinom R = new Polinom();  // результат операций над двумя полиномами
        
        //Ввод полинома А пользователем
        private void EnterA_Click(object sender, EventArgs e)
        {
                string[] strCoef = ACoefs.Text.Trim().Split(new char[] { ' ' });
                if (strCoef.Length > MAX_N + 1)
                {
                    MessageBox.Show("Слишком много коэффициентов.");
                    return;
                }
                double[] coefs = new double[strCoef.Length];
                for (int i = 0; i < coefs.Length; i++)
                    if (double.TryParse(strCoef[coefs.Length - i - 1], out double n))
                    {
                        if (n == MAX_COEF || n == MIN_COEF)
                        {
                            MessageBox.Show("Слишком большие коэффициенты");
                            return;
                        }
                        coefs[i] = n;
                    }
                    else
                    {
                        MessageBox.Show("Некорректный ввод");
                        return;
                    }
                A = new Polinom(coefs);
                APolynom.Text = A.ToString();

        }
        //Ввод полинома В пользователем
        private void EnterB_Click(object sender, EventArgs e)
        {
            string[] strCoef = BCoefs.Text.Trim().Split(new char[] { ' ' });
            if (strCoef.Length > MAX_N + 1)
            {
                MessageBox.Show("Слишком много коэффициентов.");
                BPolynom.Text = "";
                return;
            }
            double[] coefs = new double[strCoef.Length];
            for (int i = 0; i < coefs.Length; i++)
                if (double.TryParse(strCoef[coefs.Length - i - 1], out double n))
                {
                    if (n == MAX_COEF || n == MIN_COEF)
                    {
                        MessageBox.Show("Слишком большие коэффициенты.");
                        return;
                    }
                    coefs[i] = n;
                }
                else
                {
                    MessageBox.Show("Некорректный ввод");
                    return;
                }
            B = new Polinom(coefs);
            BPolynom.Text = B.ToString();
        }

        // Сложение полиномов
        private void Add_Click(object sender, EventArgs e)
        {
            IsEmptyAB();
            R = A + B;
            CoefOverflow();
            Rezult.Text = R.ToString();
        }

        // Вычитание полиномов
        private void Subtract_Click(object sender, EventArgs e)
        {
            IsEmptyAB();
            R = A - B;
            CoefOverflow();
            Rezult.Text = R.ToString();
        }

        // Умножение полиномов
        private void Multiply_Click(object sender, EventArgs e)
        {
            IsEmptyAB();
            if (A.N + B.N > MAX_N)
            {
                MessageBox.Show("Слишком высокая степень у результата");
                return;
            }
            R = A * B;
            CoefOverflow();
            Rezult.Text = R.ToString();
        }

        // Деление полиномов нацело
        private void Divide_Click(object sender, EventArgs e)
        {
            IsEmptyAB();
            R = A / B;
            CoefOverflow();
            Rezult.Text = R.ToString();
        }


        // Создание полинома по заданным параметрам.
        private void Generate(string textN, string textMin, string textMax, RichTextBox output)
        {
            try
            {
                    if (int.Parse(textN) < 0 || int.Parse(textN) > MAX_N)
                    {
                        MessageBox.Show("Порядок не может превышать 1000");
                        return;
                    }
                    if (int.Parse(textMin) > int.Parse(textMax))
                    {
                        MessageBox.Show("Минимальное значение должно быть меньше максимального ");
                        return;
                    }
                    string s = "";
                    A = new Polinom(int.Parse(textN), int.Parse(textMin), int.Parse(textMax) + 1);
                    foreach (double item in A.Coef)
                    {
                        s += item + " ";
                    }
                    output.Text = s;
            }
            catch(Exception)
            {
                MessageBox.Show("Некорректная входная строка");
                return;
            }

        }
        private void RandomA_Click(object sender, EventArgs e)
        {
            try
            {
                Generate(Convert.ToString(int.Parse(NA.Text) - 1), MinA.Text, MaxA.Text, ACoefs);
            }
            catch(Exception)
            {
                MessageBox.Show("Некорректная входная строка");
            }
        }
        private void RandomB_Click(object sender, EventArgs e)
        {
            try
            {
                Generate(Convert.ToString(int.Parse(NB.Text)-1), MinB.Text, MaxB.Text, BCoefs);
            }
            catch(Exception)
            {
                MessageBox.Show("Некорректная входная строка");
            }
        }
        // Деление на число
        private void DivideN(Polinom pol, string textPol, string textN)
        {
            IsEmptyA(textPol);
            R = pol / double.Parse(textN);
            Rezult.Text = R.ToString();
        }
        private void buttonDivideN_Click(object sender, EventArgs e)
        {
            DivideN(A, APolynom.Text, AdivN.Text);
        }

        // Умножение на число.
        private void MultiplyByN(Polinom pol, string textPol, string textN)
        {
            IsEmptyA(textPol);
            if (double.TryParse(textN, out double n))
            {
                R = pol * n;
                CoefOverflow();
                Rezult.Text = R.ToString();
            }
        }
        private void AmulN_Click(object sender, EventArgs e)
        {
            MultiplyByN(A, APolynom.Text, AxN.Text);
        }

        // Возведение в степень.
        private void Pow(Polinom pol, string textPol, string textA)
        {
            IsEmptyA(textPol);
            if (int.TryParse(textA, out int n))
            {
                if (pol.N * n > MAX_N)
                {
                    Rezult.Text = "Слишком высокая степень.";
                    return;
                }
                R = new Polinom(pol.Pow(n).Coef);
                CoefOverflow();
                Rezult.Text = R.ToString();
            }
        }
        private void APowN_Click(object sender, EventArgs e)
        {
            Pow(A, APolynom.Text, APow.Text);
        }

        // Производная
        private void GetDerivative(Polinom pol, string textPol)
        {
            IsEmptyA(textPol);
            R = new Polinom(pol.GetDx().Coef);
            CoefOverflow();
            Rezult.Text = R.ToString();
        }
        private void Get_Dx_Click(object sender, EventArgs e)
        {
            GetDerivative(A, APolynom.Text);
        }

        // Первообразная
        private void GetPrimitive(Polinom pol, string textPol)
        {
            IsEmptyA(textPol);
            if (pol.N >= MAX_N)
            {
                Rezult.Text = "Слишком высокая степень исходного полинома.";
                return;
            }
            R = new Polinom(pol.GetFx().Coef);
            CoefOverflow();
            Rezult.Text = R.ToString();
        }
        private void Get_Px_Click(object sender, EventArgs e)
        {
            GetPrimitive(A, APolynom.Text);
        }
        //Вспомогательные функции оюработки ошибок
        private void IsEmptyA(string textPol)
        {
            if (textPol == "")
            {
                MessageBox.Show("Не задан полином");
                return;
            }
        }
        private void IsEmptyAB()
        {
            if (APolynom.Text == "" || BPolynom.Text == "")
            {
                MessageBox.Show("Не задан полином");
                return;
            }
        }
        private void CoefOverflow()
        {
            for (int i = 0; i <= R.N; i++)
                if (R.Coef[i] == double.NegativeInfinity || R.Coef[i] == double.PositiveInfinity)
                {
                    MessageBox.Show("Слишком большие коэффициенты у результата");
                    return;
                }
        }
    }
}
