using RecSchedule.Domain;
using System;
using System.Collections.Generic;

namespace RecSchedule
{
	public class SessionMaster
	{
		private readonly IHolidayMaster _holidayMaster;

		public SessionMaster(
			IHolidayMaster holidayMaster)
		{
			_holidayMaster = holidayMaster;
		}

		private RecSession NewSession(
			DateTime theDate,
			SessionType theType,
			string startTime)
		{
			return new RecSession
				{
					SessionDate = theDate,
					SessionType = theType,
					StartTime = startTime,
					Activity = new RecActivity()
				};
		}

		public List<RecSession> LoadSessions(
			DateTime weekStart)
		{
			var sessionList = new List<RecSession>();
			//  Monday
			var theDate = weekStart;
			if (!_holidayMaster.IsHoliday(theDate))
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Casual,
						startTime: "1930"));
			//  Tuesday
			theDate = weekStart.AddDays(1);
			if (!_holidayMaster.IsHoliday(theDate))
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Casual,
						startTime: "1930"));
			//  Wednesday
			theDate = weekStart.AddDays(2);
			if (!_holidayMaster.IsHoliday(theDate))
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Casual,
						startTime: "1930"));
			//  Thursday
			theDate = weekStart.AddDays(3);
			if (!_holidayMaster.IsHoliday(theDate))
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Casual,
						startTime: "1930"));
			//  Friday
			theDate = weekStart.AddDays(4);
			if (!_holidayMaster.IsHoliday(theDate))
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Casual,
						startTime: "1930"));
			// Saturday
			theDate = weekStart.AddDays(5);
			if (!_holidayMaster.IsHoliday(theDate))
			{
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Casual,
						startTime: "0700"));
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Casual,
						startTime: "0930"));
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Double,
						startTime: "1100"));
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Double,
						startTime: "1500"));
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Double,
						startTime: "1930"));
			}
			// Sunday
			theDate = weekStart.AddDays(6);
			if (!_holidayMaster.IsHoliday(theDate))
			{
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Casual,
						startTime: "0700"));
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Double,
						startTime: "0830"));
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Double,
						startTime: "1130"));
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Casual,
						startTime: "1430"));
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Casual,
						startTime: "1600"));
				sessionList.Add(
					NewSession(
						theDate,
						SessionType.Casual,
						startTime: "1930"));
			}
			return sessionList;
		}

		internal IEnumerable<RecSession> LoadHolidaySessions(
			DateTime weekStart)
		{
			var holidaySessions = new List<RecSession>();
			for (int d = 0; d < 7; d++)
			{
				var theDate = weekStart.AddDays(d);
				if (_holidayMaster.IsHoliday(theDate))
				{
					holidaySessions.Add(
						new RecSession
						{
							SessionDate = theDate,
							SessionType = SessionType.Double,
							StartTime = "0830",
							Activity = new RecActivity()
						});
					holidaySessions.Add(
						new RecSession
						{
							SessionDate = theDate,
							SessionType = SessionType.Double,
							StartTime = "1130",
							Activity = new RecActivity()
						});
					holidaySessions.Add(
						new RecSession
						{
							SessionDate = theDate,
							SessionType = SessionType.Casual,
							StartTime = "1430",
							Activity = new RecActivity()
						});
					holidaySessions.Add(
						new RecSession
						{
							SessionDate = theDate,
							SessionType = SessionType.Casual,
							StartTime = "1600",
							Activity = new RecActivity()
						});
					holidaySessions.Add(
						new RecSession
						{
							SessionDate = theDate,
							SessionType = SessionType.Casual,
							StartTime = "1930",
							Activity = new RecActivity()
						});
				}
			}
			return holidaySessions;
		}
	}
}
