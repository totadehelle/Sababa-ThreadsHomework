using System.Collections.Generic;
using System.Threading;

namespace WithAutoReset
{
	public class Writer
	{
		private readonly int _id;
		private readonly int _numberOfMessages;
		private readonly AutoResetEvent _readWaitHandle;
		private readonly AutoResetEvent _writeWaitHandle;
		private readonly SharedDataContainer _container;
		public Writer(int id, int numberOfMessages, AutoResetEvent readWaitHandle, AutoResetEvent writeWaitHandle, SharedDataContainer container)
		{
			_id = id;
			_numberOfMessages = numberOfMessages;
			_writeWaitHandle = writeWaitHandle;
			_readWaitHandle = readWaitHandle;
			_container = container;
		}

		public void Write()
		{
			var messages = CreateSetOfMessages(_id);

			while (messages.Count > 0)
			{
				_writeWaitHandle.WaitOne();
				if (_container.Buffer == null)
				{
					_container.Buffer = messages.Dequeue(); 
					_readWaitHandle.Set();
				}
			}

			_container.WritersFinished++;
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