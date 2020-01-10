using RecSchedule.Domain;
using System.Collections.Generic;

namespace RecSchedule
{
	public class CasualMaster
	{
		public List<RecActivity> CasualActivities { get; set; }

		public static int LastActivity { get; set; }

		public CasualMaster()
		{
			CasualActivities = new List<RecActivity>
			{
				new RecActivity
				{
					Name = "Hearthstone",
					Description = "Hearthstone"  //  to do make this a hwiki link
				},
				new RecActivity
				{
					Name = "Gwent",
					Description = "Gwent"  //  to do make this a hwiki link
				}
			};
		}

		internal RecActivity SelectActivity(
			RecSession session)
		{
			if (session.SessionType != SessionType.Casual)
				return new RecActivity();

			var activity = CasualActivities[LastActivity];
			LastActivity++;
			if (LastActivity == CasualActivities.Count)
				LastActivity = 0;
			return activity;
		}
	}
}
