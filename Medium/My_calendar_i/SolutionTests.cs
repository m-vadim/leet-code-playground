using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(
			new object[] {
				new int[][] { [10, 20], [15, 25], [20, 30] },
				new[] { true, false, true }
			});
		yield return new TestCaseData(
			new object[] {
				new int[][] { [47, 50], [33, 41], [39, 45], [33, 42], [25, 32], [26, 35], [19, 25], [3, 8], [8, 13], [18, 27] },
				new[] { true, true, false, false, true, false, true, true, true, false }
			});
	}

	[TestCaseSource(nameof(Cases))]
	public static void Returns(int[][] input, bool[] expected) {
		var cl = new MyCalendar();
		var results = new bool[input.Length];

		for (var i = 0; i < input.Length; i++) {
			results[i] = cl.Book(input[i][0], input[i][1]);
		}

		CollectionAssert.AreEqual(expected, results);
	}
}
