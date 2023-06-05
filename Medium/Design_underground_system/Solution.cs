namespace LeetCode;

// https://leetcode.com/problems/design-underground-system/
public class UndergroundSystem {
	private readonly Dictionary<int, CheckIn> _checkIns = new();
	private readonly Dictionary<string, RouteHistory> _routeHistory = new();

	public void CheckIn(int id, string stationName, int t) {
		_checkIns.Add(id, new CheckIn(stationName, t));
	}

	public void CheckOut(int id, string stationName, int t) {
		CheckIn entry = _checkIns[id];
		int timeTaken = t - entry.Time;
		_checkIns.Remove(id);

		string routeKey = RouteKey(entry.StationName, stationName);
		if (_routeHistory.TryGetValue(routeKey, out RouteHistory routeHistory)) {
			routeHistory.Add(timeTaken);
		}
		else {
			routeHistory = new RouteHistory(timeTaken);
			_routeHistory.Add(routeKey, routeHistory);
		}
	}

	public double GetAverageTime(string startStation, string endStation) {
		string routeKey = RouteKey(startStation, endStation);
		if (_routeHistory.TryGetValue(routeKey, out RouteHistory routeHistory)) {
			return routeHistory.GetAverage();
		}

		return 0d;
	}

	private static string RouteKey(string startStation, string endStation) {
		return $"{startStation}+{endStation}";
	}
}

internal record CheckIn(string StationName, int Time);

internal sealed class RouteHistory {
	public RouteHistory(int time) {
		TotalTimeTaken = time;
		Count = 1;
	}

	public int TotalTimeTaken { get; private set; }
	public int Count { get; private set; }

	public void Add(int time) {
		TotalTimeTaken += time;
		Count++;
	}

	public double GetAverage() {
		return (double) TotalTimeTaken / Count;
	}
}