using System.Collections.Concurrent;
using System.Threading;

namespace WithSemaphoreSlim
{
	public class Reader
	{
		private readonly ConcurrentBag<string> _receivedMessages;
		private readonly SemaphoreSlim _writeSemaphore;
		private readonly SemaphoreSlim _readSemaphore;
		private readonly SharedDataContainer _container;

		public Reader(ConcurrentBag<string> receivedMessages, SemaphoreSlim readSemaphore, 
			SemaphoreSlim writeSemaphore, SharedDataContainer container)
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
					_readSemaphore.Wait();
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