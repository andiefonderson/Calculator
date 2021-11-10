using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class DateCalculations
    {
        static Validator ValidateNumber = new Validator();

        private DateTime CheckIfValidDate(string userInput)
        {
            DateTime stringToInt;

            while (!DateTime.TryParse(userInput, out stringToInt))
            {
                Console.WriteLine("Please only enter the date in DD/MM/YYYY format.");
                userInput = Console.ReadLine();
            }
            return DateTime.Parse(userInput);
        }

        public void DatesCalculator(FileWriter fileWriter)
        {
            Console.WriteLine("Please enter a date in DD/MM/YYYY or DD/MM/YY format:");
            DateTime dateInput = CheckIfValidDate(Console.ReadLine());

            Console.WriteLine("Please enter the number of days to add to the above-entered date.");
            float daysAmount = ValidateNumber.CheckIfValidNumber(Console.ReadLine());

            DateTime resultDate = dateInput.AddDays(daysAmount);

            Console.WriteLine("It will be {0}.", resultDate.ToLongDateString());
            fileWriter.WriteNewLine(dateInput, daysAmount, resultDate);
        }
    }
}
