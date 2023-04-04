namespace LeetCode;

// https://leetcode.com/problems/optimal-partition-of-string/
public class Solution {
    public int PartitionString(string str) {
        var s = new HashSet<char>();
        int count = 1;

        foreach(char c in str) {
            if (!s.Add(c)) {
                count+=1;
                s.Clear();
                s.Add(c);
            }
        }

        return count;
    }
}