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

        static void GiveUserARandomInsult(string[] availableInsults)
        {
            Random random = new Random();
            int insultIndex = random.Next(0, availableInsults.Length);
            string insult = availableInsults[insultIndex];
            Console.WriteLine(insult);
        }

        static void RespondToIncorrectGuess(string [] insultsToBeUsed, string highLowHint) // parameters in () need to be supplied. ( string array and a string are needed)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(highLowHint);
            GiveUserARandomInsult(insultsToBeUsed);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Let's play a number guessing game!");

            int max = GetIntegerFromUser("Enter the max for the range you'd like to play with:");

            Random rnd = new Random();
            int secretNumber = rnd.Next(1, max + 1);

            string[] insults = 
            {
                "Your father was a hampster and your mother smells of elderberries!",
                "You are quite the guesser! NOT!",
                "Maybe you should try a different game. Perhaps jumping down some stairs?",
                "Try " + (secretNumber + 1) + ". No, really, you should try " + (secretNumber + 1) + "."

            };

            int score = 0;
            int guess;
            bool shouldLaunchVideo = true;
            do
            {
                Console.ResetColor();

                Console.WriteLine("Your current score is " + score);
                guess = GetIntegerFromUser("Please guess a number between 1 - " + max + ": ");

                if (guess > max || guess < 1)
                {
                    Console.WriteLine("Is guessing really that hard?");

                    if (shouldLaunchVideo == true)
                    {
                        shouldLaunchVideo = false;
                        Console.WriteLine("Here's a tutorial that's about your competence level:");
    
                        System.Threading.Thread.Sleep(4000);

                        Process.Start(new ProcessStartInfo("cmd", $"/c start https://www.youtube.com/watch?v=ijoV8QrW5JM"));
                    }
                    score += 10;
                }
                else
                {
                    if (guess > secretNumber)
                    {
                        RespondToIncorrectGuess(insults, "You were too high, loser! Guess again.."); //() tell us to give parameters needed.
                        score ++;
                    }
                    else if (guess < secretNumber)
                    {
                        RespondToIncorrectGuess(insults, "You were too low, loser! Guess again..");
                        score++;
                    }
                }
            } while (guess != secretNumber);

            Console.Beep(440, 250);
            Console.Beep(440, 250);
            Console.Beep(600, 250);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("You got finally it!");
            Console.WriteLine("Your final score was " + score);
            Console.WriteLine("Better luck next time");

        }
    }
}
