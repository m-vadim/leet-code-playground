// https://leetcode.com/problems/3sum/description/
public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        int len = nums.Length;
        Array.Sort(nums);

        var res = new List<IList<int>>();
        ushort index = 0;
        while (index < len) {
            int firstOfTriplet = nums[index];
            if (index != 0 && nums[index - 1] == firstOfTriplet) {
                index++;
                continue;
            }

            int low = index + 1;
            int high = len - 1;
            
            while(low < high) {
                int sum = firstOfTriplet + nums[high] + nums[low];
                if (sum > 0) {
                    do {
                        high--;
                    } while (nums[high] == nums[high + 1] && low < high);

                    continue;
                }
                
                if (sum == 0) {
                    res.Add(new[] { firstOfTriplet, nums[low], nums[high] });
                }
                
                do {
                    low++;
                } while (nums[low] == nums[low - 1] && low < high);
            }
            
            index++;
        }
        

        return res;
    }
}