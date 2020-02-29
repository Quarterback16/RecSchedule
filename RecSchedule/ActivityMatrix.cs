using RecSchedule.Helpers;
using System;
using System.Text;

namespace RecSchedule
{
    public class ActivityMatrix
    {
        public CasualMaster CasualMaster;
        public HardCoreMaster HardcoreMaster;

        public ActivityMatrix(
            CasualMaster casualMaster,
            HardCoreMaster hardcoreMaster)
        {
            CasualMaster = casualMaster;
            HardcoreMaster = hardcoreMaster;
        }

        public string Generate()
        {
            var sb = new StringBuilder();
            var nRows = DetermineRowsInMatrix();
            sb.AppendLine(SwikiTableHeader());
            for (int i = 0; i < nRows; i++)
            {
                string[] col = new string[3];
                col[0] = i.ToString();
                if (i < CasualMaster.Activities.Count)
                    col[1] = CasualMaster.Activities[i].Description;
                else
                    col[1] = string.Empty;

                if (i < HardcoreMaster.Activities.Count)
                    col[2] = HardcoreMaster.Activities[i].Description;
                else
                    col[2] = string.Empty;

                var thisLine = SwikiTableRow(col);
                sb.Append(thisLine);
                //Console.WriteLine(thisLine);
            }
            return sb.ToString();
        }

        private string SwikiTableHeader()
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== Activity Matrix ===");
            var tableHeader = $@"||  {
                WikiUtils.ColumnOf(30, "**#**")
                }    ||  {
                WikiUtils.ColumnOf(30, "**Casual**")
                }  ||  {
                WikiUtils.ColumnOf(30, "**Hard Core**"
                )}  ||";

            sb.Append(tableHeader);
            return sb.ToString();
        }

        private string SwikiTableRow(string[] col)
        {
            var sb = new StringBuilder();
            sb.Append("||  ");
            for (int i = 0; i < col.Length; i++)
            {
                sb.Append($"  {WikiUtils.ColumnOf(30, col[i])}  ||");
            }
            sb.AppendLine();
            return sb.ToString();
        }

        private int DetermineRowsInMatrix()
        {
            var casualActivities = CasualMaster.Activities.Count;
            var hardCoreActivities = HardcoreMaster.Activities.Count;
            return Math.Max(casualActivities, hardCoreActivities);
        }
    }
}