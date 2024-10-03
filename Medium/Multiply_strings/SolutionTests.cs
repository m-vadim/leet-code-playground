using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("3", "6").SetName("3 * 6").Returns("18");
		yield return new TestCaseData("0", "100").SetName("0 * 100").Returns("0");
		yield return new TestCaseData("42", "7165").SetName("42 * 7165").Returns("300930");
		yield return new TestCaseData("28", "1").SetName("28 * 1").Returns("28");
		yield return new TestCaseData("30", "60").SetName("30 * 60").Returns("1800");
		yield return new TestCaseData("123456789", "987654321").SetName("123456789 * 987654321").Returns("121932631112635269");
		yield return new TestCaseData("42", "10").SetName("42 * 10").Returns("420");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsNumsProduct(string num1, string num2) {
		return new Solution().Multiply(num1, num2);
	}

	private static IEnumerable<TestCaseData> MultiplyCases() {
		yield return new TestCaseData("20", (ushort)4, 0).SetName("20 * 4").Returns("80");
		yield return new TestCaseData("7165", (ushort)2,  0).SetName("7165 * 2").Returns("14330");
		yield return new TestCaseData("7165", (ushort)0, 0).SetName("7165 * 0").Returns("0");
		yield return new TestCaseData("123", (ushort)1, 0).SetName("123 * 1").Returns("123");
		yield return new TestCaseData("15", (ushort)3, 1).SetName("15 * 3 with additional zero").Returns("450");
	}

	[TestCaseSource(nameof(MultiplyCases))]
	public static string ReturnsNumMultiplyDigit(string num, ushort digit, int moreZero) {
		return Solution.MultiplyByDigit(num.AsSpan(), digit, moreZero);
	}

	private static IEnumerable<TestCaseData> SumCases() {
		yield return new TestCaseData("20", "0").SetName("20 + 0").Returns("20");
		yield return new TestCaseData("1", "20").SetName("1 + 20").Returns("21");
		yield return new TestCaseData("0", "0").SetName("0 + 0").Returns("0");
		yield return new TestCaseData("250", "50000").SetName("250 + 50000").Returns("50250");
	}

	[TestCaseSource(nameof(SumCases))]
	public static string ReturnsTwoSum(string num1, string num2) {
		return Solution.TwoSum(num1.AsSpan(), num2.AsSpan());
	}
}
