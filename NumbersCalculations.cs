using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    class NumbersCalculations : ICalculator
    {
        private FileWriter calcLog;
        static Validator ValidateNumber = new Validator();
        public void AddInFileWriter(FileWriter fileWriter)
        {
            calcLog = fileWriter;
        }

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
                    return null;
            }
        }

        public void StartCalculation()
        {
            Console.WriteLine("");
            Console.WriteLine("Please only enter the operator ('+', '-', '*', or '/') you want to use.");
            string operatorToUse = ValidateNumber.CheckIfValidOperator(Console.ReadLine());
            string operatorText = SelectOperator(operatorToUse);

            Calculations(operatorText, operatorToUse, calcLog);
        }

        private void Calculations(string opText, string op, FileWriter fileWriter)
        {
            List<float> numbersToCalculate = new List<float>();
            Console.WriteLine("Please enter the first number to start calculating:");
            string entry = Console.ReadLine();
            float newNumber = ValidateNumber.CheckIfValidFloat(entry);
            fileWriter.WriteNewLine($"Number Calculation: \n{newNumber}");
            float calculatedNumber;

            while (entry != "")
            {
                newNumber = ValidateNumber.CheckIfValidFloat(entry);
                if(numbersToCalculate.Count > 0)
                {
                    fileWriter.WriteNewLine(newNumber.ToString(), op);
                }                
                numbersToCalculate.Add(newNumber);
                Console.WriteLine($"Please enter the next number to {opText}:");
                entry = Console.ReadLine();                
            }

            switch (op)
            {
                case "+":
                    calculatedNumber = numbersToCalculate.Sum();
                    break;
                case "-":
                    calculatedNumber = numbersToCalculate.Aggregate((x, y) => x - y);
                    break;
                case "*":
                    calculatedNumber = numbersToCalculate.Aggregate((x, y) => x * y);
                    break;
                case "/":
                    calculatedNumber = numbersToCalculate.Aggregate((x, y) => x / y);
                    break;
                default:
                    calculatedNumber = newNumber;
                    break;
            }
            Console.WriteLine($"The calculated value of all those numbers is {calculatedNumber}.");
            fileWriter.EndLine(calculatedNumber);
        }
    }
}
