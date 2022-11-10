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
                        operations.Pop();
                        Sensor sensorNeg = Sensor.Custom(new bool[] { operations.Pop() == "True" });
                        operations.Push((sensorNeg.Negate().ToString()=="1").ToString());
                        break;
                    case "+":
                        operations.Pop();
                        Sensor sensorOr = Sensor.Custom(new bool[] { operations.Pop() == "True", operations.Pop() == "True" });
                        operations.Push(sensorOr.Or().ToString());
                        break;
                    case "*":
                        operations.Pop();
                        Sensor sensorAnd = Sensor.Custom(new bool[] { operations.Pop() == "True", operations.Pop() == "True" });
                        operations.Push(sensorAnd.And().ToString());
                        break;
                    case "->":
                        operations.Pop();
                        bool evalB = operations.Pop()=="True";
                        bool evalA = operations.Pop() == "True";

                        Sensor sensorImplicate = Sensor.Custom(new bool[] { evalA, evalB });
                        operations.Push(sensorImplicate.Implicate().ToString());
                        break;
                    case "<->":
                    case "EQV":
                        operations.Pop();
                        Sensor sensorEqualite = Sensor.Custom(new bool[] { operations.Pop() == "True", operations.Pop() == "True" });
                        operations.Push(sensorEqualite.Equalite().ToString());
                        break;
                    case "XOR":
                        operations.Pop();
                        Sensor sensorXOR = Sensor.Custom(new bool[] { operations.Pop() == "True", operations.Pop() == "True" });
                        operations.Push(sensorXOR.Equalite().ToString());
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
                if (tokens[i] != "-" && tokens[i] != "+" && tokens[i] != "*" && tokens[i] != "->" && tokens[i] != "<->" && tokens[i] != "EQV")
                {
                    answer.Add(values.List[(int)(tokens[i].ToCharArray()[0]) - 65].ToString());
                }
                else answer.Add(tokens[i]);
            }
            return answer;
        }
    }
}
