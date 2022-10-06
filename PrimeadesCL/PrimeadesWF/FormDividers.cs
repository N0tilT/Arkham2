using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimeadesCL;

namespace PrimeadesWF
{
    public partial class FormDividers : Form
    {
        public FormDividers()
        {
            InitializeComponent();
            //Привязка кнопки Enter к копке "Вычислить"
            this.AcceptButton = buttonCalculate;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            int N = 0;
            try
            {
                N = int.Parse(textBoxInput.Text);
                if (N < 1) throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректный ввод", "Ошибка!");
                return;
            }

            textBoxDividers.Text = MakeAnswerDivs(Primes.GetDividers(N));
        }

        /// <summary>
        /// Функция построение строки-ответа, содержащую список делителей числа и их количество
        /// </summary>
        /// <param name="list">Список целых чисел - делителей числа </param>
        /// <returns>Строка-ответ, содержащая информацию о делителях числа</returns>
        private string MakeAnswerDivs(List<int> list)
        {
            string tmp = "";
            foreach (int Element in list) tmp += Element + " ";
            tmp += Environment.NewLine + "Количество делителей: "+ list.Count();
            return tmp;
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ПРОГРАММА ОПРЕДЕЛЕНИЯ ВСЕХ ДЕЛИТЕЛЕЙ ЧИСЛА\n" +
            "Программа осуществляет нахождение всех делителей заданного числа\n" +
            "В окне \"Введите число \" введите натуральное число", "Справка");
        }

        
    }
}
