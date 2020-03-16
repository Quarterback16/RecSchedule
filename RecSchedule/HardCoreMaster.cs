using RecSchedule.Domain;
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
					Name = "Hearthstone Ladder Runs",
					Description = HearthstoneLink()
				},
				new RecActivity
				{
					Name = "Galactic Civilisations III",
					Description = "[[GalacticCivilizations_3]]"
				},
				new RecActivity
				{
					Name = "Next Learning Project",
					Description = "NextLearningProject"
				},
				new RecActivity
				{
					Name = "Anno",
					Description = "[[Anno_2205]]"
				},
				new RecActivity
				{
					Name = "Next Book Non Technical",
					Description = "NextBookNonTechnical"
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
			LastActivity++;
			if (LastActivity == Activities.Count)
				LastActivity = 0;

			var activity = Activities[LastActivity];

			activity.Description = $@"{
				activity.Description
				} (cor-{
				LastActivity
				})";

			return activity;
		}
	}
}
