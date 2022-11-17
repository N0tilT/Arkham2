using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    static public class LogicalNormalForm
    {
        static public string SDNF(TruthTable table, Sensor result, List<string> tokens)
        {
        string answer="( ";
            int c = 0;
            int k = 0;
            int a = 0;
            foreach (Sensor row in table.Table)
            {
                if (result.List[c]) a++;
                c++;
            }
            c = 0;
                foreach (Sensor row in table.Table)
                {
                if (result.List[c])
                {
                    for (int i=0; i < table.Count; i++)
                    {
                        if (row.List[i])
                        {
                            if (i==table.Count-1) { answer += Convert.ToChar(i + 65); }
                            else
                            answer += Convert.ToChar(i + 65) + " * ";
                        }
                        else
                        {
                            if (i == table.Count-1) { answer += "- " + Convert.ToChar(i + 65); }
                            else
                            answer += "- " + Convert.ToChar(i + 65) + " * ";
                        }
                    }
                    k++;
                    if (k != a)
                        answer += " ) + ( ";
                }
                c++;
            }
            answer += " )";
            return answer;
        }

        static public string SKNF(TruthTable table, Sensor result, List<string> tokens)
        {
            string answer = "( ";
            int c = 0;
            int k = 0;
            int a = 0;
            foreach (Sensor row in table.Table)
            {
                if (!result.List[c]) a++;
                c++;
            }
            c = 0;
            foreach (Sensor row in table.Table)
            {
                if (!result.List[c])
                {
                    for (int i = 0; i < table.Count; i++)
                    {
                        if (!row.List[i])
                        {
                            if (i == table.Count - 1) { answer += Convert.ToChar(i + 65); }
                            else
                                answer += Convert.ToChar(i + 65) + " + ";
                        }
                        else
                        {
                            if (i == table.Count - 1) { answer += "- " + Convert.ToChar(i + 65); }
                            else
                                answer += "- " + Convert.ToChar(i + 65) + " + ";
                        }
                    }
                    k++;
                    if (k != a)
                        answer += " ) * ( ";
                }
                c++;
            }
            answer += " )";
            return answer;
        }
    }
}
