using System.Globalization;

namespace ZeroToHero.DecisionsAndIteration
{
    /*
     Guess the Number
     Develop a console-based number guessing game. The program should:

     Generate a random number between a specified range (e.g., 1 to 100).
     Allow the user to guess the number.
     Provide feedback on whether the guess is too high, too low, or correct.
     Allow the user to keep guessing until they correctly identify the number.
     
     Example:
     Welcome to the Guess the Number game!
     I have chosen a number between 1 and 100.
     
     Enter your guess: 50
     Too low! Try again.
     
     Enter your guess: 75
     Too high! Try again.
     
     Enter your guess: 60
     Congratulations! You guessed the correct number (60)!

     */
    public class PuttingItAllTogether
    {
        public PuttingItAllTogether()
        {
            
        }
        public int Score { get; set; } = 0;
        public void GuessTheNumber()
        {
            var random = new Random();
            int number = random.Next(1, 100);
            Console.WriteLine("Welcome to the Guess the Number game!");
            do
            {
                Console.WriteLine("Enter a guess");
                var isNumber = int.TryParse(Console.ReadLine(), out var guess);
                if (!isNumber)
                {
                    Console.WriteLine("Please enter a valid number");
                    continue;
                }
                if(guess > number)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else if(guess < number)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You guessed the correct number ({number})!");
                    Console.WriteLine("Would you like to play again? (y/n)");
                    var shouldPlayAgain = Console.ReadLine();
                    while (string.IsNullOrEmpty(shouldPlayAgain))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid input");
                        Console.WriteLine("Would you like to play again? (y/n)");
                        shouldPlayAgain = Console.ReadLine();
                    }
                    if(shouldPlayAgain.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        GuessTheNumber();
                    }

                    Console.WriteLine("Thanks for playing!");
                    Score++;
                    break;
                }
            } while (true);

            Console.WriteLine($"Your score is {Score}");
        }
        public void Build()
        {
            Console.WriteLine("\n-----Start PuttingItAllTogether Exercise-----\n");
            GuessTheNumber();
            Console.WriteLine("\n-----End PuttingItAllTogether Exercise-----\n");
        }
    }
}
