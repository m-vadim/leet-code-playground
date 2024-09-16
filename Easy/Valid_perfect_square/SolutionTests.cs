using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(16).Returns(true);
		yield return new TestCaseData(1521).Returns(true);
		yield return new TestCaseData(1).Returns(true);
		yield return new TestCaseData(14).Returns(false);
		yield return new TestCaseData(1520).Returns(false);
		yield return new TestCaseData(2147483647).Returns(false);
	}

	[TestCaseSource(nameof(Cases))]
	public static bool ReturnsTrueWhenNumIsPerfectSquare(int num) {
		return new Solution().IsPerfectSquare(num);
	}
}
