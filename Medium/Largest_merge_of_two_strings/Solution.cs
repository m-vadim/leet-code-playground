/// <summary>
/// https://leetcode.com/problems/largest-merge-of-two-strings/
/// </summary>
public class Solution {
	public string LargestMerge(string word1, string word2) {
		var res = new char[word1.Length + word2.Length];
		int index = 0, word1Index = 0, word2Index = 0;

		while (index < res.Length) {
			if (word1Index == word1.Length || word2Index == word2.Length) {
				if (word1Index == word1.Length) {
					Array.Copy(word2.ToCharArray(), word2Index, res, index, res.Length - index);
				}
				else {
					Array.Copy(word1.ToCharArray(), word1Index, res, index, res.Length - index);
				}
				break;
			}

			char w1 = word1[word1Index];
			char w2 = word2[word2Index];
			if (w1 != w2) {
				if (w1 > w2) {
					res[index++] = w1;
					word1Index++;
				}
				else {
					res[index++] = w2;
					word2Index++;
				}

				continue;
			}

			if (!IsFirstBigger(word1.AsSpan().Slice(word1Index), word2.AsSpan().Slice(word2Index))) {
				res[index++] = w1;
				word1Index++;
			}
			else {
				res[index++] = w2;
				word2Index++;
			}
		}

		return new string(res);
	}

	private bool IsFirstBigger(ReadOnlySpan<char> word1, ReadOnlySpan<char> word2) {
		int lim = word1.Length > word2.Length ? word2.Length : word1.Length;
		for (int i = 0; i < lim; i++) {
			if (word1[i] == word2[i]) {
				continue;
			}

			return word1[i] < word2[i];
		}

		return word1.Length < word2.Length;
	}
}