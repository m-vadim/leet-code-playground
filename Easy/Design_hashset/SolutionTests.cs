using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new Queue<HashSetAction>(new HashSetAction[] {
			new(HashSetActionType.Add, 1, false),
			new(HashSetActionType.Add, 2, false),
			new(HashSetActionType.Contains, 1, true),
			new(HashSetActionType.Contains, 3, false),
			new(HashSetActionType.Add, 2, false),
			new(HashSetActionType.Contains, 2, true),
			new(HashSetActionType.Remove, 2, false),
			new(HashSetActionType.Contains, 2, false)
		})).Returns(new[] { 1 });

		yield return new TestCaseData(new Queue<HashSetAction>(new HashSetAction[] {
			new(HashSetActionType.Add, 9, false),
			new(HashSetActionType.Remove, 19, false),
			new(HashSetActionType.Add, 14, false),
			new(HashSetActionType.Remove, 19, false),
			new(HashSetActionType.Remove, 9, false),
			new(HashSetActionType.Add, 0, false),
			new(HashSetActionType.Add, 3, false),
			new(HashSetActionType.Add, 4, false),
			new(HashSetActionType.Add, 0, false),
			new(HashSetActionType.Remove, 9, false)
		})).Returns(new[] { 0, 3, 4, 14 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] OperatesHashset(Queue<HashSetAction> actions) {
		var hs = new MyHashSet();

		while (actions.Count > 0) {
			HashSetAction act = actions.Dequeue();
			switch (act.ActionType) {
				case HashSetActionType.Add: {
					hs.Add(act.Number);
					break;
				}
				case HashSetActionType.Remove: {
					hs.Remove(act.Number);
					break;
				}
				case HashSetActionType.Contains: {
					Assert.AreEqual(act.Expected, hs.Contains(act.Number));
					break;
				}
			}
		}

		return hs.ToArray();
	}
}

internal enum HashSetActionType {
	Add,
	Remove,
	Contains
}

internal record HashSetAction(HashSetActionType ActionType, int Number, bool Expected);