using System.Collections;

/// <summary>
/// https://leetcode.com/problems/check-if-two-string-arrays-are-equivalent
/// </summary>
public class Solution {
	public bool ArrayStringsAreEqual(string[] words1, string[] words2) {
		using IEnumerator<char> words2Enumerator = new WordsIterator(words2).GetEnumerator();

		foreach (char ch in new WordsIterator(words1)) {
			if (!words2Enumerator.MoveNext() || words2Enumerator.Current != ch) {
				return false;
			}
		}

		return !words2Enumerator.MoveNext();
	}
}

internal sealed class WordsIterator : IEnumerable<char> {
	private readonly string[] _words;

	public WordsIterator(string[] words) {
		_words = words;
	}

	public IEnumerator<char> GetEnumerator() {
		foreach (string word in _words) {
			foreach (char ch in word) {
				yield return ch;
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator() {
		throw new NotImplementedException();
	}
}