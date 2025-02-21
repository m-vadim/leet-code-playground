using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	[Test]
	public static void FindsElementsInContaminatedTree() {
		TreeNode root = BinaryTreeConverter.ToTree([-1, null, -1, -1, null, -1]);

		var f = new FindElements(root);
		Assert.That(f.Find(2), Is.True);
		Assert.That(f.Find(3), Is.False);
		Assert.That(f.Find(4), Is.False);
		Assert.That(f.Find(5), Is.True);
	}
}
