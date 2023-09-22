// https://leetcode.com/problems/number-of-matching-subsequences/

public class Solution {
	public int NumMatchingSubseq(string text, string[] words) {
		var buckets = new LinkedList<Word>[26];
        
		for (ushort i = 97; i <= 'z'; i++) {
			buckets[i - 97] = new LinkedList<Word>();
		}

		for (ushort wordIndex = 0; wordIndex < words.Length; wordIndex++) {
			buckets[words[wordIndex][0] - 97].AddLast(new Word(wordIndex));
		}
        
		ushort sum = 0;

		foreach (char ch in text) {
			LinkedList<Word> ll = buckets[ch - 97];
			LinkedListNode<Word>? node = ll.First;
            
			while (node != null) {
				LinkedListNode<Word> currentNode = node;
				node = node.Next;
                
				Word w = currentNode.Value;
				w.CharIndex++;

				string word = words[w.WordIndex];
				if (w.CharIndex == word.Length) {
					sum++;
					ll.Remove(currentNode);
				} else {
					char nextChar = word[w.CharIndex];
					if (nextChar != ch) {
						ll.Remove(currentNode);
						buckets[nextChar - 97].AddLast(w);
					}
				}
			}
		}

		return sum;
	}

	private sealed class Word {
		public Word(ushort wordIndex) {
			WordIndex = wordIndex;
		}

		public ushort WordIndex { get; }
		public ushort CharIndex { get; set; } = 0;
	}
}