using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		var spreadsheet = new Spreadsheet(3);
		Action<Spreadsheet>[] actions = [
			s => Assert.That(s.GetValue("=5+7"), Is.EqualTo(12)),
			s => s.SetCell("A1", 10),
			s => Assert.That(s.GetValue("=A1+6"), Is.EqualTo(16)),
			s => s.SetCell("B2", 15),
			s => Assert.That(s.GetValue("=A1+B2"), Is.EqualTo(25)),
			s => s.ResetCell("A1"),
			s => s.ResetCell("A10"),
			s => Assert.That(s.GetValue("=A1+B2"), Is.EqualTo(15))
		];

		yield return new TestCaseData(spreadsheet, actions);
	}

	[TestCaseSource(nameof(Cases))]
	public static void RunsSpreadsheetActions(Spreadsheet taskManager, Action<Spreadsheet>[] actions) {
		foreach (Action<Spreadsheet> action in actions) {
			action(taskManager);
		}
	}
}
