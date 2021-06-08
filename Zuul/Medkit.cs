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
		public Medkit() : base(10, "Medkit")
		{
			healAmount = 50;
		}

		public override void Use()
		{
			base.Use();
		}
	}
}
