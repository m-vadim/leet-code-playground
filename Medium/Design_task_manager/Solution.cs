/// <summary>
/// https://leetcode.com/problems/design-task-manager/
/// </summary>
public sealed class TaskManager {
	private readonly PriorityQueue<TaskPriority, TaskPriority> _tasksPriority = new(TaskPriorityComparer.Instance);
	private readonly Dictionary<int, TaskData> _taskSource = new();

	public TaskManager(IList<IList<int>> tasks) {
		foreach (IList<int> taskSource in tasks) {
			Add(taskSource[0], taskSource[1], taskSource[2]);
		}
	}

	public void Add(int userId, int taskId, int priority) {
		var tp = new TaskPriority(priority, taskId);
		_tasksPriority.Enqueue(tp, tp);
		_taskSource.Add(taskId, new TaskData(userId, priority));
	}

	public void Edit(int taskId, int newPriority) {
		var tp = new TaskPriority(newPriority, taskId);
		_tasksPriority.Enqueue(tp, tp);
		_taskSource[taskId].Priority = newPriority;
	}

	public void Rmv(int taskId) {
		_taskSource.Remove(taskId);
	}

	public int ExecTop() {
		while (_tasksPriority.Count > 0) {
			TaskPriority tp = _tasksPriority.Dequeue();
			if (_taskSource.TryGetValue(tp.TaskId, out TaskData data) && data.Priority == tp.Rank) {
				_taskSource.Remove(tp.TaskId);
				return data.UserId;
			}
		}

		return -1;
	}

	private sealed class TaskData(int userId, int priority) {
		public int UserId { get; } = userId;
		public int Priority { get; set; } = priority;
	}

	private record struct TaskPriority(int Rank, int TaskId);

	private sealed class TaskPriorityComparer : IComparer<TaskPriority> {
		public int Compare(TaskPriority x, TaskPriority y) {
			int priorityIdComparison = y.Rank.CompareTo(x.Rank);
			return priorityIdComparison != 0 ? priorityIdComparison : y.TaskId.CompareTo(x.TaskId);
		}

		public static readonly TaskPriorityComparer Instance = new();
	}
}
