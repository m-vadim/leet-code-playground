// https://leetcode.com/problems/zigzag-conversion/

using System.Text;

public class Solution {
	public string Convert(string s, int numRows) {
		if (numRows == 1 || s.Length <= numRows) {
			return s;
		}
		
		ReadOnlySpan<char> span = s.AsSpan();
		var groups = new List<IGroup>();
		var index = 0;
		int zagGroupLength = numRows - 2;
		bool isZigGroup = true;
		
		while (index < s.Length) {
			if (isZigGroup) {
				if (index + numRows >= s.Length) {
					groups.Add(new ZigGroup(span[index..]));
				}
				else {
					groups.Add(new ZigGroup(span.Slice(index, numRows)));
				}

				isZigGroup = !isZigGroup;
				index += numRows;
				continue;
			}

			if (index + zagGroupLength >= s.Length) {
				groups.Add(new ZagGroup(span[index..], zagGroupLength));
			}
			else {
				groups.Add(new ZagGroup(span.Slice(index, zagGroupLength), zagGroupLength));
			}

			isZigGroup = !isZigGroup;
			index += zagGroupLength;
		}

		var sb = new StringBuilder();
		for (int i = 0; i < numRows; i++) {
			foreach (IGroup gr in groups) {
				char? ch = null;
				if (gr is ZigGroup) {
					ch = gr.Next();
				}
				else if (i > 0 && i < numRows - 1) {
					ch = gr.Next();
				}

				if (ch.HasValue) {
					sb.Append(ch.Value);
				}
			}
		}

		return sb.ToString();
	}
}

internal interface IGroup {
	public char? Next();
}

internal sealed class ZigGroup : IGroup {
	private readonly Queue<char> _queue;

	public ZigGroup(ReadOnlySpan<char> slice) {
		_queue = new Queue<char>(slice.Length);
		foreach (char ch in slice) {
			_queue.Enqueue(ch);
		}
	}
	
	public char? Next() {
		if (_queue.Count > 0) {
			return _queue.Dequeue();
		}

		return null;
	}
}

internal sealed class ZagGroup : IGroup {
	private readonly Stack<char> _stack;
	private int _skips;
	public ZagGroup(ReadOnlySpan<char> slice, int count) {
		if (slice.Length < count) {
			_skips = count - slice.Length;
		}
		
		_stack = new Stack<char>(slice.Length);
		foreach (char ch in slice) {
			_stack.Push(ch);
		}
	}

	public char? Next() {
		if (_skips > 0) {
			_skips--;
			return null;
		}
		
		if (_stack.Count > 0) {
			return _stack.Pop();
		}

		return null;
	}
}
