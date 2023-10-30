namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/implement-trie-prefix-tree/
/// </summary>
public class Trie {
	private readonly TrieNode _root = new();

	public void Insert(string word) {
		var index = 0;
		TrieNode parent = _root;
		while (index < word.Length) {
			parent = GetOrCreateChildNode(parent, word[index]);
			index++;
		}

		parent.IsWord = true;
	}

	public bool Search(string word) {
		var index = 0;
		TrieNode node = _root;
		while (node != null && index < word.Length) {
			node = node.GetNode(word[index]);
			index++;
		}

		return node is { IsWord: true };
	}

	public bool StartsWith(string prefix) {
		var index = 0;
		TrieNode node = _root;
		while (node != null && index < prefix.Length) {
			node = node.GetNode(prefix[index]);
			index++;
		}

		return node != null;
	}

	private static TrieNode GetOrCreateChildNode(TrieNode node, char key) {
		TrieNode childNode = node.GetNode(key);
		if (childNode == null) {
			childNode = new TrieNode();
			node.AddNode(key, childNode);
		}

		return childNode;
	}
}

internal sealed class TrieNode {
	private readonly TrieNode[] _nodes = new TrieNode[26];
	public bool IsWord { get; set; }

	public TrieNode GetNode(char key) {
		return _nodes[key - 97];
	}

	public void AddNode(char key, TrieNode node) {
		_nodes[key - 97] = node;
	}
}