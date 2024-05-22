/// <summary>
/// https://leetcode.com/problems/palindrome-partitioning
/// </summary>
public class Solution {
	public IList<IList<string>> Partition(string s) {
		var result = new List<IList<string>>();

		PartitionByPalindrome(s.AsSpan(), [], result);

		return result;
	}

	private static void PartitionByPalindrome(ReadOnlySpan<char> str, LinkedList<string> current, ICollection<IList<string>> result) {
		for (var len = 1; len <= str.Length; len++) {
			ReadOnlySpan<char> start = str[..len];
			if (!IsPalindrome(start)) {
				continue;
			}

			current.AddLast(start.ToString());
			if (str[len..].Length == 0) {
				result.Add(new List<string>(current));
			} else {
				PartitionByPalindrome(str[len..], current, result);
			}
			current.RemoveLast();
		}
	}

	private static bool IsPalindrome(ReadOnlySpan<char> str) {
		if (str.Length == 1) {
			return true;
		}

		for (var i = 0; i < str.Length / 2; i++) {
			if (str[i] != str[str.Length - i - 1]) {
				return false;
			}
		}

		return true;
	}
}
