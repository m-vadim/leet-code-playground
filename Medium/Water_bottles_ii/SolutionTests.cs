using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	[TestCase(13, 6, ExpectedResult = 15)]
	[TestCase(10, 3, ExpectedResult = 13)]
	public static int RunsCases(int numBottles, int numExchange) {
		return new Solution().MaxBottlesDrunk(numBottles, numExchange);
	}
}
