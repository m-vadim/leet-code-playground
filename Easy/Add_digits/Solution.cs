namespace LeetCode;

// https://leetcode.com/problems/add-digits/
public class Solution {
    public int AddDigits(int num) {
        if (num < 10) {
            return num;
        }

        int sum = num;
        while (sum > 9) {
            num = sum;
            sum = 0;
            while (num > 9) {
                sum += num % 10;
                num /= 10;
            }

            sum += num;
        }

        return sum;
    }
}