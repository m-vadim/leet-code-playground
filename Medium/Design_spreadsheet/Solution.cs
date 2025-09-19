/// <summary>
/// https://leetcode.com/problems/design-spreadsheet/
/// </summary>
public sealed class Spreadsheet {
	private readonly Dictionary<string, int> _values;

	public Spreadsheet(int rows) {
		_values = new Dictionary<string, int>(rows);
	}

	public void SetCell(string cell, int value) {
		_values[cell] = value;
	}

	public void ResetCell(string cell) {
		_values.Remove(cell);
	}

	public int GetValue(string formula) {
		ReadOnlySpan<char> span = formula.AsSpan();
		int plusIndex = span.IndexOf('+');
		ReadOnlySpan<char> leftAddend = span.Slice(1, plusIndex - 1);
		ReadOnlySpan<char> rightAddend = span.Slice(plusIndex + 1);

		int sum = 0;
		sum += IsCell(leftAddend) ? GetCellValue(leftAddend) : int.Parse(leftAddend);
		sum += IsCell(rightAddend) ? GetCellValue(rightAddend) : int.Parse(rightAddend);

		return sum;
	}

	private static bool IsCell(ReadOnlySpan<char> span) {
		return span[0] > 64 && span[0] < 91;
	}

	private int GetCellValue(ReadOnlySpan<char> span) {
		return _values.GetValueOrDefault(span.ToString(), 0);
	}
}
