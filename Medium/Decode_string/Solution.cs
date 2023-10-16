using System.Text;

namespace LeetCode; 

/// <summary>
/// https://leetcode.com/problems/decode-string
/// </summary>
public class Solution {
	private const char OpenBracket = '[';
	private const char CloseBracket = ']';
	
	public string DecodeString(string s) {
		ReadOnlySpan<char> span = s.AsSpan();
		var sb = new StringBuilder();
		var st = new Stack<EncodedPart>();
		
		int index = 0, digitStart = -1;
		
		while (index < s.Length) {
			char ch = s[index];
			if (char.IsDigit(ch)) {
				if (digitStart == -1) {
					digitStart = index;
				}
			} else if (ch == OpenBracket) {
				int times = int.Parse(span.Slice(digitStart, index - digitStart));
				digitStart = -1;
				
				st.Push(new EncodedPart(times));
			} else if (ch == CloseBracket) {
				EncodedPart part = st.Pop();
				if (st.Count == 0) {
					sb.Append(part.GetMultipliedBuilder());
				}
				else {
					st.Peek().Builder.Append(part.GetMultipliedBuilder());
				}
			}
			else {
				if (st.Count > 0) {
					st.Peek().Builder.Append(ch);
				}
				else {
					sb.Append(ch);	
				}
			}

			index++;
		}

		return sb.ToString();
	}
}

internal sealed class EncodedPart {
	private readonly int _times;

	public EncodedPart(int times) {
		_times = times;
		Builder = new StringBuilder();
	}

	public StringBuilder Builder { get; }

	public string GetMultipliedBuilder() {
		return string.Concat(Enumerable.Repeat(Builder.ToString(), _times));
	}
}