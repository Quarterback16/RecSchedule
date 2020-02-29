using Xunit;
using Xunit.Abstractions;

namespace RecSchedule.Tests
{
	public class GameListTests : BaseTests
	{
        private readonly GameList _sut;

        public GameListTests
            (ITestOutputHelper output) : base(output)
        {
            _sut = new GameList(
                new GameLottery());
        }

        [Fact]
        public void GameList_Generates_SwikiTable()
        {
            var result = _sut.Generate();
            Assert.NotNull(result);
            output.WriteLine(result);
        }
    }
}
