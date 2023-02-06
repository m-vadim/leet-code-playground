namespace LeetCode;

// https://leetcode.com/problems/valid-parentheses/
public class SolutionDP {
    public bool IsValid(string s) {
        return IsValid(s.AsSpan());
    }

    private bool IsValid(ReadOnlySpan<char> span) {
        while (true) {
            if (span.Length % 2 == 1) {
                return false;
            }

            int firstCompletePartEndIndex = Get(span);
            if (firstCompletePartEndIndex < 0) {
                return false;
            }

            if (span.Length == 2) {
                return true;
            }

            if (span.Length == firstCompletePartEndIndex + 1) {
                span = span.Slice(1, span.Length - 2);
                continue;
            }

            var leftover = span.Slice(firstCompletePartEndIndex + 1);
            span = span.Slice(0, firstCompletePartEndIndex + 1);

            if (leftover.Length == 0 && span.Length == 0) {
                return true;
            }

            return IsValid(span) && IsValid(leftover);
        }
    }

    private static int Get(ReadOnlySpan<char> span) {
        char firstChar = span[0];
        char closingSibling = GetSibling(firstChar);
        if (closingSibling == char.MinValue) {
            return -1;
        }

        int counter = 0, index = 1;
        while (index < span.Length) {
            char c = span[index];
            if (c == firstChar) {
                counter++;
            }
            
            if (c == closingSibling) {
                if (counter == 0) {
                    break;
                }

                counter--;
            }

            index ++;
        }

        if (index == span.Length) {
            return -1;
        }

        return index;
    }

    private static char GetSibling(char c) {
        switch (c) {
            case '(': return ')';
            case '[': return ']';
            case '{': return '}';
            default: return char.MinValue;
        }
    }
}