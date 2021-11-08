using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator! Here to calculate all your calculating needs. :)");
            Console.WriteLine("At the moment, all you can do is multiply two numbers. Please enter in the first number.");
            float firstNumber = UserFloatInputToString();
            Console.WriteLine("Cool. Now enter in the second number.");
            float secondNumber = UserFloatInputToString();
            float calculatedNumber = firstNumber * secondNumber;
            Console.WriteLine(firstNumber + " * " + secondNumber + " = " + calculatedNumber);
            Console.WriteLine("Thanks for using the calculator! Goodbye.");
        }

        static double CircleArea(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        static float UserFloatInputToString()
        {
            return float.Parse(Console.ReadLine());
        }

        static void CalculateCircleArea()
        {
            Console.WriteLine("At the moment, you can only calculate the area of a circle. Please enter the radius of the circle.");
            string userInput = Console.ReadLine();
            double radiusAmount = Double.Parse(userInput);
            Console.WriteLine("The area of the circle with a radius of " + userInput + " units is " + CircleArea(radiusAmount) + ".");
        }
    }
}
