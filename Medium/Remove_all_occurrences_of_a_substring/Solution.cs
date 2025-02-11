/// <summary>
///     https://leetcode.com/problems/remove-all-occurrences-of-a-substring
/// </summary>
public class Solution {
	private const char Dummy = '0';

	public string RemoveOccurrences(string s, string part) {
		char[] arr = s.ToCharArray();
		int len = arr.Length, index = 0;
		ReadOnlySpan<char> partSpan = part.AsSpan();

		bool found = false;
		while (index >= 0) {
			index = FindPart(arr, partSpan);
			if (index >= 0) {
				Mark(arr, index, partSpan.Length);
				len -= partSpan.Length;
			}
		}

		if (len == 0) {
			return string.Empty;
		}

		var res = new char[len];
		index = 0;
		foreach (char ch in arr) {
			if (ch != Dummy) {
				res[index++] = ch;
			}
		}

		return new string(res);
	}

	private static void Mark(char[] arr, int startIndex, int count) {
		while (startIndex < arr.Length && count > 0) {
			if (arr[startIndex] != Dummy) {
				arr[startIndex] = Dummy;
				count--;
			}
			startIndex++;
		}
	}

	private static int FindPart(char[] arr, ReadOnlySpan<char> part) {
		int lastPossibleIndex = arr.Length - part.Length;
		for (int index = 0; index <= lastPossibleIndex; index++) {
			if (arr[index] == part[0] && IsMatch(arr, part, index)) {
				return index;
			}
		}

		return -1;
	}

	private static bool IsMatch(char[] arr, ReadOnlySpan<char> part, int startIndex) {
		int partIndex = 0;
		while(partIndex < part.Length && startIndex < arr.Length) {
			if (arr[startIndex] == Dummy) {
				startIndex++;
				continue;
			}

			if (part[partIndex] != arr[startIndex]) {
				return false;
			}

			partIndex++;
			startIndex++;
		}

		return partIndex == part.Length;
	}
}
