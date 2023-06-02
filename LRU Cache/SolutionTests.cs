using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new LRUCache(2)).SetName("Linked list based cache");
		yield return new TestCaseData(new LRUCacheCustomLinkedList(2)).SetName("OrderedDictionary based cache");
	}

	[TestCaseSource(nameof(Cases))]
	public static void RunsLRUCache(ILRUCache lruCache) {
		lruCache.Put(1, 1);
		lruCache.Put(2, 2);

		lruCache.AssertGet(1, expected: 1);

		lruCache.Put(3, 3);

		lruCache.AssertGet(2, expected: -1);

		lruCache.Put(4, 4);

		lruCache.AssertGet(1, expected: -1);
		lruCache.AssertGet(3, expected: 3);
		lruCache.AssertGet(4, expected: 4);
	}

	[TestCaseSource(nameof(Cases))]
	public static void RunsLRUCache2(ILRUCache lruCache) {
		lruCache.Put(2, 1);
		lruCache.Put(2, 2);

		lruCache.AssertGet(2, expected: 2);

		lruCache.Put(1, 1);
		lruCache.Put(4, 1);

		lruCache.AssertGet(2, expected: -1);
	}
}

internal static class AssertHelper {
	internal static void AssertGet(this ILRUCache cache, int key, int expected) {
		int val = cache.Get(key);
		Assert.AreEqual(expected, val);
	}
}