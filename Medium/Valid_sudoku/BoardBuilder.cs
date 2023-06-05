namespace LeetCode;

internal class BoardBuilder : IReadyBoard {
	private readonly List<string> _rows = new();

	private BoardBuilder() {
	}

	public static BoardBuilder StartBoard() {
		return new BoardBuilder();
	}

	public BoardBuilder AddRow(string row) {
		if (string.IsNullOrEmpty(row) || row.Length != 9) {
			throw new ArgumentException("Invalid row value");
		}

		if (_rows.Count == 9) {
			throw new InvalidOperationException("Can't add rows any more");
		}

		_rows.Add(row);
		return this;
	}

	public char[][] Build() {
		if (_rows.Count != 9) {
			throw new InvalidOperationException("Invalid row count");
		}

		return _rows.Select(r => r.ToCharArray()).ToArray();
	}
}