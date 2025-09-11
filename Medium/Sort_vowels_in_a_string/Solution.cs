/// <summary>
/// https://leetcode.com/problems/sort-vowels-in-a-string
/// </summary>
public class Solution {
    private static readonly HashSet<char> Vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];
	
	public string SortVowels(string s) {
        char[] arr = s.ToCharArray();
		char[] vowels = new char[arr.Length];
		
		int index = 0;
		foreach(char ch in arr) {
			if (Vowels.Contains(ch)) {
				vowels[index++] = ch;
			}
		}
		
		Array.Sort(vowels, 0, index);
		index = 0;
		for(int i = 0; i < arr.Length; i++) {
			if (Vowels.Contains(arr[i])) {
				arr[i] = vowels[index++];
			}
		}
		
		return new string(arr);
    }
}