using System;
using System.Text;

namespace RecSchedule.Domain
{
	public class RecSession
	{
		public DateTime SessionDate { get; set; }
		public string StartTime { get; set; }
		public SessionType SessionType { get; set; }
		public bool IsDouble { get; set; }
		public RecActivity Activity { get; set; }

		public override string ToString()
		{
			return $@"{SessionDate.ToString("yyyy-MM-dd")} {
				SessionDate.ToString("ddd")
				} {
				StartTime
				} {
				SessionType
				} {
				Activity.Description
				} {
				Activity.Comment
				}";
		}

		public string SessionKey()
		{
			return SessionDate.ToString("yyyy-MM-dd") + StartTime; 
		}

		public bool IsBooked()
		{
			if (Activity == null)
				return false;
			return Activity.Description != "free";
		}

		internal bool Matches(RecSession session)
		{
			if (session.StartTime.Equals(StartTime)
				&& session.DayOfTheWeek().Equals(DayOfTheWeek()))
				return true;
			return false;
		}

		private DayOfWeek DayOfTheWeek()
		{
			return SessionDate.DayOfWeek;
		}

		internal string WikiLine(int sessionNumber)
		{
			var sb = new StringBuilder();
			var strSessionNumber = (sessionNumber < 10) 
				? " " + sessionNumber.ToString()
				: sessionNumber.ToString();
			sb.Append($"||  { strSessionNumber}   ||");
			sb.Append($"   {SessionDate.ToString("ddd dd")}     ||");
			sb.Append($"  {StartTime} {SessionTypeIndicator(SessionType)} ||");
			sb.Append($"  {ColumnSized(40,Activity.Description)}  ||");
			sb.Append($"  {ColumnSized(20,Activity.Comment)}  ||");
#if DEBUG
			sb.AppendLine();
#endif
			return sb.ToString();
		}

		private string SessionTypeIndicator(SessionType sessionType)
		{
			if (sessionType.Equals(SessionType.Double))
				return " * ";
			return "   ";
		}

		private string ColumnSized(int size, string data)
		{
			return data.PadRight(size).Substring(0,size);
		}

		internal bool ExactMatches(RecSession session)
		{
			if (session.SessionDate.Equals(SessionDate)
				&& session.StartTime.Equals(StartTime) )
				return true;
			return false;
		}

	}
}
