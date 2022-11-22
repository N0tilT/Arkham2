using System;
using TimelonCl;

namespace TimelonCA
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализация менеджера как можно раньше
            Manager manager = Manager.Instance;
            Tests tests = new Tests();

            tests.TestCustomCard();
            //tests.TestRandomCard();
            //tests.TestCardList();
            //tests.TestCardListManager();

            Console.ReadKey();
        }
    }
}
