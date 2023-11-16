namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/search-suggestions-system
/// </summary>
public sealed class Solution {
	private const ushort MaxSuggestionsLimit = 3;

	public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
		TrieNode trie = BuildTrie(products);
		int limit = Math.Min(products.Length, MaxSuggestionsLimit);

		var suggestionsPerInput = new List<IList<string>>(searchWord.Length);
		ReadOnlySpan<char> searchWordSpan = searchWord.AsSpan();
		for (ushort i = 0; i < searchWord.Length; i++) {
			suggestionsPerInput.Add(GetSuggestions(products, trie, searchWordSpan[..(i + 1)], limit));
		}

		return suggestionsPerInput;
	}

	private static void FindWords(IReadOnlyList<string> products, List<string> results, TrieNode trie) {
		if (trie.IsWord) {
			results.Add(products[trie.WordIndex.Value]);
		}

		foreach (TrieNode node in trie.GetNodes()) {
			if (results.Count == results.Capacity) {
				break;
			}

			FindWords(products, results, node);
		}
	}

	private static List<string> GetSuggestions(string[] products, TrieNode trie, ReadOnlySpan<char> search,
		int wordsLimit) {
		var results = new List<string>(wordsLimit);

		TrieNode current = trie;
		foreach (char c in search) {
			current = current.GetNode(c);
			if (current == null) {
				return results;
			}
		}

		FindWords(products, results, current);
		return results;
	}

	private static TrieNode BuildTrie(string[] products) {
		var root = new TrieNode();
		for (var index = 0; index < products.Length; index++) {
			string product = products[index];
			TrieNode parent = root;
			var charIndex = 0;
			while (charIndex < product.Length) {
				char ch = product[charIndex];
				TrieNode node = parent.GetNode(ch);
				if (node == null) {
					node = new TrieNode();
					parent.AddNode(ch, node);
				}

				parent = node;
				charIndex++;
			}

			parent.MarkAsWord(index);
		}

		return root;
	}
}

internal sealed class TrieNode {
	private readonly TrieNode[] _nodes =  new TrieNode[26];

	public bool IsWord => WordIndex.HasValue;

	public int? WordIndex { get; private set; }

	public void MarkAsWord(int wordIndex) {
		WordIndex = wordIndex;
	}

	public IEnumerable<TrieNode> GetNodes() {
		foreach (TrieNode node in _nodes) {
			if (node != null) {
				yield return node;
			}
		}
	} 
	
	public TrieNode GetNode(char key) {
		return _nodes[key - 97];
	}

	public void AddNode(char key, TrieNode node) {
		_nodes[key - 97] = node;
	}
}