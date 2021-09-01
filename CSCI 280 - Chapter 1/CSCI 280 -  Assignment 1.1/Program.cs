using System;

namespace CSCI_280____Assignment_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("First Bit (1 or 0): ");
            string input1 = Console.ReadLine();
            Console.Write("Second Bit: ");
            string input2 = Console.ReadLine();


            // Parse and validate input
            int bit1 = -1, bit2 = -1;
            if ( (!int.TryParse(input1, out bit1) | !int.TryParse(input2, out bit2)) ||
                !(bit1 == 0 || bit1 == 1) || !(bit2 == 0 || bit2 == 1))
            {
                Console.WriteLine("Input error! Please enter 0 or 1 for each bit.");
                QuitApp();
            }

            Console.Write("Operation (AND, OR, XOR): ");
            string operation = Console.ReadLine().ToLower();

            // Validate input
            if (!(operation == "and" || operation == "or" || operation == "xor"))
            {
                Console.WriteLine("Input error! Please enter either AND, OR, or XOR.");
                QuitApp();
            }

            int out_bit = -1;
            switch (operation)
            {
                case "and":
                    out_bit = bit1 & bit2;
                    break;
                case "or":
                    out_bit = bit1 | bit2;
                    break;
                case "xor":
                    out_bit = bit1 ^ bit2;
                    break;
            }

            Console.WriteLine(bit1 + " " + operation.ToUpper() + " " + bit2 + " = " + Convert.ToInt32(out_bit));
            QuitApp();
        }

        private static void QuitApp()
        {
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
