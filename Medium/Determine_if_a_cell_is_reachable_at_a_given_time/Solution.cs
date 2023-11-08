namespace LeetCode;

/// <summary>
///     https://leetcode.com/problems/determine-if-a-cell-is-reachable-at-a-given-time
/// </summary>
public class Solution {
	public bool IsReachableAtTime(int sx, int sy, int fx, int fy, int t) {
		int xDiff = Math.Abs(sx - fx);
		int yDiff = Math.Abs(sy - fy);
		
		if (xDiff == 0 && yDiff == 0) {
			return t != 1; 
		}

		return Math.Max(xDiff, yDiff) <= t;
	}
}