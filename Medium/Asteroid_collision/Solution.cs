/// <summary>
/// https://leetcode.com/problems/asteroid-collision/
/// </summary>
public class Solution {
	public int[] AsteroidCollision(int[] asteroids) {
		var stack = new Stack<int>();
		foreach (int ast in asteroids) {
			if (stack.Count == 0) {
				stack.Push(ast);
				continue;
			}

			int astDirection = Math.Sign(ast);

			if (Math.Sign(stack.Peek()) <= astDirection) {
				stack.Push(ast);
				continue;
			}

			while (Math.Sign(stack.Peek()) > astDirection) {
				int prev = stack.Pop();
				if (Math.Abs(prev) == Math.Abs(ast)) {
					break;
				}

				if (Math.Abs(prev) > Math.Abs(ast)) {
					stack.Push(prev);
					break;
				}

				if (stack.Count == 0 || Math.Sign(stack.Peek()) <= astDirection) {
					stack.Push(ast);
				}
			}
		}

		return stack.Reverse().ToArray();
	}
}