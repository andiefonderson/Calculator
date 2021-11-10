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
            File.AppendAllText(fileName, String.Format("{0} + {1} days = {2}\n", date.ToShortDateString(), daysAmount,resultDate.ToShortDateString()));
        }

        public void EndLine(string num)
        {
            File.AppendAllText(fileName, String.Format("= {0}\n", num));
        }

        public void ClearLog()
        {
            File.WriteAllText(fileName, "");
        }
    }
}
