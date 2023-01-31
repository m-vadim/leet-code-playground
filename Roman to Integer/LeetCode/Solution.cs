using System.Runtime.CompilerServices;

namespace LeetCode;

// https://leetcode.com/problems/roman-to-integer/
public class Solution {
    public int RomanToInt(string roman) {
        int romanLength = roman.Length;
        int charIndex = 0;
        int number = 0;
        while (charIndex < romanLength) {
            int currentCharNum = CharToInt(roman[charIndex]);
            int nextCharNum = 0;
            if (charIndex + 1 < romanLength) {
                nextCharNum = CharToInt(roman[charIndex + 1]);
            }

            if (currentCharNum > nextCharNum) {
                number += currentCharNum;
                charIndex += 1;
            }
            else if (currentCharNum == nextCharNum) {
                number += currentCharNum * 2;
                charIndex += 2;
            }
            else {
                number += nextCharNum - currentCharNum;
                charIndex += 2;
            }
        }

        return number;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int CharToInt(char roman) {
        switch (roman) {
            case 'I': {
                return 1;
            }
            case 'V': {
                return 5;
            }
            case 'X': {
                return 10;
            }
            case 'L': {
                return 50;
            }
            case 'C': {
                return 100;
            }
            case 'D': {
                return 500;
            }
            case 'M': {
                return 1000;
            }
        }

        throw new InvalidOperationException();
    }
}