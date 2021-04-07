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
            Console.WriteLine("Your value is this: " + intVal);
            
        }
    }
}