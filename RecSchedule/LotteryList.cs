using RecSchedule.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecSchedule
{
	public class LotteryList
	{
		public List<Entrant> Entrants { get; set; }

		public LotteryList()
		{
			Entrants = new List<Entrant>();
		}

        protected string SwikiTableRow(
            int itemNo,
            Entrant item)
        {
            var sb = new StringBuilder();
            sb.Append($"||  {WikiUtils.ColumnOf(3, itemNo.ToString())}  ");
            sb.Append($"||  {WikiUtils.ColumnOf(40, item.Name)}  ");
            sb.Append($"||  {WikiUtils.ColumnOf(20, item.Balls.ToString())}  ");
            sb.Append("||");
            sb.AppendLine();
            return sb.ToString();
        }

        protected string SwikiTableHeader(
            string itemName)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"=== {itemName} Contenders ===");
            var tableHeader = $@"|| **#** ||  {
                WikiUtils.ColumnOf(40, "**Item**")
                }  ||  {
                WikiUtils.ColumnOf(20, "**Weighting**"
                )}  ||";

            sb.Append(tableHeader);
            return sb.ToString();
        }

        protected void OutputTable(
            string itemName,
            StringBuilder sb)
        {
            var sortedEntrants = Entrants
                .OrderByDescending(o => o.Balls)
                .ToList();
            sb.AppendLine(
                SwikiTableHeader(
                    itemName));
            var i = 0;
            foreach (var item in sortedEntrants)
            {
                var thisLine = SwikiTableRow(++i, item);
                sb.Append(thisLine);
                Console.WriteLine(thisLine);
            }
            sb.AppendLine(
                $"  * there is one random {itemName} item chosen a week");
        }
    }
}