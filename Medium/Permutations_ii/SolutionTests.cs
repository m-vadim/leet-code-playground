using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static readonly Solution Solution = new();

	private static IEnumerable<TestCaseData> Cases() {
		int[] input = [1, 2, 3];
		var output = new List<IList<int>> {
			new List<int> { 1, 2, 3 },
			new List<int> { 1, 3, 2 },
			new List<int> { 2, 1, 3 },
			new List<int> { 2, 3, 1 },
			new List<int> { 3, 1, 2 },
			new List<int> { 3, 2, 1 }
		};

		yield return new TestCaseData(input, output);

		input = [1, 1, 2];
		output = [
			new List<int> { 1, 1, 2 },
			new List<int> { 1, 2, 1 },
			new List<int> { 2, 1, 1 }
		];

		yield return new TestCaseData(input, output);
	}

	[TestCaseSource(nameof(Cases))]
	public static void ReturnsAllUniquePermutations(int[] nums, IList<IList<int>> expected) {
		AreEqual(Solution.PermuteUnique(nums), expected);

	}

	private static void AreEqual(IList<IList<int>> actual, IList<IList<int>> expected) {
		if (actual.Count != expected.Count) {
			Assert.Fail("Actual and expected lists have different counts.");
		}

		List<string> expectedSets = expected.Select(inner => string.Join(",", inner)).ToList();
		List<string> actualSets = actual.Select(inner => string.Join(",", inner)).ToList();

		foreach (var set in expectedSets) {
			if (!actualSets.Remove(set)) {
				Assert.Fail($"Expected inner list [{set}] not found in actual list.");
			}
		}

		Assert.Pass("Success");
	}
}
