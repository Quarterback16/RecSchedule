using System.Collections.Generic;

namespace RecSchedule
{
	public class GameLottery : Lottery
	{
		public GameLottery()
		{
			Entrants = new List<Entrant>
			{
				new Entrant
				{
					Name = "[[FTL]]",
					Balls = 3
				},
				new Entrant
				{
					Name = "[[Stellaris]]",
					Balls = 2
				},
				new Entrant
				{
					Name = "Defence Grid 2",
					Balls = 2
				},
				new Entrant
				{
					Name = "Ultima IV",
					Balls = 1
				},
				new Entrant
				{
					Name = "Darkest Dungeon",
					Balls = 1
				},
				new Entrant
				{
					Name = "Divinity Original Sin",
					Balls = 1
				},
				new Entrant
				{
					Name = "Endless Legend",
					Balls = 1
				},
				new Entrant
				{
					Name = "Endless Space",
					Balls = 1
				},
				new Entrant
				{
					Name = "Master of Orion 2",
					Balls = 1
				},
				new Entrant
				{
					Name = "Alpha Centauri",
					Balls = 1
				},
				new Entrant
				{
					Name = "Crying Suns",
					Balls = 1
				},
			};
		}


	}


}
