using RecSchedule.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RecSchedule
{
    public class ScheduleGenerator
    {
        public string ScheduleStarts { get; set; }
        private readonly TextWriter _outputWriter;

        public CasualMaster CasualMaster { get; set; }
        public HardCoreMaster HardCoreMaster { get; set; }
        public List<RecSession> RecSessions { get; set; }

        public ScheduleGenerator(
               string dateIn,
               TextWriter outputWriter)
        {
            ScheduleStarts = dateIn;
            _outputWriter = outputWriter;
            CasualMaster = new CasualMaster();
            HardCoreMaster = new HardCoreMaster();
        }

        public string Generate()
        {
            var holidayMaster = new HolidayMaster();
            var _sessionMaster = new SessionMaster(
                  holidayMaster);

            var sb = new StringBuilder();

            AppendHeader(sb);

            //  Get the date (Monday)  the week is starting on
            var weekStart = DateTime.Parse(ScheduleStarts);

            //  load sessions available
            RecSessions = _sessionMaster.LoadSessions(
                  weekStart);
            //  Add sessions for public holidays
            RecSessions.AddRange(
                  _sessionMaster.LoadHolidaySessions(
                         weekStart));

            var _fixedMaster = new FixedMaster(
                  new GameLottery(),
                  new MediaLottery());

            ApplyFixedBookings(
                  RecSessions,
                  _fixedMaster);

            Allocate(
                  RecSessions,
                  CasualMaster,
                  HardCoreMaster);

            SaveState(
                  CasualMaster,
                  HardCoreMaster);

            sb.Append(
                  DisplayWikiOutput(
                         RecSessions,
                         weekStart));

            return sb.ToString();
        }

        public int HardCoreFlexSessions()
        {
            var noSessions = 0;
            foreach (var session in RecSessions)
            {
                if ((session.SessionType.Equals(SessionType.Double)
                         || session.SessionType.Equals(SessionType.Triple))
                       && !session.IsFixed)
                    noSessions++;
            }
            return noSessions;
        }

        public int FixedSessions()
        {
            var noSessions = 0;
            foreach (var session in RecSessions)
            {
                if (session.IsFixed)
                    noSessions++;
            }
            return noSessions;
        }

        public int CasualFlexSessions()
        {
            var noOfCasualSessions = 0;
            foreach (var session in RecSessions)
            {
                if (session.SessionType.Equals(SessionType.Casual)
                       && !session.IsFixed)
                    noOfCasualSessions++;
            }
            return noOfCasualSessions;
        }

        public int CasualSessions()
        {
            var noOfCasualSessions = 0;
            foreach (var session in RecSessions)
            {
                if (session.SessionType.Equals(SessionType.Casual))
                    noOfCasualSessions++;
            }
            return noOfCasualSessions;
        }

        private void SaveState(
               CasualMaster casualMaster,
               HardCoreMaster hardCoreMaster)
        {
            casualMaster.SaveState();
            hardCoreMaster.SaveState();
        }

        private void AppendHeader(StringBuilder sb)
        {
            sb.Append(
                  Output($"=== Rec Schedule : {HwikiMonth(ScheduleStarts)} ==="));
            sb.AppendLine(
                  Output(string.Empty));
        }

        private string Output(string text)
        {
            _outputWriter.WriteLine(text);
            return text;
        }

        private string HwikiMonth(string scheduleStarts)
        {
            return $"[[{scheduleStarts.Substring(0, 7)}]]{scheduleStarts.Substring(7, 3)}";
        }

        private static void ApplyFixedBookings(
               List<RecSession> sessions,
               FixedMaster fixedMaster)
        {
            foreach (var session in sessions)
            {
                var fixedActivity = fixedMaster.BookingFor(session);
                if (fixedActivity != null)
                {
                    session.Activity = fixedActivity;
                    session.IsFixed = true;
                }
            }
        }

        private static void Allocate(
               List<RecSession> sessions,
               CasualMaster casualMaster,
               HardCoreMaster hardCoreMaster)
        {
            foreach (var session in sessions)
            {
                if (session.IsBooked())
                    continue;

                if (session.SessionType == SessionType.Casual)
                    session.Activity = casualMaster.SelectActivity();
                else if (session.SessionType == SessionType.Double)
                    session.Activity = hardCoreMaster.SelectActivity();
            }
        }

        private void DisplayOutput(List<RecSession> sessions)
        {
            foreach (var session in sessions)
                Output(session.ToString());
        }

        private string DisplayWikiOutput(
               List<RecSession> sessions,
               DateTime thisMonday)
        {
            List<RecSession> sortedSessions = sessions
                  .OrderBy(o => o.SessionKey())
                  .ToList();

            var sb = new StringBuilder();
            sb.AppendLine(
                  DisplayHeader());

            var line = 0;
            foreach (var session in sortedSessions)
            {
                sb.Append(
                       Output(
                              session.WikiLine(++line)));
            }
            sb.Append(Threading(thisMonday));
            return sb.ToString();
        }

        private string Threading(
               DateTime thisMonday)
        {
            var sb = new StringBuilder();
            sb.AppendLine(Output(string.Empty));
            sb.AppendLine(Output("----"));
            sb.AppendLine(
                  Output($@"<< [[RecSessions_{
                         LastMonday(thisMonday)
                         }]] (m) [[RecSessions_{
                         NextMonday(thisMonday)
                         }]] >>"));

            return sb.ToString();
        }

        private string NextMonday(DateTime thisMonday)
        {
            var nextMonday = thisMonday.AddDays(7);
            return nextMonday.ToString("yyyy_MM_dd");
        }

        private string LastMonday(DateTime thisMonday)
        {
            var lastMonday = thisMonday.AddDays(-7);
            return lastMonday.ToString("yyyy_MM_dd");
        }

        private string DisplayHeader()
        {
            return Output(
                  "|| **#** ||   **Day**    || **Time**  ||  **Allocation**                            ||  **Comments**          ||");
        }


    }

}
