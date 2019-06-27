using System;

namespace NumberGuessingGame
{
    class Program
    {
        static int GetIntegerFromUser(string question) //Give a question and this method will do the following.
        {
            int integerFromUser;
            bool success;
            do
            {
                Console.WriteLine(question);
                string strMax = Console.ReadLine();
                success = int.TryParse(strMax, out integerFromUser);
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
            } while (guess != secretNumber);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("You got it!");
            Console.WriteLine("Your final score was " + score);

        }
    }
}
