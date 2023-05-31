namespace LeetCode;

// https://leetcode.com/problems/candy/
public class Solution {
	public int Candy(int[] seq) {
		int sum = 0;
		int countOfSmallerNumbersToTheLeft = 0;
		int countOfSmallerNumbersToTheRight = 0;

		for (int i = 0; i < seq.Length; i++) {
			int leftCursor = i - 1;
			if (countOfSmallerNumbersToTheLeft == 0) {
				while (leftCursor >= 0 && seq[leftCursor] < seq[leftCursor + 1]) {
					countOfSmallerNumbersToTheLeft++;
					leftCursor--;
				}
			}
			else if (seq[leftCursor] < seq[leftCursor + 1]) {
				countOfSmallerNumbersToTheLeft++;
			}
			else {
				countOfSmallerNumbersToTheLeft = 0;
			}

			int rightCursor = i + 1;
			if (countOfSmallerNumbersToTheRight == 0) {
				while (rightCursor < seq.Length && seq[rightCursor] < seq[rightCursor - 1]) {
					countOfSmallerNumbersToTheRight++;
					rightCursor++;
				}
			}
			else if (rightCursor < seq.Length && seq[rightCursor] < seq[rightCursor - 1]) {
				countOfSmallerNumbersToTheRight--;
			}
			else {
				countOfSmallerNumbersToTheRight = 0;
			}

			sum += (1 + Math.Max(countOfSmallerNumbersToTheLeft, countOfSmallerNumbersToTheRight));
		}

		return sum;
	}
}