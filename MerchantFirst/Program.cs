using System;

namespace MerchantFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input an integer value.");
            bool validInput = int.TryParse(Console.ReadLine(), out int intVal);
            while (!validInput)
            {
                Console.WriteLine("Please input an INTEGER value.");
                validInput = int.TryParse(Console.ReadLine(), out intVal);    
            }
            Console.WriteLine("Your value is this: " + intVal);
            
        }
    }
}