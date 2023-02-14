using System.Text;

// https://leetcode.com/problems/add-binary/description/
public class Solution {
    public string AddBinary(string a, string b) {
        const byte zeroCharCode = 48;
        
        var resultString = new StringBuilder();
        var ai = a.Length - 1;
        var bi = b.Length - 1;

        byte surplus = 0;
        while (ai >= 0 || bi >= 0) {
            int first = ai >= 0 ? a[ai] - zeroCharCode : 0;
            int second = bi >= 0 ? b[bi] - zeroCharCode : 0;

            int sum = first + second + surplus;
            if (sum > 1) {
                sum = sum == 2 ? 0 : 1;
                surplus = 1;
            }
            else {
                surplus = 0;
            }

            resultString.Insert(0, sum.ToString());
            ai--;
            bi--;
        }

        if (surplus == 1) {
            resultString.Insert(0, 1);
        }

        return resultString.ToString();
    }
}