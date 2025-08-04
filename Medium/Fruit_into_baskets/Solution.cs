/// <summary>
/// https://leetcode.com/problems/fruit-into-baskets/description
/// </summary>
public sealed class Solution {
	public int TotalFruit(int[] fruits) {
		int left = 0, right = 0;
		int max = 0;

		var baskets = new Baskets();
		while (right < fruits.Length) {
			int fruitType = fruits[right];
			if (baskets.CanFruitBeAdded(fruitType)) {
				baskets.AddFruit(fruitType);
				right++;
			} else {
				max = Math.Max(baskets.CurrentMax, max);
				baskets.RemoveFruit(fruits[left]);
				left++;
			}
		}

		return Math.Max(baskets.CurrentMax, max);
	}
}

internal sealed class Baskets {
	private const int BasketsLimit = 2;
	private readonly Dictionary<int, int> _baskets = new(BasketsLimit);
	private int _max = 0;

	public bool CanFruitBeAdded(int fruit) {
		return _baskets.ContainsKey(fruit) || _baskets.Count < BasketsLimit;
	}

	public void AddFruit(int fruit) {
		_max++;
		if (!_baskets.TryAdd(fruit, 1)) {
			_baskets[fruit]++;
		}
	}

	public void RemoveFruit(int fruit) {
		_max--;
		if (_baskets[fruit] == 1) {
			_baskets.Remove(fruit);
		} else {
			_baskets[fruit]--;
		}
	}

	public int CurrentMax => _max;
}
