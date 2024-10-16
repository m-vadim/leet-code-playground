using System.Text;

/// <summary>
/// https://leetcode.com/problems/longest-happy-string
/// </summary>
public class Solution {
	public string LongestDiverseString(int a, int b, int c) {
		var letters = new LetterSize[] {
			new('a', a),
			new('b', b),
			new('c', c)
		};
		var comparer = new LetterSizeComparer();
		Array.Sort(letters, comparer);

		var prev = new LetterSize('x', 0);
		var sb = new StringBuilder();
		while (true) {
			var let = prev != letters[0] ? letters[0] : letters[1];
			if (let.Size == 0) {
				break;
			}

			var len = prev.Size > let.Size ? 1 : let.Size > 1 ? 2 : 1;
			prev = let;
			let.Size -= len;
			sb.Append(new string(let.Letter, len));
			Array.Sort(letters, comparer);
		}

		return sb.ToString();
	}
}

internal sealed class LetterSize {
	public LetterSize(char letter, int size) {
		Letter = letter;
		Size = size;
	}

	public char Letter { get; }
	public int Size { get; set; }
}

internal sealed class LetterSizeComparer : IComparer<LetterSize> {
	public int Compare(LetterSize x, LetterSize y) {
		if (x.Size == y.Size) {
			return 1;
		}

		return y.Size > x.Size ? 1 : -1;
	}
}
