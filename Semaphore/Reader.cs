using System.Collections.Concurrent;
using System.Threading;

namespace WithSemaphore
{
	public class Reader
	{
		private readonly ConcurrentBag<string> _receivedMessages;
		private readonly Semaphore _writeSemaphore;
		private readonly Semaphore _readSemaphore;
		private readonly SharedDataContainer _container;

		public Reader(ConcurrentBag<string> receivedMessages, Semaphore readSemaphore, 
			Semaphore writeSemaphore, SharedDataContainer container)
		{
			_receivedMessages = receivedMessages;
			_writeSemaphore = writeSemaphore;
			_readSemaphore = readSemaphore;
			_container = container;
		}

		public void Read()
		{
			while (true)
			{
				try
				{
					_readSemaphore.WaitOne();
					if (_container.Buffer != null)
					{
						_receivedMessages.Add(_container.Buffer);
					}
					_container.Buffer = null;
					_writeSemaphore.Release();
				}
				catch (ThreadInterruptedException e)
				{
					if (_container.IsCancelled)
					{
						break;
					}
				}
			}
		}
	}
}