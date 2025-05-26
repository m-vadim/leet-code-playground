using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;

namespace LeetCode;

public class Program {
	public static void Main(string[] _) {
		var config = new ManualConfig()
			.WithOptions(ConfigOptions.DisableOptimizationsValidator)
			.AddLogger(ConsoleLogger.Default)
			.AddColumnProvider(DefaultColumnProviders.Instance);

		BenchmarkRunner.Run<SolutionBenchmark>(config);
	}
}
