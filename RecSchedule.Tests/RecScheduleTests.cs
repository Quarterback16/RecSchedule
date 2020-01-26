using RecSchedule.Domain;
using System;
using Xunit;
using Xunit.Abstractions;

namespace RecSchedule.Tests
{
	public class RecScheduleTests
	{
		private readonly ITestOutputHelper output;

		public RecScheduleTests(
			ITestOutputHelper output)
		{
			this.output = output;
		}

		[Fact]
		public void Main_DisplaysWikiOutput()
		{
			var cut = new ScheduleGenerator(
				"2020-01-27",
				Console.Out);
			var result = cut.Generate();
			output.WriteLine(result);
			Assert.NotNull(result);
		}

		[Fact]
		public void DefaultRecActivityDescription_IsFree()
		{
			var cut = new RecActivity();
			Assert.True(cut.Description == "free");
		}

		[Fact]
		public void DefaultRecSessionType_IsCasual()
		{
			var cut = new RecSession();
			Assert.True(cut.SessionType == SessionType.Casual);
		}

	}
}
