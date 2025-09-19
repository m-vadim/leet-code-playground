using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		var taskManager = new TaskManager([[1, 101, 10], [2, 102, 20], [3, 103, 15]]);
		Action<TaskManager>[] actions = [
			tm => tm.Add(4, 104, 5),
			tm => tm.Edit(102, 8),
			tm => Assert.That(tm.ExecTop(), Is.EqualTo(3)),
			tm => tm.Rmv(101),
			tm => tm.Add(5, 105, 15),
			tm => Assert.That(tm.ExecTop(), Is.EqualTo(5))
		];

		yield return new TestCaseData(taskManager, actions);

		taskManager = new TaskManager([[0, 14, 1]]);
		actions = [
			tm => Assert.That(tm.ExecTop(), Is.EqualTo(0))
		];

		yield return new TestCaseData(taskManager, actions);

		taskManager = new TaskManager([[10, 4, 10], [10, 0, 6], [5, 23, 50], [3, 29, 50], [2, 15, 9]]);
		actions = [
			tm => Assert.That(tm.ExecTop(), Is.EqualTo(3))
		];

		yield return new TestCaseData(taskManager, actions);

		taskManager = new TaskManager([[5, 4, 10], [10, 0, 11]]);
		actions = [
			tm => Assert.That(tm.ExecTop(), Is.EqualTo(10)),
			tm => Assert.That(tm.ExecTop(), Is.EqualTo(5)),
			tm => tm.Add(5, 4, 10)
		];

		yield return new TestCaseData(taskManager, actions);
	}

	[TestCaseSource(nameof(Cases))]
	public static void RunsTaskManagerActions(TaskManager taskManager, Action<TaskManager>[] actions) {
		foreach (Action<TaskManager> action in actions) {
			action(taskManager);
		}
	}
}
