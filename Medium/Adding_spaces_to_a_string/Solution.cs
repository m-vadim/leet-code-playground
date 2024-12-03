/// <summary>
///     https://leetcode.com/problems/adding-spaces-to-a-string
/// </summary>
public class Solution {
	private const char SpaceSymbol = ' ';

	public string AddSpaces(string s, int[] spaces) {
		char[] result = new char[s.Length + spaces.Length];

		for (var i = 0; i < spaces.Length; i++) {
			result[spaces[i] + i] = SpaceSymbol;
		}

		int index = 0;
		foreach (char l in s) {
			if (result[index] == SpaceSymbol) {
				index++;
			}

			result[index++] = l;
		}

		return new string(result);
	}
}
