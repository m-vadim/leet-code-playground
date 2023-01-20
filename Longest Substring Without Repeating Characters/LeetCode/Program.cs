using LeetCode;

namespace AddTwoNumbers;
class Program {
	static void Main(string[] _) {
		AssertCase("abcabcbb", 3);
		AssertCase("bbbbb", 1);
		AssertCase("x", 1);
		AssertCase("xx", 1);
		AssertCase("eu", 2);
		AssertCase("asic", 4);
	}

	private static void AssertCase(string s, int expected) {
		int output = new Solution().LengthOfLongestSubstring(s);
		if (output == expected) {
			Console.WriteLine($"{s} => OK");
		} else {
			Console.WriteLine($"{s} => FAIL. Expected {expected} but was {output}");
		}
	}
}