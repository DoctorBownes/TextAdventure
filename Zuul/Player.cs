using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuul
{
    public class Player
    {
        public Room currentRoom;
        private int PlayerHealth;
		private Inventory inventory;

		public Player(Room setCurrentRoom)
        {
            currentRoom = setCurrentRoom;
            PlayerHealth = 100;
			inventory = new Inventory(70);
        }


		public bool TakeFromChest(string itemName)
		{
			Item ItemCheck = currentRoom.Chest.Get(itemName);
			if (ItemCheck != null)
			{
				if  (inventory.Put(ItemCheck) == true)
				{
					Console.WriteLine("You put the " + itemName + " in your inventory.");
					return true;
				}
				currentRoom.Chest.Put(ItemCheck);
				return false;
			}
			Console.WriteLine("There is no " + itemName + " in the room...");
			return false;
		}
		public bool DropToChest(string itemName)
		{
			Item ItemCheck = inventory.Get(itemName);
			if (ItemCheck != null)
			{
				currentRoom.Chest.Put(ItemCheck);
				Console.WriteLine("You dropped the " + itemName);
				return true;
			}
			Console.WriteLine("There is no " + itemName + " in your inventory.");
			return false;
		}

        public string Use(Command command)
		{
			string str = "You use the " + command.GetSecondWord();
			var ItemCheck = inventory.Get(command.GetSecondWord());
			if (ItemCheck != null)
			{
				if (!command.HasThirdWord())
				{
					ItemCheck.Use(this);
					return str;
				}
				Room nextRoom = CurrentRoomExits(command.GetThirdWord());
				if (nextRoom == null)
				{
					ItemCheck.Use(nextRoom);
					return str;
				}
			}
			str = "You don't have a " + command.GetSecondWord();
			return str;
		}

        public int DamagePlayer(int amount)
        {
            return PlayerHealth -= amount;
        }
        public int HealPlayer(int amount)
		{
			PlayerHealth += amount;
            if (PlayerHealth > 100)
            {
                PlayerHealth = 100;
            }
            return PlayerHealth;

		}
        public bool isAlive()
        {
            if (PlayerHealth <= 0)
            {
                Console.WriteLine("You have died...");
                return false;
            }
            return true;
		}

		public string GetPlayerItems()
		{
			return inventory.GetAllItems();
		}

		public string GetCurrentRoomItems()
		{
			return currentRoom.Chest.GetAllItems();
		}

        public string GetCurrentRoomDesc()
        {
            return currentRoom.GetLongDescription();
        }

        public Room CurrentRoomExits(string exit)
        {
            return currentRoom.GetExit(exit);
        }
    }
}
