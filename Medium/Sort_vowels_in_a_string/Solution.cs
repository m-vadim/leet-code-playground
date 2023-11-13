/// <summary>
/// https://leetcode.com/problems/sort-vowels-in-a-string
/// </summary>
public class Solution {
	private static readonly char[] Vowels = { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };
	private const char Stub = '1';

	public string SortVowels(string s) {
		var vowelsCount = new int[10];
		char[] charArray = s.ToCharArray();
		
		for (var i = 0; i < charArray.Length; i++) {
			int index = Array.IndexOf(Vowels, charArray[i]);
			if (index >= 0) {
				vowelsCount[index] += 1;
				charArray[i] = Stub;
			}
		}

		int from = 0;
		
		for (var i = 0; i < charArray.Length; i++) {
			if (charArray[i] == Stub) {
				while (from < vowelsCount.Length) {
					if (vowelsCount[from] == 0) {
						from++;
					}
					else {
						vowelsCount[from] -= 1;
						break;
					}
				}

				charArray[i] = Vowels[from];
			}
		}

		return new string(charArray);
	}
}