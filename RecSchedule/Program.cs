using System;
using System.Globalization;

namespace RecSchedule
{
	class Program
	{
		static void Main(string[] args)
		{
#if !DEBUG
			var scheduleDate = FindNextMonday();
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
			var am = new ActivityMatrix(
				sg.CasualMaster,
				sg.HardCoreMaster);
			am.Generate();
		}

		private static DateTime FindNextMonday()
		{
			var testDate = DateTime.Now;
			while (!IsMonday(testDate))
				testDate = testDate.AddDays(1);
			return testDate;
		}

		public static bool IsMonday(DateTime dGame)
		{
			return dGame.DayOfWeek == DayOfWeek.Monday;
		}

		public int WeekNumber(DateTime theDate)
		{
			DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(theDate);
			if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
				theDate = theDate.AddDays(3);

			// Return the week of our adjusted day
			return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
				theDate,
				CalendarWeekRule.FirstFourDayWeek,
				DayOfWeek.Monday);
		}
	}
}
