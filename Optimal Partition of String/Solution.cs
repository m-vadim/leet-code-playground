namespace LeetCode;

// https://leetcode.com/problems/optimal-partition-of-string/
public class Solution {
    public int PartitionStringArrayMap(string str) {
        var charMap = new byte[26];

        int count = 1;
        foreach (char c in str) {
            if (charMap[c - 97] == 0) {
                charMap[c - 97] = 1;
            }
            else {
                count += 1;
                Array.Clear(charMap, 0, 26);
                charMap[c - 97] = 1;
            }
        }

        return count;
    }

    public int PartitionStringHashSet(string str) {
        var s = new HashSet<char>();
        int count = 1;

        foreach (char c in str) {
            if (!s.Add(c)) {
                count += 1;
                s.Clear();
                s.Add(c);
            }
        }

        return count;
    }
}