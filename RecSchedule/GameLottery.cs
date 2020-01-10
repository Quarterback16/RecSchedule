using System;
using System.Collections.Generic;

namespace RecSchedule
{
	public class GameLottery : IGameLottery
	{
		public List<Entrant> Entrants { get; set; }
		public List<Entrant> TheHat { get; set; }

		public GameLottery()
		{
			Entrants = new List<Entrant>
			{
				new Entrant
				{
					Name = "[[FTL]]",
					Balls = 4
				},
				new Entrant
				{
					Name = "[[GalacticCivilizations_3]]",
					Balls = 3
				},
				new Entrant
				{
					Name = "[[Stellaris]]",
					Balls = 1
				},
				new Entrant
				{
					Name = "Defence Grid 2",
					Balls = 1
				},
				new Entrant
				{
					Name = "Ultima IV",
					Balls = 1
				},
			};
		}

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
