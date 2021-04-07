using System;

namespace MerchantFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input an integer value >=1.");
            bool validInput = int.TryParse(Console.ReadLine(), out int intVal);
            while (!validInput || intVal < 1)
            {
                Console.WriteLine("Please input an INTEGER value >=1.");
                validInput = int.TryParse(Console.ReadLine(), out intVal);    
            }
            Console.WriteLine("======START=======");
            for (int i = 1; i <= intVal; i++)
            {
                Console.WriteLine(GenerateStringFromValue(i, 
                    3, "Hot", 5, "Dog"));
            }
            
        }

        public static string GenerateStringFromValue(int input, int value1, string text1, int value2, string text2)
        {
            string output = "";
            bool multipleOfVal1 = input % value1 == 0;
            bool multipleOfVal2 = input % value2 == 0;
            if (!multipleOfVal1 && !multipleOfVal2)
                return input.ToString();
            if (multipleOfVal1)
                output += text1;
            if (multipleOfVal2)
                output += text2;
            if (multipleOfVal1 && multipleOfVal2)
                output += " " + input;
            return output;
        }
    }
}