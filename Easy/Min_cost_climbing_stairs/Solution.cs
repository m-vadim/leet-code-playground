/// <summary>
/// https://leetcode.com/problems/min-cost-climbing-stairs
/// </summary>
public class Solution {
	public int MinCostClimbingStairs(int[] costs) {
		int oneStepBehind = costs[1], twoStepBehind = costs[0], tmp = 0;

		for (var i = 2; i < costs.Length; i++) {
			tmp = costs[i] + Math.Min(oneStepBehind, twoStepBehind);
			twoStepBehind = oneStepBehind;
			oneStepBehind = tmp;
		}

		return Math.Min(twoStepBehind, oneStepBehind);
	}
}