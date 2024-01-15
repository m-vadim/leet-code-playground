/// <summary>
/// https://leetcode.com/problems/find-players-with-zero-or-one-losses
/// </summary>
public class Solution {
	public IList<IList<int>> FindWinners(int[][] matches) {
		var map = new Dictionary<int, short>();
		foreach (int[] match in matches) {
			if (!map.ContainsKey(match[0])) {
				map.Add(match[0], 1);
			}

			int loser = match[1];
			if (map.TryGetValue(loser, out short balance)) {
				if (balance >= 0) {
					map[loser] -= 1;
				}
			}
			else {
				map[loser] = 0;
			}
		}

		var noLoss = new List<int>();
		var oneLoss = new List<int>();
		foreach (KeyValuePair<int, short> m in map) {
			if (m.Value == 1) {
				noLoss.Add(m.Key);
			} else if (m.Value == 0) {
				oneLoss.Add(m.Key);
			}
		}

		noLoss.Sort();
		oneLoss.Sort();

		return new List<IList<int>> { noLoss, oneLoss };
	}
}