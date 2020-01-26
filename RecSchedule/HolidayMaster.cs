using System;

namespace RecSchedule
{
	public class HolidayMaster : IHolidayMaster
	{
		public bool IsHoliday(DateTime theDate)
		{
			if (theDate.Equals(new DateTime(2020, 1, 27)))
				return true;  // Australia Day
			return false;
		}
	}
}
