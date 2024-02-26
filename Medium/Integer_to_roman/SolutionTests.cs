using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(3).Returns("III");
		yield return new TestCaseData(58).Returns("LVIII");
		yield return new TestCaseData(1994).Returns("MCMXCIV");
	}


	[TestCaseSource(nameof(Cases))]
	public static string ReturnRoman(int num) {
		return new Solution().IntToRoman(num);
	}
}