using BenchmarkDotNet.Running;
using System;

namespace WithAutoReset
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
