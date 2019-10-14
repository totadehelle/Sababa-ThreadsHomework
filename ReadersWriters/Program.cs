using System;
using System.Threading;

namespace WithoutSynchronization
{
	class Program
	{
		static void Main(string[] args)
		{
			var controller = new Controller()
			{
				NumberOfMessages = 3,
				NumberOfWriters = 10,
				NumberOfReaders = 10,
				Priority = ThreadPriority.Normal
			};

			var receivedMessages = controller.Process();
			foreach (var message in receivedMessages)
			{
				Console.WriteLine(message);
			}
		}
	}
}
