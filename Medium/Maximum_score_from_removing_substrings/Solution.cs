/// <summary>
/// https://leetcode.com/problems/maximum-score-from-removing-substrings
/// </summary>
public class Solution {
	public int MaximumGain(string s, int x, int y) {
		ScoreCriteria first, second;
		if (x > y) {
			first = new ScoreCriteria(x, 'a', 'b');
			second = new ScoreCriteria(y, 'b', 'a');
		} else {
			first = new ScoreCriteria(y, 'b', 'a');
			second = new ScoreCriteria(x, 'a', 'b');
		}

		int score = 0;
		var chars = new List<char>(s.Length);

		foreach (char ch in s) {
			if (chars.Count > 0 && chars[^1] == first.FirstLetter && ch == first.SecondLetter) {
				score += first.Score;
				chars.RemoveAt(chars.Count - 1);
			} else {
				chars.Add(ch);
			}
		}

		if (chars.Count > 1) {
			var stack = new Stack<char>(chars.Count);
			foreach (char ch in chars) {
				if (stack.Count > 0 && stack.Peek() == second.FirstLetter && ch == second.SecondLetter) {
					score += second.Score;
					stack.Pop();
				} else {
					stack.Push(ch);
				}
			}
		}

		return score;
	}

	private record struct ScoreCriteria(int Score, char FirstLetter, char SecondLetter);
}
