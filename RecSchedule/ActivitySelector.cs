using RecSchedule.Domain;
using RecSchedule.Model;
using System;
using System.Collections.Generic;

namespace RecSchedule
{
	public class ActivitySelector
	{
		public List<RecActivity> Activities { get; set; }

		private readonly CountMaster _countMaster;

		public ActivitySelector()
		{
			_countMaster = new CountMaster("counts.xml");
		}

		public int GetLastActivity(
			string activitySubType)
		{
			var countItem = (CountItem)_countMaster
				.TheHt[activitySubType];
			return countItem.Count;
		}

		public void SaveState(
			string activitySubType,
			int index)
		{
			// put this in the XML
			_countMaster.PutItem(
				new CountItem(
					activitySubType, 
					index));
			_countMaster.Dump2Xml();
		}

		public int Counts()
		{
			return _countMaster.TheHt.Count;
		}

		public string HearthstoneLink( string comment = "" )
		{
			return $"[[Hearthstone-{DateTime.Now.AddDays(1).ToString("yyyy-MM")}]] {comment}";
		}
	}
}