using System.Text;

namespace RecSchedule
{
	public class GameList : LotteryList
	{
		public ILottery Lottery { get; set; }

		public GameList(
			ILottery gameLottery)
		{
			Lottery = gameLottery;
		}

        public string Generate()
        {
            var sb = new StringBuilder();
            LoadGameEntrants();
            OutputTable("Game",sb);
            return sb.ToString();
        }

        private void LoadGameEntrants()
        {
            Entrants.AddRange(Lottery.Entrants);
        }
    }
}
