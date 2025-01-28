using System;
using System.Collections.Generic;

namespace CarAdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMainMenu();
        }

        static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("*********************************");
            Console.WriteLine("*                               *");
            Console.WriteLine("*    Eren's racing adventure.   *");
            Console.WriteLine("*                               *");
            Console.WriteLine("*********************************");
            Console.WriteLine();
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Credits");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    StartGame();
                    break;
                case "2":
                    ShowCredits();
                    break;
                case "3":
                    ExitGame();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    ShowMainMenu();
                    break;
            }
        }

        static void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine("*********************************");
            Console.WriteLine("*           Credits             *");
            Console.WriteLine("*********************************");
            Console.WriteLine("*                               *");
            Console.WriteLine("* Developed by:                 *");
            Console.WriteLine("* EREN KESKIN                   *");
            Console.WriteLine("*                               *");
            Console.WriteLine("*********************************");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            ShowMainMenu();
        }

        static void StartGame()
        {
            Console.Clear();
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine() ?? "Player";
            Player player = new Player(playerName);
            Map map = new Map(10, 10); 

            Console.WriteLine();
            Console.WriteLine("******************************************");
            Console.WriteLine("*                                        *");
            Console.WriteLine("* Use 'W', 'A', 'S', 'D' to move.        *");
            Console.WriteLine("* Type -inventory- to see your items     *");
            Console.WriteLine("* Type -money- to see your balance       *");
            Console.WriteLine("* Type -power- to see your power         *");
            Console.WriteLine("* and 'exit' to quit.                    *");
            Console.WriteLine("*                                        *");
            Console.WriteLine("******************************************");
            Console.WriteLine("\nPress any key to start...");
            Console.ReadKey();

            map.DisplayMap(player.Initial);

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    Console.WriteLine("Exiting the game. Goodbye!");
                    break;
                }
                else if (input == "inventory")
                {
                    player.ShowInventory();
                }
                else if (input == "money")
                {
                    Console.WriteLine($"You have {player.Money} coins.");
                }
                else if (input == "power")
                {
                    Console.WriteLine($"You have {player.Power} power.");
                }
                else if (input.Length == 1 && "wasd".Contains(input))
                {
                    map.MovePlayer(input[0], player);
                }
                else
                {
                    Console.WriteLine("Invalid command. Use 'w', 'a', 's', 'd' to move, 'inventory' to view your inventory, 'money' to view your money, 'power' to view your power, or 'exit' to quit.");
                }
            }
        }

        static void ExitGame()
        {
            Console.WriteLine("Exiting the game. Goodbye!");
            Environment.Exit(0);
        }
    }
}
