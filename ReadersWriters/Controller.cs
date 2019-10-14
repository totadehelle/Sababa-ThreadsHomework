using System.Collections.Concurrent;
using System.Threading;

namespace WithoutSynchronization
{
	public class Controller
	{
		public int NumberOfWriters { get; set; }
		public int NumberOfReaders { get; set; }
		public int NumberOfMessages { get; set; }
		public ThreadPriority Priority { get; set; }

		public ConcurrentBag<string> Process()
		{
			var container = new SharedDataContainer();
			var receivedMessages = new ConcurrentBag<string>();

			for (int i = 0; i < NumberOfWriters; i++)
			{
				int id = i;
				var writer = new Writer(id, NumberOfMessages, container);
				var thread = new Thread(() => writer.Write()) { Name = "Writer" + id, Priority = Priority };
				thread.Start();
			}

			for (int i = 0; i < NumberOfReaders; i++)
			{
				var reader = new Reader(receivedMessages, container);
				var thread = new Thread(() => reader.Read())
				{
					IsBackground = true,
					Name = "Reader" + i,
					Priority = Priority
				};
				thread.Start();
			}

			var totalMessages = NumberOfMessages * NumberOfWriters;
			while (container.WritersFinished < NumberOfWriters || receivedMessages.Count < totalMessages)
			{
				Thread.Sleep(10);
			}

			return receivedMessages;
		}
	}
}