using RecSchedule.Domain;
using System;
using System.Collections.Generic;

namespace RecSchedule
{
	class Program
	{
		static void Main(string[] args)
		{
#if !DEBUG
			var scheduleDate = DateTime.Now.AddDays(1);
#endif
			var _casualMaster = new CasualMaster();
			var scheduleDate = new DateTime(2020, 1, 6);
			var scheduleDateOut = scheduleDate.ToString("yyyy-MM-dd");
			if (args.Length > 0)
				scheduleDateOut = args[0].ToString();

			Console.WriteLine($"Rec Schedule : {scheduleDateOut}");

			//  Get the date (Monday)  the week is starting on
			var weekStart = DateTime.Parse(scheduleDateOut);

			//  load sessions available
			var sessions = LoadSessions(weekStart);

			var _fixedMaster = new FixedMaster();

			ApplyFixedBookings(
				sessions,
				_fixedMaster);

			Allocate(
				sessions,
				_casualMaster);

			DisplayWikiOutput(sessions);
		}

		private static void ApplyFixedBookings(
			List<RecSession> sessions,
			FixedMaster fixedMaster)
		{
			foreach (var session in sessions)
			{
				var fixedActivity = fixedMaster.BookingFor(session);
				if (fixedActivity != null )
				{
					session.Activity = fixedActivity;
				}
			}
		}

		private static void Allocate(
			List<RecSession> sessions, 
			CasualMaster casualMaster)
		{
			foreach (var session in sessions)
			{
				if (session.IsBooked())
					continue;

				if (session.SessionType == SessionType.Casual)
					session.Activity = casualMaster.SelectActivity(session);
			}
		}

		private static void DisplayWikiOutput(List<RecSession> sessions)
		{
			foreach (var session in sessions)
			{
				Console.WriteLine( session );
			}
		}

		private static List<RecSession> LoadSessions(
			DateTime weekStart)
		{
			var sessionList = new List<RecSession>
			{
				new Domain.RecSession
				{
					SessionDate = weekStart,
					SessionType = Domain.SessionType.Casual,
					StartTime = "1930",
					Activity = new Domain.RecActivity()
				},
				new Domain.RecSession
				{
					SessionDate = weekStart.AddDays(2),
					SessionType = Domain.SessionType.Casual,
					StartTime = "1930",
					Activity = new Domain.RecActivity()
				},
				new Domain.RecSession
				{
					SessionDate = weekStart.AddDays(4),
					SessionType = Domain.SessionType.Casual,
					StartTime = "1930",
					Activity = new Domain.RecActivity()
				}
			};
			return sessionList;
		}
	}


}
