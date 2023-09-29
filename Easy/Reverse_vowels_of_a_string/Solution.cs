using System.Runtime.CompilerServices;

namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/reverse-vowels-of-a-string
/// </summary>
public class Solution {
    public string ReverseVowels(string s) {
        char[] ch = s.ToCharArray();
        int l = 0, r = ch.Length - 1;
        while (l < r) {
            if (!IsVowel(ch[l])) {
                l++;
                continue;
            }
            
            if (!IsVowel(ch[r])) {
                r--;
                continue;
            }

            (ch[l], ch[r]) = (ch[r], ch[l]);
            l++;
            r--;
        }

        return new string(ch);
    }

    private const string Vowels = "aeiouAEIOU";
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsVowel(char ch) {
        return Vowels.Contains(ch);
    }
}