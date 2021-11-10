using System;
using System.Net;

namespace Calculator
{
    class Program
    {
        static bool startCalculation = false;
        const int NumberCalculatorNo = (int)CalculatorMode.NumberCalculator;
        const int DateCalculatorNo = (int)CalculatorMode.DateCalculator;
        static FileWriter FileWriter = new FileWriter();
        static DateCalculations dateCalc = new DateCalculations();
        static NumbersCalculations numbCalc = new NumbersCalculations();
        static Validator validator = new Validator();


        static void Main(string[] args)
        {
            WelcomeMessage();

            while (!startCalculation)
            {
                SelectMode();
                RestartPrompt();
            }
        }

        static void WelcomeMessage()
        {
            FileWriter.ClearLog();
            Console.WriteLine("Welcome to the calculator! Here to calculate all your calculating needs. :) " +
                "\nPlease make sure to do exactly as the instructions say so that you won't get an error.");
        }

        static void SelectMode()
        {
            startCalculation = true;

            Console.WriteLine("\nType in the number of the calculator you want to use:" +
                "\n1) Number Calculator" +
                "\n2) Date Calculator");

            int? calculatorMode = validator.CheckIfValidInt(Console.ReadLine());
            switch (calculatorMode)
            {
                case NumberCalculatorNo:
                    numbCalc.NumbersCalculator(FileWriter);
                    break;
                case DateCalculatorNo:
                    dateCalc.DatesCalculator(FileWriter);
                    break;
                default:
                    Console.WriteLine("Please enter a valid number to select the calculator mode.");
                    startCalculation = false;
                    SelectMode();
                    break;

            }
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
