using System;

namespace Calculator
{
    class Program
    {
        static bool startCalculation = false;
        const int NumberCalculatorNo = 1;
        const int DateCalculatorNo = 2;

        static void Main(string[] args)
        {
            WelcomeMessage();

            while (!startCalculation)
            {
                int calculatorMode = SelectMode();
                if (calculatorMode == NumberCalculatorNo)
                {
                    NumbersCalculator();
                }
                else
                {
                    DatesCalculator();
                }
                RestartPrompt();
            }
        }

        static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the calculator! Here to calculate all your calculating needs. :) " +
                "\nPlease make sure to do exactly as the instructions say so that you won't get an error.");
        }

        static int SelectMode()
        {
            startCalculation = true;
            Console.WriteLine("\nType in the number of the calculator you want to use:" +
                "\n1) Number Calculator" +
                "\n2) Date Calculator");
            int numSelection = int.Parse(CheckIfValidNumber(Console.ReadLine()).ToString());
            while (numSelection > 2 || numSelection < 1)
            {
                Console.WriteLine("Please only enter 1 for Number Calculator or 2 for Date Calculator.");
                numSelection = int.Parse(Console.ReadLine());
            }
            return numSelection;
        }

        static string SelectOperator(string op)
        {
            switch (op)
            {
                case "+":
                    return "add";
                case "-":
                    return "subtract";
                case "*":
                    return "multiply";
                case "/":
                    return "divide";
                default:
                    return "ERROR";
            }
        }

        static void NumbersCalculator()
        {
            Console.WriteLine("");
            string operatorToUse = "";
            string operatorText = "";

            while (operatorText == "ERROR" || operatorText == "")
            {
                Console.WriteLine("Please only enter the operator ('+', '-', '*', or '/') you want to use.");
                operatorToUse = Console.ReadLine();
                operatorText = SelectOperator(operatorToUse);
            }
            Calculations(operatorText, operatorToUse);
        }

        static void DatesCalculator()
        {
            Console.WriteLine("Please enter a date in DD/MM/YYYY or DD/MM/YY format:");
            DateTime dateInput = CheckIfValidDate(Console.ReadLine());

            Console.WriteLine("Please enter the number of days to add to the above-entered date.");
            float daysAmount = CheckIfValidNumber(Console.ReadLine());

            Console.WriteLine("It will be " + dateInput.AddDays(daysAmount).ToLongDateString() + ".");
        }

        static void Calculations(string opText, string op)
        {
            Console.WriteLine("How many numbers do you want to " + opText + "?");
            float amountOfNumbers = CheckIfValidNumber(Console.ReadLine());
            float calculatedNumber = 0;
            float newNumber;

            for (int i = 0; i < amountOfNumbers; i++)
            {
                Console.WriteLine("Please enter number " + (i + 1));
                newNumber = CheckIfValidNumber(Console.ReadLine());
                if (i == 0)
                {
                    calculatedNumber = newNumber;
                }
                else
                {
                    switch (op)
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
        }

        static void RestartPrompt()
        {
            Console.WriteLine("Type 'Y' if you would like to make another calculation. Otherwise type 'N' if you would like to stop.");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                startCalculation = false;
            }
            else { Console.WriteLine("Thank you for using the Calculator!"); }
        }

        static float CheckIfValidNumber(string userInput)
        {
            float stringToInt;

            while (!float.TryParse(userInput, out stringToInt))
            {
                Console.WriteLine("Only a number can be entered; please try again.");
                userInput = Console.ReadLine();
            }
            return float.Parse(userInput);
        }

        static DateTime CheckIfValidDate(string userInput)
        {
            DateTime stringToInt;

            while (!DateTime.TryParse(userInput, out stringToInt))
            {
                Console.WriteLine("Please only enter the date in DD/MM/YYYY format.");
                userInput = Console.ReadLine();
            }
            return DateTime.Parse(userInput);
        }
    }
}
