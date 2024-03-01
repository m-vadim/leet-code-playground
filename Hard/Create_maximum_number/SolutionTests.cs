using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 3, 4, 6, 5 }, new[] { 9, 1, 2, 5, 8, 3 }, 5)
			.Returns("98653");
		yield return new TestCaseData(new[] { 6, 7 }, new[] { 6, 0, 4 }, 5)
			.Returns("67604");
		yield return new TestCaseData(new[] { 3, 9 }, new[] { 8, 9 }, 3)
			.Returns("989");
		yield return new TestCaseData(new[] { 2, 5, 6, 4, 4, 0 }, new[] { 7, 3, 8, 0, 6, 5, 7, 6, 2 }, 15)
			.Returns("738256440657620");
		yield return new TestCaseData(new[] { 8, 6, 9 }, new[] { 1, 7, 5 }, 3)
			.Returns("975");
		yield return new TestCaseData(new[] { 3, 3, 1, 8, 2, 4, 2, 9, 2, 4, 7, 1, 9, 2, 3, 4, 0, 7, 5, 4 },
				new[] {
					9, 7, 7, 1, 3, 6, 8, 6, 9, 6, 0, 4, 3, 6, 6, 1, 0, 4, 6, 2, 2, 6, 4, 6, 0, 4, 9, 7, 4, 9, 8, 4, 9,
					8, 4, 6, 6, 5, 8, 2, 8, 6, 6, 6, 1, 0, 9, 0, 8, 0, 4, 0, 4, 4, 1, 7, 9, 8, 4, 2, 2, 0, 3, 2, 3, 9,
					1, 8, 9, 5, 2, 7, 9, 2, 7, 7, 8, 5, 4, 4, 8, 6, 5, 5, 9, 6, 1, 4, 6, 0, 8, 5, 3, 4, 2, 0, 0, 9, 5, 2
				}, 100)
			.Returns(
				"9999646623410754046226460497498498466582866610908040441798422032391895279277854486559614608534200952");
		yield return new TestCaseData(
				new[] {
					5, 7, 7, 0, 1, 6, 7, 2, 2, 4, 6, 8, 9, 2, 0, 9, 8, 7, 6, 3, 9, 4, 8, 8, 4, 5, 3, 3, 7, 4, 3, 2, 8,
					9, 8, 4, 0, 2, 0, 2, 2, 0, 4, 2, 2, 8, 6, 7, 1, 0, 8, 7, 5, 4, 6, 4, 1, 7, 4, 4, 3, 7, 5, 8, 8, 0,
					3, 1, 3, 4, 6, 0, 6, 9, 6, 6, 4, 2, 1, 9, 3, 7, 4, 4, 4, 2, 1, 9, 5, 2, 1, 7, 6, 0, 1, 3, 5, 3, 7, 7
				}, new[] { 8, 3, 7, 8, 6, 9, 1, 5, 5, 0, 5, 2, 8, 7, 8, 3, 3, 7, 9, 2 }, 100)
			.Returns(
				"9998887869453374328984155052878337920202204228671087546417443758803134606966421937444219521760135377");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsMaxNumber(int[] nums1, int[] nums2, int k) {
		return string.Join(string.Empty, new Solution().MaxNumber(nums1, nums2, k));
	}
}