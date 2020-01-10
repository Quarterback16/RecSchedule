using System;

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
	}
}
