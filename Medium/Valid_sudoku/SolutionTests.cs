using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(BoardBuilder.StartBoard()
			.AddRow("53..7....")
			.AddRow("6..195...")
			.AddRow(".98....6.")
			.AddRow("8...6...3")
			.AddRow("4..8.3..1")
			.AddRow("7...2...6")
			.AddRow(".6....28.")
			.AddRow("...419..5")
			.AddRow("....8..79")).Returns(true);

		yield return new TestCaseData(BoardBuilder.StartBoard()
			.AddRow("83..7....")
			.AddRow("6..195...")
			.AddRow(".98....6.")
			.AddRow("8...6...3")
			.AddRow("4..8.3..1")
			.AddRow("7...2...6")
			.AddRow(".6....28.")
			.AddRow("...419..5")
			.AddRow("....8..79")).Returns(false);

		yield return new TestCaseData(BoardBuilder.StartBoard()
			.AddRow("....5..1.")
			.AddRow(".4.3.....")
			.AddRow(".....3..1")
			.AddRow("8......2.")
			.AddRow("..2.7....")
			.AddRow(".15......")
			.AddRow(".....2...")
			.AddRow(".2.9.....")
			.AddRow("..4......")).Returns(false);

		yield return new TestCaseData(BoardBuilder.StartBoard()
			.AddRow(".4.......")
			.AddRow("..4......")
			.AddRow("...1..7..")
			.AddRow(".........")
			.AddRow("...3...6.")
			.AddRow(".....6.9.")
			.AddRow("....1....")
			.AddRow("......2..")
			.AddRow("...8.....")).Returns(false);
	}

	[TestCaseSource(nameof(Cases))]
	public static bool ReturnsTrueIfSudokuIsValid(IReadyBoard readyBoard) {
		return new Solution().IsValidSudoku(readyBoard.Build());
	}
}