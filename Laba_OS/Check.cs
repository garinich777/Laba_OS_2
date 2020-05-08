using System;

namespace Laba_OS_2
{
    enum Checking { Empty, Yes, Create }
    enum FileCheck { Start, Read, Write, Exit, End }

    class Check
    {
        public static int GetInt()
        {
            int value;
            string text = Console.ReadLine();
            while (!int.TryParse(text, out value))
            {
                Console.WriteLine("Incorrect choice, try again");
                text = Console.ReadLine();
            }
            return value;
        }
    }


}
