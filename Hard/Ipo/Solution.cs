/// <summary>
///     https://leetcode.com/problems/ipo
/// </summary>
public sealed class Solution {
	public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital) {
		int length = profits.Length, index = 0;
		var capitalProfits = new CapitalProfit[length];
		for (index = 0; index < length; index++) {
			capitalProfits[index] = new CapitalProfit(capital[index], profits[index]);
		}

		Array.Sort(capitalProfits, new SmallerCapitalFirstComparer());
		var profitQueue = new PriorityQueue<int, int>(new HigherProfitFirstComparer());

		index = 0;
		while (k > 0) {
			while (index < length && capitalProfits[index].Capital <= w) {
				CapitalProfit capitalProfit = capitalProfits[index];
				if (capitalProfit.Capital > w) {
					break;
				}

				profitQueue.Enqueue(capitalProfit.Profit, capitalProfit.Profit);
				index++;
			}

			if (profitQueue.Count == 0) {
				break;
			}

			w += profitQueue.Dequeue();
			k--;
		}

		return w;
	}

	private record struct CapitalProfit(int Capital, int Profit);

	private sealed class SmallerCapitalFirstComparer : IComparer<CapitalProfit> {
		public int Compare(CapitalProfit x, CapitalProfit y) {
			if (x.Capital > y.Capital) {
				return 1;
			}
			if (x.Capital < y.Capital) {
				return -1;
			}
			return 0;
		}
	}

	private sealed class HigherProfitFirstComparer : IComparer<int> {
		public int Compare(int x, int y) {
			if (x > y) {
				return -1;
			}
			if (x < y) {
				return 1;
			}
			return 0;
		}
	}
}


