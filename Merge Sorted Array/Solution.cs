namespace LeetCode;

// https://leetcode.com/problems/merge-sorted-array/
public class Solution {
    public void Merge(int[] nums1, int nums1Len, int[] nums2, int nums2Len) {
        if (nums2Len == 0) {
            return;
        }

        if (nums1Len == 0) {
            Array.Copy(nums2, nums1, nums2Len);
            return;
        }

        int n1Index = nums1Len - 1, n2Index = nums2Len - 1, mergedIndex = nums1.Length - 1;
        while (mergedIndex >= 0) {
            if (n1Index >= 0 && n2Index >= 0) {
                if (nums2[n2Index] > nums1[n1Index]) {
                    nums1[mergedIndex] = nums2[n2Index];
                    n2Index--;
                }
                else {
                    nums1[mergedIndex] = nums1[n1Index];
                    nums1[n1Index] = int.MaxValue;
                    n1Index--;
                }

                mergedIndex--;
                continue;
            }

            if (n1Index >= 0) {
                nums1[mergedIndex] = nums1[n1Index];
                n1Index--;
            }
            else {
                nums1[mergedIndex] = nums2[n2Index];
                n2Index--;
            }

            mergedIndex--;
        }
    }

    public void MergeNaive(int[] nums1, int nums1Len, int[] nums2, int nums2Len) {
        if (nums2Len == 0) {
            return;
        }

        if (nums1Len == 0) {
            Array.Copy(nums2, nums1, nums2Len);
            return;
        }

        Array.Copy(nums2, 0, nums1, nums1Len, nums2Len);
        Array.Sort(nums1);
    }
}