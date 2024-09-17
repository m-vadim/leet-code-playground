/// <summary>
/// https://leetcode.com/problems/course-schedule
/// </summary>
public class Solution {
	public bool CanFinish(int numCourses, int[][] prerequisites) {
		var prerequisitesMap = new Dictionary<int, IList<int>>(capacity: prerequisites.Length);

		foreach (int[] p in prerequisites) {
			if (prerequisitesMap.TryGetValue(p[0], out IList<int> reqs)) {
				reqs.Add(p[1]);
			} else {
				prerequisitesMap.Add(p[0], [p[1]]);
			}
		}

		while (prerequisitesMap.Count > 0) {
			int nextCourse = GetNextCourseWithoutPrerequisite(prerequisitesMap);
			if (nextCourse == -1) {
				return false;
			}
			prerequisitesMap.Remove(nextCourse);
		}

		return true;
	}

	private static int GetNextCourseWithoutPrerequisite(Dictionary<int, IList<int>> prerequisites) {
		foreach ((int course, IList<int> reqs) in prerequisites) {
			if (reqs.All(r => !prerequisites.ContainsKey(r))) {
				return course;
			}

		}

		return -1;
	}
}
