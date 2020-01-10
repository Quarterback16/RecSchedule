﻿using RecSchedule.Domain;
using System.Collections.Generic;

namespace RecSchedule
{
	public class CasualMaster : ActivitySelector
	{
		public CasualMaster()
		{
			Activities = new List<RecActivity>
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
				},
				new RecActivity
				{
					Name = "Witcher 3",
					Description = "Witcher 3"  //  to do make this a hwiki link
				}
			};
		}

	}
}
