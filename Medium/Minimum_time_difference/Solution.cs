/// <summary>
/// https://leetcode.com/problems/minimum-time-difference/
/// </summary>
public class Solution {
	public int FindMinDifference(IList<string> timePoints) {
		const int midNight = 24 * 60;

		var minutesArray = timePoints
			.Select(ToMinutes)
			.OrderBy(min => min)
			.ToArray();

		var min = int.MaxValue;
		for (var i = 1; i < minutesArray.Length; i++) {
			min = Math.Min(min, minutesArray[i] - minutesArray[i - 1]);
		}

		min = Math.Min(min, (midNight - minutesArray[^1]) + minutesArray[0]);

		return min;
	}

	private static int ToMinutes(string time) {
		return int.Parse(time[..2]) * 60 + int.Parse(time[3..]);
	}
}
