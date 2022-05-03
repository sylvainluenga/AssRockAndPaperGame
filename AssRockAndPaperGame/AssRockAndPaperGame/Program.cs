using System;

namespace AssRockAndPaperGame
{

    enum Choice
    {
        Rock = 0,
        Paper = 1,
        Scissor = 2
    }

    enum Player
    {
        User = 0,
        Computer = 1
    }

    class Program
    {

        static readonly Choice[] Choices = new[] { Choice.Rock, Choice.Paper, Choice.Scissor };
        static readonly Random rnd = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Rock, Paper and scissor Game");
            Console.WriteLine("*******************************");
            int computerScore = 0; 
            int userScore = 0;
            while (true)
            {
                Console.WriteLine("\n********************************************");
                Console.WriteLine("\n\n");
                Console.WriteLine("1. Rock\n2. Paper \n3. Scissor \n4. Quit the game");
                Console.Write("Enter your choice ( 1, 2, 3 or 4) : ");
                var choiceInput = Console.ReadLine();
                var tryGetChoice = int.TryParse(choiceInput, out var choice);
                if (tryGetChoice)
                {
                    if (choice < 1 || choice > 4)
                    {
                        Console.WriteLine("That was an invalid choice");
                    }
                    else
                    {
                        if (choice == 4)
                        {
                            // Quit the game

                            Console.WriteLine("You have quit the game");
                            Console.WriteLine($"Computer : {computerScore}");
                            Console.WriteLine($"You : {userScore}");
                            Console.WriteLine("****************************");
                            var result = userScore == computerScore ? "Draw" : userScore > computerScore ? "You won" : "You lost :)";
                            Console.WriteLine($"Final Result : {result}");
                            break;
                        }
                        else
                        {
                            var computerChoice = Choices[rnd.Next(0, 2)];
                            var userChoice = Choices[choice - 1];
                            Console.WriteLine($"Your choice : {userChoice}");
                            Console.WriteLine($"Computer choice: {computerChoice}");
                            Console.Write("Result : ");
                            if (computerChoice == userChoice)
                            {
                                Console.Write("It's a Tie");
                                continue;
                            }
                            Player? winner = null;
                            switch (userChoice)
                            {
                                case Choice.Rock:
                                    winner = computerChoice == Choice.Scissor ? Player.User : Player.Computer;
                                    break;
                                case Choice.Paper:
                                    winner = computerChoice == Choice.Rock ? Player.User : Player.Computer;
                                    break;
                                case Choice.Scissor:
                                    winner = computerChoice == Choice.Paper ? Player.User : Player.Computer;
                                    break;
                            }

                            if (winner == Player.User)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                userScore += 1;
                                Console.WriteLine("You won");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                
                                Console.ForegroundColor = ConsoleColor.Red;
                                computerScore += 1;
                                Console.WriteLine("You lost !!!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Your choice must be a number raging from 1 to 4");
                }
            }
        }
    }
}
