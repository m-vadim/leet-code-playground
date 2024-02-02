using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(100, 300).Returns(new[] { 123, 234 });
		yield return new TestCaseData(1000, 13000).Returns(new[] { 1234, 2345, 3456, 4567, 5678, 6789, 12345 });
		yield return new TestCaseData(500, 550).Returns(Array.Empty<int>());
		yield return new TestCaseData(10, 1000000000).Returns(new[] {
			12, 23, 34, 45, 56, 67, 78, 89, 123, 234, 345, 456, 567, 678, 789, 1234, 2345, 3456, 4567, 5678, 6789,
			12345, 23456, 34567, 45678, 56789, 123456, 234567, 345678, 456789, 1234567, 2345678, 3456789, 12345678,
			23456789, 123456789
		});
		yield return new TestCaseData(342, 353).Returns(new[] { 345 });
	}

	[TestCaseSource(nameof(Cases))]
	public static IList<int> ReturnsSequentialDigits(int low, int high) {
		return new Solution().SequentialDigits(low, high);
	}
}