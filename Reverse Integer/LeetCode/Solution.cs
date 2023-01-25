namespace LeetCode;

// https://leetcode.com/problems/reverse-integer/description/
public class Solution {
    public int Reverse(int x) {
        const int rightLimit = (int.MaxValue - 1) / 10;
        const int leftLimit = (int.MinValue + 1) / 10;
        
        int reversed = 0;
        while(x != 0) {
            int digit = x % 10;
            x /= 10;

            if (reversed is > rightLimit or < leftLimit) {
                return 0;
            }
    
            reversed = reversed * 10 + digit;
        }

        return reversed;
    }
    
    public int ReverseDirty(int x) {
        if (x is >= 0 and < 10) {
            return x;
        }

        string reversedXString = ReverseString(x.ToString());

        try {
            return x > 0 ? Convert.ToInt32(reversedXString) : - Convert.ToInt32(reversedXString.TrimEnd('-'));
        }
        catch (OverflowException) {
            return 0;
        }
    }
    
    private string ReverseString(string text) {
        char[] array = text.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }
}