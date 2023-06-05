namespace LeetCode;

// https://leetcode.com/problems/removing-stars-from-a-string/
public class Solution {
	public string RemoveStars(string s) {
		var stack = new Stack<char>();

		foreach (char c in s) {
			if (c == '*') {
				stack.Pop();
			}
			else {
				stack.Push(c);
			}
		}

		var cc = new char[stack.Count];
		for (int i = stack.Count - 1; i >= 0; i--) {
			cc[i] = stack.Pop();
		}

		return new string(cc);
	}
	
	public string RemoveStarsNonStack(string s) {
		string ss = string.Empty;

		int i = s.Length - 1;
		var stars = 0;

		while (i >= 0) {
			char currentChar = s[i];
			if (currentChar == '*') {
				stars += 1;
			}
			else if (stars > 0) {
				stars--;
			}
			else {
				ss = currentChar + ss;
			}

			i--;
		}

		return ss;
	}
}