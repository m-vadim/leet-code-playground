using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(5).Returns(new List<List<int>> {
			new() { 1 },
			new() { 1, 1 },
			new() { 1,2, 1 },
			new() { 1,3,3,1 },
			new() { 1,4,6,4, 1 }
		});
		
		yield return new TestCaseData(1).Returns(new List<List<int>> {
			new() { 1 }
		});
	}

	[TestCaseSource(nameof(Cases))]
	public static IList<IList<int>> ReturnsPascalsTriangle(int numRows) {
		return new Solution().Generate(numRows);
	}
}