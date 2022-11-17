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
        // Таблица истинности и значения функций
        private void buttonTable_Click(object sender, EventArgs e)
        {
            try
            {
                int n = int.Parse(N.Text);
                string function = Function.Text;
                if (Check(n, function))
                    return;
                int c = 0;
                TruthTable table = new TruthTable(n);
                LogicalParser parser = new LogicalParser();
                LogicalEvaluate eval = new LogicalEvaluate();
                Sensor result = Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(n), parser.Parse(function)).List);
                Rezult.Text = "Таблица истинности для переменных и значение функции: " + Environment.NewLine;
                // оглавление столбцов
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
        // Справка
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа позволят построить таблицу истинности для введенной пользователем функцией, а также найти её значение."
                + "\nПрограмма имеет удовлетворительную скорость работы только на диапазоне значений логических переменных от 1 до 10."
                + "\nПри выходе введенного значения из указанного диапазона или некорректном вводе значения количества логических переменных"
                + "\nбудет показано сообщение об ошибке. " + "\nПеред заполнение поля \'Функция\' необходимо ввести в поле \'Количевство переменных\' количество переменных" + "Поле \'Функция\' следует заполнять следующим образом:"+
                "\nВсе знаки операций вводятся через пробел после ввода переменных, представляющих собой буквы английского алфавита"+
                "\nПример правильного ввода: A + B, A -> B, A * B <-> C, - A + - B"
                , "Справка");
        }
        //СДНФ и СКНФ
        private void buttonNF_Click(object sender, EventArgs e)
        {
            int n = int.Parse(N.Text);
            string function = Function.Text;
            if (Check(n, function))
                return;
            TruthTable table = new TruthTable(n);
            LogicalParser parser = new LogicalParser();
            LogicalEvaluate eval = new LogicalEvaluate();
            Sensor result = Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(n), parser.Parse(function)).List);
            RezultNF.Text = "Реализация СДНФ и СКНФ"+ Environment.NewLine;
            RezultNF.Text += ("СДНФ")+Environment.NewLine+ (LogicalNormalForm.SDNF(table, result, parser.Parse(function)))+Environment.NewLine;
            RezultNF.Text += ("СКНФ")+Environment.NewLine+ (LogicalNormalForm.SKNF(table, result, parser.Parse(function)))+Environment.NewLine;
        }
        //Функция для проверки корректности значений  в заполненных полях
        private bool Check(int n, string function)
        {
            if (n > 10)
            {
                MessageBox.Show("Введенное значение превышает 10");
                return true;
            }
            string[] s = function.Split(' ');
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (LogicalParser.isOperator(s[i]) == false)
                {
                    count++;
                }
            }
            if (count < n)
            {
                MessageBox.Show("Заданное количество переменных не соответсвует количеству переменных функции");
                return true;
            }
            return false;
        }
    }
}
