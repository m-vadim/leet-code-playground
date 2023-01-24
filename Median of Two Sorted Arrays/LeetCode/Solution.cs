namespace LeetCode;

// https://leetcode.com/problems/median-of-two-sorted-arrays/
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int n1Length = nums1.Length;
        int n2Length = nums2.Length;
        int totalNums = n1Length + n2Length;

        if (totalNums % 2 == 1) {
            return FindMedianOdd(totalNums, nums1, n1Length, nums2, n2Length);
        }

        return FindMedianEven(totalNums, nums1, n1Length, nums2, n2Length);
    }

    private double FindMedianOdd(int totalNums, int[] nums1, int nums1Length, int[] nums2, int nums2Length) {
        int i1 = 0, i2 = 0, mergedIndex = 0;
        int medianIndex = (totalNums + 1) / 2 - 1;

        while (i1 < nums1Length || i2 < nums2Length) {
            if (i1 < nums1Length && i2 < nums2Length) {
                int n1 = nums1[i1];
                int n2 = nums2[i2];
                bool left = n1 < n2;

                if (mergedIndex == medianIndex) {
                    return left ? n1 : n2;
                }

                if (left) {
                    i1++;
                }
                else {
                    i2++;
                }
                mergedIndex++;
                continue;
            }

            // nums2 ended
            if (i2 >= nums2Length) {
                return nums1[i1+(medianIndex - mergedIndex)];
            }

            // nums1 ended
            if (i1 >= nums1Length) {
                return nums2[i2 + (medianIndex - mergedIndex)];
            }
        }

        throw new InvalidOperationException();
    }


    private double FindMedianEven(int totalNums, int[] nums1, int nums1Length, int[] nums2, int nums2Length) {
        int i1 = 0, i2 = 0, mergedIndex = 0;
        int rightHalfIndex = totalNums / 2;
        int leftHalfIndex = rightHalfIndex - 1;
        int? leftPart = null;

        while (i1 < nums1Length || i2 < nums2Length) {
            if (i1 < nums1Length && i2 < nums2Length) {
                int n1 = nums1[i1];
                int n2 = nums2[i2];
                bool left = n1 < n2;

                if (mergedIndex == leftHalfIndex) {
                    leftPart = left ? n1 : n2;
                }
                
                if (mergedIndex == rightHalfIndex) {
                    return (leftPart.Value + (left ? n1 : n2)) / 2d;
                }

                if (left) {
                    i1++;
                }
                else {
                    i2++;
                }
                mergedIndex++;
                continue;
            }

            // nums2 ended
            if (i2 >= nums2Length) {
                if (leftPart.HasValue) {
                    return (leftPart.Value + nums1[i1 + (rightHalfIndex - mergedIndex)]) / 2d;
                }

                return (nums1[i1 + (leftHalfIndex - mergedIndex)] + nums1[i1 + (rightHalfIndex - mergedIndex)]) / 2d;
            }

            // nums1 ended
            if (i1 >= nums1Length) {
                if (leftPart.HasValue) {
                    return (leftPart.Value + nums2[i2 + (rightHalfIndex - mergedIndex)]) / 2d;
                }

                return (nums2[i2 + (leftHalfIndex - mergedIndex)] + nums2[i2 + (rightHalfIndex - mergedIndex)]) / 2d;
            }
        }

        throw new InvalidOperationException();
    }
}