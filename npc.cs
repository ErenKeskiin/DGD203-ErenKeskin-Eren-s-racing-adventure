using System;

namespace CarAdventureGame
{
    public class Map
    {
        private char[,] map;
        private int playerX;
        private int playerY;
        private NPC garageNPC;
        private NPC mikelNPC;
        private bool firstRaceAttempt = true;

        public Map(int width, int height)
        {
            map = new char[height, width];
            playerX = width / 2;
            playerY = height / 2;

            
            map[height - 2, width - 2] = 'G';
            garageNPC = new NPC("Mechanic", "Welcome to the garage!");
            garageNPC.AddItemForSale(new Item("Big Turbo", 100, 50, "A special item: Boosts your car's power significantly. Available only during your first visit."));
            garageNPC.AddItemForSale(new Item("ECU", 300, 30, "Enhances your car's engine control unit."));

            
            map[1, 1] = 'M';
            mikelNPC = new NPC("Mikel", "Welcome to the gallery!");
            mikelNPC.AddItemForSale(new Item("VOLKSWAGEN scirocco", 600, 430, "A powerful and stylish car."));
            mikelNPC.AddItemForSale(new Item("SEAT ibiza", 350, 270, "A compact and efficient car."));
            mikelNPC.AddItemForSale(new Item("Exhaust system", 125, 25, "Enhances your car's exhaust system."));
            mikelNPC.AddItemForSale(new Item("Spoiler", 25, 5, "Improves your car's aerodynamics."));
            mikelNPC.AddItemForSale(new Item("Rims and tires", 50, 10, "Upgrades your car's wheels."));
            mikelNPC.AddItemForSale(new Item("Lowering springs", 50, 10, "Lowers your car for better handling."));

            
            map[height / 2, width - 2] = 'W';

           
            map[height / 2, 1] = 'R';
        }

        public void DisplayMap(char playerInitial)
        {
            Console.Clear();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (i == playerY && j == playerX)
                        Console.Write(playerInitial);
                    else
                        Console.Write(map[i, j] == '\0' ? '.' : map[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void MovePlayer(char direction, Player player)
        {
            
            map[playerY, playerX] = '.';

            switch (direction)
            {
                case 'w':
                    if (playerY > 0) playerY--;
                    break;
                case 'a':
                    if (playerX > 0) playerX--;
                    break;
                case 's':
                    if (playerY < map.GetLength(0) - 1) playerY++;
                    break;
                case 'd':
                    if (playerX < map.GetLength(1) - 1) playerX++;
                    break;
                default:
                    break;
            }

            
            map[map.GetLength(0) - 2, map.GetLength(1) - 2] = 'G';
            map[1, 1] = 'M';
            map[map.GetLength(0) / 2, map.GetLength(1) - 2] = 'W';
            map[map.GetLength(0) / 2, 1] = 'R';

            
            DisplayMap(player.Initial);

            
            if (playerX == map.GetLength(1) - 2 && playerY == map.GetLength(0) - 2)
            {
                garageNPC.Talk(player);
            }
            
            else if (playerX == 1 && playerY == 1)
            {
                mikelNPC.Talk(player);
            }
            
            else if (playerX == map.GetLength(1) - 2 && playerY == map.GetLength(0) / 2)
            {
                PlayMinigame(player);
            }
            
            else if (playerX == 1 && playerY == map.GetLength(0) / 2)
            {
                ParticipateInRace(player);
            }
        }

        private void PlayMinigame(Player player)
        {
            Console.WriteLine("You have worked hard and earned 50 coins!");
            player.Money += 50;
            Console.WriteLine($"Your new balance is: {player.Money} coins.");
        }

        private void ParticipateInRace(Player player)
        {
            Console.WriteLine("******************************************");
            Console.WriteLine("*                                        *");
            Console.WriteLine("* Welcome to the Street Race!            *");
            Console.WriteLine("*                                        *");
            Console.WriteLine("******************************************");
            if (player.Power < 500)
            {
                Console.WriteLine("You don't have enough power to participate in the race. You need at least 500 power.");
                return;
            }

            if (player.Power >= 500)
            {
                if (firstRaceAttempt && player.Power == 500)
                {
                    Console.WriteLine("You have enough power to participate, but you lost the race. Try again!");
                    firstRaceAttempt = false;
                }
                else
                {
                    Console.WriteLine("Congratulations! You won the race!");
                }
            }
        }
    }
}
