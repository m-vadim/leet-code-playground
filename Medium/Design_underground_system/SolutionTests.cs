using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private const double Tolerance = 0.001d;

	[Test]
	public static void RunsUndergroundSystem() {
		var undergroundSystem = new UndergroundSystem();

		undergroundSystem.CheckIn(45, "Leyton", 3);
		undergroundSystem.CheckIn(32, "Paradise", 8);
		undergroundSystem.CheckIn(27, "Leyton", 10);
		undergroundSystem.CheckOut(45, "Waterloo", 15);
		undergroundSystem.CheckOut(27, "Waterloo", 20);
		undergroundSystem.CheckOut(32, "Cambridge", 22);

		AssertDouble(undergroundSystem.GetAverageTime("Paradise", "Cambridge"), 14d);
		AssertDouble(undergroundSystem.GetAverageTime("Leyton", "Waterloo"), 11d);

		undergroundSystem.CheckIn(10, "Leyton", 24);
		AssertDouble(undergroundSystem.GetAverageTime("Leyton", "Waterloo"), 11d);

		undergroundSystem.CheckOut(10, "Waterloo", 38);
		AssertDouble(undergroundSystem.GetAverageTime("Leyton", "Waterloo"), 12d);
	}

	private static void AssertDouble(double actual, double expected) {
		Assert.That(actual, Is.InRange(expected - Tolerance, expected + Tolerance));
	}
}