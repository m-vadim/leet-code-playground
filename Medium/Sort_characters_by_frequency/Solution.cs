/// <summary>
/// https://leetcode.com/problems/sort-characters-by-frequency
/// </summary>
public class Solution {
	public string FrequencySort(string s) {
		var letters = new LetterCount[62];
		for (int i = 0; i < 62; i++) {
			letters[i] = new LetterCount { Ch = IndexToChar(i) };
		}
		
		foreach(char ch in s) {
			letters[CharToIndex(ch)].Count += 1;
		}

		Array.Sort(letters, new LetterSort());
		
		var sortedString = new char[s.Length];
		int strIndex = 0, letterIndex = letters.Length - 1;
		while (strIndex < s.Length) {
			LetterCount letter = letters[letterIndex];
			for (int y = 0; y < letter.Count; y++) {
				sortedString[strIndex++] = letter.Ch;
			}

			letterIndex--;
		}

		return new string(sortedString);
	}

	private class LetterCount {
		public char Ch { get; init; }
		public int Count { get; set; }
	}

	private class LetterSort : IComparer<LetterCount>
	{
		public int Compare(LetterCount x, LetterCount y)
		{
			if (x.Count == y.Count) {
				return 0;
			}

			if (x.Count < y.Count) {
				return -1;
			}

			return 1;
		}
	}

	private static char IndexToChar(int index) {
		if (index < 10) {
			return (char)(index + 48);
		}
        
		if (index < 36) {
			return (char)(index + 55);
		}
        
		return (char)(index + 61);
	}

	private static int CharToIndex(char ch) {
		if (char.IsDigit(ch)) {
			return ch - 48;
		}
        
		if (char.IsAsciiLetterUpper(ch)) {
			return ch - 55;
		}
        
		return ch - 61; 
	}
}