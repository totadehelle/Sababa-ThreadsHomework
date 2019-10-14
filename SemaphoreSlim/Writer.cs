using System.Collections.Generic;
using System.Threading;

namespace WithSemaphoreSlim
{
	public class Writer
	{
		private readonly int _id;
		private readonly int _numberOfMessages;
		private readonly SemaphoreSlim _writeSemaphore;
		private readonly SemaphoreSlim _readSemaphore;
		private readonly SharedDataContainer _container;

		public Writer(int id, int numberOfMessages, SemaphoreSlim readSemaphore, 
			SemaphoreSlim writeSemaphore, SharedDataContainer container)
		{
			_id = id;
			_numberOfMessages = numberOfMessages;
			_writeSemaphore = writeSemaphore;
			_readSemaphore = readSemaphore;
			_container = container;
		}

		public void Write()
		{
			var messages = CreateSetOfMessages(_id);

			while (messages.Count > 0)
			{
				_writeSemaphore.Wait();
				if (_container.Buffer == null)
				{
					_container.Buffer = messages.Dequeue();
					_readSemaphore.Release();
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