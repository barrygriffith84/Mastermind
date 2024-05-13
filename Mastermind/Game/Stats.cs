using MasterMind.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Game
{
    internal class Stats
    {
        private static readonly string _filePath = "./";

        private static readonly string _fileName = "users.txt";

        internal static void GenerateStats()
        {
            Console.Clear();

            double guessesPerGame = LoggedInUser.totalGuesses == 0 ? 0 : LoggedInUser.GuessesPerGame();

            Console.WriteLine($"Games played: " + LoggedInUser.gamesPlayed);
            Console.WriteLine($"Total Guesses: " + LoggedInUser.totalGuesses);
            Console.WriteLine($"Guesses per game: " + guessesPerGame);
            Console.WriteLine($"Wins: " + LoggedInUser.wins);
            Console.WriteLine($"Losses: " + LoggedInUser.losses);

            Console.WriteLine();

            Console.WriteLine("Press ENTER to return to main menu");

            Console.ReadLine();

            MainMenu.GenerateLoggedInMainMenu();
        }

        internal static void RecordStats()
        {
            TextWriter.TextWriter writer = new TextWriter.TextWriter(_filePath, _fileName);

            string lineToWrite = $"{LoggedInUser.userName};{LoggedInUser.hashedPassword};{LoggedInUser.guid};{LoggedInUser.gamesPlayed};{LoggedInUser.totalGuesses};{LoggedInUser.wins};{LoggedInUser.losses}";

            List<string> usersList = writer.GetAllLines();

            File.WriteAllText(_filePath + _fileName, "");

            usersList.ForEach(user =>
            {
                string currentUserName = user.Split(';')[0];
                if (currentUserName == LoggedInUser.userName)
                {
                    writer.WriteText(lineToWrite);
                }
                else
                {
                    writer.WriteText(user);
                }
            });
        }
    }
}
