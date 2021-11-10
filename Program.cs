using System;
using System.Net;

namespace Calculator
{
    class Program
    {
        static bool startCalculation = false;
        const int NumberCalculatorNo = 1;
        const int DateCalculatorNo = 2;
        static FileWriter FileWriter = new FileWriter();
        static Validator numValidator = new Validator();
        static NumbersCalculations numbCalc = new NumbersCalculations();
        static DateCalculations dateCalc = new DateCalculations();
        

        static void Main(string[] args)
        {
            WelcomeMessage();

            while (!startCalculation)
            {
                float calculatorMode = SelectMode();
                if (calculatorMode == NumberCalculatorNo)
                {
                    numbCalc.NumbersCalculator(FileWriter);
                }
                else
                {
                    dateCalc.DatesCalculator(FileWriter);
                }
                RestartPrompt();
            }
        }

        static void WelcomeMessage()
        {
            FileWriter.ClearLog();
            Console.WriteLine("Welcome to the calculator! Here to calculate all your calculating needs. :) " +
                "\nPlease make sure to do exactly as the instructions say so that you won't get an error.");
        }

        static float SelectMode()
        {
            startCalculation = true;
            Console.WriteLine("\nType in the number of the calculator you want to use:" +
                "\n1) Number Calculator" +
                "\n2) Date Calculator");
            float numSelection = numValidator.CheckIfValidNumber(Console.ReadLine());
            while (numSelection > 2 || numSelection < 1)
            {
                Console.WriteLine("Please only enter 1 for Number Calculator or 2 for Date Calculator.");
                numSelection = int.Parse(Console.ReadLine());
            }
            return numSelection;
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
    }
}
