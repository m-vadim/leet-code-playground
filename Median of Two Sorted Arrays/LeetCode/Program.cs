using LeetCode;

namespace AddTwoNumbers;

internal class Program {
    private static void Main(string[] _) {
        AssertCase(new[] {1, 3}, new[] {2}, 2);
        AssertCase(new[] {1, 2}, new[] {3, 4}, 2.5d);
        
        AssertCase(new[] {3}, new[] {-2, -1}, -1d);
        AssertCase(new[] {1, 1}, new[] {1, 2}, 1d);
    }

    private static void AssertCase(int[] nums1, int[] nums2, double expected) {
        var output = new Solution().FindMedianSortedArrays(nums1, nums2);
        var caseName = $"{string.Join(",", nums1)} + {string.Join(",", nums2)}";
        if (Math.Abs(output - expected) < 0.00001)
            Console.WriteLine($"{caseName} => OK");
        else
            Console.WriteLine($"{caseName} => FAIL. Expected {expected} but was {output}");
    }
}