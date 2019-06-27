using System;
using System.Diagnostics;

namespace NumberGuessingGame
{
    class Program
    {
        static int GetIntegerFromUser(string question) 
        {
            int integerFromUser;
            bool success;
            do
            {
                Console.WriteLine(question);
                string strMax = Console.ReadLine();
                success = int.TryParse(strMax, out integerFromUser); // is always giving a bool..
            } while (success == false);


            return integerFromUser;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Let's play a number guessing game!");

            int max = GetIntegerFromUser("Enter the max for the range you'd like to play with:");

            Random rnd = new Random();
            int secretNumber = rnd.Next(1, max + 1);

            int score = 0;
            int guess;
            do
            {
                Console.ResetColor();

                Console.WriteLine("Your current score is " + score);
                guess = GetIntegerFromUser("Please guess a number between 1 - " + max + ": ");

                if (guess > max || guess < 1)
                {
                    Console.WriteLine("Is guessing really that hard?");
                    Console.WriteLine("Here's a tutorial that's about your competence level:");

                    System.Threading.Thread.Sleep(4000);

                    Process.Start(new ProcessStartInfo("cmd", $"/c start https://www.youtube.com/watch?v=ijoV8QrW5JM"));
                    
                }
                else
                {
                    if (guess > secretNumber)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You were too high, loser! Guess again..");
                        score += 1;
                    }
                    else if (guess < secretNumber)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You were too low, loser! Guess again..");
                        score += 1;
                    }
                }
            } while (guess != secretNumber);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("You got it!");
            Console.WriteLine("Your final score was " + score);

        }
    }
}
