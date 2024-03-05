/// <summary>
/// https://leetcode.com/problems/minimum-length-of-string-after-deleting-similar-ends
/// </summary>
public class Solution {
	public int MinimumLength(string s) {
		int left = 0, right = s.Length - 1;
		
		while (left < right && s[left] == s[right]) {
			char prefixChar = s[left];

			while (left <= right && prefixChar == s[left]) {
				left++;
			};
			while (left <= right && prefixChar == s[right]) {
				right--;
			};
		}

		return right - left + 1;
	}
}