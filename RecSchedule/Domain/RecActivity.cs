namespace RecSchedule.Domain
{
	public class RecActivity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Comment { get; set; }

		public RecActivity()
		{
			Name = string.Empty;
			Description = "free";
			Comment = string.Empty;
		}

		public override string ToString()
		{
			return Name;
		}

	}
}
