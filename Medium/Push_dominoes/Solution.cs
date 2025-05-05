/// <summary>
///     https://leetcode.com/problems/push-dominoes
/// </summary>
public class Solution {
	private const char Dot = '.';
	private const char Right = 'R';
	private const char Left = 'L';

	public string PushDominoes(string dominoes) {
		var state = dominoes.ToCharArray();
		var changes = new List<Change>(dominoes.Length);

		while (true) {
			for (var i = 0; i < state.Length; i++) {
				if (state[i] == Dot && TryPushDomino(state, i, out char newState)) {
					changes.Add(new Change(i, newState));
				}
			}

			if (changes.Count == 0) {
				break;
			}

			foreach (Change change in changes) {
				state[change.Index] = change.NewState;
			}
			changes.Clear();
		}

		return new string(state);
	}

	private static bool TryPushDomino(char[] dominoes, int position, out char newState) {
		var prev = position > 0 ? dominoes[position - 1] : Dot;
		var next = position < dominoes.Length - 1 ? dominoes[position + 1] : Dot;
		newState = Dot;

		if (prev == Right || next == Left) {
			if (prev == Right && next == Left) {
				return false;
			}

			newState = prev == Right ? Right : Left;
			return true;
		}

		return false;
	}

	private record Change(int Index, char NewState);
}
