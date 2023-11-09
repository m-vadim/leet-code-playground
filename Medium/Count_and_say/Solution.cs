using System.Text;

namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/count-and-say/description/
/// </summary>
public class Solution {
	public string CountAndSay(int n) {
		var sbPrev = new string("1");
		var sb = new StringBuilder(sbPrev);

		int count;
		for (var iteration = 2; iteration <= n; iteration++) {
			count = 1;
			sb.Clear();
			for (var i = 1; i < sbPrev.Length; i++) {
				if (sbPrev[i] == sbPrev[i - 1]) {
					count++;
				}
				else {
					sb.Append($"{count}{sbPrev[i - 1]}");
					count = 1;
				}
			}

			sb.Append($"{count}{sbPrev[^1]}");
			sbPrev = sb.ToString();
		}

		return sb.ToString();
	}
}