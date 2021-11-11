using System;

namespace Calculator
{
    class DateCalculations : ICalculator
    {
        static Validator ValidateNumber = new Validator();
        private FileWriter calcLog;

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
            catch (Exception ex)
            {
                Console.WriteLine("The date calculator isn't sure of what you just entered, but it couldn't convert it into a date." +
                    "\nPlease try entering the date in DD/MM/YYYY or DD/MM/YYYY format.");
                return CheckIfValidDate(Console.ReadLine());
            }
        }

        public void StartCalculation(FileWriter fileWriter)
        {
            calcLog = fileWriter;
            Console.WriteLine("Please enter a date in DD/MM/YYYY or DD/MM/YY format:");
            DateTime dateInput = CheckIfValidDate(Console.ReadLine());

            Console.WriteLine("Please enter the number of days to add to the above-entered date.");
            float daysAmount = ValidateNumber.CheckIfValidFloat(Console.ReadLine());

            DateTime resultDate = dateInput.AddDays(daysAmount);

            Console.WriteLine($"It will be {resultDate.ToLongDateString()}.");
            calcLog.WriteNewLine(dateInput, daysAmount, resultDate);
        }
    }
}
