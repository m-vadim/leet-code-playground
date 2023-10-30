using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	[Test]
	public static void RunsWordDictionaryTests() {
		var wordDictionary = new WordDictionary();
		wordDictionary.AddWord("bad");
		wordDictionary.AddWord("dad");
		wordDictionary.AddWord("mad");

		Assert.That(wordDictionary.Search("pad"), Is.False);
		Assert.That(wordDictionary.Search("bad"), Is.True);
		Assert.That(wordDictionary.Search(".ad"), Is.True);
		Assert.That(wordDictionary.Search("b.."), Is.True);
	}
}