using System.Collections.Concurrent;
using System.Threading;
using BenchmarkDotNet.Attributes;

namespace WithAutoReset
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
			var readWaitHandle = new AutoResetEvent(true);
			var writeWaitHandle = new AutoResetEvent(false);
			var readers = new Thread[NumberOfReaders];

			for (int i = 0; i < NumberOfWriters; i++)
			{
				int id = i;
				var writer = new Writer(id, NumberOfMessages, readWaitHandle, writeWaitHandle, container);
				var thread = new Thread(() => writer.Write()) { Name = "Writer" + id, Priority = Priority };
				thread.Start();
			}

			for (int i = 0; i < NumberOfReaders; i++)
			{
				var reader = new Reader(receivedMessages, readWaitHandle, writeWaitHandle, container);
				var thread = new Thread(() => reader.Read())
				{
					IsBackground = true,
					Name = "Reader" + i,
					Priority = Priority
				};
				readers[i] = thread;
				thread.Start();
			}

			var totalMessages = NumberOfMessages * NumberOfWriters;
			while (container.WritersFinished < NumberOfWriters || receivedMessages.Count < totalMessages)
			{
				Thread.Sleep(1);
			}

			container.IsCancelled = true;

			for (int i = 0; i < NumberOfReaders; i++)
			{
				readers[i].Interrupt();
			}

			return receivedMessages;
		}
	}
}