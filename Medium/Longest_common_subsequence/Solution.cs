/// <summary>
/// https://leetcode.com/problems/longest-common-subsequence
/// </summary>
public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        int[,] results = InitResultsCache(text1.Length, text2.Length);
        
        return LcsLength(results, text1.AsSpan(), 0, text2.AsSpan(), 0);
    }

    private static int[,] InitResultsCache(int len1, int len2) {
        var results = new int[len1, len2];
        for(var i = 0; i < len1; i++) {
            for(var y = 0; y < len2; y++) {
                results[i, y] = -1;
            }
        }

        return results;
    }

    private static int LcsLength(int[,] results, ReadOnlySpan<char> a, int indexA, ReadOnlySpan<char> b, int indexB) {
        if (indexA == a.Length || indexB == b.Length) {
            return 0;
        }

        if (results[indexA, indexB] < 0) {
            if (a[indexA] == b[indexB]) {
                results[indexA, indexB] = (1 + LcsLength(results, a, indexA + 1, b, indexB + 1));
            }
            else {
                results[indexA, indexB] = Math.Max(LcsLength(results, a, indexA + 1, b, indexB), LcsLength(results, a, indexA, b, indexB + 1));
            }
        }

        return results[indexA, indexB];
    }
}