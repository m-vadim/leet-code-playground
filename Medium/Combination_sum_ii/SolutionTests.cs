using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(
			new[] { 10, 1, 2, 7, 6, 1, 5 }, 8, new int[][] {
				[1, 1, 6],
				[1, 2, 5],
				[1, 7],
				[2, 6]
			});
		yield return new TestCaseData(
			new[] { 2, 5, 2, 1, 2 }, 5, new int[][] {
				[1, 2, 2],
				[5]
			});
		yield return new TestCaseData(
			new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 27, new int[][] { });

		yield return new TestCaseData(
			new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 10, new int[][] { [1, 1, 1, 1, 1, 1, 1, 1, 1, 1] });
	}

	[TestCaseSource(nameof(Cases))]
	public static void ReturnsAllSumCombinations(int[] numbers, int target, int[][] expected) {
		var actual = new Solution().CombinationSum2(numbers, target);
		var actualArray = actual.Select(a => a.ToArray()).ToArray();

		Assert.That(AreSame(actualArray, expected), Is.True);
	}

	private static bool AreSame(int[][] actual, int[][] expected) {
		var sortedActual = actual.Select(subArray => subArray.OrderBy(x => x).ToArray()).OrderBy(subArray => subArray, new IntArrayComparer()).ToArray();
		var sortedExpected = expected.Select(subArray => subArray.OrderBy(x => x).ToArray()).OrderBy(subArray => subArray, new IntArrayComparer()).ToArray();

		return sortedActual.SequenceEqual(sortedExpected, new IntArrayComparer());
	}

	private class IntArrayComparer : IComparer<int[]>, IEqualityComparer<int[]> {
		public int Compare(int[] x, int[] y) {
			return x.SequenceCompare(y);
		}

		public bool Equals(int[] x, int[] y) {
			return x.SequenceEqual(y);
		}

		public int GetHashCode(int[] obj) {
			// Simple hash code for an array of integers
			return obj.Aggregate(17, (current, item) => current * 23 + item.GetHashCode());
		}
	}
}

internal static class EnumerableExtensions {
	// Helper method for comparing arrays lexicographically
	public static int SequenceCompare<T>(this IEnumerable<T> x, IEnumerable<T> y) where T : IComparable<T> {
		using var enumerator1 = x.GetEnumerator();
		using var enumerator2 = y.GetEnumerator();

		while (enumerator1.MoveNext()) {
			if (!enumerator2.MoveNext()) {
				return 1; // y is shorter
			}
			var result = enumerator1.Current.CompareTo(enumerator2.Current);
			if (result != 0) {
				return result;
			}
		}

		return enumerator2.MoveNext() ? -1 : 0; // x is shorter or they are equal
	}
}
