using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Validator
    {
        public float CheckIfValidNumber(string userInput)
        {
            float stringToInt;

            while (!float.TryParse(userInput, out stringToInt))
            {
                Console.WriteLine("Only a number can be entered; please try again.");
                userInput = Console.ReadLine();
            }
            return float.Parse(userInput);
        }
    }
}
