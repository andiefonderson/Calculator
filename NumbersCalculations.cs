using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class NumbersCalculations
    {
        static Validator ValidateNumber = new Validator();

        private string SelectOperator(string op)
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

        public void NumbersCalculator(FileWriter fileWriter)
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
            Calculations(operatorText, operatorToUse, fileWriter);
        }

        private void Calculations(string opText, string op, FileWriter fileWriter)
        {
            Console.WriteLine("How many numbers do you want to {0}?", opText);
            float amountOfNumbers = ValidateNumber.CheckIfValidNumber(Console.ReadLine());
            float calculatedNumber = 0;
            float newNumber;

            for (int i = 0; i < amountOfNumbers; i++)
            {
                Console.WriteLine("Please enter number " + (i + 1));
                newNumber = ValidateNumber.CheckIfValidNumber(Console.ReadLine());
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
                fileWriter.WriteNewLine(newNumber.ToString(), op);
            }

            Console.WriteLine("The calculated value of all those numbers is {0}.", calculatedNumber);
            fileWriter.EndLine(calculatedNumber.ToString());
        }
    }
}
