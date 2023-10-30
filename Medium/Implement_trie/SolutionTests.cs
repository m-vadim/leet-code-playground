using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	[Test]
	public static void RunsTrieTests() {
		var trie = new Trie();
		trie.Insert("apple");
		Assert.That(trie.Search("apple"), Is.True);
		Assert.That(trie.Search("app"), Is.False);
		Assert.That(trie.StartsWith("app"), Is.True);
		trie.Insert("app");
		Assert.That(trie.Search("app"), Is.True);
	}
}