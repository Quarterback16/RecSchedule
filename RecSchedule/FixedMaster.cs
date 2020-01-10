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
					SessionDate = new DateTime(2020, 1, 10),  // friday
					StartTime = "1930",
					Activity = new RecActivity
					{
						Name = "Hearthstone",
						Description = "Hearthstone",
						Comment = "Tavern Brawl"
					}
				},
				new RecSession
				{
					SessionType = SessionType.Casual,
					SessionDate = new DateTime(2020, 1, 11),  // saturday
					StartTime = "0700",
					Activity = new RecActivity
					{
						Name = "Forced booking to create slack time",
						Description = "   ",
						Comment = "unallocated"
					}
				},
				new RecSession
				{
					SessionType = SessionType.Casual,
					SessionDate = new DateTime(2020, 1, 11),  // saturday
					StartTime = "0930",
					Activity = new RecActivity
					{
						Name = "Gym",
						Description = "Pump",
						Comment = "Tuggeranong"
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