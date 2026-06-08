using System.Collections;
using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable Cases() {
		yield return new TestCaseData(120, 130).Returns(3);
		yield return new TestCaseData(198, 202).Returns(3);
		yield return new TestCaseData(4848, 4848).Returns(2);
	}

	[TestCaseSource(nameof(Cases))]
	public static int RunsCases(int num1, int num2) {
		return new Solution().TotalWaviness(num1, num2);
	}
}
