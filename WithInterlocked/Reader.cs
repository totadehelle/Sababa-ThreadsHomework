using System.Collections.Concurrent;
using System.Threading;

namespace WithInterlocked
{
	class Reader
	{
		private readonly ConcurrentBag<string> _receivedMessages;
		private readonly SharedDataContainer _container;

		public Reader(ConcurrentBag<string> receivedMessages, SharedDataContainer container)
		{
			_receivedMessages = receivedMessages;
			_container = container;
		}
		
		public void Read()
		{
			while (!_container.IsCancelled)
			{
				var message = Interlocked.Exchange(ref _container.Buffer, null);
				if (message != null)
				{
					_receivedMessages.Add(message);
				}
				Thread.Sleep(0);
			}
		}
	}
}
