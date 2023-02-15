// https://leetcode.com/problems/add-to-array-form-of-integer/

public class Solution {
    public IList<int> AddToArrayForm(int[] num, int k) {
        int i = num.Length - 1;
        ushort surplus = 0;
        var res = new List<int>();
        while (i >= 0 || k >= 1) {
            int lastDigitOfK = k >= 1 ? k % 10 : 0;
            int currentNumDigit = (i >= 0 ? num[i] : 0) + lastDigitOfK + surplus;
            if (currentNumDigit > 9) {
                currentNumDigit -= 10;
                surplus = 1;
            }
            else {
                surplus = 0;
            }

            res.Insert(0, currentNumDigit);
            if (k >= 1) {
                k = (k - lastDigitOfK) / 10;
            }

            if (i >= 0) {
                i--;
            }
        }

        if (surplus != 0) {
            res.Insert(0, 1);
        }

        return res;
    }
}