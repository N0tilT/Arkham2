using System;

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
