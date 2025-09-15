using System.Text;

/// <summary>
/// https://leetcode.com/problems/vowel-spellchecker
/// </summary>
public sealed class Solution {
	private const char WildCard = '*';
	public string[] Spellchecker(string[] wordlist, string[] queries) {
		var exactSet = new HashSet<string>(wordlist.Length);
		var allLowersMap = new Dictionary<string, string>(wordlist.Length);
		var noVowelsMap = new Dictionary<string, string>(wordlist.Length);

		foreach (string word in wordlist) {
			exactSet.Add(word);
			allLowersMap.TryAdd(word.ToLower(), word);
			noVowelsMap.TryAdd(MaskVowels(word), word);
		}

		string[] results = new string[queries.Length];
		for (var index = 0; index < queries.Length; index++) {
			results[index] = MatchWord(queries[index], exactSet, allLowersMap, noVowelsMap);
		}

		return results;
	}

	private static readonly HashSet<char> Vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];

	private static string MaskVowels(string word) {
		char[] arr = word.ToCharArray();
		for (int i = 0; i < arr.Length; i++) {
			if (Vowels.Contains(arr[i])) {
				arr[i] = WildCard;
			} else {
				arr[i] = char.ToLower(arr[i]);
			}
		}

		return new string(arr);
	}

	private string MatchWord(string query,
							 HashSet<string> exactSet,
							 Dictionary<string, string> allLowersMap,
							 Dictionary<string, string> noVowelsMap) {
		if (exactSet.Contains(query)) {
			return query;
		}

		if (allLowersMap.TryGetValue(query.ToLower(), out string word)) {
			return word;
		}

		if (noVowelsMap.TryGetValue(MaskVowels(query), out word)) {
			return word;
		}

		return string.Empty;
	}
}
