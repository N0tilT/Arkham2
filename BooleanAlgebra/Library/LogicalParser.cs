﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class LogicalParser
    {
        string[] tokens;
        Stack<string> stack = new Stack<string>();
        List<string> parsed = new List<string>();
        bool n;

        public List<string> Parse(string input)
        {
            tokens = input.Split(' ');

            foreach(string item in tokens)
            {
                if (item == "(") stack.Push(item);
                else if(item == ")")
                {
                    while (stack.Count != 0 && stack.Peek() != "(") parsed.Add(stack.Pop());
                    stack.Pop();
                }
                else if (isOperator(item))
                {
                    while (stack.Count != 0 && Priority(stack.Peek()) >= Priority(item)) parsed.Add(stack.Pop());
                    stack.Push(item);
                }
                else parsed.Add(item);
            }
            while (stack.Count != 0) parsed.Add(stack.Pop());
            

            return parsed;
        }

        static int Priority(string c)
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
        static bool isOperator(string c)
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
