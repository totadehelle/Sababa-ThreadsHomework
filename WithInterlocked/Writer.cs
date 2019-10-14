using System.Threading;

namespace WithInterlocked
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
			var sentMessages = 0;
			while (sentMessages < messages.Length)
			{
				var bufferRead = Interlocked.CompareExchange(
					ref _container.Buffer, 
					messages[_numberOfMessages - sentMessages - 1], 
					null);
				if (bufferRead == null)
				{
					sentMessages++;
				}
				Thread.Sleep(0);
			}

			Interlocked.Increment(ref _container.WritersFinished);
		}

		private string[] CreateSetOfMessages(int id)
		{
			var messages = new string[_numberOfMessages];
			for (int i = 0; i < _numberOfMessages; i++)
			{
				messages[i] = $"{id}-{i}";
			}
			return messages;
		}
	}
}