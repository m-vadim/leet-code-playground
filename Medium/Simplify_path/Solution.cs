using System.Text;

namespace LeetCode;

// https://leetcode.com/problems/simplify-path/
public class Solution {
	public string SimplifyPath(string path) {
		var dirs = new Stack<string>();
		string[] poi = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

		foreach (string segment in poi) {
			if (segment is "." or "..") {
				if (segment.Length > 1 && dirs.Count > 0) {
					dirs.Pop();
				}
			}
			else {
				dirs.Push(segment);
			}
		}

		if (dirs.Count == 0) {
			return "/";
		}

		var sb = new StringBuilder();
		foreach (string segment in dirs) {
			sb.Insert(0, $"/{segment}");
		}

		return sb.ToString();
	}
}