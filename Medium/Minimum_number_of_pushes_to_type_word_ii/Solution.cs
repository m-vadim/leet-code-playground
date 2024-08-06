/// <summary>
/// https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-ii
/// </summary>
public sealed class Solution {
	public int MinimumPushes(string word) {
		var freqs = new int[26];
		foreach (var ch in word) {
			freqs[ch - 'a']++;
		}

		Array.Sort(freqs, (a, b) => b.CompareTo(a));
		var lettersMap = new int[8];
		var minPushes = 0;

		for (var i = 0; i < 8; i++) {
			lettersMap[i] = 1;
			minPushes += freqs[i];
		}

		for (var i = 8; i < freqs.Length; i++) {
			int chFreq = freqs[i];
			if (chFreq == 0) {
				break;
			}

			int mapIndex = CheapestMap(lettersMap, chFreq);
			lettersMap[mapIndex]++;
			minPushes += chFreq * lettersMap[mapIndex];
		}

		return minPushes;
	}

	private static int CheapestMap(int[] lettersMap, int freq) {
		var cheapestMapIndex = 0;
		var minPrice = (lettersMap[0] + 1) * freq;

		for (var i = 1; i < 8; i++) {
			var price = (lettersMap[i] + 1) * freq;
			if (price < minPrice) {
				cheapestMapIndex = i;
				minPrice = price;
			}
		}

		return cheapestMapIndex;
	}
}
