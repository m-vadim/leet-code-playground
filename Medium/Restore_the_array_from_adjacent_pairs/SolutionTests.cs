using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object[] {
			new[] {
				new[] { 2, 1 },
				new[] { 3, 4 },
				new[] { 3, 2 }
			}
		}).Returns(new[] { 1, 2, 3, 4 });
		yield return new TestCaseData(new object[] {
			new[] {
				new[] { 4, -2 },
				new[] { 1, 4 },
				new[] { -3, 1 }
			}
		}).Returns(new[] { -2, 4, 1, -3 });
		yield return new TestCaseData(new object[] {
			new[] {
				new[] { -1, 0 }
			}
		}).Returns(new[] { -1, 0 });
		yield return new TestCaseData(new object[] {
			new[] {
				new[] { 1, 0 },
				new[] { -1, 1 }
			}
		}).Returns(new[] { 0, 1, -1 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsRestoredArray(int[][] adjacentPairs) {
		return new Solution().RestoreArray(adjacentPairs);
	}
}