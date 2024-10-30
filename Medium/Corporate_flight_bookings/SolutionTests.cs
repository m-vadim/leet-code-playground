using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(5, new int[][] { [1, 2, 10], [2, 3, 20], [2, 5, 25] })
			.Returns(new int[] { 10, 55, 45, 25, 25 });
		yield return new TestCaseData(2, new int[][] { [1, 2, 10], [2, 2, 15] })
			.Returns(new int[] { 10, 25 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsTotalBookingsPerFlight(int n, int[][] flights) {
		return new Solution().CorpFlightBookings(flights, n);
	}
}
