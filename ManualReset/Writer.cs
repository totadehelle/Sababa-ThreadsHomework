using System.Collections.Generic;
using System.Threading;

namespace WithManualReset
{
	class Writer
	{
		private readonly int _id;
		private readonly int _numberOfMessages;
		private readonly ManualResetEvent _readWaitHandle;
		private readonly ManualResetEvent _writeWaitHandle;
		private readonly object _padlock;
		private readonly SharedDataContainer _container;
		public Writer(int id, int numberOfMessages, ManualResetEvent readWaitHandle, 
			ManualResetEvent writeWaitHandle, object padlock, SharedDataContainer container)
		{
			_id = id;
			_numberOfMessages = numberOfMessages;
			_writeWaitHandle = writeWaitHandle;
			_readWaitHandle = readWaitHandle;
			_padlock = padlock;
			_container = container;
		}

		public void Write()
		{
			var messages = CreateSetOfMessages(_id);

			while (messages.Count > 0)
			{
				_writeWaitHandle.WaitOne();
				_writeWaitHandle.Reset();

				lock (_padlock)
				{
					if (_container.Buffer == null)
					{
						_container.Buffer = messages.Dequeue();
						_readWaitHandle.Set();
					}
				}
			}

			lock (_padlock)
			{
				_container.WritersFinished++;
			}
		}

		private Queue<string> CreateSetOfMessages(int id)
		{
			var messages = new Queue<string>();
			for (int i = 0; i < _numberOfMessages; i++)
			{
				messages.Enqueue($"{id}-{i}");
			}
			return messages;
		}
	}
}
