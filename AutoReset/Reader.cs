using System.Collections.Concurrent;
using System.Threading;

namespace WithAutoReset
{
	public class Reader
	{
		private readonly ConcurrentBag<string> _receivedMessages;
		private readonly AutoResetEvent _readWaitHandle;
		private readonly AutoResetEvent _writeWaitHandle;
		private readonly SharedDataContainer _container;

		public Reader(ConcurrentBag<string> receivedMessages, AutoResetEvent readWaitHandle, 
			AutoResetEvent writeWaitHandle, SharedDataContainer container)
		{
			_receivedMessages = receivedMessages;
			_writeWaitHandle = writeWaitHandle;
			_readWaitHandle = readWaitHandle;
			_container = container;
		}

		public void Read()
		{
			while (true)
			{
				try
				{
					_readWaitHandle.WaitOne();
					if (_container.Buffer != null)
					{
						_receivedMessages.Add(_container.Buffer);
					}
					_container.Buffer = null;
					_writeWaitHandle.Set();
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