using Xunit;
using Xunit.Abstractions;

namespace RecSchedule.Tests
{
	public class GameLotteryTests : BaseTests
	{
		private readonly GameLottery _sut;

		public GameLotteryTests(
			ITestOutputHelper output) : base(output)
		{
			_sut = new GameLottery();
		}

		[Fact]
		public void GameLottery_ReturnsTheWinner()
		{
			var result = _sut.Winner();
			Assert.NotNull(result);
			output.WriteLine(result);
		}

		[Fact]
		public void GameLottery_AfterLoading_HatHas_23_Entrants()
		{
			_sut.LoadTheHat();
			Assert.Equal(
				expected: 23,
				actual: _sut.TheHat.Count);
		}
	}
}
