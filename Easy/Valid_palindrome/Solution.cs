namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/valid-palindrome
/// </summary>
public class Solution {
    public bool IsPalindrome(string s) {
        int left = 0, right = s.Length - 1;

        while(left < right) {
            char lch = s[left];
            char rch = s[right];
            if (!char.IsLetterOrDigit(lch)) {
                left++;
            } else if (!char.IsLetterOrDigit(rch)) {
                right--;
            }
            else {
                if (char.ToLower(lch) != char.ToLower(rch)) {
                    return false;
                }
                
                left++;
                right--;
            }
        }

        return true;
    }
}