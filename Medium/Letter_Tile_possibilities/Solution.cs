/// <summary>
/// https://leetcode.com/problems/letter-tile-possibilities/
/// </summary>
public class Solution {
    public int NumTilePossibilities(string tiles) {
        var map = new int[26];
        
        foreach (char c in tiles) {
            map[c - 'A'] += 1;
        }

        int count = 0;
        Combs(map, ref count);
        
        return count;
    }

    private static void Combs(int[] tiles, ref int count) {
        for (var index = 0; index < tiles.Length; index++) {
            if (tiles[index] > 0) {
                tiles[index] -= 1;
                count++;
                Combs(tiles, ref count);
                tiles[index] += 1;
            }
        }
    }
}