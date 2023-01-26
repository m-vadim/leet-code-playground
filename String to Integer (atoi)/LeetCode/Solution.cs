using System.Runtime.CompilerServices;

namespace LeetCode;

// https://leetcode.com/problems/string-to-integer-atoi/description/
public class Solution {
    private const char Whitespace = ' ';
    
    public int MyAtoi(string s) {
        int number = 0;
        short sign = 1;
        bool startConvert = false;
        
        foreach (char c in s) {
            if (c == Whitespace && !startConvert) {
                continue;
            }

            bool charIsDigit = char.IsDigit(c);
            if (charIsDigit) {
                startConvert = true;
                int nextDigit = CharToInt(c);
                if (number > (int.MaxValue - nextDigit) / 10) {
                    return sign == -1 ? int.MinValue : int.MaxValue;
                }

                number = number * 10 + nextDigit;
            }
            else {
                if (!startConvert && c is '-' or '+') {
                    startConvert = true;
                    if (c == '-') {
                        sign = -1;
                    }

                    continue;
                }

                break;
            }
        }

        return number * sign;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int CharToInt(char c) => (c - '0');
}