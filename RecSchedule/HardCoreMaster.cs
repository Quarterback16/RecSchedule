using RecSchedule.Domain;
using System;
using System.Collections.Generic;

namespace RecSchedule
{
	public class HardCoreMaster : ActivitySelector
	{
		public static int LastActivity { get; set; }

		public HardCoreMaster()
		{
			Activities = new List<RecActivity>
			{
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

		public string HearthstoneLink()
		{
			return $"[[Hearthstone-{DateTime.Now.AddDays(1).ToString("yyyy-MM")}]]";
		}


		public RecActivity SelectActivity()
		{
			var activity = Activities[LastActivity];
			LastActivity++;
			if (LastActivity == Activities.Count)
				LastActivity = 0;
#if !DEBUG
			activity.Description = $@"{
				activity.Description
				} (cor-{
				LastActivity
				})";
#endif
			return activity;
		}
	}
}
