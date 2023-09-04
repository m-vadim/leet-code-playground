using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	[Test]
	public static void ReturnsTrueWhenListNodeHasCycle() {
		var cycleNode = new ListNode(2);
		var head = new ListNode(3) {
			next = cycleNode
		};
		head.next.next = new ListNode(0) {
			next = new ListNode(4) {
				next = cycleNode
			}
		};

		Assert.That(new Solution().HasCycle(head), Is.EqualTo(true));
	}
	
	[Test]
	public static void ReturnsFalseWhenListNodeDoesNotHaveCycle() {
		var head = new ListNode(3) {
			next = new ListNode(2) {
				next = new ListNode(1) {
					next = new ListNode(0)
				}
			}
		};

		Assert.That(new Solution().HasCycle(head), Is.EqualTo(false));
	}
}