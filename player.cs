using System;
using System.Collections.Generic;

namespace CarAdventureGame
{
    public class Player
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public int Power { get; set; } 
        public List<string> Inventory { get; set; }
        public char Initial { get { return Name[0]; } }

        public Player(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");
            }
            Name = name;
            Money = 900; 
            Power = 0; 
            Inventory = new List<string>();
        }

        public void AddToInventory(string item, int power) 
        {
            Inventory.Add(item);
            Power += power; 
            Console.WriteLine($"{item} added to inventory. Power increased by {power}. New Power: {Power}");
        }

        public void RemoveFromInventory(string item, int power) 
        {
            if (Inventory.Contains(item))
            {
                Inventory.Remove(item);
                Power -= power; 

                Console.WriteLine($"{item} removed from inventory. Power decreased by {power}. New Power: {Power}");
            }
            else
            {
                Console.WriteLine($"{item} is not in the inventory.");
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("Inventory:");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }
}
