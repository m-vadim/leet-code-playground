namespace LeetCode;

public sealed class KnuthMorrisPratt {
    public static int SearchFirst(string text, string pattern) {
        int textLen = text.Length;
        int patternLen = pattern.Length;

        int textIndex = 0, patternIndex = 0;
        int[] prefixes = BuildPrefix(pattern);
        
        while ((textLen - textIndex) >= (patternLen - patternIndex)) {
            if (pattern[patternIndex] == text[textIndex]) {
                patternIndex++;
                textIndex++;
            }
            if (patternIndex == patternLen) {
                return textIndex - patternIndex;
            }

            if (textIndex < textLen && pattern[patternIndex] != text[textIndex]) {
                if (patternIndex != 0)
                    patternIndex = prefixes[patternIndex - 1];
                else
                    textIndex += 1;
            }
        }

        return -1;
    }
    
    public static IEnumerable<int> Search(string text, string pattern) {
        int textLen = text.Length;
        int patternLen = pattern.Length;

        int textIndex = 0, patternIndex = 0;
        int[] prefixes = BuildPrefix(pattern);
        
        while ((textLen - textIndex) >= (patternLen - patternIndex)) {
            if (pattern[patternIndex] == text[textIndex]) {
                patternIndex++;
                textIndex++;
            }
            if (patternIndex == patternLen) {
                yield return textIndex - patternIndex;
                patternIndex = prefixes[patternIndex - 1];
            }

            else if (textIndex < textLen && pattern[patternIndex] != text[textIndex]) {
                if (patternIndex != 0)
                    patternIndex = prefixes[patternIndex - 1];
                else
                    textIndex += 1;
            }
        }
    }

    public static int[] BuildPrefix(string s) {
        int[] prefix = new int[s.Length];

        for (int i = 1; i < s.Length; i++) {
            int j = prefix[i - 1];
            while (j > 0 && s[j] != s[i]) {
                j = prefix[j - 1];
            }

            if (s[j] == s[i]) {
                j++;
            }

            prefix[i] = j;
        }

        return prefix;
    }
}