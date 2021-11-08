using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator! Here to calculate all your calculating needs. :)");
            Console.WriteLine("You can only make one calculation at this time. Please enter the operator ('+', '-', '*', or '/') you want to use.");
            Console.WriteLine("");
            Console.WriteLine("Please only enter the operator characters, otherwise you'll get an error and will have to restart the calculator all over again.");
            string operatorToUse = Console.ReadLine();            

            Console.WriteLine("Please enter in the first number.");
            float firstNumber = UserFloatInputToString();

            Console.WriteLine("Cool. Now enter in the second number.");
            float secondNumber = UserFloatInputToString();

            float calculatedNumber;
            switch (operatorToUse)
            {
                case "+":
                    calculatedNumber = firstNumber + secondNumber;
                    Console.WriteLine(firstNumber + " " + operatorToUse + " " + secondNumber + " = " + calculatedNumber);
                    break;
                case "-":
                    calculatedNumber = firstNumber - secondNumber;
                    Console.WriteLine(firstNumber + " " + operatorToUse + " " + secondNumber + " = " + calculatedNumber);
                    break;
                case "*":
                    calculatedNumber = firstNumber * secondNumber;
                    Console.WriteLine(firstNumber + " " + operatorToUse + " " + secondNumber + " = " + calculatedNumber);
                    break;
                case "/":
                    calculatedNumber = firstNumber / secondNumber;
                    Console.WriteLine(firstNumber + " " + operatorToUse + " " + secondNumber + " = " + calculatedNumber);
                    break;
                default:
                    Console.WriteLine("An error has occurred! It seems you didn't enter a valid operator. Try again!");
                    break;
            }
            
            Console.WriteLine("Thanks for using the calculator! Goodbye.");
        }

        static float UserFloatInputToString()
        {
            return float.Parse(Console.ReadLine());
        }
    }
}
