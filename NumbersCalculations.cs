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
                    return null;
            }
        }

        public void NumbersCalculator(FileWriter fileWriter)
        {
            Console.WriteLine("");
            Console.WriteLine("Please only enter the operator ('+', '-', '*', or '/') you want to use.");
            string operatorToUse = ValidateNumber.CheckIfValidOperator(Console.ReadLine());
            string operatorText = SelectOperator(operatorToUse);

            NewCalculations(operatorText, operatorToUse, fileWriter);
        }

        private void NewCalculations(string opText, string op, FileWriter fileWriter)
        {
            List<float> numbersToCalculate = new List<float>();
            Console.WriteLine("Please enter the first number to start calculating:");
            string entry = Console.ReadLine();
            float newNumber = ValidateNumber.CheckIfValidFloat(entry);
            fileWriter.WriteNewLine(newNumber.ToString());
            float calculatedNumber;

            while (entry != "")
            {
                newNumber = ValidateNumber.CheckIfValidFloat(entry);
                if(numbersToCalculate.Count > 0)
                {
                    fileWriter.WriteNewLine(newNumber.ToString(), op);
                }                
                numbersToCalculate.Add(newNumber);
                Console.WriteLine("Please enter the next number to {0}", opText);
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
            Console.WriteLine("The calculated value of all those numbers is {0}.", calculatedNumber);
            fileWriter.EndLine(calculatedNumber.ToString());
        }
    }
}
