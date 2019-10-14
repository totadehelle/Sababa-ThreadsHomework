namespace WithSemaphore
{
	public class SharedDataContainer
	{
		public string Buffer { get; set; } = null;
		public int WritersFinished { get; set; } = 0;
		public bool IsCancelled { get; set; } = false;
	}
}