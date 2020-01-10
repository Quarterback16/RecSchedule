using System;
using System.Collections.Generic;

namespace RecSchedule
{
	public class Lottery : ILottery
	{
		public List<Entrant> Entrants { get; set; }
		public List<Entrant> TheHat { get; set; }

		public void LoadTheHat()
		{
			TheHat = new List<Entrant>();
			foreach (var entrant in Entrants)
			{
				for (int i = 0; i < entrant.Balls; i++)
				{
					TheHat.Add(entrant);
				}
			}
		}

		public string Winner()
		{
			LoadTheHat();
			var rnd = new Random();
			int winner = rnd.Next(0, TheHat.Count);
			return TheHat[winner].Name;
		}

	}

	public class Entrant
	{
		public string Name { get; set; }
		public int Balls { get; set; }

	}
}
