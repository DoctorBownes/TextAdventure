using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuul
{
    class Player
    {
        public Room currentRoom;
        private int PlayerHealth;
        public Player(Room setCurrentRoom)
        {
            currentRoom = setCurrentRoom;
            PlayerHealth = 100;
        }

        public int DamagePlayer(int amount)
        {
            return PlayerHealth -= amount;
        }
        public int HealPlayer(int amount)
        {
            return PlayerHealth += amount;
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
