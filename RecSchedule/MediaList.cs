using System.Text;

namespace RecSchedule
{
    public class MediaList : LotteryList
	{
        public MediaLottery Lottery { get; set; }

        public MediaList(
            MediaLottery ml) : base()
		{
            Lottery = ml;
		}

        public string Generate()
        {
            var sb = new StringBuilder();
            LoadMediaEntrants();
            OutputTable("Media", sb);
            return sb.ToString();
        }

        private void LoadMediaEntrants()
        {
            Entrants.AddRange(Lottery.Entrants);
            foreach (var movie in Lottery.Movies)
            {
                Entrants.Add(
                    new Entrant
                    {
                        Name = movie.Name,
                        Balls = 1
                    });
            }
        }

    }
}