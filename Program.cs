using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator! Here to calculate all your calculating needs. :)");
            Console.WriteLine("Please enter the operator ('+', '-', '*', or '/') you want to use.");
            Console.WriteLine("Please only enter the operator characters.");
            Console.WriteLine("If you don't, you'll get an error and will have to restart the calculator all over again.");
            string operatorToUse = Console.ReadLine();

            string operatorText;
            switch (operatorToUse)
            {
                case "+":
                    operatorText = "add";
                    break;
                case "-":
                    operatorText = "subtract";
                    break;
                case "*":
                    operatorText = "multiply";
                    break;
                case "/":
                    operatorText = "divide";
                    break;
                default:
                    operatorText = "ERROR";
                    break;
            }

            if (operatorText == "ERROR")
            {
                Console.WriteLine("You need to enter only the character for the operator. Please end the calculator program and try again.");
            }
            else
            {
                Console.WriteLine("How many numbers do you want to " + operatorText + "?");
                int amountOfNumbers = int.Parse(Console.ReadLine());
                float calculatedNumber = 0;
                float newNumber;

                for (int i = 0; i < amountOfNumbers; i++)
                {
                    Console.WriteLine("Please enter number " + (i + 1));
                    newNumber = float.Parse(Console.ReadLine());
                    if (i == 0)
                    {
                        calculatedNumber = newNumber;
                    }
                    else
                    {
                        switch (operatorToUse)
                        {
                            case "+":
                                calculatedNumber += newNumber;
                                break;
                            case "-":
                                calculatedNumber -= newNumber;
                                break;
                            case "*":
                                calculatedNumber *= newNumber;
                                break;
                            case "/":
                                calculatedNumber /= newNumber;
                                break;
                            default:
                                break;

                        }
                    }
                }

                Console.WriteLine("The calculated value of all those numbers is " + calculatedNumber + ".");
                Console.WriteLine("Thanks for using the calculator! Goodbye.");
            }
        }
    }
}
