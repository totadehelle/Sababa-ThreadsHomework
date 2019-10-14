using System.Collections.Concurrent;

namespace WithoutSynchronization
{
	public class Reader
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
			while (true)
			{
				if (_container.Buffer != null)
				{
					//message may be null if after reading other thread set the buffer to null
					var message = _container.Buffer;
					//some new message written by other thread after reading may be lost
					_container.Buffer = null;
					_receivedMessages.Add(message);
				}
			}
		}
	}
}