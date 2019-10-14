namespace WithInterlocked
{
	public class SharedDataContainer
	{
		public string Buffer = null;
		public int WritersFinished = 0;
		public bool IsCancelled { get; set; } = false;
	}
}