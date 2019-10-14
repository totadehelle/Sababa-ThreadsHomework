using System.Collections.Generic;

namespace WithoutSynchronization
{
	public class Writer
	{
		private readonly int _id;
		private readonly int _numberOfMessages;
		private readonly SharedDataContainer _container;
		public Writer(int id, int numberOfMessages, SharedDataContainer container)
		{
			_id = id;
			_numberOfMessages = numberOfMessages;
			_container = container;
		}

		public void Write()
		{
			var messages = CreateSetOfMessages(_id);

			while (messages.Count > 0)
			{
				if (_container.Buffer == null)
				{
					//May write to not empty buffer if after reading other thread write to it,
					//so the message of other thread will be lost
					_container.Buffer = messages.Dequeue();
				}
			}

			//May write wrong value if after reading other thread increment it
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