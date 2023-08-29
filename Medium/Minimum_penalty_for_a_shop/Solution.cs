namespace LeetCode;

// https://leetcode.com/problems/minimum-penalty-for-a-shop/
public class Solution {
	public int BestClosingTime(string customers) {
		const char yes = 'Y';
		const char no = 'N';

		var penalties = new int[customers.Length + 1];

		int n = 0;
		for (int hour = 0; hour < penalties.Length; hour++) {
			penalties[hour] += (hour == 0 ? n : customers[hour - 1] == no ? ++n : n);
		}
		
		n = 0;
		for (int hour = penalties.Length - 1; hour >= 0; hour--) {
			penalties[hour] += (hour == penalties.Length - 1 ? n : customers[hour] == yes ? ++n : n);
		}

		int minPenalty = int.MaxValue, minHour = 0;
		for (int hour = 0; hour < penalties.Length; hour++) {
			if (penalties[hour] < minPenalty) {
				minPenalty = penalties[hour];
				minHour = hour;
			}
			
		}
		return minHour;
	}
}