using RecSchedule.Domain;
using System;
using System.Collections.Generic;

namespace RecSchedule
{
	public class HardCoreMaster : ActivitySelector
	{
		public static int LastActivity { get; set; }
		
		const string K_ActivitySubType = "Hard-Core";

		public HardCoreMaster()
		{ 
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
					Name = "Coding Project",
					Description = "NextCodingProject"
				},
				new RecActivity
				{
					Name = "Civilisation",
					Description = "[[CivilizationVI]]"
				},
				new RecActivity
				{
					Name = "Hearthstone",
					Description = HearthstoneLink()
				},
				new RecActivity
				{
					Name = "Gwent",
					Description = "[[Gwent]]"
				},
				new RecActivity
				{
					Name = "Witcher 3",
					Description = "[[TheWitcher3]]"
				}
			};
		}

		public void SaveState()
		{
			SaveState(
				K_ActivitySubType,
				LastActivity);
		}


		public RecActivity SelectActivity()
		{
			var activity = Activities[LastActivity];
			LastActivity++;
			if (LastActivity == Activities.Count)
				LastActivity = 0;

			activity.Description = $@"{
				activity.Description
				} (cor-{
				LastActivity
				})";

			return activity;
		}
	}
}
