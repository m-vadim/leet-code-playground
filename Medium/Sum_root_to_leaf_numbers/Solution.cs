using LeetCode;

/// <summary>
/// https://leetcode.com/problems/sum-root-to-leaf-numbers
/// </summary>
public class Solution {
	private int _sum = 0;

	public int SumNumbers(TreeNode root) {
		var st = new LinkedList<int>();
		Dfs(root, 0, st);
		return _sum;
	}

	private int GetNum(LinkedList<int> digits, int rank) {
		int num = 0;
		foreach (int digit in digits) {
			num += (int)Math.Pow(10, rank--) * digit;
		}
		return num;
	}

	public void Dfs(TreeNode node, int depth, LinkedList<int> nums) {
		nums.AddLast(node.val);
		if (node.left == null && node.right == null) {
			_sum += GetNum(nums, depth);
			nums.RemoveLast();
			return;
		}

		if (node.left != null) {
			Dfs(node.left, depth + 1, nums);
		}

		if (node.right != null) {
			Dfs(node.right, depth + 1, nums);
		}

		nums.RemoveLast();
	}
}
