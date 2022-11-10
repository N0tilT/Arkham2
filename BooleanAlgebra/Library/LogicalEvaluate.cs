using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class LogicalEvaluate
    {
        Stack<string> operations = new Stack<string>();
        public Sensor EvaluateTrurhTable(TruthTable table,List<string> tokens)
        {
            bool[] result = new bool[table.Table.Length];
            int i = 0;
            foreach (Sensor row in table.Table) { result[i] = EvaluateEquation(SetValues(tokens, row)); i++; }
            return Sensor.Custom(result);
        }
        public bool EvaluateEquation(List<string> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                operations.Push(tokens[i]);     //z
                string curToken = operations.Peek();
                switch (curToken)
                {
                    case "-":
                        operations.Pop();   // "-"
                        bool eval = operations.Peek() == "True";  // x
                        operations.Pop();
                        operations.Push((!(eval)).ToString());   //+(-x)
                        break;
                    case "+":
                        operations.Pop();   //+
                        bool eval1 = operations.Peek() == "True";
                        operations.Pop();
                        bool eval2 = operations.Peek() == "True";
                        operations.Pop();
                        operations.Push((eval1 || eval2).ToString());
                        break;
                    case "*":
                        operations.Pop();   //*
                        bool evalA = operations.Peek() == "True";
                        operations.Pop();
                        bool evalB = operations.Peek() == "True";
                        operations.Pop();
                        operations.Push((evalA && evalB).ToString());
                        break;
                    default:
                        break;
                }
            }
            return operations.Pop() =="True";
        }



        public List<string> SetValues(List<string> tokens, Sensor values)
        {
            List<string> answer = new List<string>();
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] != "-" && tokens[i] != "+" && tokens[i] != "*")
                {
                    answer.Add(values.List[(int)(tokens[i].ToCharArray()[0]) - 65].ToString());
                }
                else answer.Add(tokens[i]);
            }
            return answer;
        }
    }
}
