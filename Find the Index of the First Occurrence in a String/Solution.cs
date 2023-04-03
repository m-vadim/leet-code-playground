namespace LeetCode;

// https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/
public class Solution {
    public int StrStr(string haystack, string needle) {
        if (needle.Length > haystack.Length) {
            return -1;
        }

        return KnuthMorrisPratt.SearchFirst(haystack, needle);
    }
    
    public int StrStrNaive(string haystack, string needle) {
        if (needle.Length > haystack.Length) {
            return -1;
        }

        return Naive(haystack.AsSpan(), needle.AsSpan());
    }

    private static int Naive(ReadOnlySpan<char> haystack, ReadOnlySpan<char> needle) {
        int needleLength = needle.Length;
        for (int i = 0; i < haystack.Length; i++) {
            int left = haystack.Length - i;
            if (left < needleLength) {
                return -1;
            }

            for (int j = 0; j < needleLength; j++) {
                if (haystack[j + i] != needle[j]) {
                    break;
                }

                if (j == needleLength - 1 && haystack[j + i] == needle[j]) {
                    return i;
                }
            }
        }

        return -1;
    }
}