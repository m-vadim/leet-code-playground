using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class MyQueueTests {
	[Test]
	public static void RunsMyQueueTests() {
		var queue = new MyQueue();
		queue.Push(1); // queue is: [1]
		queue.Push(2); // queue is: [1, 2] (leftmost is front of the queue)

		Assert.That(queue.Peek(), Is.EqualTo(1));
		Assert.That(queue.Pop(), Is.EqualTo(1));
		Assert.That(queue.Empty(), Is.False);
		Assert.That(queue.Pop(), Is.EqualTo(2));
		Assert.That(queue.Empty(), Is.True);
	}
}