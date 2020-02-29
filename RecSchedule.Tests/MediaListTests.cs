using Xunit;
using Xunit.Abstractions;

namespace RecSchedule.Tests
{
	public class MediaListTests : BaseTests
	{
		private readonly MediaList _sut;

        public MediaListTests
            (ITestOutputHelper output) : base(output)
        {
            _sut = new MediaList(
                new MediaLottery());
        }

        [Fact]
        public void MediaList_Generates_SwikiTable()
        {
            var result = _sut.Generate();
            Assert.NotNull(result);
            output.WriteLine(result);
        }

    }
}
