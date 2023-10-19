namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/backspace-string-compare/
/// </summary>
public class Solution {
    private const char Backspace = '#';
    
    public bool BackspaceCompare(string s, string t) {
        int i1 = s.Length - 1, i2 = t.Length - 1;
        ushort i1Skip = 0, i2Skip = 0;

        while (i1 >= 0 || i2 >= 0) {
            while (i1 >= 0) {
                if (s[i1] == Backspace) {
                    i1Skip++;
                    i1--;
                }
                else {
                    if (i1Skip > 0) {
                        i1--;
                        i1Skip--;
                    }
                    else {
                        break;
                    }
                }
            }
            
            while (i2 >= 0) {
                if (t[i2] == Backspace) {
                    i2Skip++;
                    i2--;
                }
                else {
                    if (i2Skip > 0) {
                        i2--;
                        i2Skip--;
                    }
                    else {
                        break;
                    }
                }
            }

            if (i1 < 0 || i2 < 0) {
                return Math.Sign(i1) == Math.Sign(i2);
            }

            if (s[i1] != t[i2]) {
                return false;
            }
                
            i1--;
            i2--;
        }
        
        return true;
    }
}