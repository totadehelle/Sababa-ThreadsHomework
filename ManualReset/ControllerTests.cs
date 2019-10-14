using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace WithManualReset
{
	public class ControllerTests
	{
		[Test, Timeout(5000)]
		public void Process_WithMultipleWritersAndReaders_ReturnsAllExpectedMessages()
		{
			int numberOfWriters = 3;
			int numberOfReaders = 3;
			int numberOfMessages = 10;
			ThreadPriority priority = ThreadPriority.Normal;
			var expectedCollection = new ConcurrentBag<string>().ToList();
			for (int i = 0; i < numberOfWriters; i++)
			{
				var collection = CreateSetOfMessages(i, numberOfMessages);
				foreach (var message in collection)
				{
					expectedCollection.Add(message);
				}
			}
			expectedCollection.Sort();
			var sut = new Controller()
			{
				NumberOfReaders = numberOfReaders,
				NumberOfWriters = numberOfWriters,
				NumberOfMessages = numberOfMessages,
				Priority = priority
			};

			var actualCollection = sut.Process().ToList();
			actualCollection.Sort();

			CollectionAssert.AreEqual(expectedCollection, actualCollection);
		}

		private string[] CreateSetOfMessages(int id, int numberOfMessages)
		{
			var messages = new string[numberOfMessages];
			for (int i = 0; i < numberOfMessages; i++)
			{
				messages[i] = $"{id}-{i}";
			}
			return messages;
		}
	}
}