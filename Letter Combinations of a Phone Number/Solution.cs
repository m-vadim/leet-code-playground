// https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
public class Solution {
    private static readonly IReadOnlyDictionary<char, string[]> CharByDigit = new Dictionary<char, string[]> {
        {'2', new[] {"a", "b", "c"}},
        {'3', new[] {"d", "e", "f"}},
        {'4', new[] {"g", "h", "i"}},
        {'5', new[] {"j", "k", "l"}},
        {'6', new[] {"m", "n", "o"}},
        {'7', new[] {"p", "q", "r", "s"}},
        {'8', new[] {"t", "u", "v"}},
        {'9', new[] {"w", "x", "y", "z"}}
    };

    public IList<string> LetterCombinations(string digits) {
        if (string.IsNullOrEmpty(digits)) {
            return Array.Empty<string>();
        }

        ushort digitIndex = 1;
        string[] combinations = CharByDigit[digits[0]];
        while (digitIndex < digits.Length) {
            combinations = Permutate(combinations, CharByDigit[digits[digitIndex]]);
            digitIndex++;
        }

        return combinations;
    }

    private string[] Permutate(string[] source, string[] addons) {
        var res = new string[source.Length * addons.Length];
        for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++) {
            string prefix = source[sourceIndex];
            for (var addonIndex = 0; addonIndex < addons.Length; addonIndex++) {
                res[sourceIndex * addons.Length + addonIndex] = string.Concat(prefix, addons[addonIndex]);
            }
        }

        return res;
    }
}