/// <summary>
/// https://leetcode.com/problems/minimum-deletions-to-make-string-balanced
/// </summary>
public class Solution {
	public int MinimumDeletions(string s) {
		int len = s.Length, bCount = 0;
		var bCounts = new int[len];

		for (var i = 0; i < len; i++) {
			bCounts[i] = bCount;
			if (s[i] == 'b') {
				bCount++;
			}
		}

		int aCount = 0, minDeletions = len;
		for (var i = len - 1; i >= 0; i--) {
			minDeletions = Math.Min(minDeletions, bCounts[i] + aCount);
			if (s[i] == 'a') {
				aCount++;
			}
		}

		return minDeletions;
	}
}
