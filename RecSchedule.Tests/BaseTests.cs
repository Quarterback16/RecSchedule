using Xunit.Abstractions;

namespace RecSchedule.Tests
{
	public class BaseTests
	{
		public readonly ITestOutputHelper output;

		public BaseTests(
			ITestOutputHelper output)
		{
			this.output = output;
		}
	}
}
