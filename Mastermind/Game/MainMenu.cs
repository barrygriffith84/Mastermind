using MasterMind.Auth;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Game
{
    internal class MainMenu
    {
        internal static async void GenerateMainMenu()
        {

            Console.Clear();


            Console.WriteLine("Welcome to Guessing Game!");

            Console.WriteLine();

            Console.WriteLine("1. How to play");

            Console.WriteLine("2. Play without logging in");

            Console.WriteLine("3. Create an account");

            Console.WriteLine("4. Log in");

            Console.WriteLine("5. Quit");


            Console.WriteLine();

        NotFound:
            Console.Write("Input a number 1 - 5: ");

            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Demo.ShowDemo();
                    break;
                case "2":
                    GameSession.StartGameSession();
                    break;
                case "3":
                    Register.RegisterUser();
                    break;
                case "4":
                    Login.GenerateLogin();
                    break;
                case "5":
                    break;

                default:
                    goto NotFound;

            }



        }

        internal static async void GenerateLoggedInMainMenu()
        {

            Console.Clear();


            Console.WriteLine("Welcome to Guessing Game!");

            Console.WriteLine();

            Console.WriteLine("1. How to play");

            Console.WriteLine("2. Play a game");

            Console.WriteLine("3. Game stats");

            Console.WriteLine("4. Log out");

            Console.WriteLine("5. Quit");



            Console.WriteLine();

        NotFound:
            Console.Write("Input a number 1 - 4: ");

            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Demo.ShowDemo();
                    break;
                case "2":
                    GameSession.StartGameSession();
                    break;
                case "3":
                    Stats.GenerateStats();
                    break;
                case "4":
                    LoggedInUser.Logout();
                    break;
                case "5":
                    break;
                default:
                    goto NotFound;

            }



        }

    }
}
