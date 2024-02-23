/// <summary>
/// https://leetcode.com/problems/cheapest-flights-within-k-stops
/// </summary>
public class Solution {
	public int FindCheapestPrice(int citiesCount, int[][] flights, int src, int dst, int maxCountOfStops) {
		// Bellman-Ford algorithm
		int[] prices = new int[citiesCount];
		Array.Fill(prices, int.MaxValue);
		prices[src] = 0;

		for (int i = 0; i <= maxCountOfStops; i++) {
			int[] tempPrices = (int[])prices.Clone();
			
			foreach (int[] flight in flights) {
				int priceFrom = prices[flight[0]];
				if (priceFrom == int.MaxValue) {
					continue;
				}
				
				int to = flight[1];
				tempPrices[to] = Math.Min(tempPrices[to], priceFrom + flight[2]);
			}

			prices = tempPrices;
		}

		return prices[dst] == int.MaxValue ? -1 : prices[dst];
	}
}