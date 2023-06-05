namespace LeetCode;

// https://leetcode.com/problems/shuffle-the-array/
public class Solution {
    public int[] Shuffle(int[] nums, int n) {
        for (int i = n; i < 2 * n; ++i) {
            int secondNum = nums[i] << 10;
            nums[i - n] |= secondNum;
        }

        const int allOnes = 1023;
        for (int i = n - 1; i >= 0; --i) {
            int secondNum = nums[i] >> 10;
            int firstNum = nums[i] & allOnes;
            nums[2 * i + 1] = secondNum;
            nums[2 * i] = firstNum;
        }

        return nums;
    }

    public int[] ShuffleNaive(int[] nums, int n) {
        int[] result = new int[n * 2];
        for (int index = 0; index < n; index++) {
            result[index * 2] = nums[index];
            result[index * 2 + 1] = nums[n + index];
        }

        return result;
    }
}