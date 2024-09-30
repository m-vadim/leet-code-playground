using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(3, new ICustomStackOperation[] {
			new PushOperation(1),
			new PushOperation(2),
			new PopOperation(2),
			new PushOperation(2),
			new PushOperation(3),
			new PushOperation(4),
			new IncrementOperation(5, 100),
			new IncrementOperation(2, 100),
			new PopOperation(103),
			new PopOperation(202),
			new PopOperation(201),
			new PopOperation(-1)
		});
	}

	[TestCaseSource(nameof(Cases))]
	public static void DoCustomStackOperations(int stackSize, ICustomStackOperation[] operations) {
		var stack = new CustomStack(stackSize);
		foreach (var op in operations) {
			op.Do(stack);
		}
	}
}

internal interface ICustomStackOperation {
	void Do(CustomStack stack);
}

internal sealed class PopOperation(int expected) : ICustomStackOperation {
	public void Do(CustomStack stack) {
		Assert.That(stack.Pop(), Is.EqualTo(expected), "Unexpected pop value");
	}
}

internal sealed class IncrementOperation(int count, int val) : ICustomStackOperation {
	public void Do(CustomStack stack) {
		stack.Increment(count, val);
	}
}

internal sealed class PushOperation(int val) : ICustomStackOperation {
	public void Do(CustomStack stack) {
		stack.Push(val);
	}
}
