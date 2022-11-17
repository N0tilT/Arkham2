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
                
                int n = int.Parse(N.Text);
                if (n>10)
                {
                    MessageBox.Show("Введенное значение превышает 10");
                    return;
                }
                string function = Function.Text;
                string[] s = function.Split(' ');
                int count = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (LogicalParser.isOperator(s[i])==false)
                    {
                        count ++;
                    }
                }
                if(count<n)
                {
                    MessageBox.Show("Заданно е количество переменных не соответсвует количеству переменных функции");
                    return;
                }
                int c = 0;
                TruthTable table = new TruthTable(n);
                LogicalParser parser = new LogicalParser();
                LogicalEvaluate eval = new LogicalEvaluate();
                Sensor result = Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(n), parser.Parse(function)).List);
                Rezult.Text = "Таблица истинности для переменных и значение функции: " + Environment.NewLine;
                for (int i = 0; i < n; i++)
                {
                    Rezult.Text += Convert.ToChar(i + 65) +" ";
                }
                Rezult.Text += " F= "+ Environment.NewLine;
                foreach (Sensor row in table.Table)
                {
                    foreach (bool item in row.List)
                    {
                        Rezult.Text += (item == true ? "1" + " " : "0" + " ");
                    }  
                    Rezult.Text +=  (result.List[c] == true ? "  1" : "  0") + Environment.NewLine;
                    c++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректный ввод");
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа позволят построить таблицу истинности для введенного ползователем количества логических переменных."
                + "\nПрограмма имеет удовлетворительную скороть работы только на диапазоне значений логических переменных от 1 до 10."
                + "\nПри выходе введенного значения из указанного диапазона или некорректном вводе значения количества логических переменных"
                + "\nбудет показано сообщение об ошибке."
                , "Справка");
        }
    }
}
