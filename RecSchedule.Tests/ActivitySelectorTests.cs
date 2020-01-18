using RecSchedule.Model;
using Xunit;

namespace RecSchedule.Tests
{
	public class ActivitySelectorTests
	{
		[Fact]
		public void ActivitySelector_ReadsState()
		{
			var sut = new ActivitySelector();
			Assert.True(sut.Counts().Equals(2));
		}

		[Fact]
		public void ActivitySelector_SavesState()
		{
			var sut = new ActivitySelector();
			sut.SaveState("Casual", 3);
			var sut2 = new ActivitySelector();
			var result = sut2.GetLastActivity("Casual");
			Assert.Equal(3, result);
		}

		[Fact]
		public void CountMaster_Saves_Counts()
		{
			var sut = new CountMaster("counts.xml");
			var input = new CountItem("Casual", 4);
			sut.PutItem(input);
			var result = (CountItem) sut.TheHt["Casual"];
			Assert.True(result.Count == 4);
		}
	}
}
