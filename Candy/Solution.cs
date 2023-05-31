namespace LeetCode;

// https://leetcode.com/problems/candy/
public class Solution {
	public int Candy(int[] seq) {
		int sum = 0;
		
		for (int i = 0; i < seq.Length; i++) {
			int countOfSmallerNumbersToTheLeft = 0;
			int countOfSmallerNumbersToTheRight = 0;
			
			int leftCursor = i - 1;
				
			while (leftCursor >= 0 && seq[leftCursor] < seq[leftCursor + 1]) {
				countOfSmallerNumbersToTheLeft++;
				leftCursor--;
			}
			
			int rightCursor = i + 1;
				
			while (rightCursor < seq.Length && seq[rightCursor] < seq[rightCursor - 1]) {
				countOfSmallerNumbersToTheRight++;
				rightCursor++;
			}

			sum += (1 + Math.Max(countOfSmallerNumbersToTheLeft, countOfSmallerNumbersToTheRight));
		}

		return sum;
	}
}