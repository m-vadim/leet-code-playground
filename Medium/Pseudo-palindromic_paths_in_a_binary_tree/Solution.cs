using LeetCode;

/// <summary>
/// https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree
/// </summary>
public class Solution {

	private int _result;
	public int PseudoPalindromicPaths (TreeNode root) {
		var digits = new ushort[10];
		Dfs(root, digits);
		
		return _result;
	}

	private void Dfs(TreeNode node, ushort[] digits) {
		if (node == null) {
			return;
		}

		digits[node.val]++;

		Dfs(node.left, digits);
		Dfs(node.right, digits);

		if (node.left == null && node.right == null && IsPalindrome(digits)) {
			_result++;
		}
		
		digits[node.val]--;
	}

	private static bool IsPalindrome(ushort[] digits) {
		var oddFound = false;
		foreach (int digit in digits) {
			if (digit % 2 == 1) {
				if (oddFound) {
					return false;
				}
				
				oddFound = true;
			}
		}

		return true;
	}
}