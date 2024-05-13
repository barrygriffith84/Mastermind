using MasterMind.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Auth
{
    internal class Login
    {
        private static readonly string _filePath = "./";

        private static readonly string _fileName = "users.txt";

        public static void GenerateLogin()
        {
            string userNameInput;

            while (true)
            {
                Console.Write("Please enter your username: ");
                userNameInput = Console.ReadLine();

                if (!String.IsNullOrEmpty(userNameInput))
                {

                    GetUser(userNameInput, out bool userFound);

                    if (userFound)
                    {
                        Guid guid = Guid.Parse(LoggedInUser.guid);

                        while (true)
                        {
                            Console.Write("Enter your password: ");

                            string userPasswordInput = Console.ReadLine();

                            if (!String.IsNullOrEmpty(userPasswordInput))
                            {
                                string hashedPass = Hashing.CreateHashString(userPasswordInput, guid);


                                if (hashedPass == LoggedInUser.hashedPassword)
                                {
                                    LoggedInUser.isLoggedIn = true;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid password");
                                }
                            }
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Username not found");
                    }

                }

            }

            MainMenu.GenerateLoggedInMainMenu();

        }

        private static void GetUser(string userName, out bool userFound)
        {
            string currentUserName;
            userFound = false;


            if (!File.Exists(_filePath + _fileName))
            {
                File.CreateText(_filePath + _fileName);
                Thread.Sleep(2000);
            }


            StreamReader sr = new StreamReader(_filePath + _fileName);

            var line = sr.ReadLine();

            while (line != null)
            {
                string[] currentUser = line.Split(";");
                currentUserName = currentUser[0];

                if (currentUserName.ToLower() == userName.ToLower())
                {

                    LoggedInUser.userName = currentUserName;
                    LoggedInUser.hashedPassword = currentUser[1];
                    LoggedInUser.guid = currentUser[2];
                    LoggedInUser.gamesPlayed = int.Parse(currentUser[3]);
                    LoggedInUser.totalGuesses = int.Parse(currentUser[4]);
                    LoggedInUser.wins = int.Parse(currentUser[5]);
                    LoggedInUser.losses = int.Parse(currentUser[6]);

                    userFound = true;
                    break;

                }


                line = sr.ReadLine();
            }

            sr.Close();

        }

    }
}
