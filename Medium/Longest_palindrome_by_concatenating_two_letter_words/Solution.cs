/// <summary>
///     https://leetcode.com/problems/longest-palindrome-by-concatenating-two-letter-words
/// </summary>
public class Solution {
	public int LongestPalindrome(string[] words) {
		int count = 0;

		var map = new Dictionary<string, int>(words.Length);
		foreach (string word in words) {
			if (!map.TryAdd(word, 1)) {
				map[word]++;
			}
		}

		bool hasOddSameChar = false;
		foreach (var (word, freq) in map) {
			if (freq == 0) {
				continue;
			}

			if (IsTwoChar(word)) {
				if (freq % 2 == 0) {
					count += freq * 2;
				} else {
					count += (freq - 1) * 2;
					hasOddSameChar = true;
				}
			} else {
				string rev = Reverse(word);
				if (map.TryGetValue(rev, out int revFreq) && revFreq > 0) {
					int pairs = Math.Min(revFreq, freq);
					count += pairs * 4;
					map[rev] -= pairs;
					map[word] -= pairs;
				}
			}
		}

		if (hasOddSameChar) {
			count += 2;
		}

		return count;
	}

	private static string Reverse(string word) => new string([word[1], word[0]]);
	private static bool IsTwoChar(string word) => word[0] == word[1];
}
