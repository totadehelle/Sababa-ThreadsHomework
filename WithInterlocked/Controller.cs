using System.Collections.Concurrent;
using System.Threading;
using BenchmarkDotNet.Attributes;

namespace WithInterlocked
{
	public class Controller
	{
		[Params(10)]
		public int NumberOfWriters { get; set; }
		[Params(10)]
		public int NumberOfReaders { get; set; }
		[Params(10)]
		public int NumberOfMessages { get; set; }
		[Params(ThreadPriority.BelowNormal, ThreadPriority.AboveNormal)]
		public ThreadPriority Priority { get; set; }

		[Benchmark]
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
				var thread = new Thread(() => reader.Read()) { IsBackground = true, Name = "Reader" + i, 
					Priority = Priority
				};
				thread.Start();
			}

			var totalMessages = NumberOfMessages * NumberOfWriters;
			while (container.WritersFinished < NumberOfWriters || receivedMessages.Count < totalMessages)
			{
				Thread.Sleep(1);
			}

			container.IsCancelled = true;
			Thread.Sleep(1);

			return receivedMessages;
		}
	}
}
