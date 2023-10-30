namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/design-add-and-search-words-data-structure/
/// </summary>
public class WordDictionary {
	private readonly TrieNode _root = new();
	private const char WildCardPoint = '.';

	public void AddWord(string word) {
		var index = 0;
		TrieNode parent = _root;
		while (index < word.Length) {
			char key = word[index];
			TrieNode node = parent.GetNode(key);
			if (node == null) {
				node = new TrieNode();
				parent.AddNode(key, node);
			}

			parent = node;
			index++;
		}

		parent.IsWord = true;
	}

	public bool Search(string word) {
		ReadOnlySpan<char> wordSpan = word.AsSpan();

		TrieNode? node = Search(_root, wordSpan);
		return node != null;
	}

	private static TrieNode? Search(TrieNode node, ReadOnlySpan<char> chars) {
		char key = chars[0];
		if (chars.Length == 1) {
			if (key == WildCardPoint) {
				foreach (TrieNode wildcardNode in node.Nodes) {
					if (wildcardNode is { IsWord: true }) {
						return wildcardNode;
					}
				}

				return null;
			}

			TrieNode childNode = node.GetNode(chars[0]);
			return childNode is { IsWord: true } ? childNode : null;
		}

		if (key == WildCardPoint) {
			foreach (TrieNode wildcardNode in node.Nodes) {
				if (wildcardNode != null) {
					TrieNode? foundNode = Search(wildcardNode, chars[1..]);
					if (foundNode != null) {
						return foundNode;
					}
				}
			}
		}
		else {
			TrieNode childNode = node.GetNode(chars[0]);
			if (childNode != null) {
				return Search(childNode, chars[1..]);
			}
		}

		return null;
	}
}

internal sealed class TrieNode {
	private readonly TrieNode[] _nodes = new TrieNode[26];
	public bool IsWord { get; set; }
	public TrieNode[] Nodes => _nodes;

	public TrieNode GetNode(char key) {
		return _nodes[key - 97];
	}

	public void AddNode(char key, TrieNode node) {
		_nodes[key - 97] = node;
	}
}