/// <summary>
/// https://leetcode.com/problems/car-pooling/description/
/// </summary>
public class Solution {
	public bool CarPooling(int[][] trips, int capacity) {
		var res = new int[1001];

		foreach (var trip in trips) {
			var passengers = trip[0];
			var from = trip[1];
			var to = trip[2];

			res[from] += passengers;
			if (to < 1000) {
				res[to] -= passengers;
			}
		}

		int totalSum = res[0];
		foreach (int c in res) {
			totalSum += c;
			if (totalSum > capacity) {
				return false;
			}
		}

		return true;
	}
}
