namespace LeetCode;

// https://leetcode.com/problems/longest-palindromic-substring/description/
public class Solution {
    public string LongestPalindrome(string s) {
        int sLength = s.Length;
        if (sLength == 1) {
            return s;
        }

        if (sLength == 2) {
            return s[0] == s[1] ? s : s[..1];
        }

        ReadOnlySpan<char> sp = s.AsSpan();
        int longestPossible = sLength;
        while (true) {
            for (int i = 0; i <= sLength - longestPossible; i++) {
                ReadOnlySpan<char> subSp = sp.Slice(i, longestPossible);
                if (IsPalindrome(subSp)) {
                    return subSp.ToString();
                }
            }

            longestPossible -= 1;
        }
    }

    public static bool IsPalindrome(string s) => IsPalindrome(s.AsSpan());

    private static bool IsPalindrome(ReadOnlySpan<char> span) {
        int halfStringSize = span.Length / 2;
        ReadOnlySpan<char> left = span.Slice(0, halfStringSize);
        ReadOnlySpan<char> right = span.Slice(halfStringSize + span.Length % 2);

        for (int index = 0; index < halfStringSize; index++) {
            if (left[index] != right[halfStringSize - 1 - index]) {
                return false;
            }
        }

        return true;
    }
}