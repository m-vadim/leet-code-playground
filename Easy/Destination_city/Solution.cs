/// <summary>
/// https://leetcode.com/problems/destination-city/description
/// </summary>
public class Solution {
	public string DestCity(IList<IList<string>> paths) {
		var candidates = new Dictionary<string, bool>(paths.Count);
		foreach (IList<string> path in paths) {
			string from = path[0];
			string to = path[1];

			if (candidates.TryGetValue(from, out bool isViable)) {
				if (isViable) {
					candidates[from] = false;
				}
			}
			else {
				candidates.Add(from, false);
			}
			
			if (!candidates.TryGetValue(to, out isViable)) {
				candidates.Add(to, true);
			}
		}

		foreach (KeyValuePair<string,bool> pair in candidates) {
			if (pair.Value) {
				return pair.Key;
			}
		}

		return string.Empty;
	}
}