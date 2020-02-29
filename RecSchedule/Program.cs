using RecSchedule.Helpers;
using System;

namespace RecSchedule
{
	class Program
	{
		static void Main(string[] args)
		{
#if !DEBUG
			var scheduleDate = DateUtilities.FindNextMonday();
#else
			//  test with a fixed Monday
			var scheduleDate = new DateTime(2020, 1, 27);
#endif

			var scheduleDateOut = scheduleDate.ToString("yyyy-MM-dd");
			if (args.Length > 0)
				scheduleDateOut = args[0].ToString();

			var sg = new ScheduleGenerator(
				scheduleDateOut,
				Console.Out);

			sg.Generate();
		}
	}
}
