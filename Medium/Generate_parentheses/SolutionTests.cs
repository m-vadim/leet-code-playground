using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(1, new[] { "()" });
		yield return new TestCaseData(2, new[] { "()()", "(())" });
		yield return new TestCaseData(3, new[] { "((()))", "(()())", "(())()", "()(())", "()()()" });
	}

	[TestCaseSource(nameof(Cases))]
	public static void ReturnsAllParenthesesCombinations(int n, string[] expected) {
		CollectionAssert.AreEquivalent(expected, new Solution().GenerateParenthesis(n));
	}
}