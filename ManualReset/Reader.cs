using System.Collections.Concurrent;
using System.Threading;

namespace WithManualReset
{
	public class Reader
	{
		private readonly ConcurrentBag<string> _receivedMessages;
		private readonly ManualResetEvent _readWaitHandle;
		private readonly ManualResetEvent _writeWaitHandle;
		private readonly object _padlock;
		private readonly SharedDataContainer _container;

		public Reader(ConcurrentBag<string> receivedMessages, ManualResetEvent readWaitHandle, 
			ManualResetEvent writeWaitHandle, object padlock, SharedDataContainer container)
		{
			_receivedMessages = receivedMessages;
			_writeWaitHandle = writeWaitHandle;
			_readWaitHandle = readWaitHandle;
			_padlock = padlock;
			_container = container;
		}

		public void Read()
		{
			while (true)
			{
				try
				{
					_readWaitHandle.Reset();
					lock (_padlock)
					{
						if (_container.Buffer != null)
						{
							_receivedMessages.Add(_container.Buffer);
						}
						_container.Buffer = null;
					}
					_writeWaitHandle.Set();
					_readWaitHandle.WaitOne();
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