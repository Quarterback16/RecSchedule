using RecSchedule.Helpers;
using System;

namespace RecSchedule
{
	class Program
	{
		static void Main(string[] args)
		{
#if !DEBUG
			var scheduleDate = DateUtilities.FindNextMonday();
#else
			//  test with a fixed Monday
			var scheduleDate = new DateTime(2020, 1, 27);
#endif

			var scheduleDateOut = scheduleDate.ToString("yyyy-MM-dd");
			if (args.Length > 0)
				scheduleDateOut = args[0].ToString();

			var sg = new ScheduleGenerator(
				scheduleDateOut,
				Console.Out);

			sg.Generate();

			GenerateActivityList(sg);

			GenerateMediaList(sg);

			GenerateGameList(sg);
		}

		private static void GenerateGameList(
			ScheduleGenerator sg)
		{
			var gl = new GameList(
				sg.GameLottery);
			gl.Generate();
		}

		private static void GenerateMediaList(
			ScheduleGenerator sg)
		{
			var ml = new MediaList(
				sg.MediaLottery);
			ml.Generate();
		}

		private static void GenerateActivityList(
			ScheduleGenerator sg)
		{
			var am = new ActivityMatrix(
				sg.CasualMaster,
				sg.HardCoreMaster);
			am.Generate();
		}

	}
}
