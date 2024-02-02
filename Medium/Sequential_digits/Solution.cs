/// <summary>
/// https://leetcode.com/problems/sequential-digits
/// </summary>
public class Solution {
	private static readonly int[] Numbers = [
		12, 23, 34, 45, 56, 67, 78, 89,
		123, 234, 345, 456, 567, 678, 789,
		1234, 2345, 3456, 4567, 5678, 6789,
		12345, 23456, 34567, 45678, 56789,
		123456, 234567, 345678, 456789,
		1234567, 2345678, 3456789,
		12345678, 23456789,
		123456789
	];

	public IList<int> SequentialDigits(int low, int high) {
		int from = 0, to = Numbers.Length - 1;
		while (from < to) {
			if (Numbers[from] >= low && Numbers[to] <= high) {
				break;
			}
		
			if (Numbers[from] < low) {
				from++;
			}
			
			if (Numbers[to] > high) {
				to--;
			}
		}

		if (from == to && Numbers[from] < low || Numbers[from] > high) {
			return Array.Empty<int>();
		}

		return new ArraySegment<int>(Numbers, from, to - from + 1).ToArray();
	}
}