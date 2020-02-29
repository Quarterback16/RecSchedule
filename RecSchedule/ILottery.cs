using System.Collections.Generic;

namespace RecSchedule
{
	public interface ILottery
	{
		IEnumerable<Entrant> Entrants { get; }

		string Winner();
	}
}
