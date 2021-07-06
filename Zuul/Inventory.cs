using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuul
{
	public class Inventory
	{
		private int maxWeight;
		private Dictionary<string, Item> items;
		public Inventory(int maxWeight)
		{
			this.maxWeight = maxWeight;
			this.items = new Dictionary<string, Item>();
		}
		public bool Put(Item item)
		{
			if (TotalWeight() + item.Weight <= this.maxWeight)
			{
				items.Add(item.Description, item);
				return true;
			}
			Console.WriteLine("You are overcumbered!");
			return false;
		}
		public Item Get(string itemName)
		{
			if (items.ContainsKey(itemName))
			{
				Item tempItem = items[itemName];
				items.Remove(itemName);
				return tempItem;
			}
			return null;
		}

		private int TotalWeight()
        {
			int tempWeight = 0;
			foreach (KeyValuePair<string, Item> item in items)
			{
				tempWeight += item.Value.Weight;
			}
			return tempWeight;
        }

		public string GetAllItems()
		{
			string str = "Items in the room:";
			if (items.Count != 0)
			{

				// because `exits` is a Dictionary, we use a `foreach` loop
				int countcommas = 0;
				foreach (string key in items.Keys)
				{
					if (countcommas != 0)
					{
						str += ",";
					}
					str += " " + key;
					countcommas++;
				}

				return str;
			}
			str = "There are no items in the room.";
			return str;
		}
	}
}
