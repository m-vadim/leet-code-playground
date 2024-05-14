/// <summary>
/// https://leetcode.com/problems/compare-version-numbers
/// </summary>
public class Solution {
	private const char VersionSeparator = '.';

	public int CompareVersion(string version1, string version2) {
		var ver1Queue = GetVersionQueue(version1.AsSpan());
		var ver2Queue = GetVersionQueue(version2.AsSpan());

		while (ver1Queue.Count > 0 && ver2Queue.Count > 0) {
			if (ver1Queue.Peek() == ver2Queue.Peek()) {
				ver1Queue.Dequeue();
				ver2Queue.Dequeue();
			} else {
				return ver1Queue.Peek() > ver2Queue.Peek() ? 1 : -1;
			}
		}

		while (ver1Queue.Count > 0 && ver1Queue.Peek() == 0) {
			ver1Queue.Dequeue();
		}

		while (ver2Queue.Count > 0 && ver2Queue.Peek() == 0) {
			ver2Queue.Dequeue();
		}

		if (ver1Queue.Count == 0 && ver2Queue.Count == 0) {
			return 0;
		}

		return ver1Queue.Count > ver2Queue.Count ? 1 : -1;
	}

	private static Queue<int> GetVersionQueue(ReadOnlySpan<char> version) {
		int index = 0, start = 0;

		var versionQueue = new Queue<int>();
		while (index < version.Length) {
			if (version[index] == VersionSeparator) {
				versionQueue.Enqueue(int.Parse(version.Slice(start, index - start)));
				start = index + 1;
			}
			index++;
		}

		versionQueue.Enqueue(int.Parse(version[start..]));
		return versionQueue;
	}
}
