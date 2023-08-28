using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	[Test]
	public static void RunsStackTests() {
		var stack = new MyStack();

		stack.Push(1);
		stack.Push(2);
		Assert.That(stack.Top(), Is.EqualTo(2));
		Assert.That(stack.Pop(), Is.EqualTo(2));
		Assert.That(stack.Empty, Is.EqualTo(false));
	}
}