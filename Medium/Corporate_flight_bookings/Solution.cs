/// <summary>
/// https://leetcode.com/problems/corporate-flight-bookings/
/// </summary>
public sealed class Solution {
	public int[] CorpFlightBookings(int[][] bookings, int n) {
		var res = new int[n];

		foreach (var booking in bookings) {
			var first = booking[0] - 1;
			var last = booking[1] - 1;
			var seats = booking[2];

			res[first] += seats;
			if (last < n - 1) {
				res[last + 1] -= seats;
			}
		}

		var totalSum = res[0];
		for (var i = 1; i < n; i++) {
			totalSum = res[i] + totalSum;
			res[i] = totalSum;
		}

		return res;
	}
}
