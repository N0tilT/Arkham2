﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimelonCA
{
    class Program
    {
        static void Main(string[] args)
        {
            Tests tests = new Tests();

            tests.TestCustomCard();
            tests.TestRandomCard();
            tests.TestCardProvider();

            Console.ReadKey();
        }
    }
}
