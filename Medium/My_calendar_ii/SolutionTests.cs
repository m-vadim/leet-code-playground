using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(
			new int[][] { [10, 20], [50, 60], [10, 40], [5, 15], [5, 10], [25, 55] },
			new[] { true, true, true, false, true, true });

		yield return new TestCaseData(
			new int[][] {
				[47, 50], [1, 10], [27, 36], [40, 47], [20, 27], [15, 23], [10, 18], [27, 36], [17, 25], [8, 17], [24, 33], [23, 28], [21, 27], [47, 50], [14, 21], [26, 32], [16, 21], [2, 7],
				[24, 33], [6, 13], [44, 50], [33, 39], [30, 36], [6, 15], [21, 27], [49, 50], [38, 45], [4, 12], [46, 50], [13, 21]
			},
			new[] {
				true, true, true, true, true, true, true, true, false, false, false, false, false, true, false, false, false, true, false, false, false, false, false, false, false, false, true,
				false, false, false
			});
	}

	[TestCaseSource(nameof(Cases))]
	public static void Returns(int[][] input, bool[] expected) {
		var cl = new MyCalendarTwo();

		for (var i = 0; i < input.Length; i++) {
			var time = input[i];
			var expectedBooking = expected[i];
			Assert.That(cl.Book(time[0], time[1]), Is.EqualTo(expectedBooking), $"Book failed at index: {i} for time [{time[0]}:{time[1]}] ");
		}
	}
}
