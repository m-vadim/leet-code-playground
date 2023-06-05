// https://leetcode.com/problems/climbing-stairs/
public class Solution {
    public int ClimbStairs(int stepsCount) {
        return ClimbStairsCached(stepsCount);
    }

    private static readonly Dictionary<int, int> Cache = new();

    public int ClimbStairsCached(int stepsCount) {
        if (stepsCount < 4) {
            return stepsCount;
        }

        if (Cache.ContainsKey(stepsCount)) {
            return Cache[stepsCount];
        }

        int res = ClimbStairs(stepsCount - 1) + ClimbStairs(stepsCount - 2);
        Cache.Add(stepsCount, res);
        return res;
    }


    private static readonly int[] Answers = {
        1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368,
        75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817,
        39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733, 1134903170, 1836311903
    };

    public int ClimbStairsTable(int stepsCount) {
        return Answers[stepsCount - 1];
    }

    public int ClimbStairsNaive(int stepsCount) {
        if (stepsCount < 4) {
            return stepsCount;
        }

        return ClimbStairs(stepsCount - 1) + ClimbStairs(stepsCount - 2);
    }
}