using RecSchedule.Domain;
using System.Collections.Generic;

namespace RecSchedule
{
	public class CasualMaster : ActivitySelector
	{
		public static int LastActivity { get; set; }

		public CasualMaster()
		{
			Activities = new List<RecActivity>
			{
				new RecActivity
				{
					Name = "Hearthstone",
					Description = "Hearthstone link"  //  to do make this a hwiki link
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
			var activity = Activities[LastActivity];
			LastActivity++;
			if (LastActivity == Activities.Count)
				LastActivity = 0;
			return activity;
		}
	}
}
