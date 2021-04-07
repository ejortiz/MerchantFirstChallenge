using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace MerchantFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string dataDir = Path.Combine(projectDirectory, "data" + Path.DirectorySeparatorChar);
            Console.WriteLine(dataDir);
            // PART 1: Console Input
            RunPart1();
            
            // PART 2: Read File
            RunPart2(dataDir + "SampleInput.tab", "\t", dataDir + "SampleOutput.tab");
        }

        private static void RunPart1()
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
        private static string GenerateStringFromValue(int input, int value1, string text1, int value2, string text2)
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

        private static string GenPassFail(int input1, int input2)
        {
            if (input1 % input2 == 0 || input2 % input1 == 0)
                return "pass";
            return "fail";
        }

        private static void RunPart2(string filename, string sep, string outputfile)
        {
            List<string> newLines = new List<string>();
            foreach(var line in File.ReadLines(filename))
            {     
                var sepLine = line.Split(sep);
                bool validInput1 = int.TryParse(sepLine[0], out int val1);
                bool validInput2 = int.TryParse(sepLine[1], out int val2);
                if (!validInput1 || !validInput2 || val1 == 0 || val2 == 0)
                {
                    newLines.Add(string.Join(sep, sepLine[0], sepLine[1], "error"));
                    continue;
                    // throw new InvalidCastException("Could not convert " + 
                    //                                sepLine[0] + " or " + 
                    //                                sepLine[1] +
                    //                                " to string. Please correct input file.");
                }
                string result = GenPassFail(val1, val2);
                string newLine = string.Join(sep, sepLine[0], sepLine[1], result);
                newLines.Add(newLine);
            }
            File.WriteAllLines(outputfile, newLines, Encoding.UTF8);
        }
    }
}