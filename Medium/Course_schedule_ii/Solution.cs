/// <summary>
/// https://leetcode.com/problems/course-schedule-ii
/// </summary>
public class Solution {
	public int[] FindOrder(int numCourses, int[][] prerequisites) {
		var order = new List<int>(numCourses);
		var prerequisitesMap = new Dictionary<int, IList<int>>(prerequisites.Length);

		foreach (var p in prerequisites) {
			if (prerequisitesMap.TryGetValue(p[0], out IList<int> reqs)) {
				reqs.Add(p[1]);
			} else {
				prerequisitesMap.Add(p[0], [p[1]]);
			}
		}

		for (int i = 0; i < numCourses; i++) {
			if (!prerequisitesMap.ContainsKey(i)) {
				order.Add(i);
			}
		}

		while (prerequisitesMap.Count > 0) {
			var nextCourse = GetNextCourseWithoutPrerequisite(prerequisitesMap);
			if (nextCourse == -1) {
				return [];
			}
			order.Add(nextCourse);
			prerequisitesMap.Remove(nextCourse);
		}

		return order.ToArray();
	}

	private static int GetNextCourseWithoutPrerequisite(Dictionary<int, IList<int>> prerequisites) {
		foreach ((var course, IList<int> reqs) in prerequisites) {
			if (reqs.All(r => !prerequisites.ContainsKey(r))) {
				return course;
			}
		}

		return -1;
	}
}
