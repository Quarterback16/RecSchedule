using RecSchedule.Domain;
using System.Collections.Generic;

namespace RecSchedule
{
	public class HardCoreMaster : ActivitySelector
	{
		public HardCoreMaster()
		{
			Activities = new List<RecActivity>
			{
				new RecActivity
				{
					Name = "Civilisation",
					Description = "Civ 6"  //  to do make this a hwiki link
				},
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
