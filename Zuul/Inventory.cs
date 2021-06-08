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
		private int totalWeight;
		private Dictionary<string, Item> items;
		public Inventory(int maxWeight)
		{
			totalWeight = 0;
			this.maxWeight = maxWeight;
			this.items = new Dictionary<string, Item>();
		}
		public bool Put(Item item)
		{
			totalWeight += item.Weight;
			if (totalWeight <= this.maxWeight)
			{
				items.Add(item.Description, item);
				return true;
			}
			totalWeight -= item.Weight;
			Console.WriteLine("You are overcumbered!");
			return false;
		}
		public Item Get(string itemName)
		{
			if (items.ContainsKey(itemName))
			{
				Item tempItem = new Item(items[itemName].Weight, items[itemName].Description);
				totalWeight -= tempItem.Weight;
				items.Remove(itemName);
				return tempItem;
			}
			return null;
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
