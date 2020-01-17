using System.Collections.Generic;

namespace RecSchedule
{
	public class MediaLottery : Lottery
	{
		public List<Movie> Movies { get; set; }

		public MediaLottery()
		{
			Entrants = new List<Entrant>
			{
				new Entrant
				{
					Name = "The Expanse",
					Balls = 50
				},
				new Entrant
				{
					Name = "Rick and Morty",
					Balls = 30
				},
				new Entrant
				{
					Name = "Silicon Valley",
					Balls = 20
				},
				new Entrant
				{
					Name = "Ballers",
					Balls = 10
				},
				new Entrant
				{
					Name = "Twelve Monkeys",
					Balls = 10
				},
				new Entrant
				{
					Name = "Star Wars the Last Jedi",
					Balls = 20
				},
				new Entrant
				{
					Name = "The Irishman",
					Balls = 20
				},
				new Entrant
				{
					Name = "Ad Astra (carnage)",
					Balls = 20
				},
				new Entrant
				{
					Name = "Rambo Last Blood (carnage)",
					Balls = 20
				},
				new Entrant
				{
					Name = "Wonder Woman Bloodlines (carnage)",
					Balls = 10
				},

			};
			LoadMovies();
			foreach (var movie in Movies)
			{
				Entrants.Add(new Entrant
				{
					Name = movie.Name,
					Balls = 1
				});
			}
		}

		private void LoadMovies()
		{
			Movies = new List<Movie>
			{
				new Movie
				{
					Name = "Das Boot"
				},
				new Movie
				{
					Name = "Pandora and the Flying Dutchman"
				},
				new Movie
				{
					Name = "Rififi"
				},
				new Movie
				{
					Name = "Room in Rome"
				},
				new Movie
				{
					Name = "Space Pirate Captain Harlock"
				},
				new Movie
				{
					Name = "The Wages of Fear"
				},
				new Movie
				{
					Name = "Tombstone"
				},
				new Movie
				{
					Name = "When the Gam Stands Tall"
				},
				new Movie
				{
					Name = "Zorba the Greek"
				},
				new Movie
				{
					Name = "Code 8 (carnage)"
				},
				new Movie
				{
					Name = "3:10 to Yuma (carnage)"
				},
				new Movie
				{
					Name = "Desire (carnage)"
				},
				new Movie
				{
					Name = "Hacksaw Ridge (carnage)"
				},
				new Movie
				{
					Name = "Se7en (carnage)"
				},
				new Movie
				{
					Name = "Rounders"
				},
				new Movie
				{
					Name = "JoJo Rabbit"
				},
				new Movie
				{
					Name = "The House"
				},
				new Movie
				{
					Name = "Any Given Sunday"
				},
			};
		}
	}

	public class Movie
	{
		public string Name { get; set; }
	}
}
