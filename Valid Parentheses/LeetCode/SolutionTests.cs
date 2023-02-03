using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("()").Returns(true);
		yield return new TestCaseData("()[]{}").Returns(true);
		yield return new TestCaseData("{[()()]{}}").Returns(true);
		yield return new TestCaseData("[").Returns(false);
		yield return new TestCaseData("[}}").Returns(false);
		yield return new TestCaseData("[{{}").Returns(false);
		yield return new TestCaseData("[}").Returns(false);
		yield return new TestCaseData("([)]").Returns(false);
		yield return new TestCaseData("{()([]").Returns(false);
		yield return new TestCaseData("(){}}{").Returns(false);
		yield return new TestCaseData("({{{{}}}))").Returns(false);
	}

	[TestCaseSource(nameof(Cases))]
	public static bool ReturnsTrueIfValid(string s) {
		return new Solution().IsValid(s);
	}
	
	[TestCaseSource(nameof(Cases))]
	public static bool ReturnsTrueIfValidDP(string s) {
		return new SolutionDP().IsValid(s);
	}
}