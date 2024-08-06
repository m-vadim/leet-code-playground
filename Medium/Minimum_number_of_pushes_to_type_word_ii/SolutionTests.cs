using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("aabbccddeeffgghhiiiiii").Returns(24);
		yield return new TestCaseData("abcde").Returns(5);
		yield return new TestCaseData("xyzxyzxyzxyz").Returns(12);
		yield return new TestCaseData("ajqjtbjhczpakocxjrsugawef").Returns(39);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMinimumPushes(string word) {
		return new Solution().MinimumPushes(word);
	}
}
