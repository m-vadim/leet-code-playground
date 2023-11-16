/// <summary>
/// https://leetcode.com/problems/find-unique-binary-string/description/
/// </summary>
public class Solution {
	public string FindDifferentBinaryString(string[] nums) {
		int len = nums.Length;
		var max = Convert.ToInt32("1".PadRight(len, '1'), 2);
		var intNums = new HashSet<int>(len);
		foreach (string n in nums) {
			intNums.Add(Convert.ToInt32(n, 2));
		}

		while (true) {
			if (intNums.Contains(max)) {
				max--;
			}
			else {
				break;
			}
		}

		return Convert.ToString(max, 2).PadLeft(len, '0');
	}
}