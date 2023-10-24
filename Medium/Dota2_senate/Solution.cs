namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/dota2-senate
/// </summary>
public class Solution {
	private const char Radiant = 'R';
	
	public string PredictPartyVictory(string senate) {
		int radiantSenators = 0, direSenators = 0;
		int side = 0;

		var voting = new Queue<char>(senate.Length);
		foreach (char ch in senate) {
			if (ch == Radiant) {
				radiantSenators++;
			}
			else {
				direSenators++;
			}
			voting.Enqueue(ch);
		}
		
		while (radiantSenators > 0 && direSenators > 0) {
			char vote = voting.Dequeue();
			if (vote == Radiant) {
				if (side >= 0) {
					direSenators--;
					voting.Enqueue(vote);
				}

				side++;
			}
			else {
				if (side <= 0) {
					radiantSenators--;
					voting.Enqueue(vote);
				}

				side--;
			}
		}

		return direSenators == 0 ? "Radiant" : "Dire";
	}
}