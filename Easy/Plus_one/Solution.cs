// https://leetcode.com/problems/plus-one/

public class Solution {
    public int[] PlusOne(int[] digits) {
        int index = digits.Length - 1;
        while (index >= 0) {
            if (digits[index] == 9) {
                digits[index] = 0;
                index--;
                continue;
            }

            digits[index] += 1;
            break;
        }

        if (index >= 0) {
            return digits;
        }

        var result = new int[digits.Length + 1];
        result[0] = 1;
        return result;
    }
}