using RecSchedule.Domain;
using System;
using System.Collections.Generic;

namespace RecSchedule
{
	internal class FixedMaster
	{
		public List<RecSession> Bookings { get; set; }

		public FixedMaster()
		{
			Bookings = new List<RecSession>
			{
				new RecSession
				{
					SessionType = SessionType.Casual,
					SessionDate = new DateTime(2020, 1, 8),  // wednesday
					StartTime = "1930",
					Activity = new RecActivity
					{
						Name = "Gwent",
						Description = "Gwent link",
						Comment = "Gwentsday"
					}
				},
				new RecSession
				{
					SessionType = SessionType.Casual,
					SessionDate = new DateTime(2020, 1, 10),  // wednesday
					StartTime = "1930",
					Activity = new RecActivity
					{
						Name = "Hearthstone",
						Description = "Hearthstone",
						Comment = "Tavern Brawl"
					}
				},
			};
		}

		public RecActivity BookingFor(RecSession session)
		{
			foreach (var booking in Bookings)
			{
				if (booking.Matches(session))
					return booking.Activity;
			}
			return null;
		}
	}
}