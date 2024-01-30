/// <summary>
/// https://leetcode.com/problems/evaluate-reverse-polish-notation
/// </summary>
public class Solution {
	private static readonly Dictionary<char, Func<int, int, int>> Actions = new(4) {
			{ '+', (a, b) => a + b },
			{ '-', (a, b) => b - a },
			{ '*', (a, b) => a * b },
			{ '/', (a, b) => b / a }
		};
	
	public int EvalRPN(string[] tokens) {
		var operands = new Stack<int>();
		foreach (string token in tokens) {
			int val = TryParseOperator(token, out char op) 
				? Actions[op](operands.Pop(), operands.Pop()) 
				: Convert.ToInt32(token);
			
			operands.Push(val);
		}

		return operands.Pop();
	}

	private static bool TryParseOperator(string token, out char op) {
		op = token[0];
		return token.Length == 1 && !char.IsDigit(op);
	}
}