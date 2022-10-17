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
            tests.TestCardList();
            tests.TestCardListManager();

            Console.ReadKey();
        }
    }
}
