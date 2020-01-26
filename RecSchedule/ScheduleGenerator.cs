using RecSchedule.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
			var holidayMaster = new HolidayMaster();
			var _casualMaster = new CasualMaster();
			var _hardCoreMaster = new HardCoreMaster();
			var _sessionMaster = new SessionMaster(
				holidayMaster);

			var sb = new StringBuilder();

			AppendHeader(sb);

			//  Get the date (Monday)  the week is starting on
			var weekStart = DateTime.Parse(ScheduleStarts);

			//  load sessions available
			var sessions = _sessionMaster.LoadSessions(
				weekStart);
			//  Add sessions for public holidays
			sessions.AddRange(
				_sessionMaster.LoadHolidaySessions(
					weekStart));

			var _fixedMaster = new FixedMaster(
				new GameLottery(),
				new MediaLottery());

			ApplyFixedBookings(
				sessions,
				_fixedMaster);

			Allocate(
				sessions,
				_casualMaster,
				_hardCoreMaster);

			SaveState(
				_casualMaster,
				_hardCoreMaster);

			sb.Append(
				DisplayWikiOutput(
					sessions,
					weekStart));

			return sb.ToString();
		}

		private void SaveState(
			CasualMaster casualMaster,
			HardCoreMaster hardCoreMaster)
		{
			casualMaster.SaveState();
			hardCoreMaster.SaveState();
		}

		private void AppendHeader(StringBuilder sb)
		{
			sb.Append(
				Output($"=== Rec Schedule : {HwikiMonth(ScheduleStarts)} ==="));
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
			List<RecSession> sessions,
			DateTime thisMonday)
		{
			List<RecSession> sortedSessions = sessions
				.OrderBy(o => o.SessionKey())
				.ToList();

			var sb = new StringBuilder();
			sb.AppendLine(
				DisplayHeader());

			var line = 0;
			foreach (var session in sortedSessions)
			{
				sb.Append(
					Output(session.WikiLine(++line)));
			}
			sb.Append(Threading(thisMonday));
			return sb.ToString();
		}

		private string Threading(
			DateTime thisMonday)
		{
			var sb = new StringBuilder();
			sb.AppendLine(Output(string.Empty));
			sb.AppendLine(Output("----"));
			sb.AppendLine(
				Output($@"<< [[RecSessions_{
					LastMonday(thisMonday)
					}]] (m) [[RecSessions_{
					NextMonday(thisMonday)
					}]] >>"));

			return sb.ToString();
		}

		private string NextMonday(DateTime thisMonday)
		{
			var nextMonday = thisMonday.AddDays(7);
			return nextMonday.ToString("yyyy_MM_dd");
		}

		private string LastMonday(DateTime thisMonday)
		{
			var lastMonday = thisMonday.AddDays(-7);
			return lastMonday.ToString("yyyy_MM_dd");
		}

		private string DisplayHeader()
		{
			return Output(
				"|| **#** ||  **Day**  || **Time**  ||  **Allocation**                            ||  **Comments**          ||");
		}


	}

}

