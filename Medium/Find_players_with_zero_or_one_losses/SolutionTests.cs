using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object?[] {
			new int[][] { [1, 3], [2, 3], [3, 6], [5, 6], [5, 7], [4, 5], [4, 8], [4, 9], [10, 4], [10, 9] }
		}).Returns(new List<IList<int>> { new List<int> { 1, 2, 10 }, new List<int> { 4, 5, 7, 8 } });
		
		yield return new TestCaseData(new object?[] {
			new int[][] { [1,5],[2,5],[2,8],[2,9],[3,8],[4,7],[4,9],[5,7],[6,8] }
		}).Returns(new List<IList<int>> { new List<int> { 1,2,3,4,6 }, new List<int>() });
	}

	[TestCaseSource(nameof(Cases))]
	public static IList<IList<int>> FindPlayersWithMaxOneLose(int[][] matches) {
		return new Solution().FindWinners(matches);
	}
}