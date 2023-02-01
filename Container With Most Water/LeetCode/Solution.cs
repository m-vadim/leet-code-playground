namespace LeetCode;

// https://leetcode.com/problems/container-with-most-water/
public class Solution {
    public int MaxArea(int[] height) {
        int peakIndex = 0, max = 0;

        while (peakIndex < height.Length) {
            int foundMax = FindMax(height.AsSpan(peakIndex + 1), height[peakIndex], max);
            max = Math.Max(foundMax, max);
            peakIndex++;
        }

        return max;
    }

    private static int FindMax(Span<int> span, int peak, int currentMax) {
        int index = span.Length - 1;
        int foundMax = -1;

        while (index >= 0) {
            int rightPeak = span[index];
            int length = index + 1;
            
            int currentPossibleMax = length * peak;
            if (currentPossibleMax < currentMax) {
                break;
            }

            foundMax = Math.Max(foundMax, length * Math.Min(peak, rightPeak));
            index--;
        }

        return foundMax;
    }
}