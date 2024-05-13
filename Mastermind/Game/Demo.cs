using MasterMind.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Game
{
    internal class Demo
    {
        static internal void ShowDemo()
        {
            Console.Clear();

            List<string> numStringList = APIManager.APIManager.GetRandomNumbers().GetAwaiter().GetResult();


            Console.WriteLine("Guessing game will generate four random numbers between 0 and 7.");

            Thread.Sleep(5000);

            Console.WriteLine("You must guess all four numbers in the correct order to win.");

            Thread.Sleep(5000);

            Console.WriteLine("You will be prompted to enter a guess four times.");

            Thread.Sleep(5000);

            Console.WriteLine();

            for (int i = 0; i < 4; i++)
            {
                string ordinal = GameSession.CreateOrdinal(i + 1);

                Console.Write($"Enter your {ordinal} guess: ");

                Thread.Sleep(1000);

                Console.WriteLine(numStringList[i]);

                Thread.Sleep(1000);
            }

            Console.WriteLine("2 number(s) correct and 1 location(s) correct.");

            Console.WriteLine();

            Console.WriteLine("You have guessed two of the numbers correctly, but only on of them is in the correct location in the order.");

            Console.WriteLine();

            Console.WriteLine("You have 10 rounds to guess the four numbers in the correct order.");

            Console.WriteLine();

            Console.WriteLine("Hit ENTER to go back to the main menu.");

            Console.ReadLine();

            if (LoggedInUser.isLoggedIn)
            {
                MainMenu.GenerateLoggedInMainMenu();
            }
            else
            {
                MainMenu.GenerateMainMenu();
            }

            Console.ReadLine();
        }
    }
}
