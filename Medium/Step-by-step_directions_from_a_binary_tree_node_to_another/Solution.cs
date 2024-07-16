using LeetCode;

/// <summary>
///     https://leetcode.com/problems/create-binary-tree-from-descriptions/
/// </summary>
public class Solution {
	public string GetDirections(TreeNode root, int startValue, int destValue) {
		var pathToStart = new PathTracking(startValue);
		Dfs(root, pathToStart);

		var pathToDestination = new PathTracking(destValue);
		Dfs(root, pathToDestination);

		while (pathToStart.Path.Count > 0 && pathToDestination.Path.Count > 0 && pathToStart.Path[0] == pathToDestination.Path[0]) {
			pathToStart.RemoveFirst();
			pathToDestination.RemoveFirst();
		}

		char[] result = new char[pathToStart.Path.Count + pathToDestination.Path.Count];
		if (pathToStart.Path.Count > 0) {
			Array.Fill(result, 'U', 0, pathToStart.Path.Count);
		}
		Array.Copy(pathToDestination.Path.ToArray(), 0, result, pathToStart.Path.Count, pathToDestination.Path.Count);

		return new string(result);
	}

	private void Dfs(TreeNode? node, PathTracking track) {
		if (node == null || track.IsComplete) {
			return;
		}

		if (node.val == track.Value) {
			track.CompletePath();
			return;
		}

		track.AddLeft();
		Dfs(node.left, track);
		if (track.IsComplete) {
			return;
		}
		track.RemoveLast();

		track.AddRight();
		Dfs(node.right, track);
		if (track.IsComplete) {
			return;
		}
		track.RemoveLast();
	}
}

internal sealed class PathTracking {
	private readonly List<char> _path = [];
	public PathTracking(int value) {
		Value = value;
	}

	public int Value { get; }
	public IReadOnlyList<char> Path => _path;
	public bool IsComplete { get; private set; }

	public void AddLeft() => _path.Add('L');
	public void AddRight() => _path.Add('R');

	public void RemoveLast() {
		_path.RemoveAt(Path.Count - 1);
	}

	public void RemoveFirst() {
		_path.RemoveAt(0);
	}

	public void CompletePath() {
		IsComplete = true;
	}
}
