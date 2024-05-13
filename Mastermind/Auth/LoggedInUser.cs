using MasterMind.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Auth
{
    internal class LoggedInUser
    {
        public static bool isLoggedIn = false;

        public static string userName = "";

        public static string hashedPassword = "";

        public static string guid = "";

        public static int gamesPlayed = 0;

        public static int totalGuesses = 0;

        public static int wins = 0;

        public static int losses = 0;

        public static void Logout()
        {
            isLoggedIn = false;
            userName = "";
            hashedPassword = "";
            guid = "";
            gamesPlayed = 0;
            totalGuesses = 0;
            wins = 0;
            losses = 0;

            MainMenu.GenerateMainMenu();
        }
        public static double GuessesPerGame()
        {
            double guessesPerGame = Convert.ToDouble(totalGuesses) / Convert.ToDouble(gamesPlayed);

            return guessesPerGame;
        }
    }
}

