/// <summary>
/// https://leetcode.com/problems/group-anagrams
/// </summary>
public class Solution {
	public IList<IList<string>> GroupAnagrams(string[] strs) {
		var map = new Dictionary<string, IList<string>>();
		foreach (var s in strs) {
			string hash = GetWordHash(s.ToCharArray());
			if (map.TryGetValue(hash, out IList<string> res)) {
				res.Add(s);
			}
			else {
				map.Add(hash, new List<string> { s });
			}
		}

		return map.Values.ToList();
	}
	
	private static string GetWordHash(char[] sp) {
		Array.Sort(sp);
		return new string(sp);
	}
}