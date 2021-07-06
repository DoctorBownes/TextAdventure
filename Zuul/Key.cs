using System;
using System.Collections.Generic;
using System.Text;

namespace Zuul
{
	public class Key : Item
	{
		public Key(int weight, string KeyName) : base(weight, KeyName)
		{
		}

		public override void Use(Object b)
		{
			if (b is Room)
			{
				Room a = (Room)b;
				a.Unlock();
			}
			else
            {
				Console.WriteLine("You tried using the key on yourself and it broke!");
            }
			//base.Use();
		}
	}
}

