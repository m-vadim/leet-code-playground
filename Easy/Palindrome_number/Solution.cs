namespace LeetCode;

// https://leetcode.com/problems/palindrome-number/
public class Solution {
    public bool IsPalindrome(int x) {
        if (x < 0) {
            return false;
        }

        if (x < 10) {
            return true;
        }

        int digitsCount = DigitsCount(x);
        int halfLength = digitsCount / 2;

        var rightHalf = new Stack<int>(halfLength);
        int index = 0;

        int currentNumber = x;
        int startCompareIndex = (digitsCount % 2 == 0)
            ? halfLength
            : halfLength + 1;

        while (currentNumber >= 1) {
            int lastDigit = currentNumber < 10
                ? currentNumber
                : currentNumber % 10;

            if (index < halfLength) {
                rightHalf.Push(lastDigit);
            }

            if (index >= startCompareIndex) {
                var p = rightHalf.Pop();
                if (p != lastDigit) {
                    return false;
                }
            }

            index += 1;
            currentNumber = (currentNumber - lastDigit) / 10;
        }

        return true;
    }

    // https://stackoverflow.com/questions/4483886/how-can-i-get-a-count-of-the-total-number-of-digits-in-a-number
    private static int DigitsCount(int n) =>
        n == 0 ? 1 : (n > 0 ? 1 : 2) + (int) Math.Log10(Math.Abs((double) n));
}