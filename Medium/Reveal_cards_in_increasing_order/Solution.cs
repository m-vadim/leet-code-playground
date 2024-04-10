/// <summary>
/// https://leetcode.com/problems/reveal-cards-in-increasing-order
/// </summary>
public class Solution {
	public int[] DeckRevealedIncreasing(int[] deck) {
		Array.Sort(deck);

		var revealOrder = new LinkedList<int>();
		revealOrder.AddFirst(deck[^1]);

		var index = deck.Length - 2;
		while (index >= 0) {
			var nextBig = deck[index--];

			var last = revealOrder.Last;
			revealOrder.RemoveLast();
			revealOrder.AddFirst(last);
			revealOrder.AddFirst(nextBig);
		}

		index = 0;
		foreach (var node in revealOrder) {
			deck[index++] = node;
		}

		return deck;
	}
}
