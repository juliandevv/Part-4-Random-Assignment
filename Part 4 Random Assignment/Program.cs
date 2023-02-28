using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Part_4_Random_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> minMax = new List<double>();
            List<int> diceRolls = new List<int>();
            List<double> rndNumbers = new List<double>();
            Random generator = new Random();
            string[] prompts = { "Minimum value:", "Maximum value:" };

            Console.WriteLine("I am a program that generates random numbers");
            Console.WriteLine("Enter a range of values generate within");

            while (true)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine(prompts[i]);
                    if (double.TryParse(Console.ReadLine(), out double num))
                    {
                        minMax.Add(num);
                    }
                    else
                    {
                        Console.WriteLine("Not a valid input!");
                        i--;
                    }
                }
                if (minMax[0] < minMax[1])
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Maximum value cannot be less than the minimum value!");
                    minMax.Clear();
                }
            }
            Console.WriteLine($"Generating integers from the range {minMax[0]}, {minMax[1]}");
            for (int i = 0; i < 4; i++)
            {
                rndNumbers.Add(generator.Next(Convert.ToInt32(Math.Round(minMax[0])), Convert.ToInt32(Math.Round(minMax[1])) + 1));
            }
            Thread.Sleep(1000);
            Console.WriteLine("Random Numbers:");
            foreach (int num in rndNumbers)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();
            Console.WriteLine("\nPress ENTER to continue");
            Console.ReadLine();

            Console.WriteLine("Rolling two Dice...");
            diceRolls.Add(generator.Next(1, 7));
            diceRolls.Add(generator.Next(1, 7));
            Thread.Sleep(1000);
            Console.Write($"Dice 1: {diceRolls[0]}  ");
            Console.WriteLine($"Dice 2: {diceRolls[1]}");
            int sum = diceRolls.Sum();
            Console.WriteLine($"Sum of the dice: {sum}");

            Console.WriteLine("\nPress ENTER to continue");
            Console.ReadLine();

            rndNumbers.Clear();
            Console.WriteLine("Generating random decimal numbers within the same range as before...");
            for (int i = 0; i < 3; i++)
            {
                int integerMin = Convert.ToInt32(minMax[0]);
                int integerMax = Convert.ToInt32(minMax[1]);


                int decimalMin = DecimalsAsInt(minMax[0]);
                int decimalMax = DecimalsAsInt(minMax[1]);
                double maxLength = decimalMax.ToString().Length;
                if (decimalMax.ToString().Length < decimalMin.ToString().Length)
                {
                    decimalMin = decimalMin / Convert.ToInt32(Math.Pow(10, maxLength));
                }
                decimalMax = decimalMax * 10;
                double decimals = generator.Next(decimalMin, decimalMax);
                decimals = decimals * Math.Pow(10, decimals.ToString().Length * -1);
                int rndNum = generator.Next(integerMin, integerMax);
                rndNumbers.Add(rndNum + decimals);
                Console.WriteLine(rndNum + decimals);

            }


            Console.ReadLine();
        }

        static int DecimalsAsInt(double num)
        {
            //Console.WriteLine(num);
            double decimals = num - Math.Truncate(num);
            if (decimals == 0) { decimals = 1; }
            //Console.WriteLine(decimals);
            //string decimalsStr = decimals.ToString();
            //int startIndex = decimalsStr.IndexOf(".")+2;
            //if (startIndex < 0) { startIndex = 0; }
            //Console.WriteLine(startIndex);
            //double decimalLength = decimalsStr.Substring(startIndex).Length;
            //Console.WriteLine(decimalLength);
            int result = Convert.ToInt32(decimals * Math.Pow(10, 5));

            return result;
        }
    }
}
