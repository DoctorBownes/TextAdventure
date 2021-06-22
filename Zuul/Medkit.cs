using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuul
{
	public class Medkit : Item
	{
		public int healAmount;
		public Medkit(int weight) : base(weight, "medkit")
		{
			healAmount = 50;
		}

		public override void Use(Object b)
		{
			Player p = (Player) b;
			p.HealPlayer(healAmount);
			//base.Use();
		}
	}
}
