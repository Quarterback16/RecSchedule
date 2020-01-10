using RecSchedule.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RecSchedule
{
	public class ScheduleGenerator
	{
		public string ScheduleStarts { get; set; }
		private readonly TextWriter _outputWriter;

		public ScheduleGenerator(
			string dateIn,
			TextWriter outputWriter)
		{
			ScheduleStarts = dateIn;
			_outputWriter = outputWriter;
		}

		public string Generate()
		{
			var _casualMaster = new CasualMaster();
			var _hardCoreMaster = new HardCoreMaster();

			var sb = new StringBuilder();

			AppendHeader(sb);

			//  Get the date (Monday)  the week is starting on
			var weekStart = DateTime.Parse(ScheduleStarts);

			//  load sessions available
			var sessions = LoadSessions(weekStart);

			var _fixedMaster = new FixedMaster(
				new GameLottery());

			ApplyFixedBookings(
				sessions,
				_fixedMaster);

			Allocate(
				sessions,
				_casualMaster,
				_hardCoreMaster);

#if !DEBUG
			DisplayOutput(sessions);
#else
			sb.Append(
				DisplayWikiOutput(sessions));
#endif
			return sb.ToString();
		}

		private void AppendHeader(StringBuilder sb)
		{
			sb.Append(
				Output($"=== Rec Schedule : {HwikiMonth(ScheduleStarts)} ==="));
			sb.AppendLine(
				Output(string.Empty));
			sb.AppendLine(
				Output(string.Empty));
		}

		private string Output(string text)
		{
			_outputWriter.WriteLine(text);
			return text;
		}

		private string HwikiMonth(string scheduleStarts)
		{
			return $"[[{scheduleStarts.Substring(0,7)}]]{scheduleStarts.Substring(7,3)}";
		}

		private static void ApplyFixedBookings(
			List<RecSession> sessions,
			FixedMaster fixedMaster)
		{
			foreach (var session in sessions)
			{
				var fixedActivity = fixedMaster.BookingFor(session);
				if (fixedActivity != null)
				{
					session.Activity = fixedActivity;
				}
			}
		}

		private static void Allocate(
			List<RecSession> sessions,
			CasualMaster casualMaster,
			HardCoreMaster hardCoreMaster)
		{
			foreach (var session in sessions)
			{
				if (session.IsBooked())
					continue;

				if (session.SessionType == SessionType.Casual)
					session.Activity = casualMaster.SelectActivity();
				else if (session.SessionType == SessionType.Double)
					session.Activity = hardCoreMaster.SelectActivity();
			}
		}

		private void DisplayOutput(List<RecSession> sessions)
		{
			foreach (var session in sessions)
				Output(session.ToString());
		}

		private string DisplayWikiOutput(
			List<RecSession> sessions)
		{
			var sb = new StringBuilder();
			sb.AppendLine(
				DisplayHeader());

			var line = 0;
			foreach (var session in sessions)
			{
				sb.Append(
					Output(session.WikiLine(++line)));
			}
			return sb.ToString();
		}

		private string DisplayHeader()
		{
			return Output(
				"|| **#** ||  **Day**  || **Time**  ||  **Allocation**                  ||  **Comments**          ||");
		}

		private static List<RecSession> LoadSessions(
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
					SessionDate = weekStart.AddDays(2),
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
					SessionType = SessionType.Double,
					StartTime = "1430",
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

