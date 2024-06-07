using System.Text;

namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/replace-words
/// </summary>
public class Solution {
	public string ReplaceWords(IList<string> dictionary, string sentence) {
		var trie = new Trie();
		foreach (var word in dictionary) {
			trie.Insert(word);
		}

		ReadOnlySpan<char> sentenseSpan = sentence.AsSpan();
		var sb = new StringBuilder(sentence.Length);
		var spaces = GetIndexesOfSpaces(sentenseSpan);
		int start = 0;
		foreach (int spaceIndex in spaces) {
			ReadOnlySpan<char> newWord = GetWord(sentenseSpan, start, spaceIndex, trie);
			sb.Append(newWord);
			sb.Append(" ");
			start = spaceIndex + 1;
		}

		sb.Append(GetWord(sentenseSpan, start, sentenseSpan.Length, trie));

		return sb.ToString();
	}

	private ReadOnlySpan<char> GetWord(ReadOnlySpan<char> sentence, int start, int spaceIndex, Trie prefixTree) {
		ReadOnlySpan<char> word = sentence.Slice(start, spaceIndex - start);
		for (var len = 1; len <= word.Length; len++) {
			ReadOnlySpan<char> sub = word.Slice(0, len);
			if (prefixTree.Search(sub)) {
				return sub;
			}
		}

		return word;
	}

	private static IList<int> GetIndexesOfSpaces(ReadOnlySpan<char> sentence) {
		var spaces = new List<int>();
		for (int i = 0; i < sentence.Length; i++) {
			if (sentence[i] == ' ') {
				spaces.Add(i);
			}
		}

		return spaces;
	}
}

internal sealed class Trie {
	private readonly TrieNode _root = new();

	public void Insert(string word) {
		var index = 0;
		var parent = _root;
		while (index < word.Length) {
			parent = GetOrCreateChildNode(parent, word[index]);
			index++;
		}

		parent.IsWord = true;
	}

	public bool Search(ReadOnlySpan<char> word) {
		var index = 0;
		var node = _root;
		while (node != null && index < word.Length) {
			node = node.GetNode(word[index]);
			index++;
		}

		return node is { IsWord: true };
	}

	private static TrieNode GetOrCreateChildNode(TrieNode node, char key) {
		var childNode = node.GetNode(key);
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
