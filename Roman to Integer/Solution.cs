using System.Runtime.CompilerServices;

namespace LeetCode;

// https://leetcode.com/problems/roman-to-integer/
public class Solution {
    public int RomanToInt(string roman) {
        int number = 0;
        int previousCharNumber = 0;

        foreach (char currentChar in roman) {
            int currentCharNum = CharToInt(currentChar);
            if (currentCharNum <= previousCharNumber) {
                number += currentCharNum;
            }
            else {
                number = number - previousCharNumber * 2 + currentCharNum;
            }

            previousCharNumber = currentCharNum;
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