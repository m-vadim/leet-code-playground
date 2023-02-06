using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(new CustomTestCaseData(new[] {1, 1, 2}, new[] {1, 2, 0}, 2));
        yield return new TestCaseData(new CustomTestCaseData(new[] {1, 1, 2, 5, 5, 5}, new[] {1, 2, 5, 0, 0, 0}, 3));
        yield return new TestCaseData(new CustomTestCaseData(new[] {0, 0, 1, 1, 1, 2, 2, 3, 3, 4},
            new[] {0, 1, 2, 3, 4, 0, 0, 0, 0, 0}, 5));
        yield return new TestCaseData(new CustomTestCaseData(
            new[] {
                -50, -49, -48, -46, -46, -44, -44, -44, -44, -43, -43, -43, -42, -42, -41, -40, -39, -39, -38, -38, -37,
                -35, -34, -33, -31, -31, -30, -30, -28, -28, -27, -25, -22, -22, -22, -22, -22, -21, -21, -21, -21, -19,
                -18, -17, -17, -16, -16, -15, -15, -14, -13, -13, -10, -10, -9, -9, -8, -7, -7, -7, -7, -6, -5, -4, -4,
                -4, -4, -3, -3, -2, -2, -2, 0, 0, 1, 2, 2, 2, 3, 3, 4, 5, 5, 5, 7, 8, 8, 8, 10, 10, 14, 15, 16, 16, 18,
                18, 19, 21, 23, 23, 24, 24, 24, 25, 25, 25, 26, 27, 28, 28, 30, 32, 32, 32, 34, 36, 37, 37, 37, 38, 38,
                38, 39, 40, 40, 40, 41, 41, 43, 43, 43, 44, 45, 46, 46, 47, 48, 48, 50, 50, 50
            },
            new[] {
                -50, -49, -48, -46, -44, -43, -42, -41, -40, -39, -38, -37, -35, -34, -33, -31, -30, -28, -27, -25, -22,
                -21, -19, -18, -17, -16, -15, -14, -13, -10, -9, -8, -7, -6, -5, -4, -3, -2, 0, 1, 2, 3, 4, 5, 7, 8, 10,
                14, 15, 16, 18, 19, 21, 23, 24, 25, 26, 27, 28, 30, 32, 34, 36, 37, 38, 39, 40, 41, 43, 44, 45, 46, 47,
                48, 50
            }, 75));
    }


    [TestCaseSource(nameof(Cases))]
    public static void RemovesDuplicates(CustomTestCaseData testCaseData) {
        int k = new Solution().RemoveDuplicates(testCaseData.Nums);
        Assert.AreEqual(testCaseData.FinalCount, k);

        for (int i = 0; i < k; i++) {
            Assert.AreEqual(testCaseData.ExpectedNums[i], testCaseData.Nums[i]);
        }
    }

    public sealed class CustomTestCaseData {
        public CustomTestCaseData(int[] nums, int[] expectedNums, int finalCount) {
            Nums = nums;
            ExpectedNums = expectedNums;
            FinalCount = finalCount;
        }

        public int[] Nums { get; }
        public int[] ExpectedNums { get; }
        public int FinalCount { get; }
    }
}