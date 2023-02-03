namespace LeetCode;

// https://leetcode.com/problems/valid-parentheses/
public class Solution {
    public bool IsValid(string s) {
        if (s.Length % 2 == 1) {
            return false;
        }
        
        var bracketsStack = new Stack<char>();
        foreach (char c in s) {
            bool isOpen = c switch {
                '(' => true,
                '[' => true,
                '{' => true,
                _ => false
            };
            
            if (isOpen) {
                bracketsStack.Push(c);
                continue;
            }

            if (bracketsStack.Count == 0) {
                return false;
            }
            
            // '(' = 40, ')' = 41, '[' = 91, ']' = 93, '{' = 123, '}' = 125
            if (c - bracketsStack.Pop() is not (> 0 and <= 2)) {
                return false;
            }
        }

        return bracketsStack.Count == 0;
    }
}