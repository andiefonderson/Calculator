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
            try
            {
                return DateTime.Parse(userInput);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("The format of the date you tried to enter couldn't be read by the date calculator." +
                    "\nPlease try entering the date in DD/MM/YYYY or DD/MM/YYYY format.");
                return CheckIfValidDate(Console.ReadLine());
            }
        }

        public void DatesCalculator(FileWriter fileWriter)
        {
            Console.WriteLine("Please enter a date in DD/MM/YYYY or DD/MM/YY format:");
            DateTime dateInput = CheckIfValidDate(Console.ReadLine());

            Console.WriteLine("Please enter the number of days to add to the above-entered date.");
            float daysAmount = ValidateNumber.CheckIfValidFloat(Console.ReadLine());

            DateTime resultDate = dateInput.AddDays(daysAmount);

            Console.WriteLine("It will be {0}.", resultDate.ToLongDateString());
            fileWriter.WriteNewLine(dateInput, daysAmount, resultDate);
        }
    }
}
