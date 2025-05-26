using BenchmarkDotNet.Attributes;

namespace LeetCode;

public class SolutionBenchmark {
	private readonly Solution _solution = new();

	public SolutionBenchmark(string[] testData) {
		TestData = testData;
	}

	public static IEnumerable<string[]> TestDataSource() {
		yield return ["ab", "ty", "yt", "lc", "cl", "ab"];
		yield return ["cc", "ll", "xx"];
		yield return ["lc", "cl", "gg"];
	}

	[ParamsSource(nameof(TestDataSource))]
	public required string[] TestData { get; set; }

	[Benchmark]
	public void RunSolutionBenchmark() => _solution.LongestPalindrome(TestData);
}
