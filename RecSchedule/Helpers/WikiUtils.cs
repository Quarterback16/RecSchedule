namespace RecSchedule.Helpers
{
	public static class WikiUtils
	{
        public static string ColumnOf(
            int width, 
            string contents)
        {
            return contents.PadRight(width).Substring(0, width);
        }

    }
}
