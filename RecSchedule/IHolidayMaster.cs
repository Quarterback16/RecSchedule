using System;

namespace RecSchedule
{
	public interface IHolidayMaster
	{
		bool IsHoliday(DateTime theDate);
	}
}
