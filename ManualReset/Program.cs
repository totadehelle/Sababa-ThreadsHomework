using System;
using BenchmarkDotNet.Running;

namespace WithManualReset
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
