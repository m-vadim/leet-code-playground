namespace LeetCode;

// https://leetcode.com/problems/generate-parentheses/
public class Solution {
	private const char OpenParenthesis = '(';
	private const char CloseParenthesis = ')';

	public IList<string> GenerateParenthesis(int n) {
		var result = new List<string>(2 * n - 1);
		GenerateParenthesis("(", n - 1, n, result);

		return result;
	}

	private static void GenerateParenthesis(string option, int open, int close, List<string> result) {
		// open == close, we cant start with ')'
		if (open == close) {
			if (open == 0) {
				// no open parentheses available, end the run
				result.Add(option);
				return;
			}
			
			GenerateParenthesis(option + OpenParenthesis, open - 1, close, result);
		}
		else if (open == 0) {
			// no more open parentheses, '(' only option
			GenerateParenthesis(option + CloseParenthesis, open, close - 1, result);
		}
		else {
			// two possible options: '(' and ')'
			GenerateParenthesis(option + OpenParenthesis, open - 1, close, result);
			GenerateParenthesis(option + CloseParenthesis, open, close - 1, result);
		}
	}
}