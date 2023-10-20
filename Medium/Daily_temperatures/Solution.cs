/// <summary>
/// https://leetcode.com/problems/daily-temperatures
/// </summary>
public class Solution {
	public int[] DailyTemperatures(int[] temperatures) {
		var st = new Stack<int>(temperatures.Length);
		var result = new int[temperatures.Length];
		for (int i = temperatures.Length - 1; i >= 0; i--) {
			int temp = temperatures[i];
			if (st.Count == 0) {
				st.Push(i);
				continue;
			}

			while (st.Count > 0 && temperatures[st.Peek()] <= temp) {
				st.Pop();
			}

			if (st.Count > 0) {
				result[i] = st.Peek() - i;
			}
			st.Push(i);
		}

		return result;
	}
}