using RecSchedule.Domain;
using System;
using System.Collections.Generic;

namespace RecSchedule
{
	public class SessionMaster
	{
		public List<RecSession> LoadSessions(
			DateTime weekStart)
		{
			var sessionList = new List<RecSession>
			{
				new RecSession
				{
					SessionDate = weekStart,
					SessionType = SessionType.Casual,
					StartTime = "1930",
					Activity = new RecActivity()
				},
				new RecSession
				{
					SessionDate = weekStart.AddDays(1),
					SessionType = SessionType.Casual,
					StartTime = "1930",
					Activity = new RecActivity()
				},
				new RecSession
				{
					SessionDate = weekStart.AddDays(2),
					SessionType = SessionType.Casual,
					StartTime = "1930",
					Activity = new RecActivity()
				},
				new RecSession
				{
					SessionDate = weekStart.AddDays(3),
					SessionType = SessionType.Casual,
					StartTime = "1930",
					Activity = new RecActivity()
				},
				new RecSession
				{
					SessionDate = weekStart.AddDays(4),
					SessionType = SessionType.Casual,
					StartTime = "1930",
					Activity = new RecActivity()
				},
				new RecSession
				{
					SessionDate = weekStart.AddDays(5),
					SessionType = SessionType.Casual,
					StartTime = "0700",
					Activity = new RecActivity()
				},
				new RecSession
				{
					SessionDate = weekStart.AddDays(5),
					SessionType = SessionType.Casual,
					StartTime = "0930",
					Activity = new RecActivity()
				},
				new RecSession
				{
					SessionDate = weekStart.AddDays(5),
					SessionType = SessionType.Double,
					StartTime = "1100",
					Activity = new RecActivity()
				},
				new RecSession
				{
					SessionDate = weekStart.AddDays(5),
					SessionType = SessionType.Double,
					StartTime = "1500",
					Activity = new RecActivity()
				},
				new RecSession
				{
					SessionDate = weekStart.AddDays(5),
					SessionType = SessionType.Double,
					StartTime = "1930",
					Activity = new RecActivity()
				},
				new RecSession
				{
					SessionDate = weekStart.AddDays(6),
					SessionType = SessionType.Casual,
					StartTime = "0700",
					Activity = new RecActivity()
				},
				new RecSession
				{
					SessionDate = weekStart.AddDays(6),
					SessionType = SessionType.Double,
					StartTime = "0830",
					Activity = new RecActivity()
				},
				new RecSession
				{
					SessionDate = weekStart.AddDays(6),
					SessionType = SessionType.Double,
					StartTime = "1130",
					Activity = new RecActivity()
				},
				new RecSession
				{
					SessionDate = weekStart.AddDays(6),
					SessionType = SessionType.Casual,
					StartTime = "1430",
					Activity = new RecActivity()
				},
				new RecSession
				{
					SessionDate = weekStart.AddDays(6),
					SessionType = SessionType.Casual,
					StartTime = "1600",
					Activity = new RecActivity()
				},
				new RecSession
				{
					SessionDate = weekStart.AddDays(6),
					SessionType = SessionType.Casual,
					StartTime = "1930",
					Activity = new RecActivity()
				},
			};
			return sessionList;
		}
	}
}
