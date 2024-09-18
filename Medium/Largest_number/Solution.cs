using System.Text;

/// <summary>
/// https://leetcode.com/problems/largest-number
/// </summary>
public class Solution {
	private static bool IsZeroString(string s) {
		return s[0] == '0';
	}

	public string LargestNumber(int[] nums) {
		var strNums = nums.Select(n => n.ToString()).ToArray();

		Array.Sort(strNums, new NumsComparer());

		var sb = new StringBuilder();
		var zeroStart = IsZeroString(strNums[0]);
		foreach (var n in strNums) {
			zeroStart = zeroStart && IsZeroString(n);
			if (!zeroStart) {
				sb.Append(n);
			}
		}

		if (sb.Length == 0) {
			return "0";
		}

		return sb.ToString();
	}
}

internal sealed class NumsComparer : IComparer<string> {
	public int Compare(string x, string y) {
		if (x == y) {
			return 0;
		}

		return StringCompare(x, y);
	}

	private static int StringCompare(string x, string y) {
		return Convert.ToInt64(x + y) > Convert.ToInt64(y + x) ? -1 : 1;
	}
}
