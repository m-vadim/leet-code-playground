namespace LeetCode;

// https://leetcode.com/problems/longest-common-prefix/
public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        ReadOnlySpan<char> prefix = strs[0].AsSpan();

        foreach (string str in strs[1..]) {
            ReadOnlySpan<char> strSpan = str.AsSpan();
            if (strSpan.Length >= prefix.Length) {
                prefix = FindPrefix(prefix, strSpan);
            }
            else {
                prefix = FindPrefix(strSpan, prefix);
            }

            if (prefix == ReadOnlySpan<char>.Empty) {
                break;
            }
        }

        return prefix.ToString();
    }

    private ReadOnlySpan<char> FindPrefix(ReadOnlySpan<char> prefix, ReadOnlySpan<char> str) {
        if (str.Length < prefix.Length) {
            if (prefix.StartsWith(str)) {
                return str;
            }

            return ReadOnlySpan<char>.Empty;
        }

        if (str.StartsWith(prefix)) {
            return prefix;
        }

        // str > prefix
        int diffIndex = 0;
        while (prefix[diffIndex] == str[diffIndex]) {
            diffIndex++;
        }

        if (diffIndex == 0) {
            return ReadOnlySpan<char>.Empty;
        }

        return prefix[..diffIndex];
    }
}