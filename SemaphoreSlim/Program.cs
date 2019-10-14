using System;
using BenchmarkDotNet.Running;

namespace WithSemaphoreSlim
{
	class Program
	{
		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<Controller>();
			Console.ReadKey();
		}
	}
}
