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
					Name = "[[GalacticCivilizations_3]]",
					Balls = 3
				},
				new Entrant
				{
					Name = "[[Anno_2025]]",
					Balls = 2
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


	}


}
