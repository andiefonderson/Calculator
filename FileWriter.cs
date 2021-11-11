using System;
using System.IO;

namespace Calculator
{
    class FileWriter
    {
        string fileName = @"\TestOutputFiles\CalculatorLog.txt";

        public void WriteNewLine(string num)
        {
            File.AppendAllText(fileName, String.Format("{0} ", num));
        }

        public void WriteNewLine(string num, string op)
        {
            File.AppendAllText(fileName, String.Format("{0} {1} ", op, num));
        }

        public void WriteNewLine(DateTime date, float daysAmount, DateTime resultDate)
        {
            File.AppendAllText(fileName, $"Date Calculation: " +
                $"\n{date.ToShortDateString()} + {daysAmount} days = {resultDate.ToShortDateString()}\n\n");
        }

        public void EndLine(float num)
        {
            File.AppendAllText(fileName, $"= {num}\n\n");
        }

        public void ClearLog()
        {
            File.WriteAllText(fileName, "");
        }
    }
}
