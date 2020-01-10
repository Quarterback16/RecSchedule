using RecSchedule.Domain;
using System.Collections.Generic;

namespace RecSchedule
{
	public class ActivitySelector
	{
		public List<RecActivity> Activities { get; set; }

		public static int LastActivity { get; set; }

		public RecActivity SelectActivity(
			RecSession session)
		{
			if (session.SessionType != SessionType.Casual)
				return new RecActivity();

			var activity = Activities[LastActivity];
			LastActivity++;
			if (LastActivity == Activities.Count)
				LastActivity = 0;
			return activity;
		}
	}
}