using System;
using System.Globalization;

namespace RecSchedule.Helpers
{
	public static class DateUtilities
	{
		public static DateTime FindNextMonday()
		{
			var testDate = DateTime.Now;
			while (!IsMonday(testDate))
				testDate = testDate.AddDays(1);
			return testDate;
		}

		public static bool IsMonday(
			DateTime dateInFocus)
		{
			return dateInFocus.DayOfWeek == DayOfWeek.Monday;
		}


		public static int WeekNumber(
			DateTime theDate)
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
