namespace LeetCode;

// https://leetcode.com/problems/minimum-penalty-for-a-shop/
public class Solution {
	public int BestClosingTime(string customers) {
		const char yes = 'Y';
		const char no = 'N';

		var penalties = new int[customers.Length + 1];

		int counter = 0;
		for (int hour = 1; hour < penalties.Length; hour++) {
			penalties[hour] = customers[hour - 1] == no ? ++counter : counter;
		}
		
		counter = 0;
		int minPenalty = penalties[^1], minHour = penalties.Length - 1;
		for (int hour = penalties.Length - 2; hour >= 0; hour--) {
			penalties[hour] += (customers[hour] == yes ? ++counter : counter);
			if (penalties[hour] <= minPenalty) {
				minPenalty = penalties[hour];
				minHour = hour;
			}
		}

		return minHour;
	}
}