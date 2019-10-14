namespace WithoutSynchronization
{
	public class SharedDataContainer
	{
		public string Buffer { get; set; } = null;
		public int WritersFinished { get; set; } = 0;
	}
}