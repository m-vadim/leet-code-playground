// https://leetcode.com/problems/sqrtx/description/
public class Solution {
    public int MySqrt(int x) {
        if (x < 2) {
            return x;
        }

        if (x is >= 2 and < 4) {
            return 1;
        }
        
        const int intMaxSqrt = 46340; // sqrt of int.MaxValue
        int low = 1, high = x / 2, num = high;
        if (num >= intMaxSqrt) {
            high = intMaxSqrt;
            num = high;
        }

        int pow;
        while (num > low && num <= high) {
            pow = num * num;
            if (pow == x) {
                break;
            }

            if (pow > x) {
                high = num;
            }
            else {
                low = num;
            }

            num = (high + low) / 2;
        }

        return num;
    }
}