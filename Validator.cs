using System;

namespace Calculator
{
    class Validator
    {
        static public float CheckIfValidFloat(string userInput)
        {
            try
            {
                return float.Parse(userInput);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please only enter one number at a time in numerical format (example \"12\" or \"46.25\").");
                return float.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("There was an issue with the number you entered. Please only enter one number at a time.");
                return float.Parse(Console.ReadLine());
            }
        }
        static public int CheckIfValidInt(string userInput)
        {
            try
            {
                return int.Parse(userInput);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please only enter a number as prompted.");
                return int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("There was an issue with the number you entered. Please only enter one number at a time in numerical format (example \"1\").");
                return int.Parse(Console.ReadLine());
            }
        }

        static public string CheckIfValidOperator(string userInput)
        {
            switch (userInput)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    return userInput;
                default:
                    Console.WriteLine("You have not entered a valid operator. Please only enter '+', '-', '*', or '/'.");
                    return CheckIfValidOperator(Console.ReadLine());
            }
        }
    }
}
