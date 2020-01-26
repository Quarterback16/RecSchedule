using RecSchedule.Domain;
using System.Collections.Generic;

namespace RecSchedule
{
	public class CasualMaster : ActivitySelector
	{
		public static int LastActivity { get; set; }

		const string K_ActivitySubType = "Casual";

		public CasualMaster()
		{
			//  set LastActivity from State
			LastActivity = GetLastActivity(
				activitySubType: K_ActivitySubType);
			LoadActivities();
		}

		private void LoadActivities()
		{
			Activities = new List<RecActivity>
			{
				new RecActivity
				{
					Name = "Hearthstone",
					Description = HearthstoneLink()
				},
				new RecActivity
				{
					Name = "Gwent",
					Description = "[[Gwent]]"  //  to do make this a hwiki link
				},
				new RecActivity
				{
					Name = "Witcher 3",
					Description = "[[TheWitcher3]]" 
				}
			};
		}

		public RecActivity SelectActivity()
		{
			LastActivity++;
			if (LastActivity == Activities.Count)
				LastActivity = 0;

			var activity = Activities[LastActivity];

			if (!activity.Description.Contains("(cas"))
				//  first time being hit
				activity.Description = $@"{
					activity.Description
					} (cas-{
					LastActivity
					})";

			return activity;
		}

		public void SaveState()
		{
			SaveState(
				K_ActivitySubType, 
				LastActivity);
		}
	}
}
