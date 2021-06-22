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
			Room a = (Room) b;
			a.Unlock();
			//base.Use();
		}
	}
}

