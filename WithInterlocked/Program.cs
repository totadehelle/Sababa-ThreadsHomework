using System;
using BenchmarkDotNet.Running;

namespace WithInterlocked
{
	public class Program
	{
		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<Controller>();
			Console.ReadKey();
		}
	}
}
