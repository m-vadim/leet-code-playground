using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	[Test]
	public static void RunMinStackCases() {
		var minStack = new MinStack();
		minStack.Push(-2);
		minStack.Push(0);
		minStack.Push(-3);
		Assert.That(minStack.GetMin(), Is.EqualTo(-3));
		minStack.Pop();
		Assert.That(minStack.Top(), Is.EqualTo(0));
		Assert.That(minStack.GetMin(), Is.EqualTo(-2));
	}
}