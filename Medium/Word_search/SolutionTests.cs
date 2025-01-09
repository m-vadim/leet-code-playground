using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new char[][] { ['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E'] }, "ABCCED")
			.Returns(true);
		yield return new TestCaseData(new char[][] { ['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E'] }, "SEE")
			.Returns(true);
		yield return new TestCaseData(new char[][] { ['a', 'b'], ['c', 'd'] }, "acdb")
			.Returns(true);
	}

	[TestCaseSource(nameof(Cases))]
	public static bool ReturnsTrueWhenWordIsExistsOnBoard(char[][] board, string word) {
		return new Solution().Exist(board, word);
	}
}
