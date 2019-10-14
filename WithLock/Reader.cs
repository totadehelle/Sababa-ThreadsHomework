using System.Collections.Concurrent;

namespace WithLock
{
	public class Reader
	{
		private readonly ConcurrentBag<string> _receivedMessages;
		private readonly object _padlock;
		private readonly SharedDataContainer _container;

		public Reader(ConcurrentBag<string> receivedMessages, object padlock, SharedDataContainer container)
		{
			_receivedMessages = receivedMessages;
			_padlock = padlock;
			_container = container;
		}

		public void Read()
		{
			while (!_container.IsCancelled)
			{
				lock (_padlock)
				{
					if (_container.Buffer != null)
					{
						var message = _container.Buffer;
						_receivedMessages.Add(message);
						_container.Buffer = null;
					}
				}
			}
		}
	}
}