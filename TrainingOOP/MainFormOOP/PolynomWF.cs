using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainFormOOP
{
    public partial class PolynomWF : Form
    {
        public PolynomWF()
        {
            InitializeComponent();
        }
        const int MAX_N = 1000;  // максимальная степень полинома
        PolynomialWithRoots A = new PolynomialWithRoots(new double[] { 3, 2, 1 });  // первый полином
        PolynomialWithRoots B = new PolynomialWithRoots(new double[] { 6, 5, 4 });  // второй полином
        PolynomialWithRoots R = new PolynomialWithRoots();  // результат операций над двумя полиномами

        #region События TextChanged
        // Изменение введённых коэффициентов для полинома A.
        private void tbACoefs_TextChanged(object sender, EventArgs e)
        {
            string[] coefsStr = tbACoefs.Text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (coefsStr.Length > MAX_N + 1)
            {
                epACoefs.SetError(tbACoefs, "Слишком много коэффициентов.");
                tbACoefs.Margin = new Padding(3, 3, 20, 3);
                btnGenerateA.Text = "";
                return;
            }
            double[] coefs = new double[coefsStr.Length];
            for (int i = 0; i < coefs.Length; i++)
                if (double.TryParse(coefsStr[coefs.Length - i - 1], out double n))
                {
                    if (n == double.PositiveInfinity || n == double.NegativeInfinity)
                    {
                        epACoefs.SetError(tbACoefs, "Слишком большие коэффициенты.");
                        tbACoefs.Margin = new Padding(3, 3, 20, 3);
                        btnGenerateA.Text = "";
                        return;
                    }
                    coefs[i] = n;
                }
                else
                {
                    epACoefs.SetError(tbACoefs, "Невозможно привести все значения к числу.");
                    tbACoefs.Margin = new Padding(3, 3, 20, 3);
                    btnGenerateA.Text = "";
                    return;
                }
            epACoefs.Clear();
            tbACoefs.Margin = new Padding(3, 3, 3, 3);
            A = new PolynomialWithRoots(coefs);
            btnGenerateA.Text = A.ToString();
        }

        // Изменение введённых коэффициентов для полинома B.
        private void tbBCoefs_TextChanged(object sender, EventArgs e)
        {
            string[] coefsStr = tbBCoefs.Text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (coefsStr.Length > MAX_N + 1)
            {
                epBCoefs.SetError(tbBCoefs, "Слишком много коэффициентов.");
                tbBCoefs.Margin = new Padding(3, 3, 20, 3);
                tbBPolynomial.Text = "";
                return;
            }
            double[] coefs = new double[coefsStr.Length];
            for (int i = 0; i < coefs.Length; i++)
                if (double.TryParse(coefsStr[coefs.Length - i - 1], out double n))
                {
                    if (n == double.PositiveInfinity || n == double.NegativeInfinity)
                    {
                        epBCoefs.SetError(tbBCoefs, "Слишком большие коэффициенты.");
                        tbBCoefs.Margin = new Padding(3, 3, 20, 3);
                        tbBPolynomial.Text = "";
                        return;
                    }
                    coefs[i] = n;
                }
                else
                {
                    epBCoefs.SetError(tbBCoefs, "Невозможно привести все значения к числу.");
                    tbBCoefs.Margin = new Padding(3, 3, 20, 3);
                    tbBPolynomial.Text = "";
                    return;
                }
            epBCoefs.Clear();
            tbBCoefs.Margin = new Padding(3, 3, 3, 3);
            B = new PolynomialWithRoots(coefs);
            tbBPolynomial.Text = B.ToString();
        }

        // Изменение введённого значения для вычисления значения полинома A в точке X.
        private void tbAInputX_TextChanged(object sender, EventArgs e)
        {
            string s = tbAInputX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epAInputX.SetError(tbAInputX, "Невозможно привести ввод к числу.");
                tbAInputX.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epAInputX.Clear();
                tbAInputX.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения для вычисления значения полинома B в точке X.
        private void tbBInputX_TextChanged(object sender, EventArgs e)
        {
            string s = tbBInputX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epBInputX.SetError(tbBInputX, "Невозможно привести ввод к числу.");
                tbBInputX.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBInputX.Clear();
                tbBInputX.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения для умножения полинома A на число N.
        private void tbAInputN_TextChanged(object sender, EventArgs e)
        {
            string s = tbAInputN.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epAInputN.SetError(tbAInputN, "Невозможно привести ввод к числу.");
                tbAInputN.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epAInputN.Clear();
                tbAInputN.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения для умножения полинома B на число N.
        private void tbBInputN_TextChanged(object sender, EventArgs e)
        {
            string s = tbBInputN.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epBInputN.SetError(tbBInputN, "Невозможно привести ввод к числу.");
                tbBInputN.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBInputN.Clear();
                tbBInputN.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения для возведения полинома A в степень.
        private void tbAPow_TextChanged(object sender, EventArgs e)
        {
            string s = tbAPow.Text.Trim();
            if (s != "" && !int.TryParse(s, out int _))
            {
                epAPow.SetError(tbAPow, "Невозможно привести ввод к целому числу.");
                tbAPow.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epAPow.Clear();
                tbAPow.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения для возведения полинома B в степень.
        private void tbBPow_TextChanged(object sender, EventArgs e)
        {
            string s = tbBPow.Text.Trim();
            if (s != "" && !int.TryParse(s, out int _))
            {
                epBPow.SetError(tbBPow, "Невозможно привести ввод к целому числу.");
                tbBPow.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBPow.Clear();
                tbBPow.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения для поиска корней полинома A.
        private void tbARoot_TextChanged(object sender, EventArgs e)
        {
            string s = tbARoot.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epARoot.SetError(tbARoot, "Невозможно привести ввод к числу.");
                tbARoot.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epARoot.Clear();
                tbARoot.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения для поиска корней полинома B.
        private void tbBRoot_TextChanged(object sender, EventArgs e)
        {
            string s = tbBRoot.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epBRoot.SetError(tbBRoot, "Невозможно привести ввод к числу.");
                tbBRoot.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBRoot.Clear();
                tbBRoot.Margin = new Padding(3, 3, 3, 3);
            }
        }
        #endregion

        #region Операции над двумя полиномами
        // Сложение полиномов.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (btnGenerateA.Text == "" || tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полиномы.";
                return;
            }
            R = A + B;
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // Вычитание полиномов.
        private void btnSubtract_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (btnGenerateA.Text == "" || tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Полином не введен";
                return;
            }
            R = A - B;
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // Умножение полиномов.
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (btnGenerateA.Text == "" || tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Полином не введен";
                return;
            }
            if (A.N + B.N > MAX_N)
            {
                tbOutput.Text = "Результирующий полином имеет слишком высокую степень.";
                return;
            }
            R = A * B;
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // Деление полиномов нацело.
        private void btnDivide_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (btnGenerateA.Text == "" || tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Полином не введен";
                return;
            }
            R = A / B;
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // Остаток от деления полиномов нацело.
        private void btnMod_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (btnGenerateA.Text == "" || tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Полином не введен";
                return;
            }
            R = A % B;
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }
        #endregion

        #region Операции над одним полиномом
        // Генерация полинома по заданным параметрам.
        private void Generate(string textN, string textMin, string textMax, RichTextBox output)
        {
            if (int.TryParse(textN, out int n) && long.TryParse(textMin, out long min) && long.TryParse(textMax, out long max))
            {
                if (n < 0 || n > MAX_N)
                {
                    tbOutput.Text = $"N должно быть в диапазоне [0, {MAX_N}].";
                    SetInsertButtons(false);
                    return;
                }
                if (min > max)
                {
                    tbOutput.Text = $"Минимальное значение должно быть меньше максимального.";
                    SetInsertButtons(false);
                    return;
                }
                string s = "";
                A = new PolynomialWithRoots(n, min, max + 1);
                foreach (double item in A.Coefs)
                {
                    s += item + " ";
                }
                output.Text = s;
            }
            else
            {
                tbOutput.Text = "Входные данные невозможно привести к целому числу.";
                SetInsertButtons(false);
            }
        }
        private void btnGenerateA_Click(object sender, EventArgs e)
        {
            Generate(rtbN_A.Text, rtbMin_A.Text, rtbMax_A.Text, tbACoefs);
        }
        private void btnGenerateB_Click(object sender, EventArgs e)
        {
            Generate(rtbN_B.Text, rtbMin_B.Text, rtbMax_B.Text, tbBCoefs);
        }

        // Получение значения полинома в точке.
        private void GetValue(PolynomialWithRoots pol, string textPol, string textA)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "Полином не введен";
                return;
            }
            if (double.TryParse(textA, out double x))
            {
                double resInPoint = pol.P(x);
                if (resInPoint == double.NegativeInfinity || resInPoint == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результат слишком большой.";
                    return;
                }
                R = new PolynomialWithRoots(new double[] { resInPoint });
                tbOutput.Text = R.ToString();
                SetInsertButtons(true);
            }
            else
                tbOutput.Text = "Ввод невозможно привести к числу.";
        }
        private void btnAGetValue_Click(object sender, EventArgs e)
        {
            GetValue(A, btnGenerateA.Text, tbAInputX.Text);
        }
        private void btnBGetValue_Click(object sender, EventArgs e)
        {
            GetValue(B, tbBPolynomial.Text, tbBInputX.Text);
        }

        // Умножение полинома на число.
        private void MultiplyByN(PolynomialWithRoots pol, string textPol, string textN)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "Полином не введен";
                return;
            }
            if (double.TryParse(textN, out double n))
            {
                R = pol * n;
                for (int i = 0; i <= R.N; i++)
                    if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                    {
                        tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                        return;
                    }
                tbOutput.Text = R.ToString();
                SetInsertButtons(true);
            }
            else
                tbOutput.Text = "Ввод невозможно привести к числу.";
        }
        private void btnAMultiplyByN_Click(object sender, EventArgs e)
        {
            MultiplyByN(A, btnGenerateA.Text, tbAInputN.Text);
        }
        private void btnBMultiplyByN_Click(object sender, EventArgs e)
        {
            MultiplyByN(B, tbBPolynomial.Text, tbBInputN.Text);
        }

        // Возведение полинома в степень.
        private void Pow(PolynomialWithRoots pol, string textPol, string textA)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (int.TryParse(textA, out int n))
            {
                if (n < 0)
                {
                    tbOutput.Text = "Степень не должна быть меньше нуля.";
                    return;
                }
                if (pol.N * n > MAX_N)
                {
                    tbOutput.Text = "Слишком высокая степень.";
                    return;
                }
                R = new PolynomialWithRoots(pol.Pow(n).Coefs);
                for (int i = 0; i <= R.N; i++)
                    if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                    {
                        tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                        return;
                    }
                tbOutput.Text = R.ToString();
                SetInsertButtons(true);
            }
            else
                tbOutput.Text = "Ввод невозможно привести к целому числу.";
        }
        private void btnAPow_Click(object sender, EventArgs e)
        {
            Pow(A, btnGenerateA.Text, tbAPow.Text);
        }
        private void btnBPow_Click(object sender, EventArgs e)
        {
            Pow(B, tbBPolynomial.Text, tbBPow.Text);
        }

        // Корни полинома.
        private void GetRoots(PolynomialWithRoots pol, string textPol, string textA)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            const int MAX_X = 10000;
            if (double.TryParse(textA, out double y))
            {
                List<double> roots = pol.FindAllRootsNewton(-MAX_X, MAX_X, y);
                roots.Sort();
                string s = "";
                if (roots.Count >= 2)
                {
                    if (Math.Abs(roots[1] - roots[0]) < 1e-5)
                        s += Math.Round(roots[1], 6) + "\n";
                    else
                        s += roots[0] + "\n";
                    for (int i = 1; i < roots.Count; i++)
                        if (Math.Abs(roots[i] - roots[i - 1]) > 1e-5)
                            s += roots[i] + "\n";
                }
                else if (roots.Count == 1)
                    s += roots[0];
                if (s == "")
                    tbOutput.Text = "Корней нет";
                else
                    tbOutput.Text = s;
            }
            else
                tbOutput.Text = "Ввод невозможно привести к числу.";
        }
        private void btnAGetRoots_Click(object sender, EventArgs e)
        {
            GetRoots(A, btnGenerateA.Text, tbARoot.Text);
        }
        private void btnBGetRoots_Click(object sender, EventArgs e)
        {
            GetRoots(B, tbBPolynomial.Text, tbBRoot.Text);
        }

        // Производная полинома.
        private void GetDerivative(PolynomialWithRoots pol, string textPol)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            R = new PolynomialWithRoots(pol.GetDerivative().Coefs);
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }
        private void btnAGetDerivative_Click(object sender, EventArgs e)
        {
            GetDerivative(A, btnGenerateA.Text);
        }
        private void btnBGetDerivative_Click(object sender, EventArgs e)
        {
            GetDerivative(B, tbBPolynomial.Text);
        }

        // Первообразная полинома.
        private void GetPrimitive(PolynomialWithRoots pol, string textPol)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (pol.N >= MAX_N)
            {
                tbOutput.Text = "Слишком высокая степень исходного полинома.";
                return;
            }
            R = new PolynomialWithRoots(pol.GetPrimitive().Coefs);
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }
        private void btnAGetPrimitive_Click(object sender, EventArgs e)
        {
            GetPrimitive(A, btnGenerateA.Text);
        }
        private void btnBGetPrimitive_Click(object sender, EventArgs e)
        {
            GetPrimitive(B, tbBPolynomial.Text);
        }
        #endregion
    }
}
