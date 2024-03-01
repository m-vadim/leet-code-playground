/// <summary>
/// https://leetcode.com/problems/find-the-most-competitive-subsequence/
/// </summary>
public class Solution {
	public int[] MostCompetitive(int[] nums, int limit) {
		int len = nums.Length;
		var stack = new Stack<int>();
		for (int index = 0; index < len; index++) {
			int currentNum = nums[index];
			int numbersLeft = len - index;
			
			while (stack.Count > 0 && 
			       nums[stack.Peek()] > currentNum && 
			       numbersLeft > limit - stack.Count) {
				stack.Pop();
			}

			if (stack.Count < limit) {
				stack.Push(index);
			}
		}

		var result = new int[stack.Count];
		while (stack.Count > 0) {
			result[stack.Count - 1] = nums[stack.Pop()];
		}

		return result;
	}
}