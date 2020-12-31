using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker.Class
{
    class ErrorChecking
    {
        public static string EnsureDigit(string input) // ensures a string is a digit
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = false;

                foreach (char letter in input)
                {
                    if (char.IsPunctuation(letter) || char.IsLetter(letter))
                    {
                        keepGoing = true;
                    }
                }
                if (keepGoing == true)
                {
                    Console.WriteLine("Please enter a digit only");
                    input = Console.ReadLine();
                }
            }
            return input;
        }

        public static int EnsureEven(int input)
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = false;
                if (input % 2 != 0)
                {
                    Console.WriteLine("Please enter an even number only");
                    string inputString = Console.ReadLine();
                    inputString = EnsureDigit(inputString);
                    input = Int32.Parse(inputString);
                    keepGoing = true;
                }
            }
            return input;
        }

        public static string EnsureEmptyLines(string input) // checks if string is empty
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = false;

                if (input == "" || input == " " || input == "  ")
                {
                    keepGoing = true;
                    Console.WriteLine("Please enter a value, try again");
                    input = Console.ReadLine();
                    input = input.ToUpper();
                }
            }
            return input;
        }
        public static string EnsureLength(string input) // ensures a string does not exceed 25 characters
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = false;
                if (input.Length > 25)
                {
                    keepGoing = true;
                    Console.WriteLine("Please limit the length to under 25, please try again");
                    input = Console.ReadLine();
                    input = EnsureEmptyLines(input);
                    input = input.ToUpper();
                }
            }
            return input;
        }
    }
}
