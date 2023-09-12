// https://leetcode.com/problems/minimum-deletions-to-make-character-frequencies-unique
namespace LeetCode;

public class Solution {
	public int MinDeletions(string s) {
		var arr = new int[26];
		foreach(char c in s) {
			arr[c - 97] += 1;
		}
		Array.Sort(arr);
		int deletions = 0;
		
		for (ushort index = 25; index > 0; index--) {
			if (arr[index] == 0) {
				if (arr[index - 1] == 0) {
					break;
				}
				
				deletions += arr[index - 1];
				arr[index - 1] = 0;
				continue;
			} 

			if (arr[index] <= arr[index - 1]) {
				deletions += arr[index - 1] - (arr[index] - 1);
				arr[index - 1] = arr[index] - 1; 
			}
		}

		return deletions;
	}
}
