// https://leetcode.com/problems/find-the-difference/

public class Solution {
	public char FindTheDifference(string s, string t) {
		int sum = t[0];

		for (var i = 1; i < t.Length; i++) {
			sum += t[i];
			sum -= s[i - 1];
		}
		
		return (char) sum;
	}
}