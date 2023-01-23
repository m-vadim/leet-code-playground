namespace LeetCode;

// https://leetcode.com/problems/median-of-two-sorted-arrays/
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int totalNums = nums1.Length + nums2.Length;

        if (totalNums % 2 == 1) {
            return FindMedianOdd(totalNums, nums1, nums2);
        }

        return FindMedianEven(totalNums, nums1, nums2);
    }

    private IndexValue GetMergedIndex(int[] nums1, int[] nums2, Iterators i) {
        int n1;
        if (i.Num2Index >= nums2.Length && i.Num1Index < nums1.Length) {
            n1 = nums1[i.Num1Index];
            return new IndexValue(i.Num1Index++ + i.Num2Index, n1);
        }

        int n2;
        if (i.Num1Index >= nums1.Length && i.Num2Index < nums2.Length) {
            n2 = nums2[i.Num2Index];
            return new IndexValue(i.Num1Index + i.Num2Index++, n2);
        }

        n1 = nums1[i.Num1Index];
        n2 = nums2[i.Num2Index];

        if (n2 < n1) {
            return new IndexValue(i.Num1Index + i.Num2Index++, n2);
        }

        return new IndexValue(i.Num1Index++ + i.Num2Index, n1);
    }

    private double FindMedianOdd(int totalNums, int[] nums1, int[] nums2) {
        int medianIndex = (totalNums + 1) / 2 - 1;
        var iterators = new Iterators();

        while (iterators.Num1Index < nums1.Length || iterators.Num2Index < nums2.Length) {
            IndexValue mergedIndex = GetMergedIndex(nums1, nums2, iterators);
            if (mergedIndex.MergedIndex == medianIndex) {
                return mergedIndex.Value;
            }
        }

        throw new InvalidOperationException();
    }

    private double FindMedianEven(int totalNums, int[] nums1, int[] nums2) {
        int rightHalfIndex = totalNums / 2;
        int leftHalfIndex = rightHalfIndex - 1;
        int sum = 0;

        var iterators = new Iterators();

        while (iterators.Num1Index < nums1.Length || iterators.Num2Index < nums2.Length) {
            IndexValue mergedIndex = GetMergedIndex(nums1, nums2, iterators);
            if (mergedIndex.MergedIndex == leftHalfIndex) {
                sum += mergedIndex.Value;
                continue;
            }

            if (mergedIndex.MergedIndex == rightHalfIndex) {
                return (sum + mergedIndex.Value) / 2d;
            }
        }

        throw new InvalidOperationException();
    }
    
    private sealed class Iterators {
        public int Num1Index { get; set; }
        public int Num2Index { get; set; }
    }

    private sealed record IndexValue(int MergedIndex, int Value);
}