﻿using RecSchedule.Domain;
using System;
using System.Collections.Generic;

namespace RecSchedule
{
	internal class FixedMaster
	{
		public List<RecSession> RegularBookings { get; set; }
		public List<RecSession> OnceOffBookings { get; set; }

		private readonly ILottery _gameLottery;
		private readonly ILottery _mediaLottery;
		public FixedMaster(
			ILottery gameLottery,
			ILottery mediaLottery)
		{
			_gameLottery = gameLottery;
			_mediaLottery = mediaLottery;
			LoadRegularBookings();
			LoadOnceOffBookings();
		}

		private void LoadOnceOffBookings()
		{
			OnceOffBookings = new List<RecSession>
			{
				new RecSession
				{
					SessionType = SessionType.Double,
					SessionDate = new DateTime(2020, 1, 12),
					StartTime = "0830",
					Activity = new RecActivity
					{
						Name = "NFL",
						Description = "[[NFL]]",
						Comment = " MV @ [[SF]]"
					}
				},
				new RecSession
				{
					SessionType = SessionType.Double,
					SessionDate = new DateTime(2020, 1, 12),
					StartTime = "1130",
					Activity = new RecActivity
					{
						Name = "NFL",
						Description = "[[NFL]]",
						Comment = " TT @ BR"
					}
				},
			};
		}

		private void LoadRegularBookings()
		{
			RegularBookings = new List<RecSession>
			{
				new RecSession
				{
					SessionType = SessionType.Casual,
					SessionDate = new DateTime(2020, 1, 8),  // wednesday
					StartTime = "1930",
					Activity = new RecActivity
					{
						Name = "Gwent",
						Description = "[[Gwent]]",
						Comment = "fixed: Gwentsday"
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
						Description = HearthstoneLink(),
						Comment = "fixed: Tavern Brawl"
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
						Comment = "fixed: unallocated"
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
						Comment = "fixed: Tuggeranong"
					}
				},
				new RecSession
				{
					SessionType = SessionType.Casual,
					SessionDate = new DateTime(2020, 1, 11),  // saturday
					StartTime = "1930",
					Activity = new RecActivity
					{
						Name = "Media",
						Description = _mediaLottery.Winner(),
						Comment = "fixed: lottery"
					}
				},
				new RecSession
				{
					SessionType = SessionType.Casual,
					SessionDate = new DateTime(2020, 1, 12),  // Sunday
					StartTime = "0700",
					Activity = new RecActivity
					{
						Name = "Forced booking to create slack time",
						Description = "   ",
						Comment = "fixed: unallocated"
					}
				},
				new RecSession
				{
					SessionType = SessionType.Double,
					SessionDate = new DateTime(2020, 1, 12),  // Sunday
					StartTime = "0830",
					Activity = new RecActivity
					{
						Name = "Random oddball game",
						Description = _gameLottery.Winner(),
						Comment = "fixed: lottery"
					}
				},
			};
		}

		public string HearthstoneLink()
		{
			return $"[[Hearthstone-{DateTime.Now.AddDays(1).ToString("yyyy-MM")}]]";
		}

		public RecActivity BookingFor(RecSession session)
		{
			foreach (var booking in OnceOffBookings)
			{
				if (booking.ExactMatches(session))
					return booking.Activity;
			}

			foreach (var booking in RegularBookings)
			{
				if (booking.Matches(session))
					return booking.Activity;
			}
			return null;
		}
	}
}