using MasterMind.Auth;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Game
{
    internal class GameSession
    {
        public static void StartGameSession()
        {
            Console.Clear();

            List<string> numsFromAPI = APIManager.APIManager.GetRandomNumbers().GetAwaiter().GetResult();


            Console.WriteLine("Guess four numbers between 0 and 7.");

            int guessCount = 0;
            bool isWinner = false;
            string resultsMessage;
            string finalMessage = "Ahh shucks, you lost.";

            while (true)
            {
                List<string> randomNumberStringList = new(numsFromAPI);
                List<string> userInputList = new List<string>();

                int numberOfInputs = 1;

                while (true)
                {

                    if (numberOfInputs >= 5) { break; };

                    string ordinal = CreateOrdinal(numberOfInputs);

                    Console.Write($"Enter your {ordinal} guess: ");

                    string userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out int result))
                    {

                        userInputList.Add(userInput);

                        numberOfInputs++;


                    }

                }

                int correctNumber = 0;
                int correctLocation = 0;


                //Check how many locations are correct.
                for (int i = 0; i < userInputList.Count; i++)
                {
                    if (userInputList[i] == randomNumberStringList[i])
                    {
                        correctNumber++;
                        correctLocation++;
                        randomNumberStringList[i] = "Number guessed";
                        userInputList[i] = "Location found";
                    }

                }

                //Check how many remaining numbers are correct but not in the correct location.
                for (int i = 0; i < randomNumberStringList.Count; i++)
                {
                    if (randomNumberStringList.Contains(userInputList[i]))
                    {
                        correctNumber++;
                        int index = randomNumberStringList.FindIndex(numStr => numStr == userInputList[i]);

                        randomNumberStringList[index] = "Number guessed";

                    }
                }


                if (correctLocation == 4)
                {
                    finalMessage = $"{correctNumber} number(s) correct and {correctLocation} location(s) correct.  You got them all correct, you win!";
                    isWinner = true;
                    break;
                }
                else if (correctNumber > 0)
                {
                    resultsMessage = $"{correctNumber} number(s) correct and {correctLocation} location(s) correct";
                }
                else
                {
                    resultsMessage = "All incorrect!";
                }


                Console.WriteLine(resultsMessage);
                guessCount++;

                if (guessCount >= 10)
                {
                    break;
                }
            }

            Console.WriteLine();

            Console.WriteLine(finalMessage);

            Console.WriteLine();

            Console.WriteLine("Hit enter to return to the main menu.");

            Console.ReadLine();

            if (LoggedInUser.isLoggedIn)
            {
                LoggedInUser.gamesPlayed++;
                LoggedInUser.totalGuesses = guessCount + LoggedInUser.totalGuesses;

                if (isWinner)
                {
                    LoggedInUser.wins++;
                }
                else
                {
                    LoggedInUser.losses++;
                }

                Stats.RecordStats();
                MainMenu.GenerateLoggedInMainMenu();
            }
            else
            {
                MainMenu.GenerateMainMenu();
            }


        }

        public static string CreateOrdinal(int num)
        {
            switch (num)
            {
                case 1:
                    return "first";
                case 2:
                    return "second";
                case 3:
                    return "third";
                default:
                    return "fourth";
            }
        }
    }
}
