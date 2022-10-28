using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace Forms
{
    public partial class FormTable : Form
    {
        public FormTable()
        {
            InitializeComponent();
        }

        private void buttonTable_Click(object sender, EventArgs e)
        {
            try
            {
                int count1 = int.Parse(BoolN.Text);
                int count2 = int.Parse(BoolN2.Text);
                TruthTable table1 = new TruthTable(count1);
                TruthTable table2 = new TruthTable(count2);
                Rezult.Text = Convert.ToString(table1);
                Rezult2.Text = Convert.ToString(table2);
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректный ввод / Введенное значение за границами диапазона ( от 1 до 26)");
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа позволят построить таблицу истинности для введенного ползователем количества логических переменных."
                + "\nПрограмма имеет удовлетворительную скороть работы только на диапазоне значений логических переменных от 1 до 26."
                + "\nПри выходе введенного значения из указанного диапазона или некорректном вводе значения количества логических переменных"
                + "\nбудет показано сообщение об ошибке."
                , "Справка");
        }
    }
}
