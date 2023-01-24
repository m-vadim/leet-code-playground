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
        int longest = 0, from = 0, to = sLength;

        for (int i = 0; i < sLength; i++) {
            if (longest >= sLength - 1) {
                break;
            }

            for (int y = sLength - i; y > 0; y--) {
                ReadOnlySpan<char> subSp = sp.Slice(i, y);

                if (longest >= subSp.Length) {
                    break;
                }

                if (IsPalindrome(subSp) && subSp.Length > longest) {
                    longest = subSp.Length;
                    from = i;
                    to = y;
                }
            }
        }

        return sp.Slice(from, to).ToString();
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