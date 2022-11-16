using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Класс для вычисления логических выражений
    /// </summary>
    public class LogicalEvaluate
    {
        /// <summary>
        /// Стэк операций
        /// </summary>
        Stack<string> operations = new Stack<string>();
        
        /// <summary>
        /// Метод построения таблицы истинности для функции
        /// </summary>
        /// <param name="table">Таблица истинности n переменных</param>
        /// <param name="tokens">Список операций логической функции в постфиксной записи</param>
        /// <returns>кортеж булевых значений - столбец значений функции в таблице истинности</returns>
        public Sensor EvaluateTrurhTable(TruthTable table,List<string> tokens)
        {
            bool[] result = new bool[table.Table.Length];
            int resIndex = 0;

            //Вычисляем значение функции для каждой строки таблицы истинности
            foreach (Sensor row in table.Table) result[resIndex++] = EvaluateEquation(SetValues(tokens, row)); 

            return Sensor.Custom(result);
        }

        /// <summary>
        /// Метод вычисления логического выражения
        /// </summary>
        /// <param name="tokens">Логическое выражение, где A,B,C... заменены на их значения True/False </param>
        /// <returns>Значение логического выражения</returns>
        public bool EvaluateEquation(List<string> tokens)
        {
            //Заносим каждый токен в стек и выполняем соответствующую логическую операцию операцию
            for (int i = 0; i < tokens.Count; i++)
            {
                operations.Push(tokens[i]);
                string curToken = operations.Peek();
                //"Вытаскиваем" последнюю операцию из стека
                // Если это переменная ("True" или "False"), ничего не происходит
                // Операции, требующие 2 операнда "вытаскивают" последние два операнда и проводят операцию с ними, занося в стек результат
                // Операция отрицания "вытаскивает" последний операнд и выполняет отрицание, занося в стек результат
                
                switch (curToken)
                {
                    case "-":   //Отрицание
                        operations.Pop();
                        Sensor sensorNeg = Sensor.Custom(new bool[] { operations.Pop() == "True" });
                        operations.Push((sensorNeg.Negate().ToString()=="1").ToString());
                        break;

                    case "+":   //Дизъюнкция
                        operations.Pop();
                        Sensor sensorOr = Sensor.Custom(new bool[] { operations.Pop() == "True", operations.Pop() == "True" });
                        operations.Push(sensorOr.Or().ToString());
                        break;

                    case "*":   //Конъюнкция
                        operations.Pop();
                        Sensor sensorAnd = Sensor.Custom(new bool[] { operations.Pop() == "True", operations.Pop() == "True" });
                        operations.Push(sensorAnd.And().ToString());
                        break;

                    case "->":  //Импликация
                        operations.Pop();
                        bool evalB = operations.Pop()=="True";
                        bool evalA = operations.Pop() == "True";

                        Sensor sensorImplicate = Sensor.Custom(new bool[] { evalA, evalB });
                        operations.Push(sensorImplicate.Implicate().ToString());
                        break;

                    case "<->": //Эквиваленция
                    case "EQV":
                        operations.Pop();
                        Sensor sensorEqualite = Sensor.Custom(new bool[] { operations.Pop() == "True", operations.Pop() == "True" });
                        operations.Push(sensorEqualite.Equalite().ToString());
                        break;

                    case "XOR": //XOR
                        operations.Pop();
                        Sensor sensorXOR = Sensor.Custom(new bool[] { operations.Pop() == "True", operations.Pop() == "True" });
                        operations.Push(sensorXOR.Xor().ToString());
                        break;

                    default:
                        break;
                }
            }
            return operations.Pop() =="True";
        }
        /// <summary>
        /// Метод присвоения логическим переменным A,B,C... заданных значений
        /// </summary>
        /// <param name="tokens">Логическое выражение в постфиксной записи</param>
        /// <param name="values">Кортеж булевых значений - значения переменных</param>
        /// <returns>Список токенов, где буквенные переменные заменены на их значения</returns>
        public List<string> SetValues(List<string> tokens, Sensor values)
        {
            List<string> answer = new List<string>();
            for (int i = 0; i < tokens.Count; i++)
            {
                //Не операциям присвваиваем значение из кортежа по индексу
                if (tokens[i] != "-" && 
                    tokens[i] != "+" && 
                    tokens[i] != "*" && 
                    tokens[i] != "->" && 
                    tokens[i] != "<->" && 
                    tokens[i] != "EQV")
                {
                    answer.Add(values.List[(int)(tokens[i].ToCharArray()[0]) - 65].ToString());
                }
                else answer.Add(tokens[i]);
            }
            return answer;
        }
    }
}
