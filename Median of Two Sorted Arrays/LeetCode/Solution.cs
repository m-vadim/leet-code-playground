namespace LeetCode;

// https://leetcode.com/problems/median-of-two-sorted-arrays/
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int nums1Index = 0;
        int nums2Index = 0;
        int hsIndex = 0;

        var hs = new int[nums1.Length + nums2.Length];
        while (nums1Index < nums1.Length || nums2Index < nums2.Length) {
            if (nums1Index >= nums1.Length && nums2Index < nums2.Length) {
                AddToResult(nums2[nums2Index]);
                nums2Index++;
            }
            
            if (nums2Index >= nums2.Length && nums1Index < nums1.Length) {
                AddToResult(nums1[nums1Index]);
                nums1Index++;
            }

            if (nums1Index < nums1.Length && nums2Index < nums2.Length) {
                int n1 = nums1[nums1Index];
                int n2 = nums2[nums2Index];

                if (n1 < n2) {
                    AddToResult(n1);
                    
                    nums1Index++;
                } else if (n1 == n2) {
                    AddToResult(n1);
                    AddToResult(n2);
                    
                    nums1Index++;
                    nums2Index++;
                }
                else {
                    AddToResult(n2);
                    nums2Index++;
                }
            }
        }
        
        void AddToResult(int val) {
            hs[hsIndex] = val;
            hsIndex++;
        }
        
        return Median(hs);
    }

    private double Median(int[] nums) {
        if (nums.Length == 0) {
            throw new ArgumentException("Can't be empty", nameof(nums));
        }

        if (nums.Length == 1) {
            return nums[0];
        }

        if (nums.Length % 2 == 1) {
            return nums[((nums.Length + 1) / 2) - 1];
        }

        int half = nums.Length / 2;
        return (nums[half] + nums[half - 1]) / 2d;
    }
}