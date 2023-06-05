namespace LeetCode;

// https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length/
public class Solution {
	public int MaxVowels(string s, int k) {
		int max = 0, current = 0;

		for (var index = 0; index < s.Length; index++) {
			if (index + 1 > k && IsVowel(s[index - k])) {
				current -= 1;
			}
			
			if (IsVowel(s[index])) {
				current += 1;
				if (current > max) {
					max = current;
				}
			}
		}

		return max;
	}

	private static bool IsVowel(char c) {
		return c is 'a' or 'e' or 'i' or 'o' or 'u';
	}
}