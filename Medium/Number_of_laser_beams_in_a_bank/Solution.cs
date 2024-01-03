/// <summary>
/// https://leetcode.com/problems/number-of-laser-beams-in-a-bank
/// </summary>
public class Solution {
	public int NumberOfBeams(string[] lasers) {
		var beamsCount = 0;
		var prevRowLasersCount = 0;
		foreach (string laserRow in lasers) {
			int currentRowLasersCount = 0;
			foreach (char cell in laserRow) {
				if (cell == '1') {
					currentRowLasersCount += 1;
					beamsCount += prevRowLasersCount;
				}
			}

			if (currentRowLasersCount != 0) {
				prevRowLasersCount = currentRowLasersCount;;
			}
		}

		return beamsCount;
	}
}