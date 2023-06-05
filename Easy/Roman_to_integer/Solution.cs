using System.Runtime.CompilerServices;

namespace LeetCode;

// https://leetcode.com/problems/roman-to-integer/
public class Solution {
    public int RomanToInt(string roman) {
        ushort currentCharNum;
        ushort previousCharNumber = CharToInt(roman[0]);
        ushort number = previousCharNumber;

        for (ushort index = 1; index < roman.Length; index++) {
            currentCharNum = CharToInt(roman[index]);
            if (currentCharNum > previousCharNumber) {
                number = (ushort) (number + currentCharNum - previousCharNumber * 2);
            }
            else {
                number += currentCharNum;
            }

            previousCharNumber = currentCharNum;
        }

        return number;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ushort CharToInt(char roman) {
        return roman switch {
            'I' => 1,
            'V' => 5,
            'X' => 10,
            'L' => 50,
            'C' => 100,
            'D' => 500,
            'M' => 1000,
            _ => throw new InvalidOperationException()
        };
    }
}