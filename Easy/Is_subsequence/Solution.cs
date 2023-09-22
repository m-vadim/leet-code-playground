// https://leetcode.com/problems/is-subsequence/
public class Solution {
    public bool IsSubsequence(string part, string text) {
        int partIndex = 0, textIndex = 0;
        while (textIndex < text.Length && partIndex < part.Length) {
            if (part[partIndex] == text[textIndex]) {
                partIndex++;
            }
            
            textIndex++;
        }
        
        return partIndex == part.Length;
    }
}