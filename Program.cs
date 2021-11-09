using System;

namespace Calculator
{
    class Program
    {
        static bool startCalculation = false;

        static void Main(string[] args)
        {
            WelcomeMessage();
            while (!startCalculation)
            {
                CalculateIfNoError();
            }            
        }

        static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the calculator! Here to calculate all your calculating needs. :)");
            Console.WriteLine("Please make sure to do exactly as the instructions say so that you won't get an error.");
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

        static void CalculateIfNoError()
        {
            startCalculation = true;
            Console.WriteLine("");
            string operatorToUse = "";
            string operatorText = "";

            while (operatorText == "ERROR" || operatorText == "")
            {
                Console.WriteLine("Please only enter the operator ('+', '-', '*', or '/') you want to use.");
                operatorToUse = Console.ReadLine();
                operatorText = SelectOperator(operatorToUse);
            }
            CalculateNumber(operatorText, operatorToUse);
        }

        static void CalculateNumber(string opText, string op)
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
            RestartPrompt();
        }

        static void RestartPrompt()
        {
            Console.WriteLine("Type 'Y' if you would like to make another calculation. Otherwise type 'N' if you would like to stop.");
            if(Console.ReadLine().ToUpper() == "Y")
            {
                startCalculation = false;
            }
            else { Console.WriteLine("Thank you for using the Calculator!"); }
        }

        static float CheckIfValidNumber(string userInput)
        {
            float stringToInt;

            while(!float.TryParse(userInput,out stringToInt))
            {
                Console.WriteLine("Only a number can be entered; please try again.");
                userInput = Console.ReadLine();
            }
            return float.Parse(userInput);
        }
    }
}
