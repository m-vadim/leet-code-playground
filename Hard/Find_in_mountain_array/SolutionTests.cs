using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(3, new MountainArray(new[] { 1, 2, 3, 4, 5, 3, 1 })).Returns(2);
		yield return new TestCaseData(3, new MountainArray(new[] { 0, 1, 2, 4, 2, 1 })).Returns(-1);
		yield return new TestCaseData(1, new MountainArray(new[] { 1, 5, 2 })).Returns(0);
		yield return new TestCaseData(5, new MountainArray(new[] { 1, 5, 2 })).Returns(1);
		yield return new TestCaseData(22,
			new MountainArray(new[] {
				1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 20, 19, 18, 17, 16, 15, 14,
				13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2
			})).Returns(-1);
	}

	[TestCaseSource(nameof(Cases))]
	public static int FindsTargetInMountainArray(int target, MountainArray mountainArr) {
		return new Solution().FindInMountainArray(target, mountainArr);
	}
}