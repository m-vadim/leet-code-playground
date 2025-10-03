/// <summary>
/// https://leetcode.com/problems/water-bottles-ii/
/// </summary>
public class Solution {
	public int MaxBottlesDrunk(int numBottles, int numExchange) {
		int result = 0;
		var drunkyard = new Drunkyard(numBottles, numExchange);

		while (true) {
			if(drunkyard.CanDrink) {
				result += drunkyard.Drink();
			} else if (drunkyard.CanExchange) {
				drunkyard.Exchange();
			} else {
				break;
			}
		}

		return result;
	}

	private sealed class Drunkyard {
		private int _empty;
		private int _full;
		private int _exchange;

		public Drunkyard(int full, int exchange)  {
			_full = full;
			_exchange = exchange;
		}

		public int Drink() {
			_empty += _full;

			int tmp = _full;
			_full = 0;
			return tmp;
		}

		public void Exchange() {
			_empty -= _exchange;
			_full++;
			_exchange++;
		}

		public bool CanDrink => _full > 0;
		public bool CanExchange => _empty >= _exchange;
	}
}
