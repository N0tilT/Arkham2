using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Класс перевода выражения из инфиксной формы в постфиксную
    /// </summary>
    public class LogicalParser
    {
        string[] tokens;
        Stack<string> stack = new Stack<string>();
        List<string> parsed = new List<string>();

        /// <summary>
        /// Перевод логического выражения из инфиксной записи в постфиксную
        /// </summary>
        /// <param name="input">логическое выражение в инфиксной записи</param>
        /// <returns>логическое выражение в постфиксной записи</returns>
        public List<string> Parse(string input)
        {
            parsed.Clear();
            //делим выражение на отдельные операции - токены
            tokens = input.Split(' ');
            
            //Обрабатываем каждый токен
            foreach (string item in tokens)
            {
                if (item == "(") stack.Push(item);  //Открывающая скобка заносится в стек
                else if(item == ")")    //Закрывающая скобка обрабатывает стек до открывающей, занося его элементы в ответ
                {
                    while (stack.Count != 0 && stack.Peek() != "(") parsed.Add(stack.Pop());
                    stack.Pop();
                }
                else if (isOperator(item))  //Операторы следующие друг за другом по приоритетам заносятся в стек
                {
                    //Операторы с большим приоритетом выносятся вперёд операций с меньшим приоритетом в ответе
                    while (stack.Count != 0 && Priority(stack.Peek()) >= Priority(item)) parsed.Add(stack.Pop());
                    //В стек заносится текущая операция
                    stack.Push(item);
                }
                //Операнд заносится в ответ
                else parsed.Add(item);
            }
            while (stack.Count != 0) parsed.Add(stack.Pop());   //В ответ заносится оставшиеся операции
            

            return parsed;
        }

        /// <summary>
        /// Определить приоритет логической операции
        /// </summary>
        /// <param name="c">логическая операция</param>
        /// <returns>число - приоритет операци. Чем больше число, тем выше приоритет</returns>
        private int Priority(string c)
        {
            switch (c)
            {
                case "-":
                    return 5;
                case "*":
                    return 4;
                case "+":
                    return 3;
                case "->":
                    return 2;

                case "<->":
                case "EQV":
                    return 1;

                default:
                    return 0;
            }
        }
        /// <summary>
        /// Определить, является ли токен оператором или операндом
        /// </summary>
        /// <param name="c">Токен выражения</param>
        /// <returns>True, если токен - оператор </returns>
        public static bool isOperator(string c)
        {
            if (c == "+" || c == "-" || c == "*" || c=="->" || c=="EQV" || c=="<->" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
