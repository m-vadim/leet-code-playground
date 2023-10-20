/// <summary>
/// https://leetcode.com/problems/online-stock-span
/// </summary>
public class StockSpanner {
	private readonly Stack<DailyPrice> _pricesStack = new();
	private ushort _dayCounter = 1;

	public int Next(int price) {
		if (_pricesStack.Count == 0) {
			PushDay(price);

			return 1;
		}

		if (_pricesStack.Peek().Price > price) {
			PushDay(price);
			return 1;
		}

		while (_pricesStack.Count > 0 && _pricesStack.Peek().Price <= price) {
			_pricesStack.Pop();
		}

		int result = _pricesStack.Count > 0 ? _dayCounter - _pricesStack.Peek().Day : _dayCounter;
		PushDay(price);

		return result;
	}

	private void PushDay(int price) {
		_pricesStack.Push(new DailyPrice(_dayCounter, price));
		_dayCounter++;
	}
}

internal record struct DailyPrice(ushort Day, int Price);