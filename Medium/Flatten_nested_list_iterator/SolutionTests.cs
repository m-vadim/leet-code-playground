using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new List<NestedInteger> {
			new(new NestedInteger(1), new NestedInteger(1)),
			new(2),
			new(new NestedInteger(1), new NestedInteger(1))
		}).Returns(new[] { 1, 1, 2, 1, 1 });

		yield return new TestCaseData(new List<NestedInteger> {
			new(Array.Empty<NestedInteger>())
		}).Returns(Array.Empty<int>());
		
		yield return new TestCaseData(new List<NestedInteger> {
			new(new NestedInteger(1)),
			new(Array.Empty<NestedInteger>())
		}).Returns(new[] { 1 });

		yield return new TestCaseData(new List<NestedInteger> {
			new(Array.Empty<NestedInteger>()),
			new(new NestedInteger(1), new NestedInteger(new NestedInteger(2), new NestedInteger(3))),
			new(Array.Empty<NestedInteger>()),
			new(3)
		}).Returns(new[] { 1, 2, 3, 3 });
	}

	[TestCaseSource(nameof(Cases))]
	public static IEnumerable<int> IteratesNestedInteger(List<NestedInteger> nested) {
		return Iterate(nested).ToArray();
	}

	private static IEnumerable<int> Iterate(List<NestedInteger> nested) {
		var iterator = new NestedIterator(nested);
		while (iterator.HasNext()) {
			yield return iterator.Next();
		}
	}
}