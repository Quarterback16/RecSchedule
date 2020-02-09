using System;

namespace RecSchedule
{
	public class HolidayMaster : IHolidayMaster
	{
		public bool IsHoliday(DateTime theDate)
		{
			if (theDate.Equals(new DateTime(2020, 1, 27)))
				return true;  // Australia Day
			if (theDate.Equals(new DateTime(2020, 3, 9)))
				return true;  // Canberra Day
			if (theDate.Equals(new DateTime(2020, 4, 10)))
				return true;  // Good Friday
			if (theDate.Equals(new DateTime(2020, 4, 13)))
				return true;  // Easter Monday
			if (theDate.Equals(new DateTime(2020, 4, 27)))
				return true;  // ANZAC Day
			if (theDate.Equals(new DateTime(2020, 6, 1)))
				return true;  // Reconcilliation Day
			if (theDate.Equals(new DateTime(2020, 6, 8)))
				return true;  // Queens Birthday
			if (theDate.Equals(new DateTime(2020, 10, 5)))
				return true;  // Labour Day
			if (theDate.Equals(new DateTime(2020, 12, 25)))
				return true;  // Christmas Day
			return false;
		}
	}
}
